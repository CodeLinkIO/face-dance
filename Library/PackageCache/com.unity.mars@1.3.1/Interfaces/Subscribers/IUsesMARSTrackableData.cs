using System.Collections.Generic;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Provides access to raw data of the given type
    /// </summary>
    /// <typeparam name="T">The type of data</typeparam>
    public interface IUsesMARSTrackableData<T> where T: IMRTrackable
    {
    }

    public delegate void AddDataByIdDelegate<T>(int dataId, T value);
    public delegate int RemoveTrackableDataDelegate<T>(T value);
    public delegate T GetIdValueDelegate<T>(int dataId);
    public delegate ICollection<KeyValuePair<int, T>> GetCollectionDelegate<T>();
    public delegate List<KeyValuePair<int, T>> RegisterProcessingJobDelegate<T>(ProcessingJobType jobType);
    public delegate int UnregisterProcessingJobDelegate<T>(ProcessingJobType jobType);

    public static class IUsesMARSTrackableDataMethods<T>
    {
        public static AddDataDelegate<T> AddOrUpdateData { internal get; set; }
        public static AddDataByIdDelegate<T> AddDataById { internal get; set; }
        public static RemoveTrackableDataDelegate<T> RemoveData { internal get; set; }
        public static GetIdValueDelegate<T> GetIdValue { internal get; set; }
        public static GetCollectionDelegate<T> GetCollection { internal get; set; }
        public static RegisterProcessingJobDelegate<T> RegisterProcessingJob { internal get; set; }
        public static UnregisterProcessingJobDelegate<T> UnregisterProcessingJob { internal get; set; }
    }

    public static class IUsesMARSTrackableDataGenericMethods
    {
        public static int AddOrUpdateData<T>(this IUsesMARSTrackableData<T> obj, T value) where T: IMRTrackable
        {
            return IUsesMARSTrackableDataMethods<T>.AddOrUpdateData(value);
        }

        public static void AddData<T>(this IUsesMARSTrackableData<T> obj, int dataId, T value) where T: IMRTrackable
        {
            IUsesMARSTrackableDataMethods<T>.AddDataById(dataId, value);
        }

        public static int RemoveData<T>(this IUsesMARSTrackableData<T> obj, T value) where T: IMRTrackable
        {
            return IUsesMARSTrackableDataMethods<T>.RemoveData(value);
        }

        public static T GetIdValue<T>(this IUsesMARSTrackableData<T> obj, int dataId) where T: IMRTrackable
        {
            return IUsesMARSTrackableDataMethods<T>.GetIdValue(dataId);
        }

        public static ICollection<KeyValuePair<int, T>> GetCollection<T>(this IUsesMARSTrackableData<T> obj)
            where T: IMRTrackable
        {
            return IUsesMARSTrackableDataMethods<T>.GetCollection();
        }

        public static List<KeyValuePair<int, T>> RegisterProcessingJob<T>(this IUsesMARSTrackableData<T> obj, ProcessingJobType jobType)
            where T: IMRTrackable
        {
            return IUsesMARSTrackableDataMethods<T>.RegisterProcessingJob(jobType);
        }

        public static int UnregisterProcessingJob<T>(this IUsesMARSTrackableData<T> obj, ProcessingJobType jobType)
            where T: IMRTrackable
        {
            return IUsesMARSTrackableDataMethods<T>.UnregisterProcessingJob(jobType);
        }
    }
}
