using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    // version : 13 ~ 16
    public class TypeV13 : Type
    {
        byte[] scriptHash;

        public TypeV13(int version, bool hasTypeTrees) : base(version, hasTypeTrees) { }

        public override void Read(AssetReader reader)
        {
            classID = reader.ReadInt32();

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
            if (IsScriptType())
                writer.WriteLine($"ScriptHash = {BitConverter.ToString(this.scriptHash).Replace('-', ' ')}");
            writer.WriteLine($"TypeHash = {BitConverter.ToString(this.typeHash).Replace('-', ' ')}");
            if (hasTypeTrees)
                typeTree.PrettyPrint(writer);
        }
    }
}
