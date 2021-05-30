using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public class EditorExtension : ObjectBase
    {
        public EditorExtension(int version, long dataOffset) : base(version, dataOffset) { }
        public override string GetTypeName() { return "EditorExtension"; }
    }
}
