using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;
using Microsoft.VisualStudio.TextManager.Interop;

namespace appMobi.AppMobiCloudServiceExtension
{
    internal class NativeMethods
    {
        [DllImport("Ole32.dll", EntryPoint = "CreateStreamOnHGlobal")]
        internal static extern void CreateStreamOnHGlobal(IntPtr hGlobal, [MarshalAs(UnmanagedType.Bool)] bool deleteOnRelease, [Out] out Microsoft.VisualStudio.OLE.Interop.IStream stream);
    }

    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the information needed to show this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    // This attribute registers a tool window exposed by this package.
    [ProvideToolWindow(typeof(MyToolWindow),Style = Microsoft.VisualStudio.Shell.VsDockStyle.Tabbed, Window = "3ae79031-e1bc-11d0-8f78-00a0c9110057")]
    [ProvideAutoLoad(VSConstants.UICONTEXT.SolutionExists_string)]
    [Guid(GuidList.guidAppMobiCloudServiceExtensionPkgString)]
    public sealed class AppMobiCloudServiceExtensionPackage : Package
    {
        public MenuCommand toolMenuItem1;
        private int currentMCCommand; // The currently selected menu controller command

        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public AppMobiCloudServiceExtensionPackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        /// <summary>
        /// This function is called when the user clicks the menu item that shows the 
        /// tool window. See the Initialize method to see how the menu item is associated to 
        /// this function using the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void ShowToolWindow(object sender, EventArgs e)
        {
            // Get the instance number 0 of this tool window. This window is single instance so this instance
            // is actually the only one.
            // The last flag is set to true so that if the tool window does not exists it will be created.
            ToolWindowPane window = this.FindToolWindow(typeof(MyToolWindow), 0, true);
            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException(Resources.CanNotCreateWindow);
            }
            IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }


        #region properties
        /// <summary>
        /// Add your listener to this list. They should be added in the overridden Initialize befaore calling the base.
        /// </summary>
        private List<SolutionListener> solutionListeners = new List<SolutionListener>();
        protected internal IList<SolutionListener> SolutionListeners
        {
            get
            {
                return this.solutionListeners;
            }
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////
        // Overridden Package Implementation
        #region Package Members


        SolutionEventsListener listener = null;
        IVsUIShellDocumentWindowMgr winmgr = null;
        IStream comStream;

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Debug.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));


            this.solutionListeners.Add(new SolutionListenerForProjectOpen(this));
            this.solutionListeners.Add(new SolutionListenerForProjectEvents(this));

            foreach (SolutionListener solutionListener in this.solutionListeners)
            {
                solutionListener.Init();
            }

            listener = new SolutionEventsListener();

            winmgr = Package.GetGlobalService(typeof(IVsUIShellDocumentWindowMgr)) as IVsUIShellDocumentWindowMgr;

            listener.OnQueryUnloadProject += () =>
            {
                comStream = SaveDocumentWindowPositions(winmgr);
            };
            listener.OnAfterOpenProject += () =>
            {
                int hr = winmgr.ReopenDocumentWindows(comStream);
                comStream = null;
            };

            base.Initialize();

            IVsTextImageUtilities svt = GetService(typeof(IVsTextImageUtilities)) as IVsTextImageUtilities;
            if (null != svt)
            {
                svt.SaveTextImageToFile("newfile.c#",
            }


            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ( null != mcs )
            {
                // Create the command for the menu item.
                CommandID menuCommandID = new CommandID(GuidList.guidAppMobiCloudServiceExtensionCmdSet, (int)PkgCmdIDList.cmdidAppMobiCloudServiceCommand);
                //MenuCommand menuItem = new MenuCommand(MenuItemCallback, menuCommandID );
                //mcs.AddCommand( menuItem );
                toolMenuItem1 = new MenuCommand(MenuItemCallback, menuCommandID);
                mcs.AddCommand(toolMenuItem1);      
                
                // Create the command for the tool window
                CommandID toolwndCommandID = new CommandID(GuidList.guidAppMobiCloudServiceExtensionCmdSet, (int)PkgCmdIDList.cmdidAppMobiCloudServiceTool);
                MenuCommand menuToolWin = new MenuCommand(ShowToolWindow, toolwndCommandID);
                mcs.AddCommand( menuToolWin );

                for (int i = PkgCmdIDList.cmdidMCItem1; i <= PkgCmdIDList.cmdidMCItem3; i++)
                {
                    CommandID cmdID = new CommandID(GuidList.guidAppMobiCloudServiceExtensionCmdSet, i);
                    OleMenuCommand mc = new OleMenuCommand(new EventHandler(OnMCItemClicked), cmdID);
                    mc.BeforeQueryStatus += new EventHandler(OnMCItemQueryStatus);
                    mcs.AddCommand(mc);
                    // The first item is, by default, checked.
                    if (PkgCmdIDList.cmdidMCItem1 == i)
                    {
                        mc.Checked = true;
                        this.currentMCCommand = i;
                    }
                }
            
            }
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            // Unadvise solution listeners.
            try
            {
                if (disposing)
                {
                    foreach (SolutionListener solutionListener in this.solutionListeners)
                    {
                        solutionListener.Dispose();
                    }

                    // Dispose the UIThread singleton.
                    UIThread.Instance.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            // Show a Message Box to prove we were here
            IVsUIShell uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
            Guid clsid = Guid.Empty;
            int result;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
                       0,
                       ref clsid,
                       "AppMobiCloudServiceExtension",
                       string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.ToString()),
                       string.Empty,
                       0,
                       OLEMSGBUTTON.OLEMSGBUTTON_OK,
                       OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
                       OLEMSGICON.OLEMSGICON_INFO,
                       0,        // false
                       out result));
        }

        private void OnMCItemQueryStatus(object sender, EventArgs e)
        {
            OleMenuCommand mc = sender as OleMenuCommand;
            if (null != mc)
            {
                mc.Checked = (mc.CommandID.ID == this.currentMCCommand);
            }
        }

        private void OnMCItemClicked(object sender, EventArgs e)
        {
            OleMenuCommand mc = sender as OleMenuCommand;
            if (null != mc)
            {
                string selection;
                switch (mc.CommandID.ID)
                {
                    case PkgCmdIDList.cmdidMCItem1:
                        selection = "Menu controller Item 1";
                        break;

                    case PkgCmdIDList.cmdidMCItem2:
                        selection = "Menu controller Item 2";
                        break;

                    case PkgCmdIDList.cmdidMCItem3:
                        selection = "Menu controller Item 3";
                        break;

                    default:
                        selection = "Unknown command";
                        break;
                }
                this.currentMCCommand = mc.CommandID.ID;

                IVsUIShell uiShell =
                  (IVsUIShell)GetService(typeof(SVsUIShell));
                Guid clsid = Guid.Empty;
                int result;
                uiShell.ShowMessageBox(
                           0,
                           ref clsid,
                           "Test Tool Window Toolbar Package",
                           string.Format(CultureInfo.CurrentCulture,
                                         "You selected {0}", selection),
                           string.Empty,
                           0,
                           OLEMSGBUTTON.OLEMSGBUTTON_OK,
                           OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
                           OLEMSGICON.OLEMSGICON_INFO,
                           0,
                           out result);
            }
        }

        private IStream SaveDocumentWindowPositions(IVsUIShellDocumentWindowMgr windowsMgr)
        {
            if (windowsMgr == null)
            {
                Debug.Assert(false, "IVsUIShellDocumentWindowMgr", String.Empty, 0);
                return null;
            }
            IStream stream;
            NativeMethods.CreateStreamOnHGlobal(IntPtr.Zero, true, out stream);
            if (stream == null)
            {
                Debug.Assert(false, "CreateStreamOnHGlobal", String.Empty, 0);
                return null;
            }
            int hr = windowsMgr.SaveDocumentWindowPositions(0, stream);
            if (hr != VSConstants.S_OK)
            {
                Debug.Assert(false, "SaveDocumentWindowPositions", String.Empty, hr);
                return null;
            }

            // Move to the beginning of the stream 
            // In preparation for reading
            LARGE_INTEGER l = new LARGE_INTEGER();
            ULARGE_INTEGER[] ul = new ULARGE_INTEGER[1];
            ul[0] = new ULARGE_INTEGER();
            l.QuadPart = 0;
            //Seek to the beginning of the stream
            stream.Seek(l, 0, ul);
            return stream;
        }
    }
}
