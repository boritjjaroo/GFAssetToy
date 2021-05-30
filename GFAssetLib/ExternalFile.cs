using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    public class ExternalFile
    {
        int version;
        public int Version { get => version; }

        string assetName;

        byte[] guid;
        Int32 type;

        string fileName;

        string unknown;

        public ExternalFile(int version)
        {
            this.version = version;
        }

        public void Read(AssetReader reader)
        {
            if (6 <= version)
                assetName = reader.ReadNullTerminatedString(256);

            if (5 <= version)
            {
                guid = reader.ReadBytes(4 * 4);
                type = reader.ReadInt32();
            }

            fileName = reader.ReadNullTerminatedString(1024);

            if (5 <= version)
                unknown = reader.ReadNullTerminatedString(256);
        }

        public void PrettyPrint(AssetPrettyWriter writer)
        {
            if (6 <= version)
                writer.WriteLine($"AssetName = {assetName}");

            if (5 <= version)
            {
                writer.WriteLine($"GUID = {BitConverter.ToString(guid).Replace('-',' ')}");
                writer.WriteLine($"Type = {type}");
            }

            writer.WriteLine($"FileName = {fileName}");

            if (5 <= version)
                writer.WriteLine($"Unknown = {unknown}");
        }
    }
}
