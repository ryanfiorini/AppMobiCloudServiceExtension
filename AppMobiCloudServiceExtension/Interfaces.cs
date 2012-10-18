using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;

namespace appMobi.AppMobiCloudServiceExtension
{
    /// <summary>
    /// Defines the events that are internally defined for communication with other subsytems.
    /// </summary>
    [ComVisible(true)]
    public interface IProjectEvents
    {
        /// <summary>
        /// Event raised just after the project file opened.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1713:EventsShouldNotHaveBeforeOrAfterPrefix")]
        event EventHandler<AfterProjectFileOpenedEventArgs> AfterProjectFileOpened;

        /// <summary>
        /// Event raised before the project file closed.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1713:EventsShouldNotHaveBeforeOrAfterPrefix")]
        event EventHandler<BeforeProjectFileClosedEventArgs> BeforeProjectFileClosed;
    }

    /// <summary>
    /// Defines the interface that will specify ehethrr the object is a project events listener.
    /// </summary>
    [ComVisible(true)]
    public interface IProjectEventsListener
    {

        /// <summary>
        /// Is the object a project events listener.
        /// </summary>
        /// <returns></returns>
        bool IsProjectEventsListener
        { get; set; }

    }

    /// <summary>
    /// Interface for manipulating build dependency
    /// </summary>
    /// <remarks>Normally this should be an internal interface but since it shouldbe available for the aggregator it must be made public.</remarks>
    [ComVisible(true)]
    [CLSCompliant(false)]
    public interface IBuildDependencyUpdate
    {
        /// <summary>
        /// Defines a container for storing BuildDependencies
        /// </summary>

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        IVsBuildDependency[] BuildDependencies
        {
            get;
        }

        /// <summary>
        /// Adds a BuildDependency to the container
        /// </summary>
        /// <param name="dependency">The dependency to add</param>
        void AddBuildDependency(IVsBuildDependency dependency);

        /// <summary>
        /// Removes the builddependency from teh container.
        /// </summary>
        /// <param name="dependency">The dependency to add</param>
        void RemoveBuildDependency(IVsBuildDependency dependency);

    }
}
