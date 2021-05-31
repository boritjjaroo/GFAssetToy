using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public class Texture : NamedObject
    {
        public Texture(Type type, ObjectInfo objectInfo, string containerPath) : base(type, objectInfo, containerPath) { }
        public override string GetTypeName() { return "Texture"; }
    }
}
