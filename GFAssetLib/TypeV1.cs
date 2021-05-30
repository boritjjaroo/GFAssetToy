using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    // version : 1 ~ 12
    public class TypeV1 : Type
    {
        public TypeV1(int version, bool hasTypeTrees) : base(version, hasTypeTrees) { }

        public override void Read(AssetReader reader)
        {
            classID = reader.ReadInt32();
            hasTypeTrees = true;

            typeTree = TypeTree.Create(version);
            typeTree.Read(reader);
        }

        public override void PrettyPrint(AssetPrettyWriter writer)
        {
            writer.WriteLine($"ClassID = {this.classID:X8}");
            typeTree.PrettyPrint(writer);
        }
    }
}
