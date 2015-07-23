﻿
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2015 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Diagnostics;
using System.Windows.Input;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Studio;
using Dev2.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace Warewolf.Studio.ViewModels
{
    public class MenuViewModel : BindableBase, IMenuViewModel, IMenuView
    {

        bool _hasNewVersion;
        bool _panelLockedOpen;
        readonly IMainViewModel _viewModel;
        bool _isOverLock;
        ICommand _saveCommand;
        ICommand _executeServiceCommand;
        ICommand _supportCommand;

        public MenuViewModel(IMainViewModel mainViewModel)
        {
            if (mainViewModel == null)
            {
                throw new ArgumentNullException("mainViewModel");
            }
            _viewModel = mainViewModel;
            _isOverLock = false;
            NewCommand = _viewModel.NewResourceCommand;
            DeployCommand = _viewModel.DeployCommand;
            SaveCommand = _viewModel.SaveCommand;
            OpenSchedulerCommand = _viewModel.SchedulerCommand;
            OpenSettingsCommand = _viewModel.SettingsCommand;
            ExecuteServiceCommand = _viewModel.DebugCommand;
            OnPropertyChanged(() => SaveCommand);
            OnPropertyChanged(() => ExecuteServiceCommand);
            CheckForNewVersion(_viewModel);
            CheckForNewVersionCommand = new DelegateCommand(_viewModel.DisplayDialogForNewVersion);
            SupportCommand = new DelegateCommand(() =>
            {
                Process.Start(Resources.Languages.Core.WarewolfHelpURL);
            });

            LockCommand = new DelegateCommand(Lock);
            SlideOpenCommand = new DelegateCommand(() =>
            {
                if (!_isOverLock)
                {
                    SlideOpen(_viewModel);
                }
            });
            SlideClosedCommand = new DelegateCommand(() =>
            {
                // ReSharper disable CompareOfFloatsByEqualityOperator
                if (_viewModel.MenuPanelWidth >= 80 && !_isOverLock)
                {
                    SlideClosed(_viewModel);
                }
            });
            IsOverLockCommand = new DelegateCommand(() => _isOverLock = true);
            IsNotOverLockCommand = new DelegateCommand(() => _isOverLock = false);
            ButtonWidth = 125;
            IsPanelLockedOpen = true;
            IsPanelOpen = true;
        }

        public ICommand SupportCommand { get; set; }
        public ICommand DeployCommand { get; set; }
        public ICommand NewCommand { get; set; }
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
        public ICommand OpenSettingsCommand { get; set; }
        public ICommand OpenSchedulerCommand { get; set; }
        public ICommand ExecuteServiceCommand
        {
            get
            {
                return _executeServiceCommand;
            }
            set
            {
                _executeServiceCommand = value;
                OnPropertyChanged(() => ExecuteServiceCommand);
            }
        }
        public ICommand LockCommand { get; set; }
        public ICommand SlideOpenCommand { get; set; }
        public ICommand SlideClosedCommand { get; set; }
        public ICommand CheckForNewVersionCommand { get; set; }

        public string LockImage
        {
            get
            {
                if (IsPanelLockedOpen)
                    return "UnlockAlt";
                return "Lock";
            }
        }

        void UpdateProperties()
        {
            OnPropertyChanged(() => NewLabel);
            OnPropertyChanged(() => SaveLabel);
            OnPropertyChanged(() => DeployLabel);
            OnPropertyChanged(() => DatabaseLabel);
            OnPropertyChanged(() => DLLLabel);
            OnPropertyChanged(() => WebLabel);
            OnPropertyChanged(() => TaskLabel);
            OnPropertyChanged(() => DebugLabel);
            OnPropertyChanged(() => SettingsLabel);
            OnPropertyChanged(() => SupportLabel);
            OnPropertyChanged(() => ForumsLabel);
            OnPropertyChanged(() => ToursLabel);
            OnPropertyChanged(() => NewVersionLabel);
            OnPropertyChanged(() => LockLabel);
            OnPropertyChanged(() => ButtonWidth);
        }

        public ICommand IsOverLockCommand { get; private set; }
        public ICommand IsNotOverLockCommand { get; private set; }

        public void Lock()
        {
            if (!IsPanelLockedOpen)
            {
                IsPanelLockedOpen = true;
            }
            else
            {
                if (!IsPanelOpen && ButtonWidth == 125)
                    ButtonWidth = 35;
                if (IsPanelOpen && ButtonWidth == 35)
                    ButtonWidth = 125;

                IsPanelLockedOpen = false;
            }

            UpdateProperties();
        }

        void SlideOpen(IMainViewModel mainViewModel)
        {
            if (IsPanelLockedOpen)
            {
                IsPanelOpen = true;
                mainViewModel.MenuExpanded = IsPanelOpen;
                ButtonWidth = 125;
                UpdateProperties();
            }
        }

        void SlideClosed(IMainViewModel mainViewModel)
        {
            if (IsPanelLockedOpen && !IsPanelOpen)
            {
                mainViewModel.MenuExpanded = !IsPanelOpen;
                ButtonWidth = 35;
                IsPanelOpen = !IsPanelOpen;
            }
            else if (IsPanelLockedOpen && IsPanelOpen)
            {
                mainViewModel.MenuExpanded = !IsPanelOpen;
                ButtonWidth = 125;
                IsPanelOpen = !IsPanelOpen;
            }

            UpdateProperties();
        }

        async void CheckForNewVersion(IMainViewModel mainViewModel)
        {
            HasNewVersion = await mainViewModel.CheckForNewVersion();
        }

        public int ButtonWidth { get; set; }

        public bool HasNewVersion
        {
            get
            {
                return _hasNewVersion;
            }
            set
            {
                _hasNewVersion = value;
                OnPropertyChanged(() => HasNewVersion);
            }
        }

        public bool IsPanelOpen { get; set; }

        public bool IsPanelLockedOpen
        {
            get
            {
                return _panelLockedOpen;
            }
            set
            {
                _panelLockedOpen = value;
                OnPropertyChanged(() => LockLabel);
                OnPropertyChanged(() => LockImage);
            }
        }

        public bool CanExecuteService { get; set; }
        public bool CanSetSettings { get; set; }
        public bool CanSetSchedules { get; set; }
        public bool CanSave { get; set; }
        public bool CanDeploy { get; set; }
        public bool CanCreateNewService { get; set; }

        public string NewLabel
        {
            get
            {
                if (ButtonWidth == 125)
                    return Resources.Languages.Core.MenuDialogNewLabel;
                return String.Empty;
            }
        }
        public string SaveLabel
        {
            get
            {
                if (ButtonWidth == 125)
                    return Resources.Languages.Core.MenuDialogSaveLabel;
                return String.Empty;
            }
        }
        public string DeployLabel
        {
            get
            {
                if (ButtonWidth == 125)
                    return Resources.Languages.Core.MenuDialogDeployLabel;
                return String.Empty;
            }
        }
        public string DatabaseLabel
        {
            get
            {
                if (ButtonWidth == 125)
                    return Resources.Languages.Core.MenuDialogDatabaseLabel;
                return String.Empty;
            }
        }
        public string DLLLabel
        {
            get
            {
                if (ButtonWidth == 125)
                    return Resources.Languages.Core.MenuDialogDLLLabel;
                return String.Empty;
            }
        }
        public string WebLabel
        {
            get
            {
                if (ButtonWidth == 125)
                    return Resources.Languages.Core.MenuDialogWebLabel;
                return String.Empty;
            }
        }
        public string TaskLabel
        {
            get
            {
                if (ButtonWidth == 125)
                    return Resources.Languages.Core.MenuDialogTaskLabel;
                return String.Empty;
            }
        }
        public string DebugLabel
        {
            get
            {
                if (ButtonWidth == 125)
                    return Resources.Languages.Core.MenuDialogDebugLabel;
                return String.Empty;
            }
        }
        public string SettingsLabel
        {
            get
            {
                if (ButtonWidth == 125)
                    return Resources.Languages.Core.MenuDialogSettingsLabel;
                return String.Empty;
            }
        }
        public string SupportLabel
        {
            get
            {
                if (ButtonWidth == 125)
                    return Resources.Languages.Core.MenuDialogSupportLabel;
                return String.Empty;
            }
        }
        public string ForumsLabel
        {
            get
            {
                if (ButtonWidth == 125)
                    return Resources.Languages.Core.MenuDialogForumsLabel;
                return String.Empty;
            }
        }
        public string ToursLabel
        {
            get
            {
                if (ButtonWidth == 125)
                    return Resources.Languages.Core.MenuDialogToursLabel;
                return String.Empty;
            }
        }
        public string NewVersionLabel
        {
            get
            {
                if (ButtonWidth == 125)
                    return Resources.Languages.Core.MenuDialogNewVersionLabel;
                return String.Empty;
            }
        }
        public string LockLabel
        {
            get
            {
                if (IsPanelLockedOpen)
                    return Resources.Languages.Core.MenuDialogLockLabel;
                return Resources.Languages.Core.MenuDialogUnLockLabel;
            }
        }

        public object DataContext { get; set; }

        public string NewServiceToolTip
        {
            get { return Resources.Languages.Core.MenuNewServiceToolTip; }
        }
        public string SaveToolTip
        {
            get { return Resources.Languages.Core.MenuSaveToolTip; }
        }
        public string DeployToolTip
        {
            get { return Resources.Languages.Core.MenuDeployToolTip; }
        }
        public string DatabaseToolTip
        {
            get { return Resources.Languages.Core.MenuDatabaseToolTip; }
        }
        public string PluginToolTip
        {
            get { return Resources.Languages.Core.MenuPluginToolTip; }
        }
        public string WebServiceToolTip
        {
            get { return Resources.Languages.Core.MenuWebServiceToolTip; }
        }
        public string SchedulerToolTip
        {
            get { return Resources.Languages.Core.MenuSchedulerToolTip; }
        }
        public string DebugToolTip
        {
            get { return Resources.Languages.Core.DebugToolTip; }
        }
        public string SettingsToolTip
        {
            get { return Resources.Languages.Core.MenuSettingsToolTip; }
        }
        public string HelpToolTip
        {
            get { return Resources.Languages.Core.MenuHelpToolTip; }
        }
        public string DownloadToolTip
        {
            get { return Resources.Languages.Core.MenuDownloadToolTip; }
        }
        public string LockToolTip
        {
            get { return Resources.Languages.Core.MenuLockToolTip; }
        }
    }
}
