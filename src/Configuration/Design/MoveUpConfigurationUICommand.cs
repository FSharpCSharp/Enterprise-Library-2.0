//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Core
//===============================================================================
// Copyright � Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Configuration.Design.Properties;
using System.Windows.Forms;

namespace Microsoft.Practices.EnterpriseLibrary.Configuration.Design
{
	/// <summary>
	/// A command used to invoke the <see cref="MoveNodeBeforeCommand"/>.
	/// </summary>
	public class MoveUpConfigurationUICommand : ConfigurationUICommand
	{
		/// <summary>
		/// Initialize a new instance of the <see cref="MoveUpConfigurationUICommand"/> with an <see cref="IServiceProvider"/>.
		/// </summary>
		/// <param name="serviceProvider">The a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
		public MoveUpConfigurationUICommand(IServiceProvider serviceProvider)
			: base(serviceProvider,
				Resources.MoveUpMenuItemText,
				Resources.MoveUpStatusText,
				CommandState.Enabled,
				new MoveNodeBeforeCommand(serviceProvider),
				Shortcut.None,
				InsertionPoint.Action,
				null)
		{

		}

		/// <summary>
		/// Gets the command state of the node.
		/// </summary>
		/// <param name="node">The node used to get the command state.</param>
		/// <returns>One of the <see cref="CommandState"/> values.</returns>
		/// <remarks>
		/// If the node is the first node in the list, the command state will be <see cref="CommandState.Disabled"/>.
		/// </remarks>
		public override CommandState GetCommandState(ConfigurationNode node)
		{
			if (null == node) throw new ArgumentNullException("node");

			return node.PreviousSibling != null ? CommandState.Enabled : CommandState.Disabled;
		}
	}
}
