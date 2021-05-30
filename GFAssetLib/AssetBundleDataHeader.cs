using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    public class AssetBundleDataHeader
    {
        public class DataBlockInfo
        {
            public UInt32 size;
            public UInt32 compressedSize;
            public UInt16 flags;
        }

        byte[] blockDataHash;
        private int blockCount;
        public int BlockCount { get => blockCount; }
        UInt64 totalCompressedSize;
        public UInt64 TotalCompressedSize { get => totalCompressedSize; }
        UInt64 totalSize;
        public UInt64 TotalSize { get => totalSize; }
        DataBlockInfo[] blockInfos;
        public DataBlockInfo[] BlockInfos { get => blockInfos; }

        public void Read(AssetReader reader)
        {
            this.blockDataHash = reader.ReadBytes(16);
            this.blockCount = (int)reader.ReadUInt32();

            this.totalCompressedSize = 0;
            this.totalSize = 0;
            blockInfos = new DataBlockInfo[this.blockCount];
            for (int i = 0; i < this.blockCount; i++)
            {
                blockInfos[i] = new DataBlockInfo();
                blockInfos[i].size = reader.ReadUInt32();
                blockInfos[i].compressedSize = reader.ReadUInt32();
                blockInfos[i].flags = reader.ReadUInt16();

                this.totalCompressedSize += blockInfos[i].compressedSize;
                this.totalSize += blockInfos[i].size;
            }
        }

        public void PrettyPrint(AssetPrettyWriter writer)
        {
            writer.WriteLine("AssetBundleDataHeader");
            writer.IncreaseDepth();
            writer.WriteLine($"Hash : {BitConverter.ToString(this.blockDataHash).Replace('-', ' ')}");
            writer.WriteLine($"Block Count = {this.blockCount}");
            writer.WriteLine($"Total Compressed Size = {this.totalCompressedSize}");
            writer.WriteLine($"Total Size = {this.totalSize}");
            writer.DecreaseDepth();
        }
    }
}
