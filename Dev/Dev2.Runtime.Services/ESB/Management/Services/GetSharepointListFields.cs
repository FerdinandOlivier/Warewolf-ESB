using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Dev2.Common;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.Common.Interfaces.Infrastructure.SharedModels;
using Dev2.Communication;
using Dev2.Data.ServiceModel;
using Dev2.DynamicServices;
using Dev2.DynamicServices.Objects;
using Dev2.Runtime.Hosting;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Workspaces;

namespace Dev2.Runtime.ESB.Management.Services
{
    public class GetSharepointListFields : IEsbManagementEndpoint
    {
        #region Implementation of ISpookyLoadable<string>

        public string HandlesType()
        {
            return "GetSharepointListFields";
        }

        #endregion

        #region Implementation of IEsbManagementEndpoint

        /// <summary>
        /// Executes the service
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="theWorkspace">The workspace.</param>
        /// <returns></returns>
        public StringBuilder Execute(Dictionary<string, StringBuilder> values, IWorkspace theWorkspace)
        {
            if(values == null)
            {
                throw new InvalidDataContractException("No parameter values provided.");
            }
            string serializedSource = null;
            string listName = null;
            StringBuilder tmp;
            values.TryGetValue("SharepointServer", out tmp);
            if(tmp != null)
            {
                serializedSource = tmp.ToString();
            }
            values.TryGetValue("ListName", out tmp);
            if(tmp != null)
            {
                listName = tmp.ToString();
            }

           
            Dev2JsonSerializer serializer = new Dev2JsonSerializer();

            if(string.IsNullOrEmpty(serializedSource))
            {
                var res = new ExecuteMessage();
                res.HasError = true;
                res.SetMessage("No sharepoint server set");
                Dev2Logger.Log.Debug("No sharepoint server set.");
                return serializer.SerializeToBuilder(res);
            }
            if(string.IsNullOrEmpty(listName))
            {
                var res = new ExecuteMessage();
                res.HasError = true;
                res.SetMessage("No sharepoint list name set");
                Dev2Logger.Log.Debug("No sharepoint list name set.");
                return serializer.SerializeToBuilder(res);
            }
            try
            {
                var sharepointSource = serializer.Deserialize<SharepointSource>(serializedSource);
                var source = ResourceCatalog.Instance.GetResource<SharepointSource>(theWorkspace.ID, sharepointSource.ResourceID);
                List<ISharepointFieldTo> fields = source.LoadFieldsForList(listName);
                return serializer.SerializeToBuilder(fields);
            }
            catch(Exception ex)
            {
                Dev2Logger.Log.Error(ex);
                var res = new DbColumnList(ex);
                return serializer.SerializeToBuilder(res);
            }
        }

        /// <summary>
        /// Creates the service entry.
        /// </summary>
        /// <returns></returns>
        public DynamicService CreateServiceEntry()
        {
            var ds = new DynamicService
            {
                Name = HandlesType(),
                DataListSpecification = new StringBuilder("<DataList><Database ColumnIODirection=\"Input\"/><TableName ColumnIODirection=\"Input\"/><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>")
            };

            var sa = new ServiceAction
            {
                Name = HandlesType(),
                ActionType = enActionType.InvokeManagementDynamicService,
                SourceMethod = HandlesType()
            };

            ds.Actions.Add(sa);

            return ds;
        }

        #endregion
    }
}