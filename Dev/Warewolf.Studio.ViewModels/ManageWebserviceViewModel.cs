﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Data;
using Dev2.Common.Interfaces.DB;
using Dev2.Common.Interfaces.Enums.Enums;
using Dev2.Common.Interfaces.Explorer;
using Dev2.Common.Interfaces.SaveDialog;
using Dev2.Common.Interfaces.ServerProxyLayer;
using Dev2.Common.Interfaces.Studio.ViewModels.Dialogues;
using Dev2.Common.Interfaces.WebServices;
using Dev2.Controller;
using Dev2.Network;
using Microsoft.Practices.Prism.Commands;
using Warewolf.Core;
using Warewolf.Studio.AntiCorruptionLayer;
using Warewolf.Studio.ServerProxyLayer;

namespace Warewolf.Studio.ViewModels
{
    public class ManageWebServiceViewModel : SourceBaseImpl<IWebService>, IManageWebServiceViewModel
    {
        readonly IWebServiceModel _model;
        readonly IRequestServiceNameViewModel _saveDialog;
        WebRequestMethod _selectedWebRequestMethod;
        ICollection<WebRequestMethod> _webRequestMethods;
        ICommand _newWebSourceCommand;
    
        ICollection<IWebServiceSource> _sources;
        IWebServiceSource _selectedSource;
        IWebService _webService;
        ICollection<NameValue> _headers;
        string _requestUrlQuery;
        string _sourceUrl;
        string _requestBody;
        ICollection<NameValue> _variables;
        string _response;
        ICommand _pastResponseCommand;
        ICommand _testCommand;
        ICommand _saveCommand;
        ICommand _cancelCommand;
        ICollection<IServiceOutputMapping> _outputs;
        ICollection<IServiceInput> _inputs;
        string _outputName;
        string _resourceName;
        bool _requestBodyEnabled;
        ICommand _editWebSourceCommand;
        IList<IServiceOutputMapping> _outputMapping;
        bool _canSave;
        string _errorMessage;
        bool _isTesting;
        bool _canEditMappings;
        string _name;
        Guid _id;
        string _path;
        bool _canEditHeadersAndUrl;

        #region Implementation of IManageWebServiceViewModel

        public ManageWebServiceViewModel(ResourceType? image, IWebServiceModel model, IRequestServiceNameViewModel saveDialog)
            : base(image)
        {
            _model = model;
            _saveDialog = saveDialog;

            
            Init();
        }


        public ManageWebServiceViewModel(ResourceType? image, IWebServiceModel model, IRequestServiceNameViewModel saveDialog,IWebService service)
            : base(image)
        {
            _model = model;
            _saveDialog = saveDialog;
            Variables = new ObservableCollection<NameValue>();
            RequestUrlQuery = service.QueryString;
            Inputs = service.Inputs;
            Outputs = service.OutputMappings;
            Item = service;
           
            Init();
        }




        public ManageWebServiceViewModel(ResourceType webService)
            : base(webService)
        {
            var commController = new  CommunicationControllerFactory();
            var connection = new ServerProxy( new Uri( "http://localhost:3142"));
            connection.Connect(Guid.NewGuid());
            IStudioUpdateManager updateRepository = new StudioResourceUpdateManager(commController,connection); 
            IQueryManager queryProxy = new QueryManagerProxy(commController,connection);
            
            _model = new WebServiceModel(updateRepository,queryProxy,"bob");

           
            Init();
           
        }

        void Init()
        {
            WebService = new WebServiceDefinition();
            Header = Resources.Languages.Core.WebserviceTabHeader;
            WebRequestMethods = new ObservableCollection<WebRequestMethod>(Dev2EnumConverter.GetEnumsToList<WebRequestMethod>());
            SelectedWebRequestMethod = WebRequestMethods.First();
            Sources = new ObservableCollection<IWebServiceSource>(Model.RetrieveSources());
            Inputs = new ObservableCollection<IServiceInput>{new ServiceInput("a","a"),new ServiceInput("b","b")};
            Outputs = new ObservableCollection<IServiceOutputMapping> { new ServiceOutputMapping("bob", "builder"), new ServiceOutputMapping("dora", "explorer") };
            EditWebSourceCommand = new DelegateCommand(() => Model.EditSource(SelectedSource), () => SelectedSource != null);
            var headerCollection = new ObservableCollection<INameValue>();
            headerCollection.CollectionChanged += HeaderCollectionOnCollectionChanged;
            Headers = new ObservableCollection<NameValue>();
            Variables =  new ObservableCollection<NameValue>();
            RequestBody = "";
            Response = "";
            TestCommand = new DelegateCommand(() => Test(_model), CanTest);
            SaveCommand = new DelegateCommand(Save, CanSave);
            NewWebSourceCommand = new DelegateCommand(_model.CreateNewSource);

        }

        public bool CanTest()
        {
            return SelectedSource!=null;
        }

        void Save()
        {
            try
            {


                if (Item == null)
                {
                    var saveOutPut = _saveDialog.ShowSaveDialog();
                    if (saveOutPut == MessageBoxResult.OK || saveOutPut == MessageBoxResult.Yes)
                    {
                        Name = _saveDialog.ResourceName.Name;
                        Path = _saveDialog.ResourceName.Path;
                        Id = Guid.NewGuid();
                        _model.SaveService(ToModel());
                        Item = ToModel();
                        Header = Path + Name;

                    }
                }
                else
                {
                    _model.SaveService(ToModel());
                }
                ErrorMessage = "";
            }
            catch (Exception err)
            {

                ErrorMessage = err.Message;
            }
        }



        void Test(IWebServiceModel model)
        {
            try
            {
                IsTesting = true;
                Response = model.TestService(ToModel());
                UpdateMappingsFromResponse();
                _canSave = true;
                ErrorMessage = "";
                CanEditMappings = true;
               
                IsTesting = false;
            }
            catch (Exception err)
            {
                ErrorMessage = err.Message;
                _canSave = false;
                OutputMapping = new ObservableCollection<IServiceOutputMapping>();
                IsTesting = false;
                CanEditMappings = false;
            }


        }

        void UpdateMappingsFromResponse()
        {
            //update inputs and outputs based on response test. 
        }

        public bool CanSave()
        {
            return !String.IsNullOrEmpty(Response);
        }

        void HeaderCollectionOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            foreach(var nameValue in Headers)
            {
                UpdateRequestVariables(nameValue.Value);
                UpdateRequestVariables(nameValue.Name);
            }
        }

        void UpdateRequestVariables(string name)
        {
            var exp = WarewolfDataEvaluationCommon.ParseLanguageExpression(name);
            if(Variables.Any(a=>a.Name == name))
            {
                return;
            }
            if(exp.IsScalarExpression)
            {
                var scalar = exp as LanguageAST.LanguageExpression.ScalarExpression;
                Variables.Add( new NameValue {Name = WarewolfDataEvaluationCommon.LanguageExpressionToString(scalar), Value = ""  });
            }
            if (exp.IsRecordSetExpression)
            {
                var rec = exp as LanguageAST.LanguageExpression.RecordSetExpression;
                Variables.Add(new NameValue { Name = WarewolfDataEvaluationCommon.LanguageExpressionToString(rec), Value = "" });
            }
            if (exp.IsComplexExpression)
            {
                var rec = exp as LanguageAST.LanguageExpression.ComplexExpression;
                // ReSharper disable PossibleNullReferenceException
                foreach(var languageExpression in rec.Item)
                    // ReSharper restore PossibleNullReferenceException
                {
                    UpdateRequestVariables(WarewolfDataEvaluationCommon.LanguageExpressionToString(languageExpression));
                }
               
            }
            RemoveUnused();

           
           
        }

        void RemoveUnused()
        {
            IList<NameValue> unused = new List<NameValue>();
            if (Variables != null)
            {
                foreach (var nameValue in Variables)
                {
                    if (String.IsNullOrEmpty(nameValue.Value))
                    {
                        if(!RequestUrlQuery.Contains(nameValue.Name) && !RequestBody.Contains(nameValue.Name) && ! Headers.Any(a=>a.Name.Contains(nameValue.Name) || a.Value.Contains(nameValue.Name)))
                        {
                          unused.Add(nameValue);
                        }
                    }
                }

            }
            foreach(var nameValue in unused)
            {
                if(Variables != null)
                {
                    Variables.Remove(nameValue);
                }
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                OnPropertyChanged(()=>Path);
            }
        }

        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(() => Id);
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(() => Name);
            }
        }
        public bool CanEditHeadersAndUrl
        {
            get
            {
                return _canEditHeadersAndUrl;
            }
            set
            {
                _canEditHeadersAndUrl = value;
                OnPropertyChanged(() => CanEditHeadersAndUrl);
            }
        }

        public bool CanEditMappings
        {
            get
            {
                return _canEditMappings;
            }
            set
            {
                _canEditMappings = value;
                OnPropertyChanged(() => CanEditMappings);
            }
        }

        public bool IsTesting
        {
            get
            {
                return _isTesting;
            }
            set
            {
                _isTesting = value;
                OnPropertyChanged(() => IsTesting);
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(ErrorMessage);
            }
        }

        public string ResourceName
        {
            get
            {
                return _resourceName;
            }
            set
            {
                _resourceName = value;
                OnPropertyChanged(_resourceName);
            }
        }

        /// <summary>
        /// currently selected web resquest method post get
        /// </summary>
        public WebRequestMethod SelectedWebRequestMethod
        {
            get
            {
                return _selectedWebRequestMethod;
            }
            set
            {
                _selectedWebRequestMethod = value;
                RequestBodyEnabled = value != WebRequestMethod.Get;
                OnPropertyChanged(() => SelectedWebRequestMethod);
            }
        }
        public bool RequestBodyEnabled
        {
            get
            {
                return _requestBodyEnabled;
            }
            set
            {
                _requestBodyEnabled = value;
                OnPropertyChanged(() => RequestBodyEnabled);
        }
        }
        /// <summary>
        /// the collections of supported web request methods
        /// </summary>
        public ICollection<WebRequestMethod> WebRequestMethods
        {
            get
            {
                return _webRequestMethods;
            }
            set
            {
                _webRequestMethods = value;
                OnPropertyChanged(() => WebRequestMethods);
            }
        }
        /// <summary>
        /// Command to create a new web source 
        /// </summary>
        public ICommand NewWebSourceCommand
        {
            get
            {
                return _newWebSourceCommand;
            }
            set
            {
                _newWebSourceCommand = value;
                OnPropertyChanged(() => NewWebSourceCommand);
            }
        }
        /// <summary>
        /// Command to create a new web source 
        /// </summary>
        public ICommand EditWebSourceCommand
        {
            get
            {
                return _editWebSourceCommand;
            }
            set
            {
                _editWebSourceCommand = value;
                OnPropertyChanged(() => EditWebSourceCommand);
            }
        }
        /// <summary>
        /// Available Sources
        /// </summary>
        public ICollection<IWebServiceSource> Sources
        {
            get
            {
                return _sources;
            }
            // ReSharper disable MemberCanBePrivate.Global
            set
                // ReSharper restore MemberCanBePrivate.Global
            {
                _sources = value;
                OnPropertyChanged(()=> Sources);
            }
        }
        /// <summary>
        /// Currently Selected Source
        /// </summary>
        public IWebServiceSource SelectedSource
        {
            get
            {
                return _selectedSource;
            }
            set
            {
                _selectedSource = value;
                if(_selectedSource != null)
                {
                    RequestUrlQuery = _selectedSource.DefaultQuery??"";
                    SourceUrl = _selectedSource.HostName;
                    CanEditHeadersAndUrl = true;
                    ViewModelUtils.RaiseCanExecuteChanged(TestCommand);
                }
                else
                {
                    CanEditHeadersAndUrl = false;
                }
                OnPropertyChanged(() => SelectedSource);
            }
        }
        /// <summary>
        /// The underlying Web service
        /// </summary>
        public IWebService WebService
        {
            get
            {
                return _webService;
            }
            set
            {
                _webService = value;
                OnPropertyChanged(() => WebService);
            }
        }

        /// <summary>
        /// Label for selecteing a header
        /// </summary>
        // ReSharper disable UnusedMember.Global
        public string SelectSourceHeader
            // ReSharper restore UnusedMember.Global
        {
            get { return Resources.Languages.Core.WebserviceHeader; }
        }
        /// <summary>
        /// Request headers
        /// </summary>
        public ICollection<NameValue> Headers
        {
            get
            {
                return _headers;
            }
            set
            {
                _headers = value;
                if (_headers != null)
                {
                    foreach (var nameValue in _headers)
                    {
                        UpdateRequestVariables(nameValue.Name);
                        UpdateRequestVariables(nameValue.Value);
                    }

                }
                OnPropertyChanged(() => Headers);
            }
        }
        /// <summary>
        /// Select the headers
        /// </summary>
        // ReSharper disable UnusedMember.Global
        public string SelectHeadersHeader
            // ReSharper restore UnusedMember.Global
        {
            get { return Resources.Languages.Core.WebserviceHeadersHeader; }
        }
        /// <summary>
        /// The Web service query string
        /// </summary>
        public string RequestUrlQuery
        {
            get
            {
                return _requestUrlQuery;
            }
            set
            {
                _requestUrlQuery = value;
                UpdateRequestVariables(RequestUrlQuery);
                OnPropertyChanged(() => RequestUrlQuery);
            }
        }
        /// <summary>
        /// The URL as per the Source
        /// </summary>
        public string SourceUrl
        {
            get
            {
                return _sourceUrl;
            }
            set
            {
                _sourceUrl = value;
                OnPropertyChanged(() => SourceUrl);
            }
        }
        /// <summary>
        ///  The form Header
        /// </summary>
        // ReSharper disable UnusedMember.Global
        public string RequestUrlHeader
            // ReSharper restore UnusedMember.Global
        {
            get { return Resources.Languages.Core.WebserviceRequestURLHeader; }
        }
        /// <summary>
        /// The Request Body
        /// </summary>
        public string RequestBody
        {
            get
            {
                return _requestBody;
            }
            set
            {
                _requestBody = value;
                UpdateRequestVariables(value);
                OnPropertyChanged(() => RequestBody);
            }
        }
        /// <summary>
        /// Request Body Header
        /// </summary>
        // ReSharper disable UnusedMember.Global
        public string RequestBodyHeader
            // ReSharper restore UnusedMember.Global
        {
            get { return Resources.Languages.Core.WebserviceRequestBodyHeader; }
        }
        /// <summary>
        /// Request Header
        /// </summary>
        [ExcludeFromCodeCoverage]
        // ReSharper disable UnusedMember.Global
        public string RequestHeader
            // ReSharper restore UnusedMember.Global
        {
            get { return Resources.Languages.Core.WebserviceRequestHeader; }

        }
        /// <summary>
        /// Variables Header
        /// </summary>
        [ExcludeFromCodeCoverage]
        // ReSharper disable UnusedMember.Global
        public string VariablesHeader
            // ReSharper restore UnusedMember.Global
        {
            get { return Resources.Languages.Core.WebserviceVariablesHeader; }
            
        }
        /// <summary>
        /// Variables Header
        /// </summary>
        [ExcludeFromCodeCoverage]
        public string MappingsHeader
        {
            get { return Resources.Languages.Core.DefaultMappings; }
        }
        /// <summary>
        /// the warewolf variables defined in the body,headers and query string
        /// </summary>
        public ICollection<NameValue> Variables
        {
            get
            {
                return _variables;
            }
            set
            {
                _variables = value;
                OnPropertyChanged(() => Variables);
            }
        }
        /// <summary>
        /// Response Header
        /// </summary>
        [ExcludeFromCodeCoverage]
        // ReSharper disable UnusedMember.Global
        public string ResponseHeader
            // ReSharper restore UnusedMember.Global
        {
            get { return Resources.Languages.Core.WebserviceResponseHeader; }
        }
        /// <summary>
        /// the response from the web service
        /// </summary>
        public string Response
        {
            get
            {
                return _response;
            }
            set
            {
                _response = value;
                OnPropertyChanged(() => Response);
            }
        }
        /// <summary>
        /// the command to paste a command into the response
        /// </summary>
        public ICommand PasteResponseCommand
        {
            get
            {
                return _pastResponseCommand;
            }
            set
            {
                _pastResponseCommand = value;
                OnPropertyChanged(() => PasteResponseCommand);
            }
        }
        /// <summary>
        /// Test a web Service
        /// </summary>
        public ICommand TestCommand
        {
            get
            {
                return _testCommand;
            }
            set
            {
                _testCommand = value;
                OnPropertyChanged(() => TestCommand);
            }
        }
        /// <summary>
        /// Text for the Test button
        /// </summary>
        public string TestCommandButtonText { get; set; }
        /// <summary>
        /// Text for the Save button
        /// </summary>
        public string SaveCommandText { get; set; }
        /// <summary>
        /// command to save
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand;
            }
            set
            {
                _saveCommand = value;
                OnPropertyChanged(() => SaveCommand);
            }
        }
        /// <summary>
        /// Cancel Command
        /// </summary>
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand;
            }
            set
            {
                _cancelCommand = value;
                OnPropertyChanged(() => CancelCommand);
            }
        }
      
        /// <summary>
        /// Has the Source changed
        /// </summary>

        /// <summary>
        /// List OfInputs
        /// </summary>
        public ICollection<IServiceOutputMapping> Outputs
        {
            get
            {
                return _outputs;
            }
            set
            {
                _outputs = value;
                OnPropertyChanged(() => Outputs);
            }
        }
        /// <summary>
        /// List Of Outputs
        /// </summary>
        public ICollection<IServiceInput> Inputs
        {
            get
            {
                return _inputs;
            }
            set
            {
                _inputs = value;
                OnPropertyChanged(() => Inputs);
            }
        }
        public IList<IServiceOutputMapping> OutputMapping
        {
            get
            {
                return _outputMapping;
            }
            set
            {
                _outputMapping = value;
                OnPropertyChanged(() => OutputMapping);
            }
        }
        /// <summary>
        /// Input region ColumnHeader
        /// </summary>
        public string InputsHeader { get; set; }
        /// <summary>
        ///  input column Header
        /// </summary>
        public string InputNameHeader { get; set; }
        /// <summary>
        /// Default value column Header
        /// </summary>
        public string DefaultValueHeader { get; set; }
        /// <summary>
        /// IsRequiredFieldColumnHeader
        /// </summary>
        public string RequiredFieldHeader { get; set; }
        /// <summary>
        /// EmptyIsNullColumnHeader
        /// </summary>
        public string EmptyIsNullHeader { get; set; }
        /// <summary>
        /// Outputs RegionHeader
        /// </summary>
        public string OutputsHeader { get; set; }
        /// <summary>
        /// Output Column BName Header
        /// </summary>
        public string OutputName
        {
            get
            {
                return _outputName;
            }
            set
            {
                _outputName = value;
            }
        }
        /// <summary>
        /// Output Column alias Header
        /// </summary>
        public string OutputAliasHeader { get; set; }
        public IRequestServiceNameViewModel SaveDialog
        {
            get
            {
                return _saveDialog;
            }
        }
        public IWebServiceModel Model
        {
            get
            {
                return _model;
            }
        }

        #endregion

        #region Implementation of IActiveAware




        public override void UpdateHelpDescriptor(string helpText)
        {
        }

        #endregion

        #region Implementation of IDockAware

        public override IWebService ToModel()
        {
            if (Item != null)
            {
                return new WebServiceDefinition
                {
                    Name = Item.Name,
                    Inputs = Inputs == null ? new List<IServiceInput>() : Inputs.ToList(),
                    OutputMappings = OutputMapping,
                    Source = SelectedSource,
                    Path = Item.Path,
                    Id = Item.Id,
                    Headers = Headers.ToList(),
                    PostData = RequestBody,
                    QueryString = RequestUrlQuery
                };
            }
            return new WebServiceDefinition
            {
               
                Inputs = Inputs == null ? new List<IServiceInput>() : Inputs.ToList(),
                OutputMappings = OutputMapping,
                Source = SelectedSource,
                Name = "",
                Path = "",
                Id = Guid.NewGuid(),
                PostData =  RequestBody,
                Headers = Headers.ToList(),
                QueryString = RequestUrlQuery
            };

        }



        #endregion

  

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion
    }
}
