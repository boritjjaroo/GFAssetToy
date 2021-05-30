﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public class AssetBundle : NamedObject
    {
        public AssetBundle(int version, long dataOffset) : base(version, dataOffset)
        {
        }
        public override string GetTypeName() { return "AssetBundle"; }
    }
}