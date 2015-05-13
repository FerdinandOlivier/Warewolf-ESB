﻿
 /*
*  Warewolf - The Easy Service Bus
*  Copyright 2014 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Warewolf.Storage;
using WarewolfParserInterop;

namespace Dev2.TO
{
    public class JsonMappingEvaluated
    {
        readonly IExecutionEnvironment _env;
        // ReSharper disable MemberCanBePrivate.Global
        public JsonMappingTo Simple { get; set; }
        // ReSharper restore MemberCanBePrivate.Global
        object _evalResultAsObject;
        WarewolfDataEvaluationCommon.WarewolfEvalResult _evalResult;

        public JsonMappingEvaluated(
            IExecutionEnvironment env,
            string sourceName)
        {
            _env = env;
            Simple = new JsonMappingTo
            {
                SourceName = sourceName,
                DestinationName = CalculateDestinationNameFromSourceName(sourceName)
            };
        }

        string CalculateDestinationNameFromSourceName(string sourceName)
        {
            LanguageAST.LanguageExpression parsed = WarewolfDataEvaluationCommon.ParseLanguageExpression(sourceName);
            if (parsed.IsScalarExpression)
            {
                return ((LanguageAST.LanguageExpression.ScalarExpression)parsed).Item;
            }
            if (parsed.IsRecordSetExpression)
            {
                return ((LanguageAST.LanguageExpression.RecordSetExpression)parsed).Item.Column;
            }
            if (parsed.IsRecordSetNameExpression)
            {
                return ((LanguageAST.LanguageExpression.RecordSetNameExpression)parsed).Item.Name;
            }
            return string.Empty;
        }

        public WarewolfDataEvaluationCommon.WarewolfEvalResult EvalResult
        {
            get
            {
                return _evalResult ?? (_evalResult = _env.EvalForJson(
                    Simple.SourceName));
            }
        }

        public object EvalResultAsObject
        {
            get
            {
                if (_evalResultAsObject == null)
                {
                    WarewolfDataEvaluationCommon.WarewolfEvalResult e = EvalResult;
                    _evalResultAsObject = WarewolfDataEvaluationCommon.EvalResultToJsonCompatibleObject(e);
                    if (EvalResult.IsWarewolfAtomListresult && _evalResultAsObject == null)
                    {
                        _evalResultAsObject = new object[] { null };
                    }
                    if (e.IsWarewolfAtomResult)
                    {
                        var x = e as WarewolfDataEvaluationCommon.WarewolfEvalResult.WarewolfAtomResult;
                        if (x != null && x.Item.IsDataString)
                        {
                            if (((DataASTMutable.WarewolfAtom.DataString)x.Item).Item == "true")
                            {
                                _evalResultAsObject = true;
                            }
                            else if ((x.Item as DataASTMutable.WarewolfAtom.DataString).Item == "false")
                            {
                                _evalResultAsObject = false;
                            }
                        }
                    }
                }
                return _evalResultAsObject;
            }
        }

        public int Count
        {
            get
            {
                if (EvalResult.IsWarewolfAtomResult)
                {
                    return 1;
                }
                if (EvalResult.IsWarewolfAtomListresult)
                {
                    return ((WarewolfDataEvaluationCommon.WarewolfEvalResult.WarewolfAtomListresult)EvalResult).Item.Count;
                }
                if (EvalResult.IsWarewolfRecordSetResult)
                {
                    return 1;
                }
                return 0;
            }
        }
    }

    public class JsonMappingCompoundTo
    {
        readonly IExecutionEnvironment _env;
        JsonMappingTo Compound { get; set; }
        List<JsonMappingEvaluated> Evaluations { get; set; }

        public JsonMappingCompoundTo(
            IExecutionEnvironment env,
            JsonMappingTo compound)
        {
            _env = env;

            Compound = compound;
            Evaluations = new List<JsonMappingEvaluated>();

            if (!IsCompound)
            {
                Evaluations.Add(new JsonMappingEvaluated(_env, compound.SourceName));
            }
            else
            {
                if (WarewolfDataEvaluationCommon.ParseLanguageExpression(Compound.SourceName).IsRecordSetNameExpression)
                {
                    Evaluations = new List<JsonMappingEvaluated> { new JsonMappingEvaluated(_env, Compound.SourceName) };
                }
                else
                {
                    // we know this is a comma seperated list of expressions
                    Evaluations =
                        ((LanguageAST.LanguageExpression.ComplexExpression)WarewolfDataEvaluationCommon.ParseLanguageExpression(Compound.SourceName))
                            .Item
                            .Where(x => !x.IsWarewolfAtomAtomExpression)
                            .Select(x =>
                                WarewolfDataEvaluationCommon.LanguageExpressionToString(x))
                            .Select(x =>
                                new JsonMappingEvaluated(_env, x))
                            .ToList();
                }
            }
        }

        public WarewolfDataEvaluationCommon.WarewolfEvalResult EvalResult
        {
            get
            {
                return Evaluations.First().EvalResult;
            }
        }

        bool? _isCompound;
        public bool IsCompound
        {
            get
            {
                if (_isCompound == null)
                {
                    _isCompound = WarewolfDataEvaluationCommon.ParseLanguageExpression(
                        Compound.SourceName)
                        .IsComplexExpression || WarewolfDataEvaluationCommon.ParseLanguageExpression(
                            Compound.SourceName)
                            .IsRecordSetNameExpression;
                    
                }
                return (bool)_isCompound;
            }
        }

        public int MaxCount
        {
            get
            {
                return Evaluations.Select(x => x.Count).Max();
            }
        }

        public string DestinationName
        {
            get
            {
                return Compound.DestinationName;
            }
        }

        public object EvaluatedResultIndexed(int i)
        {
            return i < MaxCount ?
                Evaluations.First().EvalResultAsObject :
                Evaluations.First().EvalResult.IsWarewolfAtomListresult ? new object[] { null } : null;
        }

        public object ComplexEvaluatedResultIndexed(int i)
        {
            var a = new JObject();
            if (Evaluations.Any(x => x.EvalResult.IsWarewolfAtomListresult))
            {
                return CreateArrayOfResults(i);
            }
            if (Evaluations.Any(x => x.EvalResult.IsWarewolfRecordSetResult))
            {
                return CreateArrayOfObjectsFromRecordSet(i);
            }

            CreateScalarObject(a);
            return a;
        }

        void CreateScalarObject(JObject a)
        {
            foreach (JsonMappingEvaluated jsonMappingEvaluated in Evaluations)
            {
                a.Add(new JProperty(
                    jsonMappingEvaluated.Simple.DestinationName,
                    WarewolfDataEvaluationCommon.EvalResultToJsonCompatibleObject(jsonMappingEvaluated.EvalResult))
                    );
            }
        }

        object CreateArrayOfObjectsFromRecordSet(int i)
        {
            JsonMappingEvaluated jsonMappingEvaluated = Evaluations.First();
            return new JProperty(
                        jsonMappingEvaluated.Simple.DestinationName,
                GetEvalResult(jsonMappingEvaluated.EvalResult, i));
        }

        object CreateArrayOfResults(int i)
        {
            var objects = new List<JObject>(MaxCount);
            for (int j = 0; j < MaxCount; j++)
            {
                var obj = new JObject();
                foreach (JsonMappingEvaluated jsonMappingEvaluated in Evaluations)
                {
                    obj.Add(new JProperty(
                        jsonMappingEvaluated.Simple.DestinationName,
                        GetEvalResult(jsonMappingEvaluated.EvalResult, i))
                        );
                }
                objects.Add(obj);
            }
            return objects.ToArray();
        }

        object GetEvalResult(WarewolfDataEvaluationCommon.WarewolfEvalResult evalResult, int i)
        {
            if (EvalResult.IsWarewolfAtomListresult)
            {
                WarewolfAtomList<DataASTMutable.WarewolfAtom> lst = ((WarewolfDataEvaluationCommon.WarewolfEvalResult.WarewolfAtomListresult)evalResult).Item;
                if (i > lst.Count)
                {
                    return null;
                }
                return WarewolfDataEvaluationCommon.AtomToJsonCompatibleObject(lst[i]);
            }
            if (EvalResult.IsWarewolfAtomResult)
            {
                if (i == 0)
                {
                    return WarewolfDataEvaluationCommon.EvalResultToJsonCompatibleObject(evalResult);
                }
                return null;
            }
            if (EvalResult.IsWarewolfRecordSetResult)
            {
                DataASTMutable.WarewolfRecordset recset = ((WarewolfDataEvaluationCommon.WarewolfEvalResult.WarewolfRecordSetResult)EvalResult).Item;
                KeyValuePair<string, WarewolfAtomList<DataASTMutable.WarewolfAtom>>[] data = recset.Data.ToArray();
                var jObjects = new List<JObject>();
                for (int j = 0; j < recset.Count; j++)
                {
                    var a = new JObject();
                    foreach(KeyValuePair<string, WarewolfAtomList<DataASTMutable.WarewolfAtom>> pair in data)
                    {
                        if (pair.Key != WarewolfDataEvaluationCommon.PositionColumn)
                        {
                            try
                            {
                                a.Add(new JProperty(pair.Key, WarewolfDataEvaluationCommon.AtomToJsonCompatibleObject(pair.Value[j])));
                            }
                            catch (Exception)
                            {
                                a.Add(new JProperty(pair.Key, null));
                            }
                        }
                    }
                    jObjects.Add(a);
                }
                return jObjects;
            }
            throw new Exception("Invalid result type was encountered from warewolfstorage");
        }


        public bool HasMoreThanOneRecordSet
        {
            get
            {
                return Evaluations.Count(x => x.EvalResult.IsWarewolfRecordSetResult) > 1;
            }
        }
    }
    }