using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public class Behaviour : Component
    {
        public Behaviour(int version, long dataOffset) : base(version, dataOffset) { }
        public override string GetTypeName() { return "Behaviour"; }
    }
}
