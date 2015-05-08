
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
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Dev2.Common;
using Dev2.Common.ExtMethods;
using Dev2.DataList.Contract;
using Dev2.DataList.Contract.Binary_Objects;

namespace Dev2.DataList
{
    /// <summary>
    /// Class for the "regex" recordset search option 
    /// </summary>
    public class RsOpNotRegex : AbstractRecsetSearchValidation
    {

        public override Func<IList<string>> BuildSearchExpression(IList<RecordSetSearchPayload> operationRange, IRecsetSearch to)
        {
            // Default to a null function result

            Func<IList<string>> result = () =>
                {
           
                     
                    IList<string> fnResult = new List<string>();

                    foreach(RecordSetSearchPayload p in operationRange)
                    {
                        Regex exp = new Regex(to.SearchCriteria);
                        if(!exp.IsMatch(p.Payload) && !string.IsNullOrEmpty(p.Payload))
                        {
                            fnResult.Add(p.Index.ToString(CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            if(to.RequireAllFieldsToMatch)
                            {
                                return new List<string>();
                            }
                        }
                    }

                    return fnResult.Distinct().ToList();
                };

            return result;
        }
        public override Func<DataASTMutable.WarewolfAtom, bool> CreateFunc(IEnumerable<DataASTMutable.WarewolfAtom> values, IEnumerable<DataASTMutable.WarewolfAtom> warewolfAtoms, IEnumerable<DataASTMutable.WarewolfAtom> to, bool all)
        {


            if (all)
                return (a) => !values.All(x =>
                {
                    Regex exp = new Regex(x.ToString());
                    return exp.IsMatch(a.ToString());

                });
            return (a) => !values.Any(x =>
            {
                Regex exp = new Regex(x.ToString());
                return exp.IsMatch(a.ToString());

            });

        }
        public override string HandlesType()
        {
            return "Not Regex";
        }
    }
}
