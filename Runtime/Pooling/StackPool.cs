using System;
using System.Collections.Generic;

namespace Ktyl.Ktylities
{
    public class StackPool<T> : IPool<T>
    {
        private readonly Stack<T> _pooledObjects;
        private readonly Func<T> _createInstance;
        private readonly Action<T> _onPut;
        private readonly Action<T> _onGet;

        #region IPool implementation
        public Type PooledType => typeof(T);

        /// <summary>
        /// Number of instances currently in the pool.
        /// </summary>
        public int Count => _pooledObjects.Count;

        /// <summary>
        /// Empty the pool.
        /// </summary>
        public void Clear()
        {
            _pooledObjects.Clear();
        }

        /// <summary>
        /// Get an instance from the pool.
        /// </summary>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public T Get()
        {
            T t = _pooledObjects.Count > 0
                ? _pooledObjects.Pop()
                : _createInstance.Invoke();

            _onGet?.Invoke(t);

            return t;
        }

        /// <summary>
        /// Get an instance from the pool.
        /// </summary>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public object GetInstance()
        {
            return Get();
        }

        /// <summary>
        /// Put an instance of <typeparamref name="T"/> into the pool.
        /// </summary>
        /// <param name="instance">An object of type <typeparamref name="T"/></param>
        public void Put(T instance)
        {
            _onPut?.Invoke(instance);
            _pooledObjects.Push(instance);
        }

        /// <summary>
        /// Put an object into the pool.
        /// </summary>
        /// <param name="instance">The object to put into the pool.</param>
        /// <exception cref="Exception">Thrown if <paramref name="instance"/> is not of type <typeparamref name="T"/>.</exception>
        public void PutInstance(object instance)
        {
            T t = (T)instance;
            if (t == null)
            {
                throw new Exception($"can't cast {instance} to type {typeof(T)}.");
            }

            Put(t);
        }
        #endregion

        /// <summary>
        /// Create a StackPool with the specified callbacks.
        /// </summary>
        /// <param name="createInstance">A function to create a new instance of <typeparamref name="T"/> for when an instance is requested from an empty pool.</param>
        /// <param name="onPut">An optional callback that is invoked after removing an instance from the pool.</param>
        /// <param name="onGet">An optional callback that is invoked before putting an instance into the pool.</param>
        /// <param name="prepopulate">The number of instances to pre-allocate on pool instantiation.</param>
        public StackPool(Func<T> createInstance, Action<T> onPut = null, Action<T> onGet = null, int prepopulate = 0)
        {
            _pooledObjects = new Stack<T>();
            _createInstance = createInstance;

            _onPut = onPut;
            _onGet = onGet;

            for (int _ = 0; _ < prepopulate; _++)
            {
                Put(_createInstance.Invoke());
            }
        }
    }
}
