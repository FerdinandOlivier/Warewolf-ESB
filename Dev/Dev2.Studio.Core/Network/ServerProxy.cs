
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
using System.Net;
using System.Network;
using System.Security.Principal;
using System.Text;
using Dev2.Common.Interfaces.Explorer;
using Dev2.Common.Interfaces.Infrastructure.Events;
using Dev2.Data.ServiceModel.Messages;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Services.Security;
using Dev2.SignalR.Wrappers;
using Dev2.Studio.Core.Interfaces;
using Dev2.Threading;


namespace Dev2.Network
{
    public class ServerProxy :  IEnvironmentConnection
    {
        IEnvironmentConnection _wrappedConnection;
        IEnvironmentConnection _fallbackConnection;


        
        public ServerProxy(Uri serverUri)

        {
           _wrappedConnection = new ServerProxyWithoutChunking(serverUri);
           _wrappedConnection.PermissionsChanged += (sender, args) => RaisePermissionsChanged();
           _wrappedConnection.PermissionsModified += (sender, list) => RaisePermissionsModified(list);
           _wrappedConnection.NetworkStateChanged += (sender, args) => OnNetworkStateChanged(args);  
            _fallbackConnection = new ServerProxyWithChunking(serverUri);
            _fallbackConnection.PermissionsChanged += (sender, args) => RaisePermissionsChanged();
            _fallbackConnection.PermissionsModified += (sender, list) => RaisePermissionsModified(list);
            _fallbackConnection.NetworkStateChanged += (sender, args) => OnNetworkStateChanged(args);  
        }



        public ServerProxy(string serverUri, ICredentials credentials, IAsyncWorker worker)
        {

            _wrappedConnection = new ServerProxyWithoutChunking(serverUri,credentials,worker);
            _wrappedConnection.PermissionsChanged += (sender, args) => RaisePermissionsChanged();
            _wrappedConnection.PermissionsModified += (sender, list) => RaisePermissionsModified(list);
            _wrappedConnection.NetworkStateChanged += (sender, args) => OnNetworkStateChanged(args);
            _fallbackConnection = new ServerProxyWithChunking(serverUri, credentials, worker);
            _fallbackConnection.PermissionsChanged += (sender, args) => RaisePermissionsChanged();
            _fallbackConnection.PermissionsModified += (sender, list) => RaisePermissionsModified(list);
            _fallbackConnection.NetworkStateChanged += (sender, args) => OnNetworkStateChanged(args);  

        }





        public ServerProxy(string webAddress, string userName, string password)
            : this(webAddress, new NetworkCredential(userName, password), new AsyncWorker())
        {

        }



        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _wrappedConnection.Dispose();
            _fallbackConnection.Dispose();
        }

        #endregion

        #region Implementation of IEnvironmentConnection

        public IEventPublisher ServerEvents
        {
            get
            {
                return _wrappedConnection.ServerEvents;
            }
        }
        public Guid ServerID
        {
            get
            {
                return _wrappedConnection.ServerID;
            }
            set
            {
                _wrappedConnection.ServerID = value;
            }
        }
        public Guid WorkspaceID
        {
            get
            {
                return _wrappedConnection.WorkspaceID; 
            }
        }
        public Uri AppServerUri
        {
            get
            {
                return _wrappedConnection.AppServerUri ;
            }
        }
        public Uri WebServerUri
        {
            get
            {
                return _wrappedConnection.WebServerUri;
            }
        }
        public AuthenticationType AuthenticationType
        {
            get
            {
                return _wrappedConnection.AuthenticationType;
            }
        }
        public string UserName
        {
            get
            {
                return _wrappedConnection.UserName;
            }
        }
        public string Password
        {
            get
            {
                return _wrappedConnection.Password;
            }
        }


        public bool IsAuthorized
        {
            get
            {
                return _wrappedConnection.IsAuthorized;
            }

            set
            {
                _wrappedConnection.IsAuthorized = value;
            }
        }

        public StringBuilder ExecuteCommand(StringBuilder xmlRequest, Guid workspaceId, Guid dataListId)
        {
            return _wrappedConnection.ExecuteCommand(xmlRequest,workspaceId,dataListId);
        }

        public IHubProxyWrapper EsbProxy
        {
            get
            {
                return _wrappedConnection.EsbProxy;
            }
        }
        public bool IsConnected
        {
            get
            {
                return _wrappedConnection.IsConnected;
            }
        }
        public string Alias
        {
            get
            {
                return _wrappedConnection.Alias;
            }
            set
            {
                _wrappedConnection.Alias = value;
            }
        }
        public string DisplayName
        {
            get
            {
                return _wrappedConnection.DisplayName;
            }
            set
            {
                _wrappedConnection.DisplayName = value;
            }
        }

        public void Connect(Guid id)
        {
            try
            {
                _wrappedConnection.Connect(_wrappedConnection.ID);
            }
             catch( FallbackException)
            {
                _wrappedConnection = _fallbackConnection;
                _wrappedConnection.Connect(_wrappedConnection.ID);
            }
            catch (Exception err)
            {
                string s = err.Message;
                throw;
            }
        }
        public Guid ID { get { return _wrappedConnection.ID; } }
        public void Disconnect()
        {
            _wrappedConnection.Disconnect();
        }

        public void Verify(Action<ConnectResult> callback, bool wait = true)
        {
            _wrappedConnection.Verify(callback,wait);
        }

        public void StartAutoConnect()
        {
            _wrappedConnection.StartAutoConnect();
        }

        public bool IsLocalHost
        {
            get
            {
                return _wrappedConnection.IsLocalHost;
            }
        }
        public Action<IExplorerItem> ItemAddedMessageAction
        {
            get
            {
                return _wrappedConnection.ItemAddedMessageAction;
            }
            set
            {
                _wrappedConnection.ItemAddedMessageAction = value;
            }
        }
        public IAsyncWorker AsyncWorker
        {
            get
            {
                return _wrappedConnection.AsyncWorker;
            }
        }
        public IPrincipal Principal
        {
            get
            {
                return _wrappedConnection.Principal;
            }
        }

        public Action<Guid, CompileMessageList> ReceivedResourceAffectedMessage
        {
            get
            {
                return _wrappedConnection.ReceivedResourceAffectedMessage;
            }
            set
            {
                _wrappedConnection.ReceivedResourceAffectedMessage = value;
            }
        }
        public IHubConnectionWrapper HubConnection
        {
            get
            {
                return _wrappedConnection.HubConnection;
            }
        }



        public event EventHandler<NetworkStateEventArgs> NetworkStateChanged;
        public event EventHandler PermissionsChanged;

        void RaisePermissionsChanged()
        {
            if (PermissionsChanged != null)
            {
                PermissionsChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler<List<WindowsGroupPermission>> PermissionsModified;

        void RaisePermissionsModified(List<WindowsGroupPermission> args)
        {
            if (PermissionsModified != null)
            {
                PermissionsModified(this, args);
            }
        }

        void UpdateIsAuthorized(bool isAuthorized)
        {
            if (IsAuthorized != isAuthorized)
            {
                _wrappedConnection.IsAuthorized = isAuthorized;
                RaisePermissionsChanged();
            }
        }

        protected virtual void OnNetworkStateChanged(NetworkStateEventArgs e)
        {
            var handler = NetworkStateChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
    }
}
