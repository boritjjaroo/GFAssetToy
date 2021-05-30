using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    public class ObjectInfo
    {
        int version;

        Int64 objectID;
        Int32 dataOffset;
        public long DataOffset { get => dataOffset; }
        Int32 dataSize;
        public int DataSize { get => dataSize; }

        // version < 17
        Int32 typeID;
        Int16 classID;
        public int TypeID { get => typeID; }
        // 17 <= version
        Int32 typeIndex;
        public int TypeIndex { get => typeIndex; }

        Int16 isDestroyed;
        Int16 unknown1;
        byte unknown2;

        public int Version { get => version; }

        public ObjectInfo(int version)
        {
            this.version = version;
            this.unknown1 = -1;
            this.unknown2 = 0;
        }

        public void Read(AssetReader reader)
        {
            if (14 <= version)
                objectID = reader.ReadInt64();
            else
                objectID = reader.ReadInt32();

            dataOffset = reader.ReadInt32();
            dataSize = reader.ReadInt32();

            if (version < 17)
            {
                typeID = reader.ReadInt32();
                classID = reader.ReadInt16();
            }
            else
            {
                typeIndex = reader.ReadInt32();
            }

            if (version <= 10)
                isDestroyed = reader.ReadInt16();
            if (11 <= version && version <= 16)
                unknown1 = reader.ReadInt16();
            if (15 <= version && version <= 16)
                unknown2 = reader.ReadByte();
        }

        public void PrettyPrint(AssetPrettyWriter writer)
        {
            writer.WriteLine($"ObjectID = {objectID}");
            writer.WriteLine($"DataOffset = {dataOffset}");
            writer.WriteLine($"DataSize = {dataSize}");
            if (version < 17)
            {
                writer.WriteLine($"TypeID = {typeID}");
                writer.WriteLine($"ClassID = {classID}");
            }
            else
            {
                writer.WriteLine($"TypeIndex = {typeIndex}");
            }
            if (version <= 10)
                writer.WriteLine($"IsDestroyed = {isDestroyed}");
            if (11 <= version && version <= 16)
                writer.WriteLine($"Unknown1 = {unknown1}");
            if (15 <= version && version <= 16)
                writer.WriteLine($"Unknown2 = {unknown2}");
        }
    }
}
