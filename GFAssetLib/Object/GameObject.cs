using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    // version : 3, 5
    //GameObject Base // ByteOffset{0}, ByteSize{ffffffff}, Index{0}, IsArray{0}, MetaFlag{8000}
    //  vector m_Component // ByteOffset{18}, ByteSize{ffffffff}, Index{1}, IsArray{0}, MetaFlag{10041}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{2}, IsArray{1}, MetaFlag{10041}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{3}, IsArray{0}, MetaFlag{10041}
    //      pair data // ByteOffset{ffffffff}, ByteSize{c}, Index{4}, IsArray{0}, MetaFlag{10041}
    //        int first // ByteOffset{ffffffff}, ByteSize{4}, Index{5}, IsArray{0}, MetaFlag{10041}
    //        PPtr<Component> second // ByteOffset{ffffffff}, ByteSize{8}, Index{6}, IsArray{0}, MetaFlag{10041}
    //          int m_FileID // ByteOffset{ffffffff}, ByteSize{4}, Index{7}, IsArray{0}, MetaFlag{10041}
    //          int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{8}, IsArray{0}, MetaFlag{10041}
    //  unsigned int m_Layer // ByteOffset{28}, ByteSize{4}, Index{9}, IsArray{0}, MetaFlag{0}
    //  string m_Name // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{a}, IsArray{0}, MetaFlag{8000}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{b}, IsArray{1}, MetaFlag{4001}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{c}, IsArray{0}, MetaFlag{1}
    //      char data // ByteOffset{ffffffff}, ByteSize{1}, Index{d}, IsArray{0}, MetaFlag{1}
    //  UInt16 m_Tag // ByteOffset{2c}, ByteSize{2}, Index{e}, IsArray{0}, MetaFlag{0}
    //  bool m_IsActive // ByteOffset{2e}, ByteSize{1}, Index{f}, IsArray{0}, MetaFlag{0}

    //TypeHash = A3 72 64 68 34 BC AF 26 EA B1 D2 1B 29 E3 95 53
    //  GameObject Base  [V(5) S(-1) Array(False) 0x00008000]
    //    vector m_Component    [V(1) S(-1) Array(False) 0x00008041]
    //        Array Array       [V(1) S(-1) Array(True) 0x00004041]
    //        int size          [V(1) S(4) Array(False) 0x00000041]
    //        ComponentPair data    [V(1) S(12) Array(False) 0x00000041]
    //            PPtr<Component> component  [V(1) S(12) Array(False) 0x00000041]
    //            int m_FileID               [V(1) S(4) Array(False) 0x00000041]
    //            SInt64 m_PathID            [V(1) S(8) Array(False) 0x00000041]
    //    unsigned int m_Layer  [V(1) S(4) Array(False) 0x00000000]
    //    string m_Name         [V(1) S(-1) Array(False) 0x00008000]
    //        Array Array       [V(1) S(-1) Array(True) 0x00004001]
    //        int size          [V(1) S(4) Array(False) 0x00000001]
    //        char data         [V(1) S(1) Array(False) 0x00000001]
    //    UInt16 m_Tag      [V(1) S(2) Array(False) 0x00000000]
    //    bool m_IsActive   [V(1) S(1) Array(False) 0x00000000]

    public class GameObject : EditorExtension
    {
        public GameObject(Type type, ObjectInfo objectInfo, string containerPath) : base(type, objectInfo, containerPath) { }
        public override string GetTypeName() { return "GameObject"; }
    }
}
