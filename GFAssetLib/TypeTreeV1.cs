using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    // version : 1 ~ 9
    public class TypeTreeV1 : TypeTree
    {
        public TypeTreeV1(int version) : base(version)
        {
        }

        public override void Read(AssetReader reader)
        {
            throw new Exception("Not implemented.");
        }

        public override void PrettyPrint(AssetPrettyWriter writer)
        {
            throw new Exception("Not implemented.");
        }
    }
}
