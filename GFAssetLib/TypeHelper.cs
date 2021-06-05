using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    public class TypeHelper
    {
        public static int PrettyPrint(AssetReader reader, AssetPrettyWriter writer, TypeTreeNode[] nodes, int startIndex, int lastIndex)
        {
            if (nodes == null || nodes.Length <= startIndex)
                throw new Exception();

            int curIndex = startIndex;
            int nextIndex = startIndex;

            while (curIndex < lastIndex)
            {
                TypeTreeNode curNode = nodes[curIndex];
                var typeName = curNode.GetTypeName();
                var fieldName = curNode.GetFieldName();
                var val = "";

                if (typeName == "Array")
                {
                    int size = reader.ReadInt32();

                    var buf = $"{typeName} {fieldName}[{size}]";
                    writer.WriteLine(buf);

                    if (0 < size)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            writer.WriteLine($"[{i}]");
                            nextIndex = curIndex + 2 + PrettyPrint(reader, writer, nodes, curIndex + 2, lastIndex);
                        }
                    }
                    else
                    {
                        nextIndex = curIndex + 1;
                        while (nextIndex < nodes.Length && curNode.Depth <= nodes[nextIndex].Depth)
                            nextIndex++;
                    }
                }
                else if (typeName == "string")
                {
                    val = $" = \"{reader.ReadTypeString()}\"";
                    nextIndex = curIndex + 4;
                }
                else if (typeName == "bool")
                {
                    val = $" = {reader.ReadBoolean()}";
                    nextIndex = curIndex + 1;
                }
                else if (typeName == "int")
                {
                    val = $" = {reader.ReadInt32()}";
                    nextIndex = curIndex + 1;
                }
                else if (typeName == "SInt64")
                {
                    val = $" = {reader.ReadInt64()}";
                    nextIndex = curIndex + 1;
                }
                else if (typeName == "unsigned int")
                {
                    val = $" = {reader.ReadUInt32()}";
                    nextIndex = curIndex + 1;
                }
                else if (typeName == "UInt8")
                {
                    val = $" = {reader.ReadByte()}";
                    nextIndex = curIndex + 1;
                }
                else if (typeName == "float")
                {
                    val = $" = {reader.ReadFloat()}";
                    nextIndex = curIndex + 1;
                }
                else
                {
                    val = "";
                    nextIndex = curIndex + 1;
                }

                if (typeName != "Array")
                {
                    var buf = $"{typeName} {fieldName}{val}";
                    writer.WriteLine(buf);
                }

                if (curNode.IsAligned())
                    reader.MoveToAlignedPosition(4);

                if (nodes.Length <= nextIndex)
                    break;

                if (curNode.Depth < nodes[nextIndex].Depth)
                {
                    writer.IncreaseDepth();
                    nextIndex += TypeHelper.PrettyPrint(reader, writer, nodes, nextIndex, lastIndex);
                    writer.DecreaseDepth();
                }

                if (nodes.Length <= nextIndex)
                    break;

                if (nodes[nextIndex].Depth < curNode.Depth)
                {
                    break;
                }

                curIndex = nextIndex;
            }

            return nextIndex - startIndex;
        }

    }
}
