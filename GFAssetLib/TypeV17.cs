using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    // version : 17 ~
    public class TypeV17 : Type
    {
        byte unknown1;
        Int16 unknown2;
        byte[] scriptHash;

        public TypeV17(int version, bool hasTypeTrees) : base(version, hasTypeTrees) { }

        public override void Read(AssetReader reader)
        {
            classID = reader.ReadInt32();
            unknown1 = reader.ReadByte();
            unknown2 = reader.ReadInt16();

            if (IsScriptType())
                scriptHash = reader.ReadBytes(16);

            typeHash = reader.ReadBytes(16);

            if (hasTypeTrees)
            {
                typeTree = TypeTree.Create(version);
                typeTree.Read(reader);
            }
        }

        public override void PrettyPrint(AssetPrettyWriter writer)
        {
            writer.WriteLine($"ClassID = {this.classID:X8}");
            writer.WriteLine($"Unknown1 = {this.unknown1}");
            writer.WriteLine($"Unknown2 = {this.unknown2}");
            if (IsScriptType())
                writer.WriteLine($"ScriptHash = {BitConverter.ToString(this.scriptHash).Replace('-', ' ')}");
            writer.WriteLine($"TypeHash = {BitConverter.ToString(this.typeHash).Replace('-', ' ')}");
            if (hasTypeTrees)
                typeTree.PrettyPrint(writer);
        }
    }
}
