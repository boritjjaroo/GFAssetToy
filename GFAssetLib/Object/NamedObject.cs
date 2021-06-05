using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    //string m_Name // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{1}, IsArray{0}, MetaFlag{8001}
    //  Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{2}, IsArray{1}, MetaFlag{4001}
    //    int size // ByteOffset{ffffffff}, ByteSize{4}, Index{3}, IsArray{0}, MetaFlag{1}
    //    char data // ByteOffset{ffffffff}, ByteSize{1}, Index{4}, IsArray{0}, MetaFlag{1}
    public class NamedObject : EditorExtension
    {
        string name;

        public NamedObject(Type type, ObjectInfo objectInfo, string containerPath) : base(type, objectInfo, containerPath) { }
        public override string GetTypeName() { return "NamedObject"; }

        public override void Read(AssetReader reader)
        {
            base.Read(reader);
            this.name = reader.ReadTypeString();
        }
        public override string GetName()
        {
            return name;
        }
    }
}
