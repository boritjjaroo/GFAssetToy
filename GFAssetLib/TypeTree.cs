using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    public abstract class TypeTree
    {
        protected int version;

        public static TypeTree Create(int version)
        {
            if (version < 10)
                return new TypeTreeV1(version);
            else if (version == 10)
                return new TypeTreeV10(version);
            else if (version == 11)
                return new TypeTreeV11(version);
            else
                return new TypeTreeV12(version);
        }

        public TypeTree(int version)
        {
            this.version = version;
        }

        public virtual void Read(AssetReader reader)
        {
        }

        public virtual void PrettyPrint(AssetPrettyWriter writer)
        {
        }

        public virtual int GetTypeVersion()
        {
            return 0;
        }

        public virtual string GetName(Int32 index)
        {
            if (index < 0)
            {
                index = index & 0x7FFFFFFF;
                return GFAssetLib.GetInstance().GetGlobalString(index);
            }
            return "";
        }
    }
}
