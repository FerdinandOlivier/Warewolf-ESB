
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
using Dev2.Common;
using Dev2.DataList.Contract;
using Dev2.DataList.Contract.Binary_Objects;

namespace Dev2.DataList
{
    /// <summary>
    /// Class for the "greater than symbol" recordset search option 
    /// </summary>
    public class RsOpGreaterThan : AbstractRecsetSearchValidation
    {

        // Bug 8725 - Fixed to be double rather than int
        public override Func<IList<string>> BuildSearchExpression(IList<RecordSetSearchPayload> operationRange, IRecsetSearch to)
        {
            Func<IList<string>> result = () =>
                {
               
                     
                    IList<string> fnResult = new List<string>();
                    double search;

                    if(double.TryParse(to.SearchCriteria, out search))
                    {
                        foreach(RecordSetSearchPayload p in operationRange)
                        {
                            double tmp;

                            if(double.TryParse(p.Payload, out tmp) && tmp > search)
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
                    }
                    return fnResult.Distinct().ToList();
                };

            return result;
        }

        public override Func<DataASTMutable.WarewolfAtom, bool> CreateFunc(IEnumerable<DataASTMutable.WarewolfAtom> values, IEnumerable<DataASTMutable.WarewolfAtom> warewolfAtoms, IEnumerable<DataASTMutable.WarewolfAtom> to, bool all)
        {
            if (all)
                return (a) => values.All(x => DataASTMutable.CompareAtoms(a, x) > 0);
            return (a) => values.Any(x => DataASTMutable.CompareAtoms(a, x) > 0);
        }
        public override string HandlesType()
        {
            return ">";
        }
    }
}
