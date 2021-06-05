using System;
using System.IO;
using System.Text;

namespace GFAssetLib.Object
{
    public abstract class ObjectBase
    {
        protected Type type;
        public Type Type { get => type; }
        protected ObjectInfo objectInfo;
        public long DataOffset { get => objectInfo.DataOffset; }
        private string containerPath;
        public string ContainerPath { get => containerPath; }

        public static int ASSET_BUNDLE = 142;

        public static ObjectBase Create(Type type, ObjectInfo objectInfo, string containerPath)
        {
            int classID = type.ClassID;
            int typeVersion = type.GetTypeVersion();

            switch (classID)
            {
                case 1:
                    if (typeVersion == 3 || typeVersion == 5)
                        return new GameObject(type, objectInfo, containerPath);
                    break;
                case 4:
                    if (typeVersion == 1)
                        return new Transform(type, objectInfo, containerPath);
                    break;
                case 23:
                    if (typeVersion == 1)
                        return new MeshRenderer(type, objectInfo, containerPath);
                    break;
                case 28:
                    return Texture2D.Create(type, objectInfo, containerPath);
                case 33:
                    if (typeVersion == 1)
                        return new MeshFilter(type, objectInfo, containerPath);
                    break;
                case 49: // 0x31
                    if (typeVersion == 1)
                        return new TextAsset(type, objectInfo, containerPath);
                    break;
                case 74:
                    if (typeVersion == 6)
                        return new AnimationClip(type, objectInfo, containerPath);
                    break;
                case 95:
                    if (typeVersion == 3)
                        return new Animator(type, objectInfo, containerPath);
                    break;
                case 114:
                    return MonoBehaviour.Create(type, objectInfo, containerPath);
                case 115:
                    if (typeVersion == 4)
                        return new MonoScript(type, objectInfo, containerPath);
                    break;
                case 142:
                    if (typeVersion == 3)
                        return new AssetBundle(type, objectInfo, containerPath);
                    break;
                case 213:
                    if (typeVersion == 1)
                        return new Sprite(type, objectInfo, containerPath);
                    break;
            }
            throw new Exception("Not implemented.");
            //return null;
        }

        public ObjectBase(Type type, ObjectInfo objectInfo, string containerPath)
        {
            this.type = type;
            this.objectInfo = objectInfo;
            this.containerPath = containerPath;
        }

        public virtual void Read(AssetReader reader) {}

        public virtual string ExtractContents(AssetReader reader, string path) { return "Not Implemented."; }

        public virtual string Extract(AssetReader reader, string path)
        {
            var savePath = ContainerPath;
            //if (ContainerPath == null || ContainerPath.Length == 0)
            //    throw new Exception("Invalid path name.");
            if (savePath == null || savePath.Length == 0)
            {
                savePath = GetName();
            }
            if (savePath == null || savePath.Length == 0)
            {
                savePath = GetTypeName();
            }

            var fullPath = $"{path}{savePath}";
            var directory = Path.GetDirectoryName(fullPath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var fs = File.Open(fullPath, FileMode.Create);
            var writer = new AssetPrettyWriter(fs, 4);

            TypeTreeNode[] nodes = type.TypeTree.GetNodes();
            TypeHelper.PrettyPrint(reader, writer, nodes, 0, nodes.Length);

            writer.Close();
            return fs.Name;
        }

        public virtual string Extract(AssetReader reader)
        {
            var memStream = new MemoryStream();
            var writer = new AssetPrettyWriter(memStream, 4);

            TypeTreeNode[] nodes = type.TypeTree.GetNodes();
            TypeHelper.PrettyPrint(reader, writer, nodes, 0, nodes.Length);

            writer.Close();
            return Encoding.UTF8.GetString(memStream.ToArray());
        }

        public virtual string GetName() { return null; }

        public virtual string GetTypeName() { return "Object"; }

        public virtual int GetContentsSize() { return 0; }

    }
}
