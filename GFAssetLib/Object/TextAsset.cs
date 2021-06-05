using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFAssetLib.Object
{
    // classID{49}: TextAsset <- NamedObject <- EditorExtension <- Object
    // TextAsset Base // ByteOffset{0}, ByteSize{ffffffff}, Index{0}, IsArray{0}, MetaFlag{8000}

    // NamedObject
    //string m_Name // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{1}, IsArray{0}, MetaFlag{8001}
    //  Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{2}, IsArray{1}, MetaFlag{4001}
    //    int size // ByteOffset{ffffffff}, ByteSize{4}, Index{3}, IsArray{0}, MetaFlag{1}
    //    char data // ByteOffset{ffffffff}, ByteSize{1}, Index{4}, IsArray{0}, MetaFlag{1}

    // version 1
    //string m_Script // ByteOffset{38}, ByteSize{ffffffff}, Index{5}, IsArray{0}, MetaFlag{8001}
    //  Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{6}, IsArray{1}, MetaFlag{4001}
    //    int size // ByteOffset{ffffffff}, ByteSize{4}, Index{7}, IsArray{0}, MetaFlag{1}
    //    char data // ByteOffset{ffffffff}, ByteSize{1}, Index{8}, IsArray{0}, MetaFlag{1}

    // version ?
    //string m_PathName // ByteOffset{1c}, ByteSize{ffffffff}, Index{9}, IsArray{0}, MetaFlag{8001}
    //  Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{a}, IsArray{1}, MetaFlag{4001}
    //    int size // ByteOffset{ffffffff}, ByteSize{4}, Index{b}, IsArray{0}, MetaFlag{1}
    //    char data // ByteOffset{ffffffff}, ByteSize{1}, Index{c}, IsArray{0}, MetaFlag{1}

    public class TextAsset : NamedObject
    {
        string script;
        string pathName;

        public TextAsset(Type type, ObjectInfo dataOffset, string containerPath) : base(type, dataOffset, containerPath) { }
        public override string GetTypeName() { return "TextAsset"; }
        public override int GetContentsSize() { return script.Length; }

        public override void Read(AssetReader reader)
        {
            base.Read(reader);

            this.script = reader.ReadTypeString();

            if (type.GetTypeVersion() <= 1)
                return;

            this.pathName = reader.ReadTypeString();
        }

        public override string ExtractContents(AssetReader reader, string path)
        {
            string fullPath = $"{path}{ContainerPath}";
            string directory = Path.GetDirectoryName(fullPath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            FileStream fs = File.Open(fullPath, FileMode.Create);
            StreamWriter writer = new StreamWriter(fs);
            writer.Write(this.script);
            writer.Close();
            return fs.Name;
        }
    }
}
