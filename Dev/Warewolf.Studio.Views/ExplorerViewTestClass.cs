using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Data;
using Infragistics.Controls.Menus;
using Warewolf.Studio.ViewModels;

namespace Warewolf.Studio.Views
{
    public class ExplorerViewTestClass
    {
        private readonly ExplorerView _explorerView;

        public ExplorerViewTestClass(ExplorerView explorerView)
        {
            _explorerView = explorerView;
        }

        public IEnvironmentViewModel OpenEnvironmentNode(string nodeName)
        {
            var xamDataTreeNode = _explorerView.ExplorerTree.Nodes.FirstOrDefault(node =>
            {
                var explorerItem = node.Data as IEnvironmentViewModel;
                if (explorerItem != null)
                {
                    if (explorerItem.DisplayName.ToLowerInvariant().Contains(nodeName.ToLowerInvariant()))
                    {
                        return true;
                    }
                }
                return false;
            });
            if (xamDataTreeNode != null)
            {
                xamDataTreeNode.IsExpanded = true;
            }
            return xamDataTreeNode == null ? null : xamDataTreeNode.Data as IEnvironmentViewModel;
        }

        public List<IExplorerTreeItem> GetFoldersVisible()
        {
            var folderItems = _explorerView.ExplorerTree.Nodes[0].Nodes.Where(node =>
            {
                var explorerItem = node.Data as IExplorerTreeItem;
                if (explorerItem != null)
                {
                    if (explorerItem.ResourceType == ResourceType.Folder)
                    {
                        return true;
                    }
                }
                return false;
            }).Select(node => node.Data as IExplorerTreeItem);
            return folderItems.ToList();
        }

        public IExplorerTreeItem OpenFolderNode(string folderName)
        {
            var foundFolder = GetFolderXamDataTreeNode(folderName);
            if (foundFolder != null)
            {
                foundFolder.IsExpanded = true;
                _explorerView.ExplorerTree.ScrollNodeIntoView(foundFolder);
                var explorerItemViewModel = foundFolder.Data as IExplorerTreeItem;
                var explorerViewModelBase = _explorerView.DataContext as ExplorerViewModelBase;
                if (explorerViewModelBase != null)
                {
                    explorerViewModelBase.SelectedItem = explorerItemViewModel;
                }

                return explorerItemViewModel;
            }
            return null;
        }

        public int GetVisibleChildrenCount(string folderName)
        {
            var foundFolder = GetFolderXamDataTreeNode(folderName);
            if (foundFolder != null)
            {
                return foundFolder.Nodes[0].Manager.Nodes.Count;
            }
            return 0;
        }

        public void PerformFolderRename(string originalFolderName, string newFolderName)
        {
            var foundFolder = VerifyItemExists(originalFolderName).Data as IExplorerTreeItem;
            if (foundFolder != null)
            {
                foundFolder.RenameCommand.Execute(null);
                foundFolder.ResourceName = newFolderName;
            }
        }

        private XamDataTreeNode GetFolderXamDataTreeNode(string folderName)
        {
            var flattenTree = Descendants(_explorerView.ExplorerTree.Nodes[0]);
            var foundFolder = flattenTree.FirstOrDefault(node =>
            {
                var explorerItem = node.Data as IExplorerTreeItem;
                if (explorerItem != null)
                {
                    if (explorerItem.ResourceName != null && (explorerItem.ResourceName.ToLowerInvariant().Contains(folderName.ToLowerInvariant()) &&
                                                              explorerItem.ResourceType == ResourceType.Folder))
                    {
                        return true;
                    }
                }
                return false;
            });
            return foundFolder;
        }

        private IEnumerable<XamDataTreeNode> Descendants(XamDataTreeNode root)
        {
            var nodes = new Stack<XamDataTreeNode>(new[] { root });
            while (nodes.Any())
            {
                XamDataTreeNode node = nodes.Pop();
                yield return node;
                if(node != null)
                {
                    foreach (var n in node.Nodes)
                    {
                        if (n != null)
                        {
                            nodes.Push(n);
                        }
                    }
                }
            }
        }

        public void PerformFolderAdd(string folder, string server)
        {
            var node = _explorerView.ExplorerTree.Nodes.FirstOrDefault(a => ((IExplorerTreeItem)a.Data).ResourceName.Contains(server));

            if (node != null)
            {
                var env = (node.Data as IExplorerTreeItem);
                if (env != null)
                {
                    env.CreateFolderCommand.Execute(null);
                    var explorerItemViewModel = env.Children.FirstOrDefault(a => a.IsRenaming);
                    if (explorerItemViewModel != null)
                    {
                        explorerItemViewModel.ResourceName = folder;
                        explorerItemViewModel.IsRenaming = false;

                    }
                    else
                        throw new Exception("Folder was not found after adding");

                }

            }
            else
                throw new Exception("Server Not found in explorer");
        }

        public XamDataTreeNode VerifyItemExists(string path)
        {
            if(!path.Contains("/"))
            {

                var childnode = _explorerView.ExplorerTree.Nodes.FirstOrDefault(a => ((IExplorerTreeItem)a.Data).ResourceName.Contains(path));
            
                if (childnode == null)
                    throw new Exception("Folder or environment not found. Name" + path);
                return childnode;
   
            }
            else
            {
                var toSearch = path.Substring(0, path.IndexOf("/", StringComparison.Ordinal));
                var childnode = _explorerView.ExplorerTree.Nodes.FirstOrDefault(a => ((IExplorerTreeItem)a.Data).ResourceName.Contains(toSearch));
                if (path.Length > 1 + path.IndexOf("/", StringComparison.Ordinal))
                {
                   return VerifyItemExists(path.Substring(1 + path.IndexOf("/", StringComparison.Ordinal)),  childnode);
                }
                throw new Exception("Invalid path");
            }
        }

        XamDataTreeNode VerifyItemExists(string path, XamDataTreeNode node)
        {
            if(!path.Contains("/"))
            {

                  return GetNodeWithName(path,node);
                   
                
            }
            var toSearch = path.Substring(0, path.IndexOf("/", StringComparison.Ordinal));
            var childnode = GetNodeWithName(toSearch,node);
            if(path.Length > 1 + path.IndexOf("/", StringComparison.Ordinal))
            {
                return  VerifyItemExists(path.Substring(1 + path.IndexOf("/", StringComparison.Ordinal)), childnode);
            }
            throw  new Exception("Invalid path");
        }

        XamDataTreeNode GetNodeWithName(string path,XamDataTreeNode node)
        {
            var found = node.Nodes.FirstOrDefault(a => ((IExplorerTreeItem)a.Data).ResourceName.Equals(path));
            if (found == null)
            {
                throw new Exception("Folder or environment not found. Name" + path);
            }
            return found;
        }

        public void DeletePath(string path)
        {
            var node = VerifyItemExists(path);
            if(node!= null)
            {
                ((IExplorerTreeItem)node.Data).DeleteCommand.Execute(null);
            }
        }

        internal void PerformFolderAdd(string path)
        {
            if(path.Contains("/"))
            {
                var node = VerifyItemExists(path.Substring(0, path.LastIndexOf("/", StringComparison.Ordinal)));
                var env = node.Data as IExplorerTreeItem;
                if (env != null)
                {
                   
                    env.CreateFolderCommand.Execute(null);
                    var explorerItemViewModel = env.Children.FirstOrDefault(a => a.IsRenaming);
                    if (explorerItemViewModel != null)
                    {
                        explorerItemViewModel.ResourceName = path.Substring(1+ path.LastIndexOf("/", StringComparison.Ordinal));
                        explorerItemViewModel.IsRenaming = false;

                    }
                    else
                        throw new Exception("Folder was not found after adding");

                }
                else
                {
                    throw new Exception("Path requires server and sub folder");
                }
            }
        }

        public void PerformItemAdd(string path)
        {
            if(path.Contains("/"))
            {
                var node = VerifyItemExists(path.Substring(0, path.LastIndexOf("/", StringComparison.Ordinal)));
                if(node == null)
                    throw new Exception("Invalid path");

                var item = (node.Data as IExplorerTreeItem);
                if(item != null)
                {
                    item.AddChild(new ExplorerItemViewModel(item.Server, item) { ResourceName = path.Substring(1 + path.LastIndexOf("/", StringComparison.Ordinal)) });
                }
            }
            else
            {
                var explorerViewModelBase = _explorerView.DataContext as ExplorerViewModelBase;
                if (explorerViewModelBase != null)
                {
                    var item = explorerViewModelBase.SelectedItem;
                    item.AddChild(new ExplorerItemViewModel(item.Server, item) { ResourceName = path});
                }
            }
             
        }



        public void AddChildren(int resourceNumber, string path, string type,string name="Resource ")
        {
            var resourceType = (ResourceType)Enum.Parse(typeof(ResourceType), type);
            if (path.Contains("/"))
            {
                var node = VerifyItemExists(path);
                var item = (node.Data as IExplorerTreeItem);
              
                for(int i = 0; i < resourceNumber; i++)
                {
                    if(item != null)
                    {
                        item.AddChild(new ExplorerItemViewModel(item.Server, item) { ResourceName = name + i, ResourceType = resourceType });
                    }
                }
            }
            else
            {
                var node = VerifyItemExists(path);
                var item = (node.Data as IExplorerTreeItem);

                for (int i = 0; i < resourceNumber; i++)
                {
                    if(item != null)
                    {
                        item.AddChild(new ExplorerItemViewModel(item.Server, null) { ResourceName = name + i, ResourceType = resourceType });
                    }
                }
            }
        }

        public int GetFoldersResourcesVisible(string path)
        {
            var node = VerifyItemExists(path);
            return node.Nodes.Select(child => (child.Data as IExplorerTreeItem)).Count(childitem => childitem != null && childitem.ResourceType == ResourceType.WorkflowService);
        }

        public void ShowVersionHistory(string path)
        {
            var node = VerifyItemExists(path);
            var explorerItemViewModel = node.Data as IExplorerTreeItem;
            if(explorerItemViewModel != null)
            {
                explorerItemViewModel.ShowVersionHistory.Execute(null);
            }
        }

        public ICollection<IExplorerTreeItem> CreateChildNodes(int count, string path)
        {

      
                var node = VerifyItemExists(path);
                var item = (node.Data as IExplorerTreeItem);
                var items = new List<IExplorerTreeItem>();
                const string Name = "Resource ";
                for (int i = 0; i < count; i++)
                {
                    if (item != null)
                    {
                        items.Add(new ExplorerItemViewModel(item.Server, item) { ResourceName = Name + i, ResourceType = ResourceType.Version });
                    }
                }
                return items;
          
        }

        public void PerformVersionRollback(string versionPath)
        {
            var node = VerifyItemExists(versionPath.Substring(0,versionPath.LastIndexOf("/", StringComparison.Ordinal)));

            var explorerItemViewModel = node.Data as IExplorerTreeItem;
            if(explorerItemViewModel != null)
            {
                var child = explorerItemViewModel.Children.FirstOrDefault(a => a.ResourceName.Contains(versionPath.Substring(1+versionPath.LastIndexOf("/", StringComparison.Ordinal))));
                if(child != null)
                {
                    child.RollbackCommand.Execute(null);
                }
            }
        }

        public void PerformVersionDelete(string versionPath)
        {
            var node = VerifyItemExists(versionPath.Substring(0, versionPath.LastIndexOf("/", StringComparison.Ordinal)));
            var explorerItemViewModel = node.Data as IExplorerItemViewModel;
            if(explorerItemViewModel != null)
            {
                explorerItemViewModel= explorerItemViewModel.Children.FirstOrDefault(a => a.ResourceName.Contains(versionPath.Substring(1 + versionPath.LastIndexOf("/", StringComparison.Ordinal))));

                if (explorerItemViewModel != null)
                {
                    explorerItemViewModel.DeleteVersionCommand.Execute(null);
                }
            }
        }

        public void VerifyContextMenu(string option, string visibility, string path)
        {

        }

        public void Reset()
        {
            var item = (_explorerView.DataContext as IExplorerViewModel);
            if(item != null)
            {
                item.RefreshCommand.Execute(null);
            }
        }

        public void PerformSearch(string filter)
        {
            _explorerView.SearchTextBox.Text = filter;
            BindingExpression be = _explorerView.SearchTextBox.GetBindingExpression(TextBox.TextProperty);
            if (be != null)
            {
                be.UpdateSource();
            }
        }

        public void VerifyItemDoesNotExist(string path)
        {
            try
            {
                var node = VerifyItemExists(path);
                if (node != null)
                {
                    throw new Exception("Item found when should not exist");
                }
            }
            catch(Exception)
            {
                //Item not found might throw and exception
            }
            
        }

        public void PerformActionOnContextMenu(string menuAction, string itemName,string path)
        {
            var item = VerifyItemExists(itemName);
            if(item != null)
            {
                switch(menuAction)
                {
                    case "Create Folder":
                        PerformFolderAdd(path+"/"+itemName);
                        break;
                    case "Rename":
                        PerformFolderRename(path,itemName);
                        break;
                }
            }
        }
    }
}