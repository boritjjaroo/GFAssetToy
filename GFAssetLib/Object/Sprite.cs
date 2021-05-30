using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    // version : 1
    // classID{213}: Sprite <- NamedObject <- EditorExtension <- Object
    //Sprite Base // ByteOffset{0}, ByteSize{ffffffff}, Index{0}, IsArray{0}, MetaFlag{8000}
    //  string m_Name // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{1}, IsArray{0}, MetaFlag{8001}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{2}, IsArray{1}, MetaFlag{4001}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{3}, IsArray{0}, MetaFlag{1}
    //      char data // ByteOffset{ffffffff}, ByteSize{1}, Index{4}, IsArray{0}, MetaFlag{1}
    //  Rectf m_Rect // ByteOffset{1c}, ByteSize{10}, Index{5}, IsArray{0}, MetaFlag{0}
    //    float x // ByteOffset{1c}, ByteSize{4}, Index{6}, IsArray{0}, MetaFlag{0}
    //    float y // ByteOffset{20}, ByteSize{4}, Index{7}, IsArray{0}, MetaFlag{0}
    //    float width // ByteOffset{24}, ByteSize{4}, Index{8}, IsArray{0}, MetaFlag{0}
    //    float height // ByteOffset{28}, ByteSize{4}, Index{9}, IsArray{0}, MetaFlag{0}
    //  Vector2f m_Offset // ByteOffset{2c}, ByteSize{8}, Index{a}, IsArray{0}, MetaFlag{200000}
    //    float x // ByteOffset{2c}, ByteSize{4}, Index{b}, IsArray{0}, MetaFlag{200000}
    //    float y // ByteOffset{30}, ByteSize{4}, Index{c}, IsArray{0}, MetaFlag{200000}
    //  Vector4f m_Border // ByteOffset{34}, ByteSize{10}, Index{d}, IsArray{0}, MetaFlag{200000}
    //    float x // ByteOffset{34}, ByteSize{4}, Index{e}, IsArray{0}, MetaFlag{200000}
    //    float y // ByteOffset{38}, ByteSize{4}, Index{f}, IsArray{0}, MetaFlag{200000}
    //    float z // ByteOffset{3c}, ByteSize{4}, Index{10}, IsArray{0}, MetaFlag{200000}
    //    float w // ByteOffset{40}, ByteSize{4}, Index{11}, IsArray{0}, MetaFlag{200000}
    //  float m_PixelsToUnits // ByteOffset{98}, ByteSize{4}, Index{12}, IsArray{0}, MetaFlag{0}
    //  unsigned int m_Extrude // ByteOffset{9c}, ByteSize{4}, Index{13}, IsArray{0}, MetaFlag{0}
    //  SpriteRenderData m_RD // ByteOffset{44}, ByteSize{ffffffff}, Index{14}, IsArray{0}, MetaFlag{c000}
    //    PPtr<Texture2D> texture // ByteOffset{44}, ByteSize{8}, Index{15}, IsArray{0}, MetaFlag{0}
    //      int m_FileID // ByteOffset{44}, ByteSize{4}, Index{16}, IsArray{0}, MetaFlag{1}
    //      int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{17}, IsArray{0}, MetaFlag{1}
    //    vector vertices // ByteOffset{48}, ByteSize{ffffffff}, Index{18}, IsArray{0}, MetaFlag{0}
    //      Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{19}, IsArray{1}, MetaFlag{0}
    //        int size // ByteOffset{ffffffff}, ByteSize{4}, Index{1a}, IsArray{0}, MetaFlag{0}
    //        SpriteVertex data // ByteOffset{ffffffff}, ByteSize{c}, Index{1b}, IsArray{0}, MetaFlag{0}
    //          Vector3f pos // ByteOffset{ffffffff}, ByteSize{c}, Index{1c}, IsArray{0}, MetaFlag{200000}
    //            float x // ByteOffset{ffffffff}, ByteSize{4}, Index{1d}, IsArray{0}, MetaFlag{200000}
    //            float y // ByteOffset{ffffffff}, ByteSize{4}, Index{1e}, IsArray{0}, MetaFlag{200000}
    //            float z // ByteOffset{ffffffff}, ByteSize{4}, Index{1f}, IsArray{0}, MetaFlag{200000}
    //    vector indices // ByteOffset{58}, ByteSize{ffffffff}, Index{20}, IsArray{0}, MetaFlag{4000}
    //      Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{21}, IsArray{1}, MetaFlag{0}
    //        int size // ByteOffset{ffffffff}, ByteSize{4}, Index{22}, IsArray{0}, MetaFlag{0}
    //        UInt16 data // ByteOffset{ffffffff}, ByteSize{2}, Index{23}, IsArray{0}, MetaFlag{0}
    //    Rectf textureRect // ByteOffset{68}, ByteSize{10}, Index{24}, IsArray{0}, MetaFlag{0}
    //      float x // ByteOffset{68}, ByteSize{4}, Index{25}, IsArray{0}, MetaFlag{0}
    //      float y // ByteOffset{6c}, ByteSize{4}, Index{26}, IsArray{0}, MetaFlag{0}
    //      float width // ByteOffset{70}, ByteSize{4}, Index{27}, IsArray{0}, MetaFlag{0}
    //      float height // ByteOffset{74}, ByteSize{4}, Index{28}, IsArray{0}, MetaFlag{0}
    //    Vector2f textureRectOffset // ByteOffset{78}, ByteSize{8}, Index{29}, IsArray{0}, MetaFlag{200000}
    //      float x // ByteOffset{78}, ByteSize{4}, Index{2a}, IsArray{0}, MetaFlag{200000}
    //      float y // ByteOffset{7c}, ByteSize{4}, Index{2b}, IsArray{0}, MetaFlag{200000}
    //    unsigned int settingsRaw // ByteOffset{80}, ByteSize{4}, Index{2c}, IsArray{0}, MetaFlag{0}
    //    Vector4f uvTransform // ByteOffset{84}, ByteSize{10}, Index{2d}, IsArray{0}, MetaFlag{200000}
    //      float x // ByteOffset{84}, ByteSize{4}, Index{2e}, IsArray{0}, MetaFlag{200000}
    //      float y // ByteOffset{88}, ByteSize{4}, Index{2f}, IsArray{0}, MetaFlag{200000}
    //      float z // ByteOffset{8c}, ByteSize{4}, Index{30}, IsArray{0}, MetaFlag{200000}
    //      float w // ByteOffset{90}, ByteSize{4}, Index{31}, IsArray{0}, MetaFlag{200000}

    public class Sprite : NamedObject
    {
        public Sprite(int version, long dataOffset) : base(version, dataOffset) { }
        public override string GetTypeName() { return "Sprite"; }
    }
}
