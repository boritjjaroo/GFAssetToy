using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public abstract class ObjectBase
    {
        protected int version;
        protected long dataOffset;

        public static ObjectBase Create(int classID, int version, long dataOffset)
        {
            switch (classID)
            {
                case 1:
                    if (version == 3 || version == 5)
                        return new GameObject(version, dataOffset);
                    break;
                case 4:
                    if (version == 1)
                        return new Transform(version, dataOffset);
                    break;
                case 23:
                    if (version == 1)
                        return new MeshRenderer(version, dataOffset);
                    break;
                case 28:
                    if (version == 2)
                        return new Texture2D(version, dataOffset);
                    break;
                case 33:
                    if (version == 1)
                        return new MeshFilter(version, dataOffset);
                    break;
                case 49: // 0x31
                    if (version == 1)
                        return new TextAsset(version, dataOffset);
                    break;
                case 74:
                    if (version == 6)
                        return new AnimationClip(version, dataOffset);
                    break;
                case 95:
                    if (version == 3)
                        return new Animator(version, dataOffset);
                    break;
                case 114:
                    if (version == 1)
                        return new MonoBehaviour(version, dataOffset);
                    break;
                case 115:
                    if (version == 4)
                        return new MonoScript(version, dataOffset);
                    break;
                case 142:
                    if (version == 3)
                        return new AssetBundle(version, dataOffset);
                    break;
                case 213:
                    if (version == 1)
                        return new Sprite(version, dataOffset);
                    break;
            }
            throw new Exception("Not implemented.");
            //return null;
        }

        public ObjectBase(int version, long dataOffset)
        {
            this.version = version;
            this.dataOffset = dataOffset;
        }

        public virtual void Read(AssetReader reader) {}

        public virtual string Extract(AssetReader reader, string path) { return null; }

        public virtual string GetName() { return null; }

        public virtual string GetTypeName() { return "Object"; }

        public virtual int GetContentsSize() { return 0; }
    }
}
