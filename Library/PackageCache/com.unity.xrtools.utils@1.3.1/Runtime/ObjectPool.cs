using System.Collections.Generic;

namespace Unity.XRTools.Utils
{
    /// <summary>
    /// Instance pool for objects
    /// </summary>
    /// <typeparam name="T">The type of object to manage instances of</typeparam>
    public class ObjectPool<T> where T: class, new()
    {
        /// <summary>
        /// All objects in the pool
        /// </summary>
        protected readonly Queue<T> m_Queue = new Queue<T>();

        /// <summary>
        /// Get an instance of the object type
        /// </summary>
        /// <returns>The object instance</returns>
        public virtual T Get()
        {
            return m_Queue.Count == 0 ? new T() : m_Queue.Dequeue();
        }

        /// <summary>
        /// Return an object instance to the pool
        /// </summary>
        /// <param name="instance">The instance to return</param>
        public void Recycle(T instance)
        {
            ClearInstance(instance);
            m_Queue.Enqueue(instance);
        }

        /// <summary>
        /// Implement a clearing function in this in a derived class to
        /// have the <seealso cref="Recycle"/> method automatically clear the item.
        /// </summary>
        /// <param name="instance">The object to return to the pool</param>
        protected virtual void ClearInstance(T instance) { }
    }
}
