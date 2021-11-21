using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktylities
{
    /// <summary>
    /// A pool of <typeparamref name="T"/> instances.
    /// </summary>
    /// <typeparam name="T">The type of object to pool.</typeparam>
    public interface IPool<T> : IPool
    {
        /// <summary>
        /// Get an instance from the pool.
        /// </summary>
        /// <returns>An instance of <typeparamref name="T"/> from the pool.</returns>
        T Get();
        /// <summary>
        /// Put an instance into the pool.
        /// </summary>
        /// <param name="instance">The object to put into the pool.</param>
        void Put(T instance);
    }

    /// <summary>
    /// An object pool.
    /// </summary>
    public interface IPool
    {
        /// <summary>
        /// The type of object in the pool.
        /// </summary>
        System.Type PooledType { get; }
        /// <summary>
        /// Get an object from the pool.
        /// </summary>
        /// <returns>An object from the pool.</returns>
        object GetInstance();
        /// <summary>
        /// Put an object into the pool.
        /// </summary>
        /// <param name="instance">The object to put into the pool.</param>
        void PutInstance(object instance);
        /// <summary>
        /// Number of objects currently in the pool.
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Empty the pool.
        /// </summary>
        void Clear();
    }
}
