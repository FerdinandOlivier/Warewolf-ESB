﻿using Dev2;
using Dev2.Activities;
using Dev2.Data.Operations;
using Dev2.DataList.Contract;
using Dev2.DataList.Contract.Binary_Objects;
using Dev2.DataList.Contract.Builders;
using Dev2.DataList.Contract.Value_Objects;
using Dev2.Diagnostics;
using Dev2.Enums;
using Dev2.Interfaces;
using System;
using System.Activities;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Unlimited.Applications.BusinessDesignStudio.Activities
{
    public class DsfDataMergeActivity : DsfActivityAbstract<string>, ICollectionActivity
    {
        #region Class Members

        private string _result;

        #endregion Class Members

        #region Properties

        private IList<DataMergeDTO> _mergeCollection;
        public IList<DataMergeDTO> MergeCollection
        {
            get
            {
                return _mergeCollection;
            }
            set
            {
                _mergeCollection = value;
                OnPropertyChanged("MergeCollection");
            }
        }

        public new string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        protected override bool CanInduceIdle
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region Ctor

        public DsfDataMergeActivity()
            : base("Data Merge")
        {
            MergeCollection = new List<DataMergeDTO>();
        }

        #endregion

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
        }

        protected override void OnExecute(NativeActivityContext context)
        {

            IDSFDataObject dataObject = context.GetExtension<IDSFDataObject>();
            //IDataListCompiler compiler = context.GetExtension<IDataListCompiler>();
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();
            IDev2MergeOperations _mergeOperations = new Dev2MergeOperations();
            ErrorResultTO allErrors = new ErrorResultTO();
            ErrorResultTO errors = new ErrorResultTO();
            Guid executionId = DataListExecutionID.Get(context);

            try
            {

                CleanArguments(MergeCollection);

                if (MergeCollection.Count > 0)
                {
                    IDev2IteratorCollection iteratorCollection = Dev2ValueObjectFactory.CreateIteratorCollection();
                    IDev2DataListUpsertPayloadBuilder<string> toUpsert = Dev2DataListBuilderFactory.CreateStringDataListUpsertBuilder(true);
                    allErrors.MergeErrors(errors);
                    List<IDev2DataListEvaluateIterator> listOfIterators = new List<IDev2DataListEvaluateIterator>();

                    #region Create a iterator for each row in the data grid in the designer so that the right iteration happen on the data

                    foreach (DataMergeDTO row in MergeCollection)
                    {
                        IBinaryDataListEntry expressionsEntry = compiler.Evaluate(executionId, enActionType.User, row.InputVariable, false, out errors);
                        allErrors.MergeErrors(errors);
                        IDev2DataListEvaluateIterator itr = Dev2ValueObjectFactory.CreateEvaluateIterator(expressionsEntry);

                        iteratorCollection.AddIterator(itr);
                        listOfIterators.Add(itr);
                    }

                    #endregion

                    #region Iterate and Merge Data

                    while (iteratorCollection.HasMoreData())
                    {
                        int pos = 0;
                        foreach (IDev2DataListEvaluateIterator iterator in listOfIterators)
                        {

                            var val = iteratorCollection.FetchNextRow(iterator);

                            if(val != null)
                            {
                                string value = val.TheValue;

                                _mergeOperations.Merge(value, MergeCollection[pos].MergeType, MergeCollection[pos].At,
                                    MergeCollection[pos].Padding,
                                    MergeCollection[pos].Alignment);
                                pos++;
                            }
                        }
                    }

                    #endregion Iterate and Merge Data

                    #region Add Result to DataList

                    toUpsert.Add(Result, _mergeOperations.MergedData);
                    toUpsert.FlushIterationFrame();
                    compiler.Upsert(executionId, toUpsert, out errors);
                    allErrors.MergeErrors(errors);

                    #endregion Add Result to DataList
                }
            }
            catch (Exception e)
            {
                allErrors.AddError(e.Message);
            }
            finally
            {
                #region Handle Errors

                if (allErrors.HasErrors())
                {
                    string err = DisplayAndWriteError("DsfDataMergeActivity", allErrors);
                    compiler.UpsertSystemTag(dataObject.DataListID, enSystemTag.Error, err, out errors);
                }

                #endregion
            }
        }

        #region Private Methods

        private void CleanArguments(IList<DataMergeDTO> args)
        {
            int count = 0;
            while (count < args.Count)
            {
                if (args[count].IsEmpty())
                {
                    args.RemoveAt(count);
                }
                else
                {
                    count++;
                }
            }
        }

        private void InsertToCollection(IList<string> listToAdd, ModelItem modelItem)
        {
            ModelItemCollection mic = modelItem.Properties["MergeCollection"].Collection;

            if (mic != null)
            {
                List<DataMergeDTO> listOfValidRows = MergeCollection.Where(c => !c.CanRemove()).ToList();
                if (listOfValidRows.Count > 0)
                {
                    int startIndex = MergeCollection.Last(c => !c.CanRemove()).IndexNumber;
                    foreach (string s in listToAdd)
                    {
                        mic.Insert(startIndex, new DataMergeDTO(s, MergeCollection[startIndex - 1].MergeType, MergeCollection[startIndex - 1].At, startIndex + 1, MergeCollection[startIndex - 1].Padding, MergeCollection[startIndex - 1].Alignment));
                        startIndex++;
                    }
                    CleanUpCollection(mic, modelItem, startIndex);
                }
                else
                {
                    AddToCollection(listToAdd, modelItem);
                }
            }
        }

        private void AddToCollection(IList<string> listToAdd, ModelItem modelItem)
        {
            ModelItemCollection mic = modelItem.Properties["MergeCollection"].Collection;

            if (mic != null)
            {
                int startIndex = 0;
                string firstRowMergeType = MergeCollection[0].MergeType;
                string firstRowPadding = MergeCollection[0].Padding;
                string firstRowAlignment = MergeCollection[0].Alignment;
                mic.Clear();
                foreach (string s in listToAdd)
                {
                    mic.Add(new DataMergeDTO(s, firstRowMergeType, string.Empty, startIndex + 1, firstRowPadding, firstRowAlignment));
                    startIndex++;
                }
                CleanUpCollection(mic, modelItem, startIndex);
            }
        }

        private void CleanUpCollection(ModelItemCollection mic, ModelItem modelItem, int startIndex)
        {
            if (startIndex < mic.Count)
            {
                mic.RemoveAt(startIndex);
            }
            mic.Add(new DataMergeDTO(string.Empty, "None", string.Empty, startIndex + 1, " ", "Left To Right"));
            modelItem.Properties["DisplayName"].SetValue(CreateDisplayName(modelItem, startIndex + 1));
        }

        private string CreateDisplayName(ModelItem modelItem, int count)
        {
            string currentName = modelItem.Properties["DisplayName"].ComputedValue as string;
            if (currentName.Contains("(") && currentName.Contains(")"))
            {
                if (currentName.Contains(" ("))
                {
                    currentName = currentName.Remove(currentName.IndexOf(" ("));
                }
                else
                {
                    currentName = currentName.Remove(currentName.IndexOf("("));
                }
            }
            currentName = currentName + " (" + (count - 1) + ")";
            return currentName;
        }

        #endregion Private Methods

        #region Overridden ActivityAbstact Methods

        public override IBinaryDataList GetWizardData()
        {
            string error;
            IBinaryDataList result = Dev2BinaryDataListFactory.CreateDataList();
            string recordsetName = "MergeCollection";
            result.TryCreateScalarValue(Result, "Result", out error);
            result.TryCreateRecordsetTemplate(recordsetName, string.Empty, new List<Dev2Column> { DataListFactory.CreateDev2Column("MergeType", string.Empty), DataListFactory.CreateDev2Column("At", string.Empty), DataListFactory.CreateDev2Column("Result", string.Empty) }, true, out error);
            foreach (DataMergeDTO item in MergeCollection)
            {
                result.TryCreateRecordsetValue(item.MergeType, "MergeType", recordsetName, item.IndexNumber, out error);
                result.TryCreateRecordsetValue(item.At, "At", recordsetName, item.IndexNumber, out error);
            }
            return result;
        }

        #endregion Overridden ActivityAbstact Methods

        #region Get Debug Inputs/Outputs

        public override IList<IDebugItem> GetDebugInputs(IBinaryDataList dataList)
        {
            IList<IDebugItem> results = new List<IDebugItem>();
            int indexToShow = 1;
            foreach (DataMergeDTO dataMergeDto in MergeCollection)
            {
                if (dataMergeDto.MergeType == "None" && dataMergeDto.IndexNumber == MergeCollection.Count &&
                    dataMergeDto.InputVariable == string.Empty)
                {
                    continue;
                }

                DebugItem itemToAdd = new DebugItem();
                itemToAdd.Add(new DebugItemResult { Type = DebugItemResultType.Label, Value = indexToShow.ToString(CultureInfo.InvariantCulture) });
                itemToAdd.Add(new DebugItemResult { Type = DebugItemResultType.Label, Value = "Merge" });
                foreach (IDebugItemResult debugItemResult in CreateDebugItems(dataMergeDto.InputVariable, dataList))
                {
                    itemToAdd.Add(debugItemResult);
                }
                itemToAdd.Add(new DebugItemResult { Type = DebugItemResultType.Label, Value = "With" });
                itemToAdd.Add(new DebugItemResult { Type = DebugItemResultType.Value, Value = dataMergeDto.MergeType });
                if (!string.IsNullOrEmpty(dataMergeDto.At))
                {
                    foreach (IDebugItemResult debugItemResult in CreateDebugItems(dataMergeDto.At, dataList))
                    {
                        itemToAdd.Add(debugItemResult);
                    }
                }
                results.Add(itemToAdd);
                indexToShow++;
            }
            return results;
        }

        public override IList<IDebugItem> GetDebugOutputs(IBinaryDataList dataList)
        {
            IList<IDebugItem> results = new List<IDebugItem>();
            DebugItem itemToAdd = new DebugItem();
            foreach (IDebugItemResult debugItemResult in CreateDebugItems(Result, dataList))
            {
                itemToAdd.Add(debugItemResult);
            }
            results.Add(itemToAdd);
            return results;
        }


        #endregion

        #region Get ForEach Inputs/Outputs

        public override void UpdateForEachInputs(IList<Tuple<string, string>> updates, NativeActivityContext context)
        {
            foreach (Tuple<string, string> t in updates)
            {
                // locate all updates for this tuple
                var items = MergeCollection.Where(c => !string.IsNullOrEmpty(c.InputVariable) && c.InputVariable.Equals(t.Item1));

                // issues updates
                foreach (var a in items)
                {
                    a.InputVariable = t.Item2;
                }
            }
        }

        public override void UpdateForEachOutputs(IList<Tuple<string, string>> updates, NativeActivityContext context)
        {
            if (updates.Count == 1)
            {
                Result = updates[0].Item2;
            }
        }

        #endregion

        #region GetForEachInputs/Outputs

        public override IList<DsfForEachItem> GetForEachInputs(NativeActivityContext context)
        {
            var items = (MergeCollection.Where(c => !string.IsNullOrEmpty(c.InputVariable)).Select(c => c.InputVariable).Union(MergeCollection.Where(c => !string.IsNullOrEmpty(c.At)).Select(c => c.At))).ToArray();
            return GetForEachItems(context, StateType.Before, items);
        }

        public override IList<DsfForEachItem> GetForEachOutputs(NativeActivityContext context)
        {
            var items = new string[1];
            if (!string.IsNullOrEmpty(Result))
            {
                items[0] = Result;
            }
            return GetForEachItems(context, StateType.After, items);
        }

        #endregion

        #region Implementation of ICollectionActivity

        public int GetCollectionCount()
        {
            return MergeCollection.Count(caseConvertTO => !caseConvertTO.CanRemove());
        }

        public void AddListToCollection(IList<string> listToAdd, bool overwrite, ModelItem modelItem)
        {
            if (!overwrite)
            {
                InsertToCollection(listToAdd, modelItem);
            }
            else
            {
                AddToCollection(listToAdd, modelItem);
            }
        }

        #endregion
    }
}
