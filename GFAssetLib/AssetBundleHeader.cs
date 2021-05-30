using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    public class AssetBundleHeader
    {
        private const string SIGNATURE_FS = "UnityFS";
        private const string SIGNATURE_WEB = "UnityWeb";
        private const string SIGNATURE_RAW = "UnityRaw";

        public const UInt32 COMPRESSION_NONE = 0;
        public const UInt32 COMPRESSION_LZMA = 1;
        public const UInt32 COMPRESSION_LZ4 = 3;

        private string signature;
        private UInt32 formatVersion;
        private string targetVersion;
        private string generatorVersion;
        //private byte[] guid;
        private UInt32 unknown1;
        public UInt32 fileSize;
        public UInt32 FileSize { get => fileSize; }
        private UInt32 compressedDataHeaderSize;
        public UInt32 CompressedDataHeaderSize { get => compressedDataHeaderSize; }
        private UInt32 uncompressedDataHeaderSize;
        public UInt32 DataHeaderSize { get => uncompressedDataHeaderSize;  }
        // (UnityFS) flags
        //  0x100 = <unknown>
        //   0x80 = data header at end of file
        //   0x40 = entry info present
        //   0x3f = low six bits are data header compression method
        //             0 = none
        //             1 = LZMA
        //             3 = LZ4
        private UInt32 flags;

        public AssetBundleHeader()
        {
            signature = "";
            formatVersion = 0;
            targetVersion = "";
            generatorVersion = "";
            //guid = null;
            unknown1 = 0;
            fileSize = 0;
            compressedDataHeaderSize = 0;
            uncompressedDataHeaderSize = 0;
            flags = 0;
        }

        public void Read(AssetReader reader)
        {
            this.signature = reader.ReadNullTerminatedString(16);
            if (this.signature == SIGNATURE_FS)
            {
                this.formatVersion = reader.ReadUInt32();
                this.targetVersion = reader.ReadNullTerminatedString(256);
                this.generatorVersion = reader.ReadNullTerminatedString(256);

                if (4 <= this.formatVersion)
                {
                    //this.guid = reader.ReadBytes(16);
                    this.unknown1 = reader.ReadUInt32();
                }
                this.fileSize = reader.ReadUInt32();
                this.compressedDataHeaderSize = reader.ReadUInt32();
                this.uncompressedDataHeaderSize = reader.ReadUInt32();
                this.flags = reader.ReadUInt32();
            }
            else
            {
                throw new Exception("Not supported format");
            }
        }

        public void PrettyPrint(AssetPrettyWriter writer)
        {
            writer.WriteLine("AssetBundleHeader");
            writer.IncreaseDepth();
            writer.WriteLine($"Signature = \"{this.signature}\"");
            writer.WriteLine($"FormatVersion = {this.formatVersion}");
            writer.WriteLine($"TargetVersion = {this.targetVersion}");
            writer.WriteLine($"GeneratorVersion = {this.generatorVersion}");
            if (4 <= this.formatVersion)
            {
                //writer.WriteLine($"GUID = {BitConverter.ToString(this.guid).Replace('-', ' ')}");
                writer.WriteLine($"Unknown1 = {this.unknown1}");
            }
            writer.WriteLine($"FileSize = {this.fileSize}");
            writer.WriteLine($"CompressedDataHeaderSize = {this.compressedDataHeaderSize}");
            writer.WriteLine($"UncompressedDataHeaderSize = {this.uncompressedDataHeaderSize}");
            //writer.WriteLine($"Flags = {BitConverter.ToString(this.flags).Replace('-', ' ')}");
            writer.WriteLine($"Flags = {this.flags}");
            writer.IncreaseDepth();
            string flags = "(";
            switch (GetDataHeaderCompressionScheme())
            {
                case COMPRESSION_NONE:
                    flags += "Compression : None";
                    break;
                case COMPRESSION_LZMA:
                    flags += "Compression : LZMA";
                    break;
                case COMPRESSION_LZ4:
                    flags += "Compression : LZ4";
                    break;
                default:
                    flags += "Compression : Invalid";
                    break;
            }
            flags += $", DataHeaderAtEndOfFile : {IsDataHeaderAtEndOfFile()}";
            flags += $", EntryInfo : {IsEntryInfoPresent()}";
            flags += ")";
            writer.WriteLine(flags);
            writer.DecreaseDepth();
            writer.DecreaseDepth();
        }

        public UInt32 GetDataHeaderCompressionScheme() { return (this.flags & 0x3f); }

        public bool IsDataHeaderAtEndOfFile() { return (flags & 0x80) != 0; }

        public bool IsEntryInfoPresent() { return (this.signature == SIGNATURE_FS) ? ((this.flags & 0x40) != 0) : true; }
    }
}
