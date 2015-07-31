﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Dev2;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Core;
using Dev2.Common.Interfaces.Data;
using Dev2.Common.Interfaces.SaveDialog;
using Dev2.Runtime.ServiceModel.Data;
using Microsoft.Practices.Prism.Commands;
using Warewolf.Core;

namespace Warewolf.Studio.ViewModels
{
    public sealed class ManageNewServerViewModel : SourceBaseImpl<IServerSource>, IManageNewServerViewModel
    {
        string _userName;
        string _password;
        string _testMessage;
        string _address;
        bool _testPassed;
        AuthenticationType _authenticationType;

        #region Implementation of IInnerDialogueTemplate

        readonly IStudioUpdateManager _updateManager;
        readonly IRequestServiceNameViewModel _requestServiceNameViewModel;
        readonly string _connectedServer;

        string _headerText;
        IServerSource _serverSource;
        string _protocol;
        string _selectedPort;
        // ReSharper disable TooManyDependencies
        public ManageNewServerViewModel(IServerSource newServerSource,
            IStudioUpdateManager updateManager, IRequestServiceNameViewModel requestServiceNameViewModel,
            string connectedServer, Guid originationSource):base(ResourceType.Server)
        // ReSharper restore TooManyDependencies
        {
            //VerifyArgument.AreNotNull(new Dictionary<string, object> { { "newServerSource", newServerSource }, { "updateManager", updateManager }, { "requestServiceNameViewModel", requestServiceNameViewModel } ,{"connectedServer",connectedServer}});
            Protocols = new[] { "http", "https" };
            Protocol = Protocols[0];
         
            Ports = new ObservableCollection<string> { "3142", "3143" };
            SelectedPort = Ports[0];
            _updateManager = updateManager;
            _requestServiceNameViewModel = requestServiceNameViewModel;
            _connectedServer = connectedServer;
            OriginationSource = originationSource;

            ServerSource = newServerSource;
            Header = String.IsNullOrEmpty(newServerSource.Name) ? "New Server Source" : SetToEdit(newServerSource);

            IsValid = false;
            Address = newServerSource.Address;
            AuthenticationType = newServerSource.AuthenticationType;
            UserName = newServerSource.UserName;
            Password = newServerSource.Password;
            TestPassed = false;


            TestCommand = new DelegateCommand(Test);
            OkCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(() => CloseAction.Invoke());
        }

        public override bool CanSave()
        {
            return TestPassed;
        }

        void Save()
        {
            var res = MessageBoxResult.OK;
            if (String.IsNullOrEmpty(ServerSource.Name))
                res = RequestServiceNameViewModel.ShowSaveDialog();
            if (res == MessageBoxResult.OK)
            {
                try
                {
                    var source = ToModel();

                    ServerSource = source;
                    _updateManager.Save(source);
                    HeaderText = SetToEdit(source);
                    if (CloseAction != null)
                        CloseAction.Invoke();
                }
                catch (Exception err)
                {

                    TestMessage = err.Message;
                }
            }

        }

        public override IServerSource ToModel()
        {
            return new ServerSource
            {
                Address = Protocol+"://"+Address+":"+SelectedPort,
                AuthenticationType = AuthenticationType,
                ID = ServerSource.ID == Guid.Empty ? Guid.NewGuid() : ServerSource.ID,
                Name = String.IsNullOrEmpty(ServerSource.Name) ? RequestServiceNameViewModel.ResourceName.Name : ServerSource.Name,
                Password = Password,
                ResourcePath = RequestServiceNameViewModel.ResourceName.Path
            };
        }

        string SetToEdit(IServerSource source)
        {
            return "Edit " + _connectedServer.Trim() + "/" + source.ResourcePath + source.Name;
        }

        public Action CloseAction { get; set; }
        void Test()
        {
            TestFailed = false;
            TestPassed = false;
            Testing = true;
            TestMessage = _updateManager.TestConnection(new ServerSource
            {
                Address = Protocol +"://" + Address + ":" + SelectedPort,
                AuthenticationType = AuthenticationType,
                ID = ServerSource.ID == Guid.Empty ? Guid.NewGuid() : ServerSource.ID,
                Name = String.IsNullOrEmpty(ServerSource.Name) ? "" : ServerSource.Name,
                Password = Password,
                ResourcePath = "" //todo: needs to come from explorer
            });
            Testrun = true;
            Testing = false;
            if (TestMessage == "")
            {
                TestPassed = true;
                TestFailed = false;
            }
            else
            {
                TestPassed = false;
                TestFailed = true;
            }

            OnPropertyChanged(() => Validate);
            OnPropertyChanged(() => CanClickOk);

        }

        /// <summary>
        /// called by outer when validating
        /// </summary>
        /// <returns></returns>
        public string Validate
        {

            get
            {
                IsValid = false;



                if (!Testrun)
                {
                    return Resources.Languages.Core.ServerSourceDialogNoTestMessage;
                }

                if (TestFailed)
                {
                    return Resources.Languages.Core.TestConnectionLabel; 
                }

                IsValid = true;
                return String.Empty;
            }



        }
        public bool Testrun { get; set; }




        /// <summary>
        /// Is valid 
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// Command for save/ok
        /// </summary>
        public ICommand OkCommand { get; set; }
        /// <summary>
        /// Command for cancel
        /// </summary>
        public ICommand CancelCommand { get; set; }
        public bool CanClickOk
        {
            get
            {
                return Validate == "";
            }
        }

        public string HeaderText
        {
            get
            {
                return _headerText;
            }
            set
            {
                _headerText = value;
                OnPropertyChanged(() => HeaderText);
                OnPropertyChanged(() => Header);
            }
        }
        public Guid OriginationSource { get; private set; }

        #endregion

        #region Implementation of INewServerDialogue

        /// <summary>
        /// The server address that we are trying to connect to
        /// </summary>
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                
                _address = value;

                OnPropertyChanged(() => Address);
                OnPropertyChanged(() => Validate);
                OnPropertyChanged(() => CanClickOk);
            }

        }
        /// <summary>
        ///  Windows or user or publlic
        /// </summary>
        public AuthenticationType AuthenticationType
        {
            get
            {
                return _authenticationType;
            }
            set
            {
                if (value != _authenticationType)
                {
                    _authenticationType = value;
                    OnPropertyChanged(() => AuthenticationType);
                    OnPropertyChanged(() => IsUserNameVisible);
                    Testrun = false;
                    TestPassed = false;
                }
            }
        }
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(() => UserName);
            }
        }
        /// <summary>
        /// Password
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(() => Password);
            }
        }

        /// <summary>
        /// The message that will be set if the test is either successful or not
        /// </summary>
        public string TestMessage
        {
            get
            {
                return _testMessage;
            }

            set
            {
                _testMessage = value;
                OnPropertyChanged(() => TestMessage);
            }

        }

        #endregion


        public bool TestPassed
        {
            get
            {
                return _testPassed;
            }
            set
            {
                _testPassed = value;
                OnPropertyChanged(() => TestPassed);
                OnPropertyChanged(() => CanClickOk);
            }
        }
        public bool TestFailed
        {
            get
            {
                return _testPassed;
            }
            set
            {
                _testPassed = value;
                OnPropertyChanged(() => TestFailed);
                OnPropertyChanged(() => CanClickOk);
            }
        }
        public bool Testing
        {
            get
            {
                return _testPassed;
            }
            set
            {
                _testPassed = value;
                OnPropertyChanged(() => Testing);
                OnPropertyChanged(() => CanClickOk);
            }
        }

        public bool IsOkEnabled
        {
            get
            {
                return IsValid;
            }

        }

        public bool IsTestEnabled
        {
            get
            {
                return (Address.Length > 0);
            }

        }

        public bool IsUserNameVisible
        {
            get
            {
                return AuthenticationType == AuthenticationType.User;
            }

        }

        public bool IsPasswordVisible
        {
            get
            {
                return AuthenticationType == AuthenticationType.User;
            }

        }

        public string AddressLabel
        {
            get
            {
                return Resources.Languages.Core.ServerSourceDialogAddressLabel;
            }
        }

        public string UserNameLabel
        {
            get
            {
                return Resources.Languages.Core.UserNameLabel;
            }
        }

        public string AuthenticationLabel
        {
            get
            {
                return Resources.Languages.Core.AuthenticationTypeLabel;
            }
        }

        public string PasswordLabel
        {
            get
            {
                return Resources.Languages.Core.PasswordLabel;

            }
        }

        public string TestLabel
        {
            get
            {
                return Resources.Languages.Core.TestConnectionLabel;
            }
        }


        /// <summary>
        /// Test if connection is successful
        /// </summary>
        public ICommand TestCommand
        { get; set; }
        public IServerSource ServerSource
        {
            get
            {
                return _serverSource;
            }
            set
            {
                _serverSource = value;
                if(!String.IsNullOrEmpty(value.Name))
                HeaderText = SetToEdit(value);
            }
        }
        public IRequestServiceNameViewModel RequestServiceNameViewModel
        {
            get
            {
                return _requestServiceNameViewModel;
            }
        }
        public string Protocol
        {
            get
            {
                return _protocol;
            }
            set
            {
                _protocol = value;
                OnPropertyChanged(Protocol);
                if (Protocol == "https" && SelectedPort == "3142")
                {
                    SelectedPort = "3143";
                }
                else if(Protocol == "http" && SelectedPort == "3143")
                {
                    SelectedPort = "3142";
                }
            }
        }
        public string[] Protocols { get; set; }
        public ObservableCollection<string> Ports { get; set; }
        public string SelectedPort
        {
            get
            {
                return _selectedPort;
            }
            set
            {
                if (_selectedPort != value)
                {
                    _selectedPort = value;
                    OnPropertyChanged(() => SelectedPort);
                    TestPassed = false;
                    OnPropertyChanged(()=>TestPassed);
                }
               
            }
        }

        public string AddressToolTip
        {
            get
            {
                return Resources.Languages.Core.ServerSourceDialogAddressToolTip; 
            }
        }
        public string ProtocolToolTip
        {
            get
            {
                return Resources.Languages.Core.ServerSourceDialogProtocolToolTip;
            }
        }
        public string PortToolTip
        {
            get
            {
                return Resources.Languages.Core.ServerSourceDialogAddressPortTip;
            }
        }
        public string WindowsAuthenticationToolTip
        {
            get
            {
                return Resources.Languages.Core.WindowsAuthenticationToolTip;
            }
        }
        public string UserAuthenticationToolTip
        {
            get
            {
                return Resources.Languages.Core.UserAuthenticationToolTip;
            }
        }
        public string PublicToolTip
        {
            get
            {
                return Resources.Languages.Core.ServerSourceDialogPublicToolTip;
            }
        }
        public string UserNameToolTip
        {
            get
            {
                return Resources.Languages.Core.UserNameToolTip;
            }
        }
        public string PasswordToolTip
        {
            get
            {
                return Resources.Languages.Core.PasswordToolTip;
            }
        }
        public string TestToolTip
        {
            get
            {
                return Resources.Languages.Core.ServerSourceDialogsTestToolTip;
            }
        }
        public string SaveToolTip
        {
            get
            {
                return Resources.Languages.Core.ServerSourceDialogAddressSaveTip;
            }
        }

        public override void UpdateHelpDescriptor(string helpText)
        {
            var helpDescriptor = new HelpDescriptor("", helpText, null);
            VerifyArgument.IsNotNull("helpDescriptor", helpDescriptor);
            //_aggregator.GetEvent<HelpChangedEvent>().Publish(helpDescriptor);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return _headerText;
        }
    }
}