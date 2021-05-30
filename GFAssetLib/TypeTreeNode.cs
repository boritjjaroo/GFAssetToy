using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    public class TypeTreeNode
    {
        TypeTree typeTree;

        Int16 version;
        public int Version { get => version; }
        byte depth;
        public int Depth { get => depth; }
        bool isArray;
        Int32 typeNameOffset;
        Int32 fieldNameOffset;
        Int32 size;
        Int32 index;
        UInt32 flags;

        public TypeTreeNode(TypeTree typeTree)
        {
            this.typeTree = typeTree;
        }

        public void Read(AssetReader reader)
        {
            version = reader.ReadInt16();
            depth = reader.ReadByte();
            isArray = 0 < reader.ReadByte();
            typeNameOffset = reader.ReadInt32();
            fieldNameOffset = reader.ReadInt32();
            size = reader.ReadInt32();
            index = reader.ReadInt32();
            flags = reader.ReadUInt32();
        }

        public void PrettyPrint(AssetPrettyWriter writer)
        {
            string buf = $"{typeTree.GetName(typeNameOffset)} {typeTree.GetName(fieldNameOffset)}   [ V({version}) S({size}) Array({isArray}) 0x{flags:X8} ]";
            writer.WriteLine(buf);
        }

        public void PrettyPrint_(AssetPrettyWriter writer)
        {
            writer.WriteLine($"Version = {version}");
            writer.WriteLine($"Depth = {depth}");
            writer.WriteLine($"IsArray = {isArray}");
            writer.WriteLine($"TypeNameOffset = {typeNameOffset} ({typeTree.GetName(typeNameOffset)})");
            writer.WriteLine($"FieldNameOffset = {fieldNameOffset} ({typeTree.GetName(fieldNameOffset)})");
            writer.WriteLine($"Size = {size}");
            writer.WriteLine($"Index = {index}");
            writer.WriteLine($"Flags = {flags:X8}");
        }

        public bool IsAligned() { return 0 < (this.flags & 0x4000); }
    }
}
