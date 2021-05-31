using K4os.Compression.LZ4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFAssetLib
{
    public class AssetCompression
    {
        public static byte[] Decode(int compressionScheme, AssetReader reader, long compSize, long decompSize)
        {
            switch (compressionScheme)
            {
                case AssetBundleHeader.COMPRESSION_NONE:
                    return reader.ReadBytes((int)decompSize);
                case AssetBundleHeader.COMPRESSION_LZMA:
                    return DecodeLZMA(reader.BaseStream, compSize, decompSize);
                case AssetBundleHeader.COMPRESSION_LZ4:
                    {
                        byte[] compressed = reader.ReadBytes((int)compSize);
                        byte[] decompressed = new byte[decompSize];

                        int size = LZ4Codec.Decode(compressed, 0, (int)compSize, decompressed, 0, (int)decompSize);
                        if (size < 0 || size != (int)decompSize)
                            throw new Exception("Invalid format. (LZ4 compressed Data block is invalid.)");
                        return decompressed;
                    }
            }
            throw new Exception("Invalid compressed data.");
        }

        private static byte[] DecodeLZMA(Stream input, long compSize, long decompSize)
        {
            long inputPosition = input.Position;
            SevenZip.Compression.LZMA.Decoder decoder = new SevenZip.Compression.LZMA.Decoder();
            var properties = new byte[5];
            if (input.Read(properties, 0, 5) != 5)
                throw new Exception("Invalid LZMA format.");
            decoder.SetDecoderProperties(properties);
            var output = new MemoryStream();
            decoder.Code(input, output, compSize - 5, decompSize, null);
            input.Position = inputPosition + compSize;
            output.Flush();
            return output.GetBuffer();
        }
    }
}
