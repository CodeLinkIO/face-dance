using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// Interface for the component on a data visual that controls how the data visual shows ratings
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IDataVisual
    {
        /// <summary>
        /// Change the visual to show a given rating value.
        /// </summary>
        /// <param name="rating">This data's rating value from 0 to 1</param>
        void ShowRating(float rating);

        /// <summary>
        /// Reset the visual to show no rating
        /// </summary>
        void ClearRating();
    }
}
