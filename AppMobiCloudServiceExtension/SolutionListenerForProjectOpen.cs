using System;
using System.Diagnostics;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using IServiceProvider = System.IServiceProvider;

namespace appMobi.AppMobiCloudServiceExtension
{
    [CLSCompliant(false)]
    public class SolutionListenerForProjectOpen : SolutionListener
    {
        public SolutionListenerForProjectOpen(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public override int OnAfterOpenProject(IVsHierarchy hierarchy, int added)
        {
            // If this is a new project and our project. We use here that it is only our project that will implemnet the "internal"  IBuildDependencyOnProjectContainer.
            if (added != 0 && hierarchy is IBuildDependencyUpdate)
            {
                IVsUIHierarchy uiHierarchy = hierarchy as IVsUIHierarchy;
                Debug.Assert(uiHierarchy != null, "The ProjectNode should implement IVsUIHierarchy");
                // Expand and select project node
            }
            return VSConstants.S_OK;
        }
    }
}
