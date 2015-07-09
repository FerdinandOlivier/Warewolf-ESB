﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Dev2.Common.Interfaces;
using Dev2.Runtime.ServiceModel.Data;
using Microsoft.Practices.Prism.Mvvm;

namespace Warewolf.Studio.Views
{
    /// <summary>
    /// Interaction logic for ManageWebserviceSourceControl.xaml
    /// </summary>
    public partial class ManageWebserviceSourceControl : IView, ICheckControlEnabledView
    {
        public ManageWebserviceSourceControl()
        {
            InitializeComponent();
            ServerTextBox.Focus();
        }

        public void EnterServerName(string serverName)
        {
            ServerTextBox.Text = serverName;
        }
        
        public void EnterDefaultQuery(string defaultQuery)
        {
            DefaultQueryTextBox.Text = defaultQuery;
        }

        public bool GetControlEnabled(string controlName)
        {
            switch (controlName)
            {
                case "Save":
                    return SaveButton.Command.CanExecute(null);
                case "Test Connection":
                    return TestConnectionButton.Command.CanExecute(null);
                case "TestQuery":
                    return TestDefault.IsEnabled;
            }
            return false;
        }

        public void SetAuthenticationType(AuthenticationType authenticationType)
        {
            if (authenticationType == AuthenticationType.Anonymous)
            {
                AnonymousRadioButton.IsChecked = true;
            }
            else
            {
                UserRadioButton.IsChecked = true;
            }
        }

        public Visibility GetUsernameVisibility()
        {
            BindingExpression be = UserNamePasswordContainer.GetBindingExpression(VisibilityProperty);
            if (be != null)
            {
                be.UpdateTarget();
            }
            return UserNamePasswordContainer.Visibility;
        }

        public Visibility GetPasswordVisibility()
        {
            BindingExpression be = UserNamePasswordContainer.GetBindingExpression(VisibilityProperty);
            if (be != null)
            {
                be.UpdateTarget();
            }
            return UserNamePasswordContainer.Visibility;
        }

        public void PerformTestConnection()
        {
            TestConnectionButton.Command.Execute(null);
        }

        public void PerformSave()
        {
            SaveButton.Command.Execute(null);
        }

        public void EnterUserName(string userName)
        {
            UserNameTextBox.Text = userName;
        }

        public void EnterPassword(string password)
        {
            PasswordTextBox.Password = password;
        }

        public string GetErrorMessage()
        {
            BindingExpression be = ErrorTextBlock.GetBindingExpression(TextBlock.TextProperty);
            if (be != null)
            {
                be.UpdateTarget();
            }
            return ErrorTextBlock.Text;
        }

        #region Implementation of IComponentConnector

        /// <summary>
        /// Attaches events and names to compiled content. 
        /// </summary>
        /// <param name="connectionId">An identifier token to distinguish calls.</param><param name="target">The target to connect events and names to.</param>
        public void Connect(int connectionId, object target)
        {
        }

        #endregion

        public string GetAddress()
        {
            return ServerTextBox.Text;
        }

        public string GetDefaultQuery()
        {
            return DefaultQueryTextBox.Text;
        }

        public string GetUsername()
        {
            return UserNameTextBox.Text;
        }

        public string GetPassword()
        {
            return PasswordTextBox.Password;
        }

        public string GetTestDefault()
        {
            BindingExpression be = TestDefault.GetBindingExpression(Hyperlink.NavigateUriProperty);
            if (be != null)
            {
                be.UpdateTarget();
            }
            return TestDefault.NavigateUri.ToString();
        }

        public void ClickHyperLink()
        {
            TestDefault.Command.Execute(null);
        }

        public string GetHeaderText()
        {
            BindingExpression be = HeaderTextBlock.GetBindingExpression(TextBlock.TextProperty);
            if (be != null)
            {
                be.UpdateTarget();
            }
            return HeaderTextBlock.Text;
        }
    }
}
