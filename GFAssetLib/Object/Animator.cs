using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    // version : 3
    // classID{95}: Animator <- Behaviour <- Component <- EditorExtension <- Object
    //Animator Base // ByteOffset{0}, ByteSize{23}, Index{0}, IsArray{0}, MetaFlag{8000}
    //  PPtr<GameObject> m_GameObject // ByteOffset{18}, ByteSize{8}, Index{1}, IsArray{0}, MetaFlag{10041}
    //    int m_FileID // ByteOffset{ffffffff}, ByteSize{4}, Index{2}, IsArray{0}, MetaFlag{10041}
    //    int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{3}, IsArray{0}, MetaFlag{10041}
    //  UInt8 m_Enabled // ByteOffset{1c}, ByteSize{1}, Index{4}, IsArray{0}, MetaFlag{4101}
    //  PPtr<Avatar> m_Avatar // ByteOffset{34}, ByteSize{8}, Index{5}, IsArray{0}, MetaFlag{0}
    //    int m_FileID // ByteOffset{34}, ByteSize{4}, Index{6}, IsArray{0}, MetaFlag{1}
    //    int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{7}, IsArray{0}, MetaFlag{1}
    //  PPtr<RuntimeAnimatorController> m_Controller // ByteOffset{38}, ByteSize{8}, Index{8}, IsArray{0}, MetaFlag{0}
    //    int m_FileID // ByteOffset{38}, ByteSize{4}, Index{9}, IsArray{0}, MetaFlag{1}
    //    int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{a}, IsArray{0}, MetaFlag{1}
    //  int m_CullingMode // ByteOffset{2c}, ByteSize{4}, Index{b}, IsArray{0}, MetaFlag{0}
    //  int m_UpdateMode // ByteOffset{30}, ByteSize{4}, Index{c}, IsArray{0}, MetaFlag{0}
    //  bool m_ApplyRootMotion // ByteOffset{139}, ByteSize{1}, Index{d}, IsArray{0}, MetaFlag{804000}
    //  bool m_HasTransformHierarchy // ByteOffset{1ac}, ByteSize{1}, Index{e}, IsArray{0}, MetaFlag{800000}

    public class Animator : Behaviour
    {
        public Animator(Type type, ObjectInfo objectInfo, string containerPath) : base(type, objectInfo, containerPath) { }
        public override string GetTypeName() { return "Animator"; }
    }
}
