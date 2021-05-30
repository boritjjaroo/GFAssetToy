using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    public class AssetBundleEntry
    {
        public class EntryInfo
        {
            public UInt64 offset;
            public UInt64 size;
            public UInt32 flags;
            public string path;
        }

        private int count;
        public EntryInfo[] entries;

        public void Read(AssetReader reader)
        {
            this.count = (int)reader.ReadUInt32();
            entries = new EntryInfo[this.count];

            for (int i = 0; i < this.count; i++)
            {
                entries[i] = new EntryInfo();
                entries[i].offset = reader.ReadUInt64();
                entries[i].size = reader.ReadUInt64();
                entries[i].flags = reader.ReadUInt32();
                entries[i].path = reader.ReadNullTerminatedString(256);
            }
        }

        public void PrettyPrint(AssetPrettyWriter writer)
        {
            writer.WriteLine("AssetBundleEntry");
            writer.IncreaseDepth();
            writer.WriteLine($"Count = {this.count}");
            for (int i = 0; i < this.count; i++)
            {
                writer.WriteLine($"Entry[{i}]");
                writer.IncreaseDepth();
                writer.WriteLine($"offset = {entries[i].offset}");
                writer.WriteLine($"size = {entries[i].size}");
                writer.WriteLine($"flags = {entries[i].flags:X8}");
                writer.WriteLine($"path = {entries[i].path}");
                writer.DecreaseDepth();
            }
            writer.DecreaseDepth();
        }
    }
}
