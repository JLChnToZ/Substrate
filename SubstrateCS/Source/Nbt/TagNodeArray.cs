using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Substrate.Nbt {
    /// <summary>
    /// An abstract base class representing a NBT node stores an array.
    /// </summary>
    /// <typeparam name="T">Array data type</typeparam>
    public abstract class TagNodeArray<T> : TagNode, IEnumerable<T> where T : struct {

        protected T[] _data = null;

        /// <summary>
        /// Gets or sets a single data at the specified index.
        /// </summary>
        /// <param name="index">Valid index within stored array.</param>
        /// <returns>The byte value at the given index of the stored array.</returns>
        public T this[int index] {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        /// <summary>
        /// Gets or sets an array of tag data.
        /// </summary>
        public T[] Data {
            get { return _data; }
            set { _data = value; }
        }

        /// <summary>
        /// Gets the length of the stored array.
        /// </summary>
        public int Length {
            get { return _data.Length; }
        }

        /// <summary>
        /// Constructs a new array node.
        /// </summary>
        /// <param name="d">The value to set the node's tag data value.</param>
        public TagNodeArray(T[] d) {
            _data = d;
        }

        /// <summary>
        /// Constructs a new array node with a null data value.
        /// </summary>
        public TagNodeArray() { }

        /// <summary>
        /// Gets a string representation of the node's data.
        /// </summary>
        /// <returns>String representation of the node's data.</returns>
        public override string ToString() {
            return _data.ToString();
        }

        /// <summary>
        /// Converts an array node to a system array representing the same data.
        /// </summary>
        /// <param name="i">An array node.</param>
        /// <returns>A system array set to the node's data.</returns>
        public static implicit operator T[](TagNodeArray<T> i) {
            return i._data;
        }

        /// <summary>
        /// Gets the enumerator respends the data of this tag.
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<T> GetEnumerator() {
            foreach (T i in _data)
                yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
