using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public class Behaviour : Component
    {
        public Behaviour(Type type, ObjectInfo objectInfo, string containerPath) : base(type, objectInfo, containerPath) { }
        public override string GetTypeName() { return "Behaviour"; }
    }
}
