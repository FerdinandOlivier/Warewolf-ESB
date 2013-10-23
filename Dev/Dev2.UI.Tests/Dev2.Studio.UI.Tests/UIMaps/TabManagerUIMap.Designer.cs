﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 11.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

using Dev2.CodedUI.Tests.UIMaps.DocManagerUIMapClasses;
using Dev2.CodedUI.Tests.UIMaps.ExplorerUIMapClasses;
using Dev2.Studio.UI.Tests;

namespace Dev2.CodedUI.Tests.TabManagerUIMapClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using System;
    using System.CodeDom.Compiler;
    using System.Drawing;
    using System.Linq;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;


    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public partial class TabManagerUIMap : UIMapBase
    {
        public UITestControl GetManager()
        {
            var mainPane = DockManagerUIMap.GetMainPane();
            if (mainPane != null)
            {
                return mainPane.GetChildren()[0].GetChildren()[0];
            }
            return null;
        }

        public UITestControl FindTabByName(string name)
        {
            UITestControl control = _tabManager.GetTab(name);
            return control;
        }

        private int GetChildrenCount()
        {
            int childCount = 0;
            if(_tabManager != null)
            {
                foreach(var child in _tabManager.GetChildren())
                {
                    if (child.ControlType.Name == "TabPage")
                    {
                        childCount = _tabManager.GetChildren().Count;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return childCount;
        }

        private UITestControlCollection GetWorkflowNotSavedButtons()
        {
            // Workflow not saved...
            UITestControl theWindow = new UITestControl();
            theWindow.TechnologyName = "MSAA";
            theWindow.SearchProperties["Name"] = "Workflow not saved...";
            theWindow.SearchProperties["ControlType"] = "Window";
            theWindow.Find();
            UITestControlCollection firstChildren = theWindow.GetChildren();

            var ctrls = firstChildren.Where(c => c.ClassName == "Uia.Button");

            UITestControlCollection saveDialogButtons = new UITestControlCollection();
            foreach (UITestControl control in ctrls)
            {
                saveDialogButtons.Add(control);
            }
            
            return saveDialogButtons;
        }
        public class UIUI_TabManager_AutoIDTabList1 : WpfTabList
        {

            public UIUI_TabManager_AutoIDTabList1(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
            {
                #region Search Criteria
                this.SearchProperties[WpfTabList.PropertyNames.AutomationId] = "UI_TabManager_AutoID";
                this.WindowTitles.Add(TestBase.GetStudioWindowName());
                #endregion
            }

            public UITestControl GetTab(string childAutomationID)
            {
                WpfTabList theList = (WpfTabList)this;
                UITestControlCollection tabList = theList.Tabs; // This lags for some reason
                foreach (WpfTabPage currentTapPage in tabList)
                {
                    UITestControlCollection tabChildren = currentTapPage.GetChildren();
                    foreach (var tabChild in tabChildren)
                    {
                        if (tabChild.FriendlyName.Contains(childAutomationID))
                        {
                            return currentTapPage;
                        }
                    }
                }
                return null;
            }
        }
    }
}
