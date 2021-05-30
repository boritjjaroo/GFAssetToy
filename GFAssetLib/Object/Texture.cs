using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public class Texture : NamedObject
    {
        public Texture(int version, long dataOffset) : base(version, dataOffset) { }
        public override string GetTypeName() { return "Texture"; }
    }
}
