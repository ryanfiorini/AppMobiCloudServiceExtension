using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appMobi.AppMobiCloudServiceExtension
{
    public class AfterProjectFileOpenedEventArgs : EventArgs
    {
        #region fields
        private bool added;
        #endregion

        #region properties
        /// <summary>
        /// True if the project is added to the solution after the solution is opened. false if the project is added to the solution while the solution is being opened.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal bool Added
        {
            get { return this.added; }
        }
        #endregion

        #region ctor
        internal AfterProjectFileOpenedEventArgs(bool added)
        {
            this.added = added;
        }
        #endregion
    }

    public class BeforeProjectFileClosedEventArgs : EventArgs
    {
        #region fields
        private bool removed;
        #endregion

        #region properties
        /// <summary>
        /// true if the project was removed from the solution before the solution was closed. false if the project was removed from the solution while the solution was being closed.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal bool Removed
        {
            get { return this.removed; }
        }
        #endregion

        #region ctor
        internal BeforeProjectFileClosedEventArgs(bool removed)
        {
            this.removed = removed;
        }
        #endregion
    }

}
