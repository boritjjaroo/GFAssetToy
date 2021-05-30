using System;
using System.Collections.Generic;
using System.Text;
using GFAssetLib.Object;

namespace GFAssetLib
{
    public class SerializedFile
    {
        string path;
        public string Path
        {
            get => path;
            set { path = value; }
        }
        AssetReader reader;

        SerializedFileHeader header;
        SerializedFileMetaData metadata;

        ObjectBase[] objects;

        public void Read(AssetReader reader)
        {
            this.reader = reader;
            header = new SerializedFileHeader();
            header.Read(reader);
            metadata = new SerializedFileMetaData(header.Version);
            reader.IsBigEndian = header.IsBigEndian;
            metadata.Read(reader);

        }

        public int GetObjectCount()
        {
            return metadata.GetObjectCount();
        }

        public ObjectBase ReadObject(int index)
        {
            if (objects == null)
                objects = new ObjectBase[metadata.GetObjectCount()];

            if (objects[index] == null)
            {
                reader.Position = header.ObjectDataOffset;
                reader.SetAlignBasePosition();
                objects[index] = metadata.ReadObject(index, reader);
            }

            return objects[index];
        }

        public string ExtractObject(int index, string path)
        {
            ObjectBase obj = ReadObject(index);
            if (obj == null)
                return null;

            reader.Position = header.ObjectDataOffset;
            reader.SetAlignBasePosition();
            return obj.Extract(reader, path);
        }

        public void PrettyPrint(AssetPrettyWriter writer)
        {
            writer.WriteLine($"AssetFile({path})");
            writer.IncreaseDepth();
            header.PrettyPrint(writer);
            metadata.PrettyPrint(writer);
            writer.DecreaseDepth();
        }
    }
}
