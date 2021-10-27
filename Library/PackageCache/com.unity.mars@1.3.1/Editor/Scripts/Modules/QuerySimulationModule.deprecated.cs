using System;

namespace UnityEditor.MARS.Simulation
{
    public partial class QuerySimulationModule
    {
        /// <summary>
        /// (Obsolete) Simulated data available
        /// </summary>
        [Obsolete("simulatedDataAvailable has been deprecated", true)]
        public bool simulatedDataAvailable => false;

        /// <summary>
        /// (Obsolete) Stops query simulation that runs frame-to-frame (Obsolete)
        /// </summary>
        [Obsolete("StopTemporalSimulation() has been deprecated because it does not fully reset the state " +
            "of simulation. To stop temporal simulation and reset state, use RestartSimulationIfNeeded().", false)]
        public void StopTemporalSimulation() { }
    }
}
