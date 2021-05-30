using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public class Component : EditorExtension
    {
        public Component(int version, long dataOffset) : base(version, dataOffset) { }
        public override string GetTypeName() { return "Component"; }
    }
}
