using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    public class Add
    {
        int version;
        public int Version { get => version; }

        Int32 fileID;
        Int64 pathID;

        public Add(int version)
        {
            this.version = version;
        }

        public void Read(AssetReader reader)
        {
            fileID = reader.ReadInt32();

            if (14 <= version)
            {
                reader.MoveToAlignedPosition(4);
                pathID = reader.ReadInt64();
            }
            else
            {
                pathID = reader.ReadInt32();
            }
        }

        public void PrettyPrint(AssetPrettyWriter writer)
        {
            writer.WriteLine($"FileID = {fileID}");
            writer.WriteLine($"PathID = {pathID}");
        }
    }
}
