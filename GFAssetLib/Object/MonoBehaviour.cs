using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFAssetLib.Object
{
    // version : 1

    // MonoBehaviour <- Behaviour <- Component <- EditorExtension <- Object
    public class MonoBehaviour : Behaviour
    {
        public static new MonoBehaviour Create(Type type, ObjectInfo objectInfo, string containerPath)
        {
            if (type.GetTypeVersion() == 1)
            {
                if (type.CheckTypeHash(MonoBehaviour1.TypeHash))
                    return new MonoBehaviour1(type, objectInfo, containerPath);
                else
                    return new MonoBehaviour(type, objectInfo, containerPath);
            }
            throw new Exception("Not implemented.");
        }

        string name;

        public MonoBehaviour(Type type, ObjectInfo objectInfo, string containerPath) : base(type, objectInfo, containerPath)
        {
        }

        public override string GetTypeName() { return "MonoBehaviour"; }

        public override void Read(AssetReader reader)
        {
            // MonoBehaviour Base  [V(1) S(-1) Array(False) 0x00008000]

            base.Read(reader);

            // PPtr<GameObject> m_GameObject  [V(1) S(12) Array(False) 0x00000041]
            //   int m_FileID                 [V(1) S(4) Array(False) 0x00000041]
            //   SInt64 m_PathID              [V(1) S(8) Array(False) 0x00000041]
            reader.ReadTypePPtr();
            // UInt8 m_Enabled            [V(1) S(1) Array(False) 0x00004101]
            reader.ReadTypeUInt8();
            // PPtr<MonoScript> m_Script  [V(1) S(12) Array(False) 0x00000000]
            //   int m_FileID             [V(1) S(4) Array(False) 0x00800001]
            //   SInt64 m_PathID          [V(1) S(8) Array(False) 0x00800001]
            reader.ReadTypePPtr();
            // string m_Name  [V(1) S(-1) Array(False) 0x00008001]
            //   Array Array  [V(1) S(-1) Array(True) 0x00004001]
            //     int size   [V(1) S(4) Array(False) 0x00000001]
            //     char data  [V(1) S(1) Array(False) 0x00000001]
            name = reader.ReadTypeString();

            // ----------------------------------------------------------------
            // It seems to be common part so far.

        }

    }


    public class MonoBehaviour1 : MonoBehaviour
    {
        static public byte[] TypeHash = new byte[] { 0x4F, 0x0C, 0x93, 0x64, 0x03, 0x83, 0x35, 0xAF, 0x7C, 0x13, 0x8A, 0xA8, 0x69, 0x16, 0x17, 0xE0 };

        long dataOffset;
        int dataSize;

        public MonoBehaviour1(Type type, ObjectInfo objectInfo, string containerPath) : base(type, objectInfo, containerPath)
        {
        }

        public override void Read(AssetReader reader)
        {
            // MonoBehaviour Base  [V(1) S(-1) Array(False) 0x00008000]

            // PPtr<GameObject> m_GameObject  [V(1) S(12) Array(False) 0x00000041]
            //   int m_FileID                 [V(1) S(4) Array(False) 0x00000041]
            //   SInt64 m_PathID              [V(1) S(8) Array(False) 0x00000041]
            // UInt8 m_Enabled            [V(1) S(1) Array(False) 0x00004101]
            // PPtr<MonoScript> m_Script  [V(1) S(12) Array(False) 0x00000000]
            //   int m_FileID             [V(1) S(4) Array(False) 0x00800001]
            //   SInt64 m_PathID          [V(1) S(8) Array(False) 0x00800001]
            // string m_Name  [V(1) S(-1) Array(False) 0x00008001]
            //   Array Array  [V(1) S(-1) Array(True) 0x00004001]
            //     int size   [V(1) S(4) Array(False) 0x00000001]
            //     char data  [V(1) S(1) Array(False) 0x00000001]
            base.Read(reader);

            // vector _bytes   [V(1) S(-1) Array(False) 0x0000C000]
            //   Array Array   [V(1) S(-1) Array(True) 0x00004000]
            //     int size    [V(1) S(4) Array(False) 0x00000000]
            //     UInt8 data  [V(1) S(1) Array(False) 0x00000000]
            dataSize = reader.ReadInt32();
            dataOffset = reader.Position;
        }

        public override string ExtractContents(AssetReader reader, string path)
        {
            reader.Position = dataOffset;
            var dataBuf = reader.ReadBytes(dataSize);

            var fullPath = $"{path}{ContainerPath}";
            var directory = Path.GetDirectoryName(fullPath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var fs = File.Open(fullPath, FileMode.Create);
            var writer = new BinaryWriter(fs);
            writer.Write(dataBuf);
            writer.Close();
            return fs.Name;
        }
    }
}
