using System;
using UnityEngine;

namespace UnityEditor.MARS.Simulation
{
    public partial class MARSEnvironmentManager
    {
        /// <summary>
        /// Try to frame the simulation view on the current environment, if possible
        /// </summary>
        /// <param name="simView">The simulation view which should be updated</param>
        /// <param name="rotateView">Whether to rotate the view as well as translate it</param>
        /// <param name="instant">Whether to update the view instantly or with an animated transition</param>
        /// <returns>The rotation of the simulation view camera once the view is framed</returns>
        [Obsolete("The rotateView parameter of TryFrameSimViewOnEnvironment is obsolete; Use the overload with two parameters")]
        public Quaternion TryFrameSimViewOnEnvironment(ISimulationView simView, bool rotateView, bool instant)
        {
            return TryFrameSimViewOnEnvironment(simView, instant);
        }
    }
}

