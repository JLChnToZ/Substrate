using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Substrate.Core;

namespace Substrate.Nbt 
{
    /// <summary>
    /// An abstract base class representing a node in an NBT tree.
    /// </summary>
    public abstract class TagNode : ICopyable<TagNode>
    {
        /// <summary>
        /// Convert this node to a null tag type if supported.
        /// </summary>
        /// <returns>A new null node.</returns>
        public virtual TagNodeNull ToTagNull () 
        {
            throw new InvalidCastException();
        }

        public static explicit operator TagNodeNull(TagNode node) {
            return node.ToTagNull();
        }

        /// <summary>
        /// Convert this node to a byte tag type if supported.
        /// </summary>
        /// <returns>A new byte node.</returns>
        public virtual TagNodeByte ToTagByte ()
        {
            throw new InvalidCastException(); 
        }

        public static explicit operator TagNodeByte(TagNode node) {
            return node.ToTagByte();
        }

        /// <summary>
        /// Convert this node to a short tag type if supported.
        /// </summary>
        /// <returns>A new short node.</returns>
        public virtual TagNodeShort ToTagShort () 
        {
            throw new InvalidCastException(); 
        }

        public static explicit operator TagNodeShort(TagNode node) {
            return node.ToTagShort();
        }

        /// <summary>
        /// Convert this node to an int tag type if supported.
        /// </summary>
        /// <returns>A new int node.</returns>
        public virtual TagNodeInt ToTagInt ()
        {
            throw new InvalidCastException(); 
        }

        public static explicit operator TagNodeInt(TagNode node) {
            return node.ToTagInt();
        }

        /// <summary>
        /// Convert this node to a long tag type if supported.
        /// </summary>
        /// <returns>A new long node.</returns>
        public virtual TagNodeLong ToTagLong () 
        {
            throw new InvalidCastException(); 
        }

        public static explicit operator TagNodeLong(TagNode node) {
            return node.ToTagLong();
        }

        /// <summary>
        /// Convert this node to a float tag type if supported.
        /// </summary>
        /// <returns>A new float node.</returns>
        public virtual TagNodeFloat ToTagFloat () 
        {
            throw new InvalidCastException();
        }

        public static explicit operator TagNodeFloat(TagNode node) {
            return node.ToTagFloat();
        }

        /// <summary>
        /// Convert this node to a double tag type if supported.
        /// </summary>
        /// <returns>A new double node.</returns>
        public virtual TagNodeDouble ToTagDouble () 
        {
            throw new InvalidCastException();
        }

        public static explicit operator TagNodeDouble(TagNode node) {
            return node.ToTagDouble();
        }

        /// <summary>
        /// Convert this node to a byte array tag type if supported.
        /// </summary>
        /// <returns>A new byte array node.</returns>
        public virtual TagNodeByteArray ToTagByteArray () 
        {
            throw new InvalidCastException();
        }

        /// <summary>
        /// Convert this node to a string tag type if supported.
        /// </summary>
        /// <returns>A new string node.</returns>
        public virtual TagNodeString ToTagString () 
        {
            throw new InvalidCastException(); 
        }

        public static explicit operator TagNodeString(TagNode node) {
            return node.ToTagString();
        }

        /// <summary>
        /// Convert this node to a list tag type if supported.
        /// </summary>
        /// <returns>A new list node.</returns>
        public virtual TagNodeList ToTagList ()
        {
            throw new InvalidCastException();
        }

        public static explicit operator TagNodeList(TagNode node) {
            return node.ToTagList();
        }

        /// <summary>
        /// Convert this node to a compound tag type if supported.
        /// </summary>
        /// <returns>A new compound node.</returns>
        public virtual TagNodeCompound ToTagCompound () 
        {
            throw new InvalidCastException(); 
        }

        public static explicit operator TagNodeCompound(TagNode node) {
            return node.ToTagCompound();
        }

        /// <summary>
        /// Conver this node to an int array tag type if supported.
        /// </summary>
        /// <returns>A new int array node.</returns>
        public virtual TagNodeIntArray ToTagIntArray ()
        {
            throw new InvalidCastException();
        }

        public static explicit operator TagNodeIntArray(TagNode node) {
            return node.ToTagIntArray();
        }

        /// <summary>
        /// Gets the underlying tag type of the node.
        /// </summary>
        /// <returns>An NBT tag type.</returns>
        public virtual TagType GetTagType () 
        {
            return TagType.TAG_END; 
        }

        /// <summary>
        /// Checks if this node is castable to another node of a given tag type.
        /// </summary>
        /// <param name="type">An NBT tag type.</param>
        /// <returns>Status indicating whether this object could be cast to a node type represented by the given tag type.</returns>
        public virtual bool IsCastableTo (TagType type)
        {
            return type == GetTagType();
        }

        /// <summary>
        /// Makes a deep copy of the NBT node.
        /// </summary>
        /// <returns>A new NBT node.</returns>
        public virtual TagNode Copy ()
        {
            return null;
        }

        /// <summary>
        /// Clone (deep copy) this object.
        /// </summary>
        /// <returns></returns>
        public object Clone() {
            return Copy();
        }
        
        /// <summary>
        /// Get JSON string respends this NBT node.
        /// </summary>
        /// <param name="SingleLine">Should the result is in single line</param>
        /// <returns>JSON string</returns>
        public string toJSON (bool SingleLine = false)
        {
            return JSONSerializer.Serialize(this, SingleLine);
        }
    }
}