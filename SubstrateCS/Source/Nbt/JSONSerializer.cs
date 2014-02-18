using System;
using System.Collections.Generic;
using System.Text;
using Substrate.Core;

namespace Substrate.Nbt
{
    public static class JSONSerializer
    {
        public static string Serialize (TagNode tag, bool singleLine = false)
        {
            return Serialize(tag, 0, singleLine);
        }

        public static string Serialize(TagNode tag, int level, bool singleLine = false)
        {
            StringBuilder str = new StringBuilder();

            Serialize(tag, level, str, singleLine);

            return str.ToString();
        }

        private static void Serialize(TagNode tag, int level, StringBuilder str, bool indent = false, bool singleLine = false)
        {
            switch (tag.GetTagType()) {
                case TagType.TAG_COMPOUND:
                    SerializeCompound(tag as TagNodeCompound, str, level);
                    break;
                case TagType.TAG_LIST:
                    SerializeList(tag as TagNodeList, str, level);
                    break;
                case TagType.TAG_BYTE_ARRAY:
                    SerializeArray(tag as TagNodeByteArray, str, level);
                    break;
                case TagType.TAG_INT_ARRAY:
                    SerializeArray(tag as TagNodeIntArray, str, level);
                    break;
                default:
                    if(indent && !singleLine) Indent(str, level);
                    SerializeScaler(tag, str);
                    break;
            }
        }

        private static void SerializeCompound(TagNodeCompound tag, StringBuilder str, int level, bool singleLine = false)
        {
            if (tag.Count == 0) {
                str.Append("{ }");
                return;
            }

            if(!singleLine)
                str.AppendLine();
            AddLine(str, "{", level, singleLine);

            bool first = true;
            foreach(KeyValuePair<string, TagNode> item in tag) {
                if (!first) {
                    str.Append(",");
                    if(!singleLine)
                        str.AppendLine();
                }

                Add(str, "\"" + Escape(item.Key) + "\": ", level + 1, singleLine);

                Serialize(tag, level + 1, str, false, singleLine);

                first = false;
            }
            if(!singleLine)
                str.AppendLine();
            Add(str, "}", level, singleLine);
        }

        private static void SerializeList(TagNodeList tag, StringBuilder str, int level, bool singleLine = false)
        {
            if (tag.Count == 0) {
                str.Append("[ ]");
                return;
            }

            if(!singleLine)
                str.AppendLine();

            AddLine(str, "[", level, singleLine);

            bool first = true;
            foreach (TagNode item in tag) {
                if (!first) {
                    str.Append(",");
                    str.AppendLine();
                }

                Serialize(item, level + 1, str, true, singleLine);

                first = false;
            }
            if(!singleLine)
                str.AppendLine();
            Add(str, "]", level, singleLine);
        }

        private static void SerializeArray<T>(TagNodeArray<T> tag, StringBuilder str, int level, bool singleLine = false) where T : struct {
            if (tag.Length == 0) {
                str.Append("[ ]");
                return;
            }
            if(!singleLine)
                str.AppendLine();
            AddLine(str, "[", level, singleLine);

            bool first = true;
            foreach (T item in tag) {
                if (!first) {
                    str.Append(",");
                    str.AppendLine();
                }
                
                str.Append(item);

                first = false;
            }
            if(!singleLine)
                str.AppendLine();
            Add(str, "]", level, singleLine);
        }

        private static void SerializeScaler (TagNode tag, StringBuilder str)
        {
            switch (tag.GetTagType()) {
                case TagType.TAG_STRING:
                    str.Append("\"" + Escape(tag.ToTagString().Data) + "\"");
                    break;

                case TagType.TAG_BYTE:
                    str.Append(tag.ToTagByte().Data);
                    break;

                case TagType.TAG_SHORT:
                    str.Append(tag.ToTagShort().Data);
                    break;

                case TagType.TAG_INT:
                    str.Append(tag.ToTagInt().Data);
                    break;

                case TagType.TAG_LONG:
                    str.Append(tag.ToTagLong().Data);
                    break;

                case TagType.TAG_FLOAT:
                    str.Append(tag.ToTagFloat().Data);
                    break;

                case TagType.TAG_DOUBLE:
                    str.Append(tag.ToTagDouble().Data);
                    break;
            }
        }

        private static void AddLine (StringBuilder str, string line, int level, bool singleLine = false)
        {
            if (singleLine) {
                str.Append(line);
                return;
            }
            Indent(str, level);
            str.AppendLine(line);
        }

        private static void Add(StringBuilder str, string line, int level, bool singleLine = false)
        {
            if(!singleLine)
                Indent(str, level);
            str.Append(line);
        }

        private static void Indent (StringBuilder str, int count)
        {
            for (int i = 0; i < count; i++)
                str.Append("\t");
        }

        private static string Escape(string str) {
            return new StringBuilder(str) // It is faster to escape string if a string builder is used.
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n")
                .Replace("\t", "\\t")
                .Replace("\b", "\\b")
                .Replace("\f", "\\f")
                .ToString();
        }
    }
}
