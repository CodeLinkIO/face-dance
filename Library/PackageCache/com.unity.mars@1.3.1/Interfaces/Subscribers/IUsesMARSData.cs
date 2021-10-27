using System.Collections.Generic;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Provides access to generic MARS data of the given type
    /// </summary>
    /// <typeparam name="T">The type of data</typeparam>
    public interface IUsesMARSData<T> { }
    
    public delegate int AddDataDelegate<T>(T value);
    public delegate bool UpdateDataDelegate<T>(int dataId, T value);
    public delegate bool RemoveDataDelegate<T>(int dataId);

    public static class IUsesMARSDataMethods<T>
    {
        public static AddDataDelegate<T> AddData { get; set; }
        public static UpdateDataDelegate<T> UpdateData { get; set; }
        public static RemoveDataDelegate<T> RemoveData { get; set; }
        public static GetIdValueDelegate<T> GetIdValue { get; set; }
        public static GetCollectionDelegate<T> GetCollection { get; set; }
    }

    public static class IUsesMARSDataGenericMethods
    {
        public static int AddData<T>(this IUsesMARSData<T> obj, T value)
        {
            return IUsesMARSDataMethods<T>.AddData(value);
        }

        public static bool UpdateData<T>(this IUsesMARSData<T> obj, int dataId, T value)
        {
            return IUsesMARSDataMethods<T>.UpdateData(dataId, value);
        }

        public static bool RemoveData<T>(this IUsesMARSData<T> obj, int dataId)
        {
            return IUsesMARSDataMethods<T>.RemoveData(dataId);
        }

        public static T GetIdValue<T>(this IUsesMARSData<T> obj, int dataId)
        {
            return IUsesMARSDataMethods<T>.GetIdValue(dataId);
        }

        public static ICollection<KeyValuePair<int, T>> GetCollection<T>(this IUsesMARSData<T> obj)
        {
            return IUsesMARSDataMethods<T>.GetCollection();
        }
    }
}
