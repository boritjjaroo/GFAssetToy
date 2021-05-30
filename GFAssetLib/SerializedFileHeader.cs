using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    public class SerializedFileHeader
    {
        Int32 metaDataSize;
        UInt32 fileSize;
        Int32 version;
        public int Version { get => (int)version; }
        UInt32 objectDataOffset;
        public long ObjectDataOffset { get => objectDataOffset; }
        bool isBigEndian;
        public bool IsBigEndian { get => isBigEndian; }

        public void Read(AssetReader reader)
        {
            metaDataSize = reader.ReadInt32();
            fileSize = reader.ReadUInt32();
            version = reader.ReadInt32();
            objectDataOffset = reader.ReadUInt32();
            if (9 <= version)
            {
                isBigEndian = 0 < reader.ReadByte();
                // read off paddings
                reader.ReadBytes(3);
            }
            else
            {
                isBigEndian = true;
            }
        }

        public void PrettyPrint(AssetPrettyWriter writer)
        {
            writer.WriteLine("SerializedFileHeader");
            writer.IncreaseDepth();
            writer.WriteLine($"MetaDataSize = {this.metaDataSize}");
            writer.WriteLine($"FileSize = {this.fileSize}");
            writer.WriteLine($"Version = {this.version}");
            writer.WriteLine($"ObjectDataOffset = {this.objectDataOffset}");
            writer.WriteLine($"IsBigEndian = {this.isBigEndian}");
            writer.DecreaseDepth();
        }
    }
}
