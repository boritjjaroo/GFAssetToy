using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    public abstract class ObjectBase
    {
        protected int version;
        protected long dataOffset;
        private string containerPath;
        public string ContainerPath { get => containerPath; }

        public static int ASSET_BUNDLE = 142;

        public static ObjectBase Create(int classID, int version, long dataOffset, string containerPath)
        {
            switch (classID)
            {
                case 1:
                    if (version == 3 || version == 5)
                        return new GameObject(version, dataOffset, containerPath);
                    break;
                case 4:
                    if (version == 1)
                        return new Transform(version, dataOffset, containerPath);
                    break;
                case 23:
                    if (version == 1)
                        return new MeshRenderer(version, dataOffset, containerPath);
                    break;
                case 28:
                    if (version == 2)
                        return new Texture2D(version, dataOffset, containerPath);
                    break;
                case 33:
                    if (version == 1)
                        return new MeshFilter(version, dataOffset, containerPath);
                    break;
                case 49: // 0x31
                    if (version == 1)
                        return new TextAsset(version, dataOffset, containerPath);
                    break;
                case 74:
                    if (version == 6)
                        return new AnimationClip(version, dataOffset, containerPath);
                    break;
                case 95:
                    if (version == 3)
                        return new Animator(version, dataOffset, containerPath);
                    break;
                case 114:
                    if (version == 1)
                        return new MonoBehaviour(version, dataOffset, containerPath);
                    break;
                case 115:
                    if (version == 4)
                        return new MonoScript(version, dataOffset, containerPath);
                    break;
                case 142:
                    if (version == 3)
                        return new AssetBundle(version, dataOffset, containerPath);
                    break;
                case 213:
                    if (version == 1)
                        return new Sprite(version, dataOffset, containerPath);
                    break;
            }
            throw new Exception("Not implemented.");
            //return null;
        }

        public ObjectBase(int version, long dataOffset, string containerPath)
        {
            this.version = version;
            this.dataOffset = dataOffset;
            this.containerPath = containerPath;
        }

        public virtual void Read(AssetReader reader) {}

        public virtual string Extract(AssetReader reader, string path) { return null; }

        public virtual string GetName() { return null; }

        public virtual string GetTypeName() { return "Object"; }

        public virtual int GetContentsSize() { return 0; }
    }
}
