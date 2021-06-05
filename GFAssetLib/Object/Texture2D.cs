using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using TextureWrapper;

namespace GFAssetLib.Object
{
    // classID{28}: Texture2D <- Texture <- NamedObject <- EditorExtension <- Object

    public class Texture2D : Texture
    {
        static public byte[] TypeHash = new byte[] { 0x1E, 0x87, 0xD8, 0x2D, 0x4F, 0xD0, 0x58, 0x50, 0x9A, 0x3C, 0x78, 0x66, 0xDB, 0x0E, 0x73, 0x56 };

        public static new Texture2D Create(Type type, ObjectInfo objectInfo, string containerPath)
        {
            if (type.GetTypeVersion() == 2)
            {
                if (type.CheckTypeHash(Texture2D.TypeHash))
                    return new Texture2D(type, objectInfo, containerPath);
            }
            throw new Exception("Not implemented.");
        }

        int imageWidth;
        int imageHeight;
        int textureFormat;
        long imageDataOffset;
        int imageDataSize;

        public Texture2D(Type type, ObjectInfo objectInfo, string containerPath) : base(type, objectInfo, containerPath) { }
        public override string GetTypeName() { return "Texture2D"; }

        public override void Read(AssetReader reader)
        {
            // Texture2D Base  [V(2) S(-1) Array(False) 0x00008000]
            //   string m_Name  [V(1) S(-1) Array(False) 0x00008001]
            //     Array Array  [V(1) S(-1) Array(True) 0x00004001]
            //       int size   [V(1) S(4) Array(False) 0x00000001]
            //       char data  [V(1) S(1) Array(False) 0x00000001]
            base.Read(reader);

            //   int m_ForcedFallbackFormat  [V(1) S(4) Array(False) 0x00000000]
            reader.ReadInt32();
            //   bool m_DownscaleFallback    [V(1) S(1) Array(False) 0x00004000]
            reader.ReadTypeBool();
            //   int m_Width   [V(1) S(4) Array(False) 0x00000010]
            imageWidth = reader.ReadInt32();
            //   int m_Height  [V(1) S(4) Array(False) 0x00000010]
            imageHeight = reader.ReadInt32();
            //   int m_CompleteImageSize  [V(1) S(4) Array(False) 0x00000010]
            reader.ReadInt32();
            //   int m_TextureFormat      [V(1) S(4) Array(False) 0x00000001]
            textureFormat = reader.ReadInt32();
            //   int m_MipCount           [V(1) S(4) Array(False) 0x00000010]
            reader.ReadInt32();
            //   bool m_IsReadable        [V(1) S(1) Array(False) 0x00004000]
            reader.ReadTypeBool();
            //   int m_ImageCount         [V(1) S(4) Array(False) 0x00000010]
            reader.ReadInt32();
            //   int m_TextureDimension   [V(1) S(4) Array(False) 0x00000001]
            reader.ReadInt32();
            //   GLTextureSettings m_TextureSettings   [V(2) S(24) Array(False) 0x00000000]
            //     int m_FilterMode                    [V(1) S(4) Array(False) 0x00000000]
            reader.ReadInt32();
            //     int m_Aniso                         [V(1) S(4) Array(False) 0x00000000]
            reader.ReadInt32();
            //     float m_MipBias                     [V(1) S(4) Array(False) 0x00000000]
            reader.ReadFloat();
            //     int m_WrapU                         [V(1) S(4) Array(False) 0x00000000]
            reader.ReadInt32();
            //     int m_WrapV                         [V(1) S(4) Array(False) 0x00000000]
            reader.ReadInt32();
            //     int m_WrapW                         [V(1) S(4) Array(False) 0x00000000]
            reader.ReadInt32();
            //   int m_LightmapFormat      [V(1) S(4) Array(False) 0x00000000]
            reader.ReadInt32();
            //   int m_ColorSpace          [V(1) S(4) Array(False) 0x00000000]
            reader.ReadInt32();
            //   TypelessData image data   [V(1) S(-1) Array(True) 0x00004001]
            //     int size                [V(1) S(4) Array(False) 0x00000001]
            imageDataSize = reader.ReadInt32();
            //     UInt8 data              [V(1) S(1) Array(False) 0x00000001]
            imageDataOffset = reader.Position;
            //   StreamingInfo m_StreamData    [V(1) S(-1) Array(False) 0x00008000]
            //     unsigned int offset         [V(1) S(4) Array(False) 0x00000000]
            //     unsigned int size           [V(1) S(4) Array(False) 0x00000000]
            //     string path                 [V(1) S(-1) Array(False) 0x00008000]
            //       Array Array               [V(1) S(-1) Array(True) 0x00004001]
            //         int size                [V(1) S(4) Array(False) 0x00000001]
            //         char data               [V(1) S(1) Array(False) 0x00000001]
        }

        public override string Extract(AssetReader reader)
        {
            var memStream = new MemoryStream();
            var writer = new AssetPrettyWriter(memStream, 4);

            TypeHelper.PrettyPrint(reader, writer, type.TypeTree.GetNodes(), 0, 21);

            writer.Close();
            return Encoding.UTF8.GetString(memStream.ToArray());
        }

        public override string ExtractContents(AssetReader reader, string path)
        {
            reader.Position = imageDataOffset;
            var dataBuf = reader.ReadBytes(imageDataSize);
            byte[] imageBuf;

            if (this.textureFormat == (int)TextureFormat.ETC2_RGBA8)
            {
                imageBuf = new byte[imageWidth * imageHeight * 4];
                TextureDecoder.DecodeETC2A8(dataBuf, imageWidth, imageHeight, imageBuf);
            }
            else if (this.textureFormat == (int)TextureFormat.RGBA32)
            {
                imageBuf = dataBuf;
            }
            else
            {
                throw new Exception("Not implemented.");
            }

            var fullPath = $"{path}{ContainerPath}";
            var directory = Path.GetDirectoryName(fullPath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            using (var image = Image.LoadPixelData<Rgba32>(imageBuf, imageWidth, imageHeight))
            {
                image.SaveAsPng(fullPath);
            }

            return fullPath;
        }
    }

    public enum TextureFormat
    {
        Alpha8 = 1,
        ARGB4444,
        RGB24,
        RGBA32,
        ARGB32,
        RGB565 = 7,
        R16 = 9,
        DXT1,
        DXT5 = 12,
        RGBA4444,
        BGRA32,
        RHalf,
        RGHalf,
        RGBAHalf,
        RFloat,
        RGFloat,
        RGBAFloat,
        YUY2,
        RGB9e5Float,
        BC4 = 26,
        BC5,
        BC6H = 24,
        BC7,
        DXT1Crunched = 28,
        DXT5Crunched,
        PVRTC_RGB2,
        PVRTC_RGBA2,
        PVRTC_RGB4,
        PVRTC_RGBA4,
        ETC_RGB4,
        ATC_RGB4,
        ATC_RGBA8,
        EAC_R = 41,
        EAC_R_SIGNED,
        EAC_RG,
        EAC_RG_SIGNED,
        ETC2_RGB,
        ETC2_RGBA1,
        ETC2_RGBA8,
        ASTC_RGB_4x4,
        ASTC_RGB_5x5,
        ASTC_RGB_6x6,
        ASTC_RGB_8x8,
        ASTC_RGB_10x10,
        ASTC_RGB_12x12,
        ASTC_RGBA_4x4,
        ASTC_RGBA_5x5,
        ASTC_RGBA_6x6,
        ASTC_RGBA_8x8,
        ASTC_RGBA_10x10,
        ASTC_RGBA_12x12,
        ETC_RGB4_3DS,
        ETC_RGBA8_3DS,
        RG16,
        R8,
        ETC_RGB4Crunched,
        ETC2_RGBA8Crunched,
        ASTC_HDR_4x4,
        ASTC_HDR_5x5,
        ASTC_HDR_6x6,
        ASTC_HDR_8x8,
        ASTC_HDR_10x10,
        ASTC_HDR_12x12,
        RG32,
        RGB48,
        RGBA64
    }
}
