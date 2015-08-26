
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2015 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/


#region

using System;
using System.Activities.Presentation.Model;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using Dev2.Activities.Designers2.Decision;
using Dev2.Activities.Designers2.Switch;
using Dev2.Common;
using Dev2.Common.Interfaces.Studio.Controller;
using Dev2.Data.SystemTemplates.Models;
using Dev2.Services.Events;
using Dev2.Studio.Core.AppResources.ExtensionMethods;
using Dev2.Studio.Core.Messages;
using Dev2.Utilities;
using Dev2.Webs;
using Dev2.Webs.Callbacks;
using Newtonsoft.Json;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Warewolf.Studio.Views;

#endregion

// ReSharper disable CheckNamespace
namespace Dev2.Studio.Controller
// ReSharper restore CheckNamespace
{
    public interface IFlowController
    {
        void Handle(ConfigureDecisionExpressionMessage message);

        void Handle(ConfigureSwitchExpressionMessage message);

        void Handle(ConfigureCaseExpressionMessage message);

        void Handle(EditCaseExpressionMessage message);
    }

    public class FlowController : IHandle<ConfigureDecisionExpressionMessage>, IHandle<ConfigureSwitchExpressionMessage>,
                                  IHandle<ConfigureCaseExpressionMessage>, IHandle<EditCaseExpressionMessage>, IFlowController
    {

        #region Fields

        private static readonly IPopupController PopupController = CustomContainer.Get<IPopupController>();
        private static Dev2DecisionCallbackHandler _callBackHandler;

        #endregion Fields

        #region ctor

        public FlowController()
        {
            
            EventPublishers.Aggregator.Subscribe(this);
            _callBackHandler = new Dev2DecisionCallbackHandler();
        }

        #endregion ctor

        #region Public Methods

        /// <summary>
        ///     Configures the decision expression.
        ///     Travis.Frisinger - Developed for new Decision Wizard
        /// </summary>
        public static void ConfigureDecisionExpression(ConfigureDecisionExpressionMessage args)
        {
            var condition = ConfigureActivity<DsfFlowDecisionActivity>(args.ModelItem, GlobalConstants.ConditionPropertyText, args.IsNew);
            if (condition == null)
            {
                return;
            }

            var expression = condition.Properties[GlobalConstants.ExpressionPropertyText];

            _callBackHandler = StartDecisionWizard(condition);

            if (_callBackHandler != null)
            {
                try
                {

                    string tmp = FlowNodeHelper.CleanModelData(_callBackHandler.ModelData);
                    var dds = JsonConvert.DeserializeObject<Dev2DecisionStack>(tmp);

                    if (dds == null)
                    {
                        return;
                    }

                    ActivityHelper.SetArmTextDefaults(dds);
                    ActivityHelper.InjectExpression(dds, expression);
                    ActivityHelper.SetArmText(args.ModelItem, dds);
                    ActivityHelper.SetDisplayName(args.ModelItem, dds); // PBI 9220 - 2013.04.29 - TWR
                }
                catch
                {
                    //
                }
            }
        }

        public static void ConfigureSwitchExpression(ConfigureSwitchExpressionMessage args)
        {
            var expression = ConfigureActivity<DsfFlowSwitchActivity>(args.ModelItem, GlobalConstants.SwitchExpressionPropertyText, args.IsNew);
            if (expression == null)
            {
                return;
            }
            var expressionText = expression.Properties[GlobalConstants.SwitchExpressionTextPropertyText];
            _callBackHandler = StartSwitchDropWizard(expression);
            if (_callBackHandler != null)
            {
                try
                {
                    var resultSwitch = JsonConvert.DeserializeObject<Dev2Switch>(_callBackHandler.ModelData);
                    ActivityHelper.InjectExpression(resultSwitch, expressionText);
                    ActivityHelper.SetDisplayName(args.ModelItem, resultSwitch); // MUST use args.ModelItem otherwise it won't be visible!
                }
                catch
                {
                    PopupController.Show(GlobalConstants.SwitchWizardErrorString,
                                          GlobalConstants.SwitchWizardErrorHeading, MessageBoxButton.OK,
                                          MessageBoxImage.Error, null);
                }
            }
        }

        static Dev2DecisionCallbackHandler StartSwitchDropWizard(ModelItem modelItem)
        {
            var large = new ConfigureSwitch();
            var dataContext = new SwitchDesignerViewModel(modelItem);
            large.DataContext = dataContext;
            var window = new WindowBorderLess();
            var contentPresenter = window.FindChild<ContentPresenter>();
            if (contentPresenter != null)
            {
                contentPresenter.Content = large;
            }

            var showDialog = window.ShowDialog();
            if (showDialog.HasValue && showDialog.Value)
            {
                var callBack = new Dev2DecisionCallbackHandler { ModelData = JsonConvert.SerializeObject(dataContext.Switch) };
                return callBack;
            }
            return null;
        }

        public static void ConfigureSwitchCaseExpression(ConfigureCaseExpressionMessage args)
        {
            _callBackHandler = ShowSwitchDragDialog(args.ModelItem, args.ExpressionText);
            if (_callBackHandler != null)
            {
                try
                {
                    var ds = JsonConvert.DeserializeObject<Dev2Switch>(_callBackHandler.ModelData);
                    ActivityHelper.SetSwitchKeyProperty(ds, args.ModelItem);
                }
                catch
                {
                    PopupController.Show(GlobalConstants.SwitchWizardErrorString,
                                          GlobalConstants.SwitchWizardErrorHeading, MessageBoxButton.OK,
                                          MessageBoxImage.Error, null);
                }
            }
        }

        static Dev2DecisionCallbackHandler ShowSwitchDragDialog(ModelItem modelData, string variable = "")
        {
            var large = new ConfigureSwitchArm();
            var dataContext = new SwitchDesignerViewModel(modelData) { SwitchVariable = variable };
            large.DataContext = dataContext;
            var window = new WindowBorderLess();
            var contentPresenter = window.FindChild<ContentPresenter>();
            if (contentPresenter != null)
            {
                contentPresenter.Content = large;
            }

            var showDialog = window.ShowDialog();
            if (showDialog.HasValue && showDialog.Value)
            {
                var callBack = new Dev2DecisionCallbackHandler { ModelData = JsonConvert.SerializeObject(dataContext.Switch) };
                return callBack;
            }
            return null;
        }

        // 28.01.2013 - Travis.Frisinger : Added for Case Edits
        public static void EditSwitchCaseExpression(EditCaseExpressionMessage args)
        {
            ModelProperty switchCaseValue = args.ModelItem.Properties["Case"];
            var switchVal = args.ModelItem.Properties["ParentFlowSwitch"];
            var variable = SwitchExpressionValue(switchVal);
            _callBackHandler = ShowSwitchDragDialog(args.ModelItem, variable);
            if (_callBackHandler != null)
            {
                try
                {
                    var ds = JsonConvert.DeserializeObject<Dev2Switch>(_callBackHandler.ModelData);

                    if (ds != null)
                    {
                        if (switchCaseValue != null)
                        {
                            switchCaseValue.SetValue(ds.SwitchExpression);
                        }
                    }
                }
                catch
                {
                    PopupController.Show(GlobalConstants.SwitchWizardErrorString,
                                          GlobalConstants.SwitchWizardErrorHeading, MessageBoxButton.OK,
                                          MessageBoxImage.Error, null);
                }
            }
        }

        static string SwitchExpressionValue(ModelProperty activityExpression)
        {
            var tmpModelItem = activityExpression.Value;

            var switchExpressionValue = string.Empty;

            if (tmpModelItem != null)
            {
                var tmpProperty = tmpModelItem.Properties["Expression"];

                if (tmpProperty != null)
                {
                    if (tmpProperty.Value != null)
                    {
                        var value = tmpProperty.ComputedValue as DsfFlowSwitchActivity;
                        if (value != null)
                        {
                            var tmp = value.ExpressionText;
                            if (!string.IsNullOrEmpty(tmp))
                            {
                                int start = tmp.IndexOf("(", StringComparison.Ordinal);
                                int end = tmp.IndexOf(",", StringComparison.Ordinal);

                                if (start < end && start >= 0)
                                {
                                    start += 2;
                                    end -= 1;
                                    switchExpressionValue = tmp.Substring(start, (end - start));
                                }
                            }
                        }
                    }
                }
            }
            return switchExpressionValue;
        }
        #endregion public methods

        #region Protected Methods

        //protected static Dev2DecisionCallbackHandler StartDecisionWizard(IEnvironmentModel environmentModel, string val)
        //{
        //    return RootWebSite.ShowDecisionDialog(environmentModel, val);
        //}

        protected static Dev2DecisionCallbackHandler StartDecisionWizard(ModelItem mi)
        {
            var large = new Large();
            var dataContext = new DecisionDesignerViewModel(mi);
            large.DataContext = dataContext;
            var window = new WindowBorderLess();
            var contentPresenter = window.FindChild<ContentPresenter>();
            if (contentPresenter != null)
            {
                contentPresenter.Content = large;
            }

            var showDialog = window.ShowDialog();

            if (showDialog.HasValue && showDialog.Value)
            {
                var dev2DecisionCallbackHandler = new Dev2DecisionCallbackHandler();
                dataContext.GetExpressionText();
                dev2DecisionCallbackHandler.ModelData = dataContext.ExpressionText;
                return dev2DecisionCallbackHandler;
            }
            return null;
        }

        #endregion

        #region IHandle

        public void Handle(ConfigureDecisionExpressionMessage message)
        {

        }

        public void Handle(ConfigureSwitchExpressionMessage message)
        {
            ConfigureSwitchExpression(message);
        }

        public void Handle(ConfigureCaseExpressionMessage message)
        {
            ConfigureSwitchCaseExpression(message);
        }

        public void Handle(EditCaseExpressionMessage message)
        {
            EditSwitchCaseExpression(message);
        }

        #endregion IHandle

        #region ConfigureActivity

        static ModelItem ConfigureActivity<T>(ModelItem modelItem, string propertyName, bool isNew) where T : class, IFlowNodeActivity, new()
        {
            var property = modelItem.Properties[propertyName];
            if (property == null)
            {
                return null;
            }

            ModelItem result;
            var activity = property.ComputedValue as T;
            if (activity == null)
            {
                activity = new T();
                result = property.SetValue(activity);
            }
            else
            {
                result = property.Value;

                // BUG 9717 - 2013.06.22 - don't show wizard on copy paste
                var isCopyPaste = isNew && !string.IsNullOrEmpty(activity.ExpressionText);
                if (result == null || isCopyPaste)
                {
                    return null;
                }
            }
            return result;
        }

        #endregion

    }
}
