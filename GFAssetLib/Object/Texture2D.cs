using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    // version : 2
    // classID{28}: Texture2D <- Texture <- NamedObject <- EditorExtension <- Object


    //Texture2D Base[V(2) S(-1) Array(False) 0x00008000]
    //  string m_Name[V(1) S(-1) Array(False) 0x00008001]
    //    Array Array[V(1) S(-1) Array(True) 0x00004001]
    //      int size[V(1) S(4) Array(False) 0x00000001]
    //      char data[V(1) S(1) Array(False) 0x00000001]
    //  int m_ForcedFallbackFormat[V(1) S(4) Array(False) 0x00000000]
    //  bool m_DownscaleFallback[V(1) S(1) Array(False) 0x00004000]
    //  int m_Width[V(1) S(4) Array(False) 0x00000010]
    //  int m_Height[V(1) S(4) Array(False) 0x00000010]
    //  int m_CompleteImageSize[V(1) S(4) Array(False) 0x00000010]
    //  int m_TextureFormat[V(1) S(4) Array(False) 0x00000001]
    //  int m_MipCount[V(1) S(4) Array(False) 0x00000010]
    //  bool m_IsReadable[V(1) S(1) Array(False) 0x00004000]
    //  int m_ImageCount[V(1) S(4) Array(False) 0x00000010]
    //  int m_TextureDimension[V(1) S(4) Array(False) 0x00000001]
    //  GLTextureSettings m_TextureSettings[V(2) S(24) Array(False) 0x00000000]
    //    int m_FilterMode[V(1) S(4) Array(False) 0x00000000]
    //    int m_Aniso[V(1) S(4) Array(False) 0x00000000]
    //    float m_MipBias[V(1) S(4) Array(False) 0x00000000]
    //    int m_WrapU[V(1) S(4) Array(False) 0x00000000]
    //    int m_WrapV[V(1) S(4) Array(False) 0x00000000]
    //    int m_WrapW[V(1) S(4) Array(False) 0x00000000]
    //  int m_LightmapFormat[V(1) S(4) Array(False) 0x00000000]
    //    int m_ColorSpace[V(1) S(4) Array(False) 0x00000000]
    //  TypelessData image data[V(1) S(-1) Array(True) 0x00004001]
    //    int size[V(1) S(4) Array(False) 0x00000001]
    //    UInt8 data[V(1) S(1) Array(False) 0x00000001]
    //  StreamingInfo m_StreamData[V(1) S(-1) Array(False) 0x00008000]
    //    unsigned int offset[V(1) S(4) Array(False) 0x00000000]
    //    unsigned int size[V(1) S(4) Array(False) 0x00000000]
    //    string path[V(1) S(-1) Array(False) 0x00008000]
    //      Array Array[V(1) S(-1) Array(True) 0x00004001]
    //        int size[V(1) S(4) Array(False) 0x00000001]
    //        char data[V(1) S(1) Array(False) 0x00000001]

    //Texture2D Base // ByteOffset{0}, ByteSize{ffffffff}, Index{0}, IsArray{0}, MetaFlag{8000}
    //  string m_Name // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{1}, IsArray{0}, MetaFlag{8001}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{2}, IsArray{1}, MetaFlag{4001}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{3}, IsArray{0}, MetaFlag{1}
    //      char data // ByteOffset{ffffffff}, ByteSize{1}, Index{4}, IsArray{0}, MetaFlag{1}
    //  int m_Width // ByteOffset{60}, ByteSize{4}, Index{5}, IsArray{0}, MetaFlag{10}
    //  int m_Height // ByteOffset{64}, ByteSize{4}, Index{6}, IsArray{0}, MetaFlag{10}
    //  int m_CompleteImageSize // ByteOffset{6c}, ByteSize{4}, Index{7}, IsArray{0}, MetaFlag{10}
    //  int m_TextureFormat // ByteOffset{68}, ByteSize{4}, Index{8}, IsArray{0}, MetaFlag{1}
    //  bool m_MipMap // ByteOffset{88}, ByteSize{1}, Index{9}, IsArray{0}, MetaFlag{10}
    //  bool m_IsReadable // ByteOffset{8c}, ByteSize{1}, Index{a}, IsArray{0}, MetaFlag{0}
    //  bool m_ReadAllowed // ByteOffset{8d}, ByteSize{1}, Index{b}, IsArray{0}, MetaFlag{4010}
    //  int m_ImageCount // ByteOffset{74}, ByteSize{4}, Index{c}, IsArray{0}, MetaFlag{10}
    //  int m_TextureDimension // ByteOffset{78}, ByteSize{4}, Index{d}, IsArray{0}, MetaFlag{1}
    //  GLTextureSettings m_TextureSettings // ByteOffset{1c}, ByteSize{10}, Index{e}, IsArray{0}, MetaFlag{0}
    //    int m_FilterMode // ByteOffset{1c}, ByteSize{4}, Index{f}, IsArray{0}, MetaFlag{0}
    //    int m_Aniso // ByteOffset{20}, ByteSize{4}, Index{10}, IsArray{0}, MetaFlag{0}
    //    float m_MipBias // ByteOffset{24}, ByteSize{4}, Index{11}, IsArray{0}, MetaFlag{0}
    //    int m_WrapMode // ByteOffset{28}, ByteSize{4}, Index{12}, IsArray{0}, MetaFlag{0}
    //  int m_LightmapFormat // ByteOffset{30}, ByteSize{4}, Index{13}, IsArray{0}, MetaFlag{0}
    //  int m_ColorSpace // ByteOffset{34}, ByteSize{4}, Index{14}, IsArray{0}, MetaFlag{0}
    //  TypelessData image data // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{15}, IsArray{1}, MetaFlag{4001}
    //    int size // ByteOffset{ffffffff}, ByteSize{4}, Index{16}, IsArray{0}, MetaFlag{1}
    //    UInt8 data // ByteOffset{ffffffff}, ByteSize{1}, Index{17}, IsArray{0}, MetaFlag{1}

    public class Texture2D : Texture
    {
        public Texture2D(int version, long dataOffset, string containerPath) : base(version, dataOffset, containerPath) { }
        public override string GetTypeName() { return "Texture2D"; }
    }
}
