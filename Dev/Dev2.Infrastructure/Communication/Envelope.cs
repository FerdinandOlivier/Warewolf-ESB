
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

namespace Dev2.Communication
{
    /// <summary>
    /// Used to describe serialized content.
    /// </summary>
    public class Envelope
    {
        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets the content - typically a JSON string.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the order unique identifier.
        /// </summary>
        /// <value>
        /// The order unique identifier.
        /// </value>
        public int PartID { get; set; }
    }
}
