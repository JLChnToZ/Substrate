using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Nbt
{
    /// <summary>
    /// An NBT node representing an integer array tag type.
    /// </summary>
    public sealed class TagNodeIntArray : TagNodeArray<int>
    {

        /// <summary>
        /// Converts the node to itself.
        /// </summary>
        /// <returns>A reference to itself.</returns>
        public override TagNodeIntArray ToTagIntArray () 
        {
            return this;
        }

        /// <summary>
        /// Gets the tag type of the node.
        /// </summary>
        /// <returns>The TAG_INT_ARRAY tag type.</returns>
        public override TagType GetTagType ()
        {
            return TagType.TAG_INT_ARRAY; 
        }

        /// <summary>
        /// Constructs a new byte array node with a null data value.
        /// </summary>
        public TagNodeIntArray () { }

        /// <summary>
        /// Constructs a new byte array node.
        /// </summary>
        /// <param name="d">The value to set the node's tag data value.</param>
        public TagNodeIntArray (int[] d) : base(d) { }

        /// <summary>
        /// Makes a deep copy of the node.
        /// </summary>
        /// <returns>A new int array node representing the same data.</returns>
        public override TagNode Copy ()
        {
            int[] arr = new int[_data.Length];
            _data.CopyTo(arr, 0);

            return new TagNodeIntArray(arr);
        }

        /// <summary>
        /// Converts a system int array to a int array node representing the same data.
        /// </summary>
        /// <param name="i">A int array.</param>
        /// <returns>A new int array node containing the given value.</returns>
        public static implicit operator TagNodeIntArray (int[] i)
        {
            return new TagNodeIntArray(i);
        }
    }
}
