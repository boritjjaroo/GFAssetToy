using K4os.Compression.LZ4;
using System;
using System.IO;

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

                AssetReader headerReader;
                switch (header.GetDataHeaderCompressionScheme())
                {
                    case AssetBundleHeader.COMPRESSION_NONE:
                        headerReader = reader;
                        break;
                    case AssetBundleHeader.COMPRESSION_LZMA:
                        throw new Exception("Not implemented.");
                        //break;
                    case AssetBundleHeader.COMPRESSION_LZ4:
                        byte[] compressed = reader.ReadBytes((int)header.CompressedDataHeaderSize);
                        byte[] decompressed = new byte[header.DataHeaderSize];

                        int size = LZ4Codec.Decode(compressed, 0, (int)header.CompressedDataHeaderSize, decompressed, 0, (int)header.DataHeaderSize);
                        if (size < 0 || size != (int)header.DataHeaderSize)
                            throw new Exception("Invalid format. (LZ4 compressed DataHeader is invalid.)");
                        headerReader = new AssetReader(decompressed, 0);
                        break;
                    default:
                        throw new Exception("Invalid format. (Unknown compression scheme.)");
                }

                dataHeader = new AssetBundleDataHeader();
                dataHeader.Read(headerReader);

                entry = new AssetBundleEntry();
                entry.Read(headerReader);

                blockData = new byte[dataHeader.TotalSize];
                int blockDataIndex = 0;

                foreach (AssetBundleDataHeader.DataBlockInfo blockInfo in dataHeader.BlockInfos)
                {
                    switch (header.GetDataHeaderCompressionScheme())
                    {
                        case AssetBundleHeader.COMPRESSION_NONE:
                            throw new Exception("Not implemented.");
                            //break;
                        case AssetBundleHeader.COMPRESSION_LZMA:
                            throw new Exception("Not implemented.");
                            //break;
                        case AssetBundleHeader.COMPRESSION_LZ4:
                            byte[] compressed = reader.ReadBytes((int)blockInfo.compressedSize);
                            byte[] decompressed = new byte[blockInfo.size];

                            int size = LZ4Codec.Decode(compressed, 0, (int)blockInfo.compressedSize, decompressed, 0, (int)blockInfo.size);
                            if (size < 0 || size != (int)blockInfo.size)
                                throw new Exception("Invalid format. (LZ4 compressed Data block is invalid.)");

                            Buffer.BlockCopy(decompressed, 0, blockData, blockDataIndex, (int)blockInfo.size);
                            blockDataIndex += (int)blockInfo.size;
                            break;
                    }
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
    }
}
