using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public class EditorExtension : ObjectBase
    {
        public EditorExtension(int version, long dataOffset, string containerPath) : base(version, dataOffset, containerPath) { }
        public override string GetTypeName() { return "EditorExtension"; }
    }
}
