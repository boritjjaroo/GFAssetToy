using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public class Motion : NamedObject
    {
        public Motion(int version, long dataOffset) : base(version, dataOffset) { }
        public override string GetTypeName() { return "Motion"; }
    }
}
