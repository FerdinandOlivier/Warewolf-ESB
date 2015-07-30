
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
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Dev2.Common.Interfaces.Data;
using Warewolf.Studio.Core;

namespace Dev2.AppResources.Converters
{
    public class ExplorerItemModelToIconConverter : IMultiValueConverter
    {
        #region Implementation of IMultiValueConverter

        /// <summary>
        /// Converts source values to a value for the binding target. The data binding engine calls this method when it propagates the values from source bindings to the binding target.
        /// </summary>
        /// <returns>
        /// A converted value.If the method returns null, the valid null value is used.A return value of <see cref="T:System.Windows.DependencyProperty"/>.<see cref="F:System.Windows.DependencyProperty.UnsetValue"/> indicates that the converter did not produce a value, and that the binding will use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue"/> if it is available, or else will use the default value.A return value of <see cref="T:System.Windows.Data.Binding"/>.<see cref="F:System.Windows.Data.Binding.DoNothing"/> indicates that the binding does not transfer the value or use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue"/> or the default value.
        /// </returns>
        /// <param name="values">The array of values that the source bindings in the <see cref="T:System.Windows.Data.MultiBinding"/> produces. The value <see cref="F:System.Windows.DependencyProperty.UnsetValue"/> indicates that the source binding has no value to provide for conversion.</param><param name="targetType">The type of the binding target property.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            const string pathname = "/Warewolf.Studio.Themes.Luna;component/Images.xaml";
            ResourceDictionary dict = Application.LoadComponent(new Uri(pathname, UriKind.Relative)) as ResourceDictionary;
            ResourceType resourceType = values[0] is ResourceType ? (ResourceType)values[0] : ResourceType.Unknown;
            switch(resourceType)
            {
                case ResourceType.WorkflowService:
                    return dict[CustomMenuIcons.WorkflowService] as DrawingImage;
                case ResourceType.DbService:
                    return dict[CustomMenuIcons.DbService] as DrawingImage;
                case ResourceType.PluginService:
                    return dict[CustomMenuIcons.PluginService] as DrawingImage;
                case ResourceType.WebService:
                    return dict[CustomMenuIcons.WebService] as DrawingImage;
                case ResourceType.DbSource:
                    return dict[CustomMenuIcons.DbSource] as DrawingImage;
                case ResourceType.PluginSource:
                    return dict[CustomMenuIcons.PluginSource] as DrawingImage;
                case ResourceType.WebSource:
                    return dict[CustomMenuIcons.WebSource] as DrawingImage;
                case ResourceType.EmailSource:
                    return dict[CustomMenuIcons.EmailSource] as DrawingImage;
                case ResourceType.ServerSource:
                    return dict[CustomMenuIcons.ServerSource] as DrawingImage;
                case ResourceType.Server:
                    return Application.Current.Resources["System-Logo"];
                case ResourceType.Version:
                case ResourceType.Message:
                    return null;
                case ResourceType.Folder:
                    return dict[CustomMenuIcons.Folder] as DrawingImage;
                case ResourceType.OauthSource :
                    return Application.Current.Resources["DropBoxLogo"];
                case ResourceType.SharepointServerSource:
                    return Application.Current.Resources["AddSharepointLogo"];
                default:
                    return dict[CustomMenuIcons.WorkflowService] as DrawingImage;
            }
        }

        /// <summary>
        /// Converts a binding target value to the source binding values.
        /// </summary>
        /// <returns>
        /// An array of values that have been converted from the target value back to the source values.
        /// </returns>
        /// <param name="value">The value that the binding target produces.</param><param name="targetTypes">The array of types to convert to. The array length indicates the number and types of values that are suggested for the method to return.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { };
        }

        #endregion
    }
}
