using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Substrate.Nbt
{
    /// <summary>
    /// An NBT node representing an unsigned byte array tag type.
    /// </summary>
    public sealed class TagNodeByteArray : TagNodeArray<byte>
    {

        /// <summary>
        /// Converts the node to itself.
        /// </summary>
        /// <returns>A reference to itself.</returns>
        public override TagNodeByteArray ToTagByteArray () 
        {
            return this;
        }

        /// <summary>
        /// Gets the tag type of the node.
        /// </summary>
        /// <returns>The TAG_BYTE_ARRAY tag type.</returns>
        public override TagType GetTagType ()
        {
            return TagType.TAG_BYTE_ARRAY; 
        }

        /// <summary>
        /// Constructs a new byte array node with a null data value.
        /// </summary>
        public TagNodeByteArray () { }

        /// <summary>
        /// Constructs a new byte array node.
        /// </summary>
        /// <param name="d">The value to set the node's tag data value.</param>
        public TagNodeByteArray (byte[] d) : base(d) { }

        /// <summary>
        /// Makes a deep copy of the node.
        /// </summary>
        /// <returns>A new byte array node representing the same data.</returns>
        public override TagNode Copy ()
        {
            byte[] arr = new byte[_data.Length];
            _data.CopyTo(arr, 0);

            return new TagNodeByteArray(arr);
        }

        /// <summary>
        /// Converts a system byte array to a byte array node representing the same data.
        /// </summary>
        /// <param name="b">A byte array.</param>
        /// <returns>A new byte array node containing the given value.</returns>
        public static implicit operator TagNodeByteArray (byte[] b)
        {
            return new TagNodeByteArray(b);
        }
    }
}