using Unity.MARS.Data.Reasoning;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Interface that all Reasoning APIs implement to communicate with the backend.
    /// </summary>
    public interface IReasoningAPI : IProvidesTraits
    {
        float processSceneInterval { get; }

        /// <summary>
        /// One-time setup for a Reasoning API which allows usage of Functionality Injection methods
        /// </summary>
        void Setup();

        /// <summary>
        /// One-time tear down for a Reasoning API
        /// </summary>
        void TearDown();

        /// <summary>
        /// In here, a Reasoning API should do large-scale processing of a scene to make new data
        /// </summary>
        void ProcessScene();

        /// <summary>
        /// In here, a Reasoning API should update the properties of any bits of data it created or altered
        /// </summary>
        void UpdateData();
    }

    public static class IReasoningAPIMethods
    {
        public static void ChangeProcessSceneInterval(this IReasoningAPI api)
        {
            ReasoningModule.instance.ChangeReasoningAPIInterval(api);
        }
    }
}
