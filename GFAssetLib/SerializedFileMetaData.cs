using GFAssetLib.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib
{
    public class SerializedFileMetaData
    {
        int version;
        string generatorVersion;
        Int32 platform;

        bool hasTypeTrees;
        Int32 numTypes;
        Type[] types;

        Int32 unknown1;

        Int32 numObjectInfos;
        ObjectInfo[] objectInfos;

        Int32 numAdds;
        Add[] adds;

        Int32 numExternalFiles;
        ExternalFile[] externalFiles;

        public SerializedFileMetaData(int version)
        {
            this.version = version;
        }

        public void Read(AssetReader reader)
        {
            reader.SetAlignBasePosition();

            generatorVersion = reader.ReadNullTerminatedString(256);
            platform = reader.ReadInt32();
            if (13 <= version)
            {
                hasTypeTrees = 0 < reader.ReadByte();
                numTypes = reader.ReadInt32();

                types = new Type[numTypes];
                for (int i = 0; i < numTypes; i++)
                {
                    types[i] = Type.Create(version, hasTypeTrees);
                    types[i].Read(reader);
                }
            }
            else
            {
                throw new Exception("Not implemented.");
            }

            if (7 <= version && version <= 13)
            {
                unknown1 = reader.ReadInt32();
            }

            numObjectInfos = reader.ReadInt32();

            objectInfos = new ObjectInfo[numObjectInfos];
            for (int i = 0; i < numObjectInfos; i++)
            {
                if (14 <= version)
                    reader.MoveToAlignedPosition(4);

                objectInfos[i] = new ObjectInfo(version);
                objectInfos[i].Read(reader);
            }

            numAdds = reader.ReadInt32();

            adds = new Add[numAdds];
            for (int i = 0; i < numAdds; i++)
            {
                adds[i] = new Add(version);
                adds[i].Read(reader);
            }

            numExternalFiles = reader.ReadInt32();

            externalFiles = new ExternalFile[numExternalFiles];
            for (int i = 0; i < numExternalFiles; i++)
            {
                externalFiles[i] = new ExternalFile(version);
                externalFiles[i].Read(reader);
            }
        }

        public int GetObjectCount()
        {
            if (objectInfos == null)
                return 0;
            return objectInfos.Length;
        }

        public ObjectBase ReadObject(int index, AssetReader reader)
        {
            if (index < 0 || objectInfos.Length <= index)
                return null;

            Type type = FindType(objectInfos[index]);
            if (type == null)
                return null;

            ObjectBase obj = ObjectBase.Create(type.ClassID, type.GetTypeVersion(), objectInfos[index].DataOffset);
            reader.Position += objectInfos[index].DataOffset;
            obj.Read(reader);
            return obj;
        }

        private Type FindType(ObjectInfo objectInfo)
        {
            if (version < 17)
            {
                for (int i = 0; i < types.Length; i++)
                {
                    if (objectInfo.TypeID == types[i].ClassID)
                        return types[i];
                }
            }
            else
            {
                return types[objectInfo.TypeIndex];
            }
            return null;
        }

        public void PrettyPrint(AssetPrettyWriter writer)
        {
            writer.WriteLine("SerializedFileMetaData");
            writer.IncreaseDepth();
            writer.WriteLine($"GeneratorVersion = {this.generatorVersion}");
            writer.WriteLine($"Platform = {this.platform}");
            writer.WriteLine($"HasTypeTrees = {this.hasTypeTrees}");
            writer.WriteLine($"NumTypes = {this.numTypes}");
            for (int i = 0; i < numTypes; i++)
            {
                writer.WriteLine($"TypeV{types[i].Version}[{i}]");
                writer.IncreaseDepth();
                types[i].PrettyPrint(writer);
                writer.DecreaseDepth();
            }
            writer.DecreaseDepth();
            if (7 <= version && version <= 13)
                writer.WriteLine($"Unknown1 = {this.unknown1}");

            writer.WriteLine($"NumObjectInfos = {this.numObjectInfos}");
            //for (int i = 0; i < numObjectInfos; i++)
            //{
            //    writer.WriteLine($"ObjectInfoV{objectInfos[i].Version}[{i}]");
            //    writer.IncreaseDepth();
            //    objectInfos[i].PrettyPrint(writer);
            //    writer.DecreaseDepth();
            //}

            writer.WriteLine($"NumAdds = {this.numAdds}");
            for (int i = 0; i < numAdds; i++)
            {
                writer.WriteLine($"AddV{adds[i].Version}[{i}]");
                writer.IncreaseDepth();
                adds[i].PrettyPrint(writer);
                writer.DecreaseDepth();
            }

            writer.WriteLine($"NumExternalFiles = {this.numExternalFiles}");
            for (int i = 0; i < numExternalFiles; i++)
            {
                writer.WriteLine($"AddV{externalFiles[i].Version}[{i}]");
                writer.IncreaseDepth();
                externalFiles[i].PrettyPrint(writer);
                writer.DecreaseDepth();
            }
        }
    }
}
