using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    // version : 1
    //MonoBehaviour Base // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{0}, IsArray{0}, MetaFlag{8000}
    //  PPtr<GameObject> m_GameObject // ByteOffset{18}, ByteSize{8}, Index{1}, IsArray{0}, MetaFlag{10041}
    //    int m_FileID // ByteOffset{ffffffff}, ByteSize{4}, Index{2}, IsArray{0}, MetaFlag{10041}
    //    int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{3}, IsArray{0}, MetaFlag{10041}
    //  UInt8 m_Enabled // ByteOffset{1c}, ByteSize{1}, Index{4}, IsArray{0}, MetaFlag{4101}
    //  PPtr<MonoScript> m_Script // ByteOffset{ffffffff}, ByteSize{8}, Index{5}, IsArray{0}, MetaFlag{0}
    //    int m_FileID // ByteOffset{ffffffff}, ByteSize{4}, Index{6}, IsArray{0}, MetaFlag{1}
    //    int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{7}, IsArray{0}, MetaFlag{1}
    //  string m_Name // ByteOffset{24}, ByteSize{ffffffff}, Index{8}, IsArray{0}, MetaFlag{8001}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{9}, IsArray{1}, MetaFlag{4001}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{a}, IsArray{0}, MetaFlag{1}
    //      char data // ByteOffset{ffffffff}, ByteSize{1}, Index{b}, IsArray{0}, MetaFlag{1}

    public class MonoBehaviour : Behaviour
    {
        public MonoBehaviour(int version, long dataOffset, string containerPath) : base(version, dataOffset, containerPath)
        {
        }

        public override string GetTypeName() { return "MonoBehaviour"; }
    }
}
