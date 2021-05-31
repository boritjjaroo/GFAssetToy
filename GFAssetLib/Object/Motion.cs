﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public class Motion : NamedObject
    {
        public Motion(Type type, ObjectInfo objectInfo, string containerPath) : base(type, objectInfo, containerPath) { }
        public override string GetTypeName() { return "Motion"; }
    }
}
