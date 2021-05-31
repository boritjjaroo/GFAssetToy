using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFAssetLib.Object
{
    // version : 4
    // classID{115}: MonoScript <- TextAsset <- NamedObject <- EditorExtension <- Object     (That's not correct!!!)
    // classID{115}: MonoScript <- NamedObject <- EditorExtension <- Object
    //MonoScript Base // ByteOffset{0}, ByteSize{ffffffff}, Index{0}, IsArray{0}, MetaFlag{8000}
    //  string m_Name // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{1}, IsArray{0}, MetaFlag{8001}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{2}, IsArray{1}, MetaFlag{4001}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{3}, IsArray{0}, MetaFlag{1}
    //      char data // ByteOffset{ffffffff}, ByteSize{1}, Index{4}, IsArray{0}, MetaFlag{1}
    //  int m_ExecutionOrder // ByteOffset{54}, ByteSize{4}, Index{5}, IsArray{0}, MetaFlag{10}
    //  unsigned int m_PropertiesHash // ByteOffset{58}, ByteSize{4}, Index{6}, IsArray{0}, MetaFlag{10}
    //  string m_ClassName // ByteOffset{60}, ByteSize{ffffffff}, Index{7}, IsArray{0}, MetaFlag{8010}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{8}, IsArray{1}, MetaFlag{4011}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{9}, IsArray{0}, MetaFlag{11}
    //      char data // ByteOffset{ffffffff}, ByteSize{1}, Index{a}, IsArray{0}, MetaFlag{11}
    //  string m_Namespace // ByteOffset{7c}, ByteSize{ffffffff}, Index{b}, IsArray{0}, MetaFlag{8010}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{c}, IsArray{1}, MetaFlag{4011}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{d}, IsArray{0}, MetaFlag{11}
    //      char data // ByteOffset{ffffffff}, ByteSize{1}, Index{e}, IsArray{0}, MetaFlag{11}
    //  string m_AssemblyName // ByteOffset{98}, ByteSize{ffffffff}, Index{f}, IsArray{0}, MetaFlag{8010}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{10}, IsArray{1}, MetaFlag{4011}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{11}, IsArray{0}, MetaFlag{11}
    //      char data // ByteOffset{ffffffff}, ByteSize{1}, Index{12}, IsArray{0}, MetaFlag{11}
    //  bool m_IsEditorScript // ByteOffset{b4}, ByteSize{1}, Index{13}, IsArray{0}, MetaFlag{1}

    public class MonoScript : NamedObject
    {
        public MonoScript(Type type, ObjectInfo objectInfo, string containerPath) : base(type, objectInfo, containerPath)
        {
        }
        public override string GetTypeName() { return "MonoScript"; }

        public override void Read(AssetReader reader)
        {
            // MonoScript Base[V(4) S(-1) Array(False) 0x00008000]

            // string m_Name[V(1) S(-1) Array(False) 0x00008001]
            base.Read(reader);

            // int m_ExecutionOrder[V(1) S(4) Array(False) 0x00000010]
            reader.ReadInt32();
            // Hash128 m_PropertiesHash[V(1) S(16) Array(False) 0x00000010]
            reader.ReadBytes(16);
            // string m_ClassName[V(1) S(-1) Array(False) 0x00008010]
            reader.ReadString();
            // string m_Namespace[V(1) S(-1) Array(False) 0x00008010]
            reader.ReadString();
            // string m_AssemblyName[V(1) S(-1) Array(False) 0x00008010]
            reader.ReadString();
            // bool m_IsEditorScript[V(1) S(1) Array(False) 0x00000001]
            reader.ReadBoolean();
        }

        public override string Extract(AssetReader reader, string path)
        {
            var fullPath = $"{path}{ContainerPath}";
            var directory = Path.GetDirectoryName(fullPath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var fs = File.Open(fullPath, FileMode.Create);
            var writer = new AssetPrettyWriter(fs, 4);

            TypeHelper.PrettyPrint(reader, writer, type.TypeTree.GetNodes());

            writer.Close();
            return fs.Name;
        }
    }
}
