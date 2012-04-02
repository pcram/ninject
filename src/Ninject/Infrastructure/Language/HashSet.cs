namespace System.Collections.Generic
{
#if !NO_HASH_SET
    public class NinjectHashSet<T> : HashSet<T>
    {
    }
#else
    using System.Linq;
    /// <summary>
    /// A hash set collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NinjectHashSet<T>
    {
        private readonly IDictionary<T, object> data = new Dictionary<T,object>();

        /// <summary>
        /// Gets the number of objects in this set.
        /// </summary>
        /// <value>The number of objects in this set.</value>
        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            this.data.Clear();
        }

        /// <summary>
        /// Adds the specified object.
        /// </summary>
        /// <param name="o">The object.</param>
        public void Add(T o)
        {
            this.data.Add(o, null);
        }

        /// <summary>
        /// Determines whether the specified object is contained in the hash set.
        /// </summary>
        /// <param name="o">The object.</param>
        /// <returns>
        ///     <c>true</c> if the hash set contains the specified object; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T o)
        {
            return this.data.ContainsKey(o);
        }

        /// <summary>
        /// Removes the objects that match the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public void RemoveWhere(Predicate<T> predicate)
        {
            var objectsToRemove = this.data.Where(entry => predicate(entry.Key)).ToList();
            foreach (var objectToRemove in objectsToRemove)
            {
                this.data.Remove(objectToRemove);
            }
        }
    }
#endif
}

