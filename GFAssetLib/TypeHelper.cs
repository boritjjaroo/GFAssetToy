using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    public class TypeHelper
    {
        public static void PrettyPrint(AssetReader reader, AssetPrettyWriter writer, TypeTreeNode[] nodes)
        {
            if (nodes == null || nodes.Length < 0)
                throw new Exception();

            TypeHelper.PrettyPrintNode(reader, writer, nodes, 0);
        }

        private static int PrettyPrintNode(AssetReader reader, AssetPrettyWriter writer, TypeTreeNode[] nodes, int index)
        {
            if (nodes == null || nodes.Length <= index)
                throw new Exception();

            int curIndex = index;
            int nextIndex = index;

            while (curIndex < nodes.Length)
            {
                TypeTreeNode curNode = nodes[curIndex];
                var typeName = curNode.GetTypeName();
                var fieldName = curNode.GetFieldName();
                var val = "";

                if (typeName == "Array")
                {
                    int size = reader.ReadInt32();

                    if (0 < size)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            writer.WriteLine($"[{i}]");
                            nextIndex = curIndex + 2 + PrettyPrintNode(reader, writer, nodes, curIndex + 2);
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
                    val = $" = \"{reader.ReadString()}\"";
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

                var buf = $"{typeName} {fieldName}{val}";
                writer.WriteLine(buf);

                if (curNode.IsAligned())
                    reader.MoveToAlignedPosition(4);

                if (nodes.Length <= nextIndex)
                    break;

                if (curNode.Depth < nodes[nextIndex].Depth)
                {
                    writer.IncreaseDepth();
                    nextIndex += TypeHelper.PrettyPrintNode(reader, writer, nodes, nextIndex);
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

            return nextIndex - index;
        }
    }
}
