
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2014 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Dynamic;
using Dev2.Data.Enums;
using Dev2.DataList.Contract;

// ReSharper disable once CheckNamespace
namespace Unlimited.Applications.BusinessDesignStudio.Activities.Value_Objects
{
    /// <summary>
    /// Used with the ForEach Activity
    /// </summary>
    public class ForEachBootstrapTOOld : DynamicObject
    {
        public enForEachExecutionType ExeType { get; set; }
        public int MaxExecutions { get; set; }
        public int IterationCount { get; set; }
        public IDev2DataListEvaluateIterator DataIterator { get; set; }
        public ForEachInnerActivityTO InnerActivity { get; set; }
        public enForEachType ForEachType { get; set; }




        public bool HasMoreData()
        {

            bool result = (IterationCount < MaxExecutions);

            if(ExeType == enForEachExecutionType.GhostService)
            {
                if(DataIterator != null && result)
                {
                    // check that there is still data to iterate across ;)
                    result = DataIterator.HasMoreRecords();
                }
            }

            return result;
        }
    }
}
