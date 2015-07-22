
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2015 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Collections.ObjectModel;
using Dev2.ConnectionHelpers;
using Dev2.Studio.Core.Interfaces;

namespace Dev2.CustomControls.Connections
{
    public interface IConnectControlViewModel
    {
        void SetTargetEnvironment();
        void UpdateActiveEnvironment(IEnvironmentModel environmentModel, bool isSetFromConnectControl);

        ObservableCollection<IConnectControlEnvironment> Servers { get; }
    }
}
