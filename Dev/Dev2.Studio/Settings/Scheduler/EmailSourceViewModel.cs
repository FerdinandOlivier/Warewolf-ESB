using System.Windows;
using Caliburn.Micro;
using Dev2.Activities.Designers2.Core.Help;
using Dev2.Common.Interfaces.Studio.Controller;
using Dev2.Interfaces;
using Dev2.Studio.ViewModels.WorkSurface;
using Warewolf.Studio.ViewModels;

namespace Dev2.Settings.Scheduler
{
    public class EmailSourceViewModel : BaseWorkSurfaceViewModel, IHelpSource, IStudioTab
    {
        string _helpText;
        ManageEmailSourceViewModel _vm;
        readonly IPopupController _popupController;
        public EmailSourceViewModel(IEventAggregator eventPublisher, ManageEmailSourceViewModel vm, IPopupController popupController)
            : base(eventPublisher)
        {
            ViewModel = vm;
            _popupController = popupController;
        }

        #region Implementation of IHelpSource

        public string HelpText
        {
            get
            {
                return _helpText;
            }
            set
            {
                _helpText = value;
            }
        }
        public ManageEmailSourceViewModel ViewModel
        {
            get
            {
                return _vm;
            }
            set
            {
                _vm = value;
            }
        }

        #endregion

        #region Implementation of IStudioTab

        public bool DoDeactivate()
        {
            if (ViewModel.HasChanged )
            {
                MessageBoxResult showSchedulerCloseConfirmation = _popupController.ShowSchedulerCloseConfirmation();
                if(showSchedulerCloseConfirmation == MessageBoxResult.Cancel || showSchedulerCloseConfirmation == MessageBoxResult.None)
                {
                    return false;
                }
                if(showSchedulerCloseConfirmation == MessageBoxResult.No)
                {
                    return true;
                }

            }

            return true;
        }

        #endregion
    }
}