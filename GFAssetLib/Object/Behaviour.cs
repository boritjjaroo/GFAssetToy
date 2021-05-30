using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public class Behaviour : Component
    {
        public Behaviour(int version, long dataOffset, string containerPath) : base(version, dataOffset, containerPath) { }
        public override string GetTypeName() { return "Behaviour"; }
    }
}
