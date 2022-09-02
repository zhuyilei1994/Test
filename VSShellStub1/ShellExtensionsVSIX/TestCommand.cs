//------------------------------------------------------------------------------
// <copyright file="TestCommand.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System.Windows.Controls;

namespace ShellExtensionsVSIX
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class TestCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("a4a65c8d-7d71-4e6a-826c-7e5c544d8e4f");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private TestCommand(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static TestCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {
            Instance = new TestCommand(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            try
            {
                var toolWindowPersistenceGuid = Guid.NewGuid();
                IVsWindowFrame windowFrame;
                IVsWindowFrame windowFrame2;
                var position = new int[1];
                ThreadHelper.ThrowIfNotOnUIThread();
                var uiShell = (IVsUIShell)Package.GetGlobalService(typeof(SVsUIShell));
                var guidNull = Guid.Empty;
                var result = uiShell.CreateToolWindow((uint)__VSCREATETOOLWIN.CTW_fMultiInstance,
                    (uint)12, new TextBlock() { Text = "test" }, ref guidNull, ref toolWindowPersistenceGuid,
                    ref guidNull, null, "123", position, out windowFrame);

                var uu = Guid.NewGuid();
                uiShell.FindToolWindow((uint)__VSFINDTOOLWIN.FTW_fFrameOnly, ref toolWindowPersistenceGuid, out windowFrame2);
                var listener = new ToolWindowListener(12, windowFrame);
                ErrorHandler.ThrowOnFailure(result);
                windowFrame.SetProperty((int)__VSFPROPID.VSFPROPID_FrameMode, VSFRAMEMODE.VSFM_MdiChild);
                windowFrame.Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.StackTrace);
                Console.WriteLine(exception);
                throw;
            }
        }
    }
    public class ToolWindowListener : IDisposable, IVsWindowFrameNotify, IVsWindowFrameNotify3
    {
        private uint _cookie;

        public ToolWindowListener(int windowID,
            IVsWindowFrame window
        )
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (window == null)
                throw new ArgumentNullException(nameof(window));
            WindowID = windowID;
            WindowPane = window;
            SubscribeForEvents();
        }

        public int WindowID { get; }

        public IVsWindowFrame WindowPane { get; private set; }

        public void Dispose()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
        }

        public int OnShow(int fShow)
        {
            return VSConstants.S_OK;
        }

        public int OnMove()
        {
            return 0;
        }

        public int OnSize()
        {
            return 0;
        }

        public int OnDockableChange(int fDockable)
        {
            return 0;
        }

        public int OnMove(int x, int y, int w, int h)
        {
            return 0;
        }

        public int OnSize(int x, int y, int w, int h)
        {
            return 0;
        }

        public int OnDockableChange(int fDockable, int x, int y, int w, int h)
        {
            return 0;
        }

        public int OnClose(ref uint pgrfSaveOptions)
        {
            if (MessageBox.Show("close?", "", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return VSConstants.E_ABORT;
            }
            else
            {
                return VSConstants.S_OK;
            }
        }


        private void UnsubscribeForEvents()
        {
            if (WindowPane == null || _cookie == 0U)
                return;

            ThreadHelper.ThrowIfNotOnUIThread();
            // ReSharper disable once SuspiciousTypeConversion.Global
            var frame = WindowPane as IVsWindowFrame2;
            if (frame == null)
                return;
            frame.Unadvise(_cookie);
            _cookie = 0U;
        }

        private void SubscribeForEvents()
        {
            if (WindowPane == null)
                throw new InvalidOperationException();

            ThreadHelper.ThrowIfNotOnUIThread();
            // ReSharper disable once SuspiciousTypeConversion.Global
            var frame = WindowPane as IVsWindowFrame2;
            if (frame == null)
                throw new InvalidOperationException();
            if (_cookie != 0U)
                throw new InvalidOperationException();
            ErrorHandler.ThrowOnFailure(frame.Advise(this, out _cookie));
        }

        private void OnClose()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            UnsubscribeForEvents();
        }
    }
}
