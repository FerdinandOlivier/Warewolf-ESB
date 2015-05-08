
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
using Dev2.Common;
using Dev2.DataList.Contract.Binary_Objects;

namespace Dev2.DataList.Contract
{
    /// <summary>
    /// Interface for all the recordset search operation
    /// </summary>
    public interface IFindRecsetOptions
    {
        Func<IList<string>> BuildSearchExpression(IList<RecordSetSearchPayload> operationRange, IRecsetSearch to);

        string HandlesType();
        Func<DataASTMutable.WarewolfAtom, bool> GenerateFunc(IEnumerable<DataASTMutable.WarewolfAtom> values, IEnumerable<DataASTMutable.WarewolfAtom> from, IEnumerable<DataASTMutable.WarewolfAtom> to, bool all);

        Func<IList<RecordSetSearchPayload>> GenerateInputRange(IRecsetSearch to, IBinaryDataList bdl, out ErrorResultTO errors);
    }
}
