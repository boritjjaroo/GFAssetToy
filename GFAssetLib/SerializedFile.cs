using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GFAssetLib.Object;

namespace GFAssetLib
{
    public class SerializedFile
    {
        string bundlePath;
        string path;
        AssetReader reader;

        SerializedFileHeader header;
        SerializedFileMetaData metadata;

        ObjectBase[] objects;
        Object.AssetBundle assetBundle;

        public SerializedFile(string path, string bundlePath)
        {
            this.path = path;
            this.bundlePath = bundlePath;
        }

        public void Read(AssetReader reader)
        {
            this.reader = reader;
            header = new SerializedFileHeader();
            header.Read(reader);
            metadata = new SerializedFileMetaData(header.Version);
            reader.IsBigEndian = header.IsBigEndian;
            metadata.Read(reader);

            assetBundle = (Object.AssetBundle)ReadObject(metadata.AssetBundleIndex, true);
        }

        public int GetObjectCount()
        {
            return metadata.GetObjectCount();
        }

        public ObjectBase ReadObject(int index)
        {
            return ReadObject(index, false);
        }

        private ObjectBase ReadObject(int index, bool isAssetBundle)
        {
            if (objects == null)
                objects = new ObjectBase[metadata.GetObjectCount()];

            if (objects[index] == null)
            {
                reader.Position = header.ObjectDataOffset;
                reader.SetAlignBasePosition();

                ObjectInfo objectInfo = metadata.GetObjectInfo(index);
                Type type = metadata.FindType(objectInfo);
                if (type == null)
                    return null;

                string containerPath = "";
                if (!isAssetBundle)
                {
                    containerPath = assetBundle.GetContainerPath(objectInfo.ObjectID);
                }

                ObjectBase obj = ObjectBase.Create(type, objectInfo, containerPath);
                reader.Position += objectInfo.DataOffset;
                obj.Read(reader);
                objects[index] = obj;
            }

            return objects[index];
        }

        public string ExtractObjectContents(int index, string path = null)
        {
            ObjectBase obj = ReadObject(index);
            if (obj == null)
                return null;

            if (path == null)
            {
                path = $"{Path.GetDirectoryName(bundlePath)}\\";
            }
            reader.Position = header.ObjectDataOffset;
            reader.Position += obj.DataOffset;
            reader.SetAlignBasePosition();
            return obj.ExtractContents(reader, path);
        }

        public string ExtractObject(int index, string path = null)
        {
            ObjectBase obj = ReadObject(index);
            if (obj == null)
                return null;

            if (path == null)
            {
                path = $"{Path.GetDirectoryName(bundlePath)}\\";
            }
            reader.Position = header.ObjectDataOffset;
            reader.Position += obj.DataOffset;
            reader.SetAlignBasePosition();
            return obj.Extract(reader, path);
        }

        public string ExtractObjectToString(int index)
        {
            ObjectBase obj = ReadObject(index);
            if (obj == null)
                return null;

            reader.Position = header.ObjectDataOffset;
            reader.Position += obj.DataOffset;
            reader.SetAlignBasePosition();
            return obj.Extract(reader);
        }

        public void PrettyPrint(AssetPrettyWriter writer)
        {
            writer.WriteLine($"SerializedFile({path})");
            writer.IncreaseDepth();
            header.PrettyPrint(writer);
            metadata.PrettyPrint(writer);
            writer.DecreaseDepth();
        }
    }
}
