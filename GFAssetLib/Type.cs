using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GFAssetLib
{
    public abstract class Type
    {
        protected int version;
        public int Version { get => version; }
        protected bool hasTypeTrees;
        protected Int32 classID;
        public int ClassID { get => classID; }
        protected TypeTree typeTree;
        public TypeTree TypeTree { get => typeTree; }
        // 13 <= version
        protected byte[] typeHash;

        public static Type Create(int version, bool hasTypeTrees)
        {
            if (version < 13)
                return new TypeV1(version, hasTypeTrees);
            else if (13 <= version && version < 17)
                return new TypeV13(version, hasTypeTrees);
            else if (17 <= version)
                return new TypeV17(version, hasTypeTrees);
            throw new Exception();
        }

        public Type(int version, bool hasTypeTrees)
        {
            this.version = version;
            this.hasTypeTrees = hasTypeTrees;
        }

        public virtual void Read(AssetReader reader)
        {
        }

        public virtual void PrettyPrint(AssetPrettyWriter writer)
        {
        }

        public bool CheckTypeHash(byte[] hash) { return (typeHash != null) && typeHash.SequenceEqual(hash); }
        public bool CheckBaseObjectVersion(int version)
        {
            return typeTree.GetBaseObjectVersion() == version;
        }

        public int GetTypeVersion()
        {
            return typeTree.GetTypeVersion();
        }

        protected bool IsScriptType() { return (17 <= version && classID == 0x72) || (version < 17 && classID < 0); }
    }
}
