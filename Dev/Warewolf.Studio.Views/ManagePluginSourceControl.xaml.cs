﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Dev2.Common.Interfaces;
using Infragistics.Controls.Menus;
using Microsoft.Practices.Prism.Mvvm;
using Warewolf.Studio.Core;

namespace Warewolf.Studio.Views
{
    /// <summary>
    /// Interaction logic for ManagePluginSourceControl.xaml
    /// </summary>
    public partial class ManagePluginSourceControl : IView, ICheckControlEnabledView
    {
        public ManagePluginSourceControl()
        {
            InitializeComponent();

           // ExplorerTree.SelectedNodesCollectionChanged+=ExplorerTreeOnSelectedNodesCollectionChanged;
        }

//        void ExplorerTreeOnSelectedNodesCollectionChanged(object sender, NodeSelectionEventArgs nodeSelectionEventArgs)
//        {
//            if (nodeSelectionEventArgs.CurrentSelectedNodes.Count > 0)
//            {
//                var currentNodeSelection = nodeSelectionEventArgs.CurrentSelectedNodes[0];
//                if (currentNodeSelection!=null)
//                {
//                    var item = currentNodeSelection.Data as IDllListingModel;
//                    if (item!=null && item.IsSelected)
//                    {
//                        item.IsSelected = false;
//                    }
//                }
//            }
//
//        }

        public string GetHeaderText()
        {
            BindingExpression be = HeaderTextBlock.GetBindingExpression(TextBlock.TextProperty);
            if (be != null)
            {
                be.UpdateTarget();
            }
            return HeaderTextBlock.Text;
        }

        private void ExplorerTree_OnNodeExpansionChanging(object sender, CancellableNodeExpansionChangedEventArgs e)
        {
            if (DataContext != null)
            {
                var node = e.Node.Data as DllListingModel;
                if (node != null)
                {
                    node.IsExpanded = e.Node.IsExpanded;
                    node.ExpandingCommand.Execute(null);
                }
            }
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

        public IDllListingModel SelectItem(string itemName)
        {
            
            var xamDataTreeNode = GetItem(itemName);
            if (xamDataTreeNode != null)
            {
                xamDataTreeNode.IsSelected = true;
                ExplorerTree.ActiveNode = xamDataTreeNode;
            }
            return xamDataTreeNode == null ? null : xamDataTreeNode.Data as IDllListingModel;
        }

        public bool IsItemVisible(string itemName)
        {
            var xamDataTreeNode = GetItem(itemName);
            return xamDataTreeNode != null;
        }

        XamDataTreeNode GetItem(string itemName)
        {
            var xamDataTreeNodes = TreeUtils.Descendants(ExplorerTree.Nodes.ToArray());
            return xamDataTreeNodes.FirstOrDefault(node =>
            {
                var item = node.Data as IDllListingModel;
                if (item != null)
                {
                    if (item.Name.ToLowerInvariant().Contains(itemName.ToLowerInvariant()))
                    {
                        return true;
                    }
                }
                return false;
            });
        }

        public string GetAssemblyName()
        {
            BindingExpression be = AssemblyNameTextBox.GetBindingExpression(TextBox.TextProperty);
            if (be != null)
            {
                be.UpdateTarget();
            }
            return AssemblyNameTextBox.Text;
        }

        public void PerformSave()
        {
            SaveButton.Command.Execute(null);
        }

        public void SetAssemblyName(string assemblyName)
        {
            AssemblyNameTextBox.Text = assemblyName;
            BindingExpression be = AssemblyNameTextBox.GetBindingExpression(TextBlock.TextProperty);
            if (be != null)
            {
                be.UpdateSource();
            }
        }

        public IDllListingModel OpenItem(string itemNameToOpen)
        {
            var xamDataTreeNode = GetItem(itemNameToOpen);
            if (xamDataTreeNode != null)
            {
                xamDataTreeNode.IsExpanded = true;
            }
            return xamDataTreeNode == null ? null : xamDataTreeNode.Data as IDllListingModel;
        }

        public bool GetControlEnabled(string controlName)
        {
            switch(controlName)
            {
                case "Save":
                    return SaveButton.Command.CanExecute(null);
            }
            return false;
        }

        public void ExecuteRefresh()
        {
            RefreshButton.Command.Execute(null);
        }

        public void FilterItems()
        {
            var count = ExplorerTree.Nodes.Count;
        }

        void ExplorerTree_OnLoaded(object sender, RoutedEventArgs e)
        {
            var menuTree = sender as XamDataTree;
            if(menuTree != null)
            {
                var items = menuTree.ItemsSource;
            }
            selectNode(ExplorerTree.Nodes, "KEYTOSELECT");
        }
        void selectNode(XamDataTreeNodesCollection nodes, string nodeKey)
        {
            
        }
    }
}
