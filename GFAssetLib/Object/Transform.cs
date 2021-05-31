using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    // version : 1
    //Transform Base // ByteOffset{0}, ByteSize{ffffffff}, Index{0}, IsArray{0}, MetaFlag{0}
    //  PPtr<GameObject> m_GameObject // ByteOffset{18}, ByteSize{8}, Index{1}, IsArray{0}, MetaFlag{10041}
    //    int m_FileID // ByteOffset{ffffffff}, ByteSize{4}, Index{2}, IsArray{0}, MetaFlag{10041}
    //    int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{3}, IsArray{0}, MetaFlag{10041}
    //  Quaternionf m_LocalRotation // ByteOffset{1c}, ByteSize{10}, Index{4}, IsArray{0}, MetaFlag{200800}
    //    float x // ByteOffset{1c}, ByteSize{4}, Index{5}, IsArray{0}, MetaFlag{200800}
    //    float y // ByteOffset{20}, ByteSize{4}, Index{6}, IsArray{0}, MetaFlag{200800}
    //    float z // ByteOffset{24}, ByteSize{4}, Index{7}, IsArray{0}, MetaFlag{200800}
    //    float w // ByteOffset{28}, ByteSize{4}, Index{8}, IsArray{0}, MetaFlag{200800}
    //  Vector3f m_LocalPosition // ByteOffset{2c}, ByteSize{c}, Index{9}, IsArray{0}, MetaFlag{200800}
    //    float x // ByteOffset{2c}, ByteSize{4}, Index{a}, IsArray{0}, MetaFlag{200800}
    //    float y // ByteOffset{30}, ByteSize{4}, Index{b}, IsArray{0}, MetaFlag{200800}
    //    float z // ByteOffset{34}, ByteSize{4}, Index{c}, IsArray{0}, MetaFlag{200800}
    //  Vector3f m_LocalScale // ByteOffset{38}, ByteSize{c}, Index{d}, IsArray{0}, MetaFlag{200800}
    //    float x // ByteOffset{38}, ByteSize{4}, Index{e}, IsArray{0}, MetaFlag{200800}
    //    float y // ByteOffset{3c}, ByteSize{4}, Index{f}, IsArray{0}, MetaFlag{200800}
    //    float z // ByteOffset{40}, ByteSize{4}, Index{10}, IsArray{0}, MetaFlag{200800}
    //  vector m_Children // ByteOffset{8c}, ByteSize{ffffffff}, Index{11}, IsArray{0}, MetaFlag{10041}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{12}, IsArray{1}, MetaFlag{10041}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{13}, IsArray{0}, MetaFlag{10041}
    //      PPtr<Transform> data // ByteOffset{ffffffff}, ByteSize{8}, Index{14}, IsArray{0}, MetaFlag{10041}
    //        int m_FileID // ByteOffset{ffffffff}, ByteSize{4}, Index{15}, IsArray{0}, MetaFlag{10041}
    //        int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{16}, IsArray{0}, MetaFlag{10041}
    //  PPtr<Transform> m_Father // ByteOffset{a0}, ByteSize{8}, Index{17}, IsArray{0}, MetaFlag{10001}
    //    int m_FileID // ByteOffset{ffffffff}, ByteSize{4}, Index{18}, IsArray{0}, MetaFlag{10001}
    //    int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{19}, IsArray{0}, MetaFlag{10001}

    public class Transform : Component
    {
        public Transform(Type type, ObjectInfo objectInfo, string containerPath) : base(type, objectInfo, containerPath)
        {
        }
        public override string GetTypeName() { return "Transform"; }
    }
}
