//-------------------------------------------------------------------------------
// <copyright file="NinjectHashSet.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2012 Ninject Project Contributors
//   Authors: Remo Gloor (remo.gloor@gmail.com)
//           
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace System.Collections.Generic
{
#if !NO_HASH_SET
    /// <summary>
    /// A hash set collection.
    /// </summary>
    /// <typeparam name="T">The type of the objects stored int the hash set</typeparam>
    public class NinjectHashSet<T> : HashSet<T>
    {
    }
#else
    using System.Linq;
    /// <summary>
    /// A hash set collection.
    /// </summary>
    /// <typeparam name="T">The type of the objects stored int the hash set</typeparam>
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

