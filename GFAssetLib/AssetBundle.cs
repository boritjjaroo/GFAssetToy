using System;

namespace GFAssetLib
{
    // https://www.programmersought.com/article/61574758150/
    // https://github.com/HearthSim/UnityPack/wiki/Format-Documentation

    public class AssetBundle
    {
        private string bundlePath;
        public AssetBundleHeader header;
        public AssetBundleDataHeader dataHeader;
        public AssetBundleEntry entry;

        private byte[] blockData;

        public void LoadAssetBundle(string path)
        {
            this.bundlePath = path;
            AssetReader reader = new AssetReader(path);
            this.header = new AssetBundleHeader();
            this.header.Read(reader);

            if (0 < this.header.CompressedDataHeaderSize)
            {
                if (this.header.IsDataHeaderAtEndOfFile())
                    reader.Position = header.fileSize - header.CompressedDataHeaderSize;

                var dataHeaderBuf = AssetCompression.Decode(header.GetCompressionScheme(), reader, header.CompressedDataHeaderSize, header.DataHeaderSize);
                AssetReader headerReader = new AssetReader(dataHeaderBuf, 0);
                dataHeader = new AssetBundleDataHeader();
                dataHeader.Read(headerReader);

                entry = new AssetBundleEntry();
                entry.Read(headerReader);

                blockData = new byte[dataHeader.TotalSize];
                int blockDataIndex = 0;

                foreach (AssetBundleDataHeader.DataBlockInfo blockInfo in dataHeader.BlockInfos)
                {
                    var blockBuf = AssetCompression.Decode(blockInfo.GetCompressionScheme(), reader, blockInfo.compressedSize, blockInfo.size);
                    Buffer.BlockCopy(blockBuf, 0, blockData, blockDataIndex, (int)blockInfo.size);
                    blockDataIndex += (int)blockInfo.size;
                }
            }
            else
            {
                throw new Exception("Not supported format.");
            }
            reader.Close();
        }

        public SerializedFile LoadSerializedFile(int index)
        {
            if (index < 0 || entry.entries.Length <= index)
                throw new Exception("Out of bound.");

            // Do not close reader!!!
            AssetReader reader = new AssetReader(blockData, (long)entry.entries[index].offset);
            SerializedFile file = new SerializedFile(entry.entries[index].path, bundlePath);
            file.Read(reader);

            return file;
        }

        public void PrettyPrint(AssetPrettyWriter writer)
        {
            writer.WriteLine($"AssetBundle({this.bundlePath})");
            writer.IncreaseDepth();
            header.PrettyPrint(writer);
            dataHeader.PrettyPrint(writer);
            entry.PrettyPrint(writer);
            writer.DecreaseDepth();
        }

        public static int GetCompressionScheme(UInt32 flags) { return (int)(flags & 0x3F); }
    }
}
