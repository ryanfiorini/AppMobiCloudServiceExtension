using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell.Interop;
using System.ComponentModel.Design;
using System.Security.Permissions;

namespace appMobi.AppMobiCloudServiceExtension
{
    public sealed class ToolWindowEvents : IVsWindowFrameNotify3
    {
        private AppMobiCloudServiceExtensionPackage package;
        public ToolWindowEvents(AppMobiCloudServiceExtensionPackage apackage)
        {
            package = apackage;
        }
        
        public int OnClose(ref uint pgrfSaveOptions)
        {
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }

        public int OnDockableChange(int fDockable, int x, int y, int w, int h)
        {
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }

        public int OnMove(int x, int y, int w, int h)
        {
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        public int OnShow(int fShow)
        {
            package.toolMenuItem1.Visible
                = ((__FRAMESHOW)fShow
                != __FRAMESHOW.FRAMESHOW_WinHidden);
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }

        public int OnSize(int x, int y, int w, int h)
        {
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }
    }
}
