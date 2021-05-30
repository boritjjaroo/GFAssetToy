using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    // version : 1
    // classID{33}: MeshFilter <- Component <- EditorExtension <- Object
    //MeshFilter Base // ByteOffset{0}, ByteSize{10}, Index{0}, IsArray{0}, MetaFlag{0}
    //  PPtr<GameObject> m_GameObject // ByteOffset{18}, ByteSize{8}, Index{1}, IsArray{0}, MetaFlag{10041}
    //    int m_FileID // ByteOffset{ffffffff}, ByteSize{4}, Index{2}, IsArray{0}, MetaFlag{10041}
    //    int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{3}, IsArray{0}, MetaFlag{10041}
    //  PPtr<Mesh> m_Mesh // ByteOffset{1c}, ByteSize{8}, Index{4}, IsArray{0}, MetaFlag{800}
    //    int m_FileID // ByteOffset{1c}, ByteSize{4}, Index{5}, IsArray{0}, MetaFlag{801}
    //    int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{6}, IsArray{0}, MetaFlag{801}

    public class MeshFilter : Component
    {
        public MeshFilter(int version, long dataOffset) : base(version, dataOffset) { }
        public override string GetTypeName() { return "MeshFilter"; }
    }
}
