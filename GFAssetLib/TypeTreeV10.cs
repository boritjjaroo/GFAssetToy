using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    // version : 10
    public class TypeTreeV10 : TypeTree
    {
        Int32 numNodes;
        Int32 stringBufferSize;
        TypeTreeNode[] nodes;
        byte[] stringBuffer;

        public TypeTreeV10(int version) : base(version)
        {

        }

        public override void Read(AssetReader reader)
        {
            numNodes = reader.ReadInt32();
            stringBufferSize = reader.ReadInt32();

            nodes = new TypeTreeNode[numNodes];
            for (int i = 0; i < numNodes; i++)
            {
                nodes[i] = new TypeTreeNode(this);
                nodes[i].Read(reader);
            }
            if (0 < stringBufferSize)
            {
                stringBuffer = reader.ReadBytes(stringBufferSize);
            }
        }

        public override void PrettyPrint(AssetPrettyWriter writer)
        {
            writer.WriteLine($"TypeTreeV{version}");
            writer.IncreaseDepth();

            writer.WriteLine($"NumNodes = {numNodes}");
            writer.WriteLine($"StringBufferSize = {stringBufferSize}");
            if (0 < stringBufferSize)
                writer.WriteLine($"StringBuffer = \"{Encoding.ASCII.GetString(stringBuffer)}\"");

            //for (int i = 0; i < numNodes; i++)
            //{
            //    writer.IncreaseDepth();
            //    writer.WriteLine($"Node[{i}]");
            //    writer.IncreaseDepth();
            //    nodes[i].PrettyPrint(writer);
            //    writer.DecreaseDepth();
            //    writer.DecreaseDepth();
            //}

            writer.IncreaseDepth();
            int depth = 0;
            for (int i = 0; i < numNodes; i++)
            {
                if (depth < nodes[i].Depth)
                    writer.IncreaseDepth(nodes[i].Depth - depth);
                else if (nodes[i].Depth < depth)
                    writer.DecreaseDepth(depth - nodes[i].Depth);
                depth = nodes[i].Depth;

                nodes[i].PrettyPrint(writer);
            }
            if (0 < depth)
                writer.DecreaseDepth(depth);
            writer.DecreaseDepth();

            writer.DecreaseDepth();
        }

        public override int GetTypeVersion()
        {
            if (0 < nodes.Length)
                return nodes[0].Version;
            return 0;
        }

        public override string GetName(Int32 index)
        {
            if (0 <= index)
            {
                if (stringBuffer != null && index < stringBuffer.Length)
                {
                    int count = 0;
                    while (stringBuffer[index + count] != '\0')
                        count++;
                    return Encoding.ASCII.GetString(stringBuffer, index, count);
                }
                return "";
            }
            return base.GetName(index);
        }

        public override int GetBaseObjectVersion()
        {
            if (nodes == null || 0 == nodes.Length || nodes[0] == null)
                return 0;
            return nodes[0].Version;
        }

        public override TypeTreeNode[] GetNodes() { return nodes; }
    }
}
