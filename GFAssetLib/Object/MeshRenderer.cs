using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    // version : 1
    // classID{23}: MeshRenderer <- Renderer <- Component <- EditorExtension <- Object
    //Renderer Base // ByteOffset{0}, ByteSize{ffffffff}, Index{0}, IsArray{0}, MetaFlag{8000}
    //  PPtr<GameObject> m_GameObject // ByteOffset{18}, ByteSize{8}, Index{1}, IsArray{0}, MetaFlag{10041}
    //    int m_FileID // ByteOffset{ffffffff}, ByteSize{4}, Index{2}, IsArray{0}, MetaFlag{10041}
    //    int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{3}, IsArray{0}, MetaFlag{10041}
    //  bool m_Enabled // ByteOffset{fc}, ByteSize{1}, Index{4}, IsArray{0}, MetaFlag{1}
    //  bool m_CastShadows // ByteOffset{32}, ByteSize{1}, Index{5}, IsArray{0}, MetaFlag{0}
    //  bool m_ReceiveShadows // ByteOffset{33}, ByteSize{1}, Index{6}, IsArray{0}, MetaFlag{0}
    //  UInt8 m_LightmapIndex // ByteOffset{31}, ByteSize{1}, Index{7}, IsArray{0}, MetaFlag{800001}
    //  Vector4f m_LightmapTilingOffset // ByteOffset{20}, ByteSize{10}, Index{8}, IsArray{0}, MetaFlag{a00001}
    //    float x // ByteOffset{20}, ByteSize{4}, Index{9}, IsArray{0}, MetaFlag{a00001}
    //    float y // ByteOffset{24}, ByteSize{4}, Index{a}, IsArray{0}, MetaFlag{a00001}
    //    float z // ByteOffset{28}, ByteSize{4}, Index{b}, IsArray{0}, MetaFlag{a00001}
    //    float w // ByteOffset{2c}, ByteSize{4}, Index{c}, IsArray{0}, MetaFlag{a00001}
    //  vector m_Materials // ByteOffset{cc}, ByteSize{ffffffff}, Index{d}, IsArray{0}, MetaFlag{0}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{e}, IsArray{1}, MetaFlag{0}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{f}, IsArray{0}, MetaFlag{0}
    //      PPtr<Material> data // ByteOffset{ffffffff}, ByteSize{8}, Index{10}, IsArray{0}, MetaFlag{0}
    //        int m_FileID // ByteOffset{ffffffff}, ByteSize{4}, Index{11}, IsArray{0}, MetaFlag{1}
    //        int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{12}, IsArray{0}, MetaFlag{1}
    //  vector m_SubsetIndices // ByteOffset{e0}, ByteSize{ffffffff}, Index{13}, IsArray{0}, MetaFlag{1}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{14}, IsArray{1}, MetaFlag{1}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{15}, IsArray{0}, MetaFlag{1}
    //      unsigned int data // ByteOffset{ffffffff}, ByteSize{4}, Index{16}, IsArray{0}, MetaFlag{1}
    //  PPtr<Transform> m_StaticBatchRoot // ByteOffset{f4}, ByteSize{8}, Index{17}, IsArray{0}, MetaFlag{1}
    //    int m_FileID // ByteOffset{f4}, ByteSize{4}, Index{18}, IsArray{0}, MetaFlag{1}
    //    int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{19}, IsArray{0}, MetaFlag{1}
    //  bool m_UseLightProbes // ByteOffset{fe}, ByteSize{1}, Index{1a}, IsArray{0}, MetaFlag{4000}
    //  PPtr<Transform> m_LightProbeAnchor // ByteOffset{100}, ByteSize{8}, Index{1b}, IsArray{0}, MetaFlag{4000}
    //    int m_FileID // ByteOffset{100}, ByteSize{4}, Index{1c}, IsArray{0}, MetaFlag{1}
    //    int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{1d}, IsArray{0}, MetaFlag{1}
    //  unsigned int m_SortingLayerID // ByteOffset{108}, ByteSize{4}, Index{1e}, IsArray{0}, MetaFlag{1}
    //  SInt16 m_SortingOrder // ByteOffset{10c}, ByteSize{2}, Index{1f}, IsArray{0}, MetaFlag{4001}

    public class MeshRenderer : Renderer
    {
        public MeshRenderer(int version, long dataOffset) : base(version, dataOffset) { }
        public override string GetTypeName() { return "MeshRenderer"; }
    }
}
