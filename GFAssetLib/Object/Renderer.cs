using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public class Renderer : Component
    {
        public Renderer(int version, long dataOffset) : base(version, dataOffset) { }
        public override string GetTypeName() { return "Renderer"; }
    }
}
