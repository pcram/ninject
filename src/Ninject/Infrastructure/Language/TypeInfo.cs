//-------------------------------------------------------------------------------
// <copyright file="TypeInfo.cs" company="Ninject Project Contributors">
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

#if !HAS_TYPEINFO
namespace System.Reflection
{
    /// <summary>
    /// Type info for a type.
    /// </summary>
    public struct TypeInfo
    {
        /// <summary>
        /// The type of this type info. 
        /// </summary>
        private readonly Type type;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeInfo"/> struct.
        /// </summary>
        /// <param name="type">The type.</param>
        public TypeInfo(Type type)
        {
            this.type = type;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is generic type definition.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is generic type definition; otherwise, <c>false</c>.
        /// </value>
        public bool IsGenericTypeDefinition
        {
            get
            {
                return this.type.IsGenericTypeDefinition;
            }
        }

        /// <summary>
        /// Gets the generic type arguments.
        /// </summary>
        /// <value>The generic type arguments.</value>
        public Type[] GenericTypeArguments
        {
            get
            {
                return this.type.GetGenericArguments();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the type contains generic parameters.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the type contains generic parameters; otherwise, <c>false</c>.
        /// </value>
        public bool ContainsGenericParameters
        {
            get
            {
                return this.type.ContainsGenericParameters;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is generic type.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is generic type; otherwise, <c>false</c>.
        /// </value>
        public bool IsGenericType
        {
            get
            {
                return this.type.IsGenericType;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is interface.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is interface; otherwise, <c>false</c>.
        /// </value>
        public bool IsInterface
        {
            get
            {
                return this.type.IsInterface;
            }
        }

        /// <summary>
        /// Gets the declared constructors of the type.
        /// </summary>
        /// <value>The declared constructors of the type.</value>
        public ConstructorInfo[] DeclaredConstructors
        {
            get
            {
                return this.type.GetConstructors();
            }
        }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        public string Name
        {
            get
            {
                return this.type.Name;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the type is value type.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the type is value type; otherwise, <c>false</c>.
        /// </value>
        public bool IsValueType
        {
            get
            {
                return this.type.IsValueType;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the type is abstract.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the type is abstract; otherwise, <c>false</c>.
        /// </value>
        public bool IsAbstract
        {
            get
            {
                return this.type.IsAbstract;
            }
        }

        /// <summary>
        /// Determines whether the type is assignable from the the type of the specified type info.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <returns>
        ///     <c>true</c> if the type is assignable from the type of the specified type info; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAssignableFrom(TypeInfo info)
        {
            return this.type.IsAssignableFrom(info.type);
        }
    }
}
#endif