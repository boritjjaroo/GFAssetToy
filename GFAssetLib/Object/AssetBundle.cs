using System;
using System.Collections.Generic;
using System.Text;

namespace GFAssetLib.Object
{
    // version : 3
    //AssetBundle Base[V(3) S(-1) Array(False) 0x00008000]
    //  string m_Name[V(1) S(-1) Array(False) 0x00008001]
    //    Array Array[V(1) S(-1) Array(True) 0x00004001]
    //      int size[V(1) S(4) Array(False) 0x00000001]
    //      char data[V(1) S(1) Array(False) 0x00000001]
    //  vector m_PreloadTable[V(1) S(-1) Array(False) 0x00008000]
    //    Array Array[V(1) S(-1) Array(True) 0x00004000]
    //      int size[V(1) S(4) Array(False) 0x00000000]
    //      PPtr<Object> data[V(1) S(12) Array(False) 0x00000000]
    //        int m_FileID[V(1) S(4) Array(False) 0x00800001]
    //        SInt64 m_PathID[V(1) S(8) Array(False) 0x00800001]
    //  map m_Container[V(1) S(-1) Array(False) 0x00008000]
    //    Array Array[V(1) S(-1) Array(True) 0x00008000]
    //      int size[V(1) S(4) Array(False) 0x00000000]
    //      pair data[V(1) S(-1) Array(False) 0x00008000]
    //        string first[V(1) S(-1) Array(False) 0x00008000]
    //          Array Array[V(1) S(-1) Array(True) 0x00004001]
    //            int size[V(1) S(4) Array(False) 0x00000001]
    //            char data[V(1) S(1) Array(False) 0x00000001]
    //        AssetInfo second[V(1) S(20) Array(False) 0x00000000]
    //          int preloadIndex[V(1) S(4) Array(False) 0x00000000]
    //          int preloadSize[V(1) S(4) Array(False) 0x00000000]
    //          PPtr<Object> asset[V(1) S(12) Array(False) 0x00000000]
    //            int m_FileID[V(1) S(4) Array(False) 0x00800001]
    //            SInt64 m_PathID[V(1) S(8) Array(False) 0x00800001]
    //  AssetInfo m_MainAsset[V(1) S(20) Array(False) 0x00000000]
    //    int preloadIndex[V(1) S(4) Array(False) 0x00000000]
    //    int preloadSize[V(1) S(4) Array(False) 0x00000000]
    //    PPtr<Object> asset[V(1) S(12) Array(False) 0x00000000]
    //      int m_FileID[V(1) S(4) Array(False) 0x00800001]
    //      SInt64 m_PathID[V(1) S(8) Array(False) 0x00800001]
    //  unsigned int m_RuntimeCompatibility[V(1) S(4) Array(False) 0x00000000]
    //  string m_AssetBundleName[V(1) S(-1) Array(False) 0x00008000]
    //    Array Array[V(1) S(-1) Array(True) 0x00004001]
    //      int size[V(1) S(4) Array(False) 0x00000001]
    //      char data[V(1) S(1) Array(False) 0x00000001]
    //  vector m_Dependencies[V(1) S(-1) Array(False) 0x00008000]
    //    Array Array[V(1) S(-1) Array(True) 0x0000C000]
    //      int size[V(1) S(4) Array(False) 0x00000000]
    //      string data[V(1) S(-1) Array(False) 0x00008000]
    //        Array Array[V(1) S(-1) Array(True) 0x00004001]
    //          int size[V(1) S(4) Array(False) 0x00000001]
    //          char data[V(1) S(1) Array(False) 0x00000001]
    //  bool m_IsStreamedSceneAssetBundle[V(1) S(1) Array(False) 0x00004000]
    //  int m_ExplicitDataLayout[V(1) S(4) Array(False) 0x00000000]
    //  int m_PathFlags[V(1) S(4) Array(False) 0x00000000]
    //  map m_SceneHashes[V(1) S(-1) Array(False) 0x00008000]
    //    Array Array[V(1) S(-1) Array(True) 0x00008000]
    //      int size[V(1) S(4) Array(False) 0x00000000]
    //      pair data[V(1) S(-1) Array(False) 0x00008000]
    //        string first[V(1) S(-1) Array(False) 0x00008000]
    //          Array Array[V(1) S(-1) Array(True) 0x00004001]
    //            int size[V(1) S(4) Array(False) 0x00000001]
    //            char data[V(1) S(1) Array(False) 0x00000001]
    //        string second[V(1) S(-1) Array(False) 0x00008000]
    //          Array Array[V(1) S(-1) Array(True) 0x00004001]
    //            int size[V(1) S(4) Array(False) 0x00000001]
    //            char data[V(1) S(1) Array(False) 0x00000001]


    // classID{142}: AssetBundle <- NamedObject <- EditorExtension <- Object
    //AssetBundle Base // ByteOffset{0}, ByteSize{ffffffff}, Index{0}, IsArray{0}, MetaFlag{8000}
    //  string m_Name // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{1}, IsArray{0}, MetaFlag{8001}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{2}, IsArray{1}, MetaFlag{4001}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{3}, IsArray{0}, MetaFlag{1}
    //      char data // ByteOffset{ffffffff}, ByteSize{1}, Index{4}, IsArray{0}, MetaFlag{1}
    //  vector m_PreloadTable // ByteOffset{4c}, ByteSize{ffffffff}, Index{5}, IsArray{0}, MetaFlag{0}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{6}, IsArray{1}, MetaFlag{0}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{7}, IsArray{0}, MetaFlag{0}
    //      PPtr<Object> data // ByteOffset{ffffffff}, ByteSize{8}, Index{8}, IsArray{0}, MetaFlag{0}
    //        int m_FileID // ByteOffset{ffffffff}, ByteSize{4}, Index{9}, IsArray{0}, MetaFlag{1}
    //        int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{a}, IsArray{0}, MetaFlag{1}
    //  map m_Container // ByteOffset{5c}, ByteSize{ffffffff}, Index{b}, IsArray{0}, MetaFlag{8000}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{c}, IsArray{1}, MetaFlag{8000}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{d}, IsArray{0}, MetaFlag{0}
    //      pair data // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{e}, IsArray{0}, MetaFlag{8000}
    //        string first // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{f}, IsArray{0}, MetaFlag{8000}
    //          Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{10}, IsArray{1}, MetaFlag{4001}
    //            int size // ByteOffset{ffffffff}, ByteSize{4}, Index{11}, IsArray{0}, MetaFlag{1}
    //            char data // ByteOffset{ffffffff}, ByteSize{1}, Index{12}, IsArray{0}, MetaFlag{1}
    //        AssetInfo second // ByteOffset{ffffffff}, ByteSize{10}, Index{13}, IsArray{0}, MetaFlag{0}
    //          int preloadIndex // ByteOffset{ffffffff}, ByteSize{4}, Index{14}, IsArray{0}, MetaFlag{0}
    //          int preloadSize // ByteOffset{ffffffff}, ByteSize{4}, Index{15}, IsArray{0}, MetaFlag{0}
    //          PPtr<Object> asset // ByteOffset{ffffffff}, ByteSize{8}, Index{16}, IsArray{0}, MetaFlag{0}
    //            int m_FileID // ByteOffset{ffffffff}, ByteSize{4}, Index{17}, IsArray{0}, MetaFlag{1}
    //            int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{18}, IsArray{0}, MetaFlag{1}
    //  AssetInfo m_MainAsset // ByteOffset{40}, ByteSize{10}, Index{19}, IsArray{0}, MetaFlag{0}
    //    int preloadIndex // ByteOffset{40}, ByteSize{4}, Index{1a}, IsArray{0}, MetaFlag{0}
    //    int preloadSize // ByteOffset{44}, ByteSize{4}, Index{1b}, IsArray{0}, MetaFlag{0}
    //    PPtr<Object> asset // ByteOffset{48}, ByteSize{8}, Index{1c}, IsArray{0}, MetaFlag{0}
    //      int m_FileID // ByteOffset{48}, ByteSize{4}, Index{1d}, IsArray{0}, MetaFlag{1}
    //      int m_PathID // ByteOffset{ffffffff}, ByteSize{4}, Index{1e}, IsArray{0}, MetaFlag{1}
    //  vector m_ScriptCompatibility // ByteOffset{20}, ByteSize{ffffffff}, Index{1f}, IsArray{0}, MetaFlag{8000}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{20}, IsArray{1}, MetaFlag{8000}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{21}, IsArray{0}, MetaFlag{0}
    //      AssetBundleScriptInfo data // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{22}, IsArray{0}, MetaFlag{8000}
    //        string className // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{23}, IsArray{0}, MetaFlag{8000}
    //          Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{24}, IsArray{1}, MetaFlag{4001}
    //            int size // ByteOffset{ffffffff}, ByteSize{4}, Index{25}, IsArray{0}, MetaFlag{1}
    //            char data // ByteOffset{ffffffff}, ByteSize{1}, Index{26}, IsArray{0}, MetaFlag{1}
    //        string nameSpace // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{27}, IsArray{0}, MetaFlag{8000}
    //          Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{28}, IsArray{1}, MetaFlag{4001}
    //            int size // ByteOffset{ffffffff}, ByteSize{4}, Index{29}, IsArray{0}, MetaFlag{1}
    //            char data // ByteOffset{ffffffff}, ByteSize{1}, Index{2a}, IsArray{0}, MetaFlag{1}
    //        string assemblyName // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{2b}, IsArray{0}, MetaFlag{8000}
    //          Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{2c}, IsArray{1}, MetaFlag{4001}
    //            int size // ByteOffset{ffffffff}, ByteSize{4}, Index{2d}, IsArray{0}, MetaFlag{1}
    //            char data // ByteOffset{ffffffff}, ByteSize{1}, Index{2e}, IsArray{0}, MetaFlag{1}
    //        unsigned int hash // ByteOffset{ffffffff}, ByteSize{4}, Index{2f}, IsArray{0}, MetaFlag{0}
    //  vector m_ClassCompatibility // ByteOffset{30}, ByteSize{ffffffff}, Index{30}, IsArray{0}, MetaFlag{0}
    //    Array Array // ByteOffset{ffffffff}, ByteSize{ffffffff}, Index{31}, IsArray{1}, MetaFlag{0}
    //      int size // ByteOffset{ffffffff}, ByteSize{4}, Index{32}, IsArray{0}, MetaFlag{0}
    //      pair data // ByteOffset{ffffffff}, ByteSize{8}, Index{33}, IsArray{0}, MetaFlag{0}
    //        int first // ByteOffset{ffffffff}, ByteSize{4}, Index{34}, IsArray{0}, MetaFlag{0}
    //        unsigned int second // ByteOffset{ffffffff}, ByteSize{4}, Index{35}, IsArray{0}, MetaFlag{0}
    //  unsigned int m_RuntimeCompatibility // ByteOffset{1c}, ByteSize{4}, Index{36}, IsArray{0}, MetaFlag{0}

    public class AssetBundle : NamedObject
    {
        public class ContainerItem
        {
            public string path;
            public Int32 fileID;
            public Int64 pathID;
        }

        List<ContainerItem> container;
        string assetBundleName;

        public AssetBundle(Type type, ObjectInfo objectInfo, string containerPath) : base(type, objectInfo, containerPath)
        {
        }
        public override string GetTypeName() { return "AssetBundle"; }
        public override string GetName() { return assetBundleName; }

        public override void Read(AssetReader reader)
        {
            //AssetBundle Base[V(3) S(-1) Array(False) 0x00008000]
            //  string m_Name[V(1) S(-1) Array(False) 0x00008001]
            //    Array Array[V(1) S(-1) Array(True) 0x00004001]
            //      int size[V(1) S(4) Array(False) 0x00000001]
            //      char data[V(1) S(1) Array(False) 0x00000001]
            base.Read(reader);

            //  vector m_PreloadTable[V(1) S(-1) Array(False) 0x00008000]
            //    Array Array[V(1) S(-1) Array(True) 0x00004000]
            //      int size[V(1) S(4) Array(False) 0x00000000]
            Int32 size = reader.ReadInt32();
            for (int i = 0; i < size; i++)
            {
                //      PPtr<Object> data[V(1) S(12) Array(False) 0x00000000]
                //        int m_FileID[V(1) S(4) Array(False) 0x00800001]
                reader.ReadInt32();
                //        SInt64 m_PathID[V(1) S(8) Array(False) 0x00800001]
                reader.ReadInt64();
            }

            //  map m_Container[V(1) S(-1) Array(False) 0x00008000]
            //    Array Array[V(1) S(-1) Array(True) 0x00008000]
            //      int size[V(1) S(4) Array(False) 0x00000000]
            container = new List<ContainerItem>();

            size = reader.ReadInt32();
            for (int i = 0; i < size; i++)
            {
                //      pair data[V(1) S(-1) Array(False) 0x00008000]
                //        string first[V(1) S(-1) Array(False) 0x00008000]
                //          Array Array[V(1) S(-1) Array(True) 0x00004001]
                //            int size[V(1) S(4) Array(False) 0x00000001]
                //            char data[V(1) S(1) Array(False) 0x00000001]
                string key = reader.ReadTypeString();
                //        AssetInfo second[V(1) S(20) Array(False) 0x00000000]
                //          int preloadIndex[V(1) S(4) Array(False) 0x00000000]
                reader.ReadInt32();
                //          int preloadSize[V(1) S(4) Array(False) 0x00000000]
                reader.ReadInt32();
                //          PPtr<Object> asset[V(1) S(12) Array(False) 0x00000000]
                //            int m_FileID[V(1) S(4) Array(False) 0x00800001]
                Int32 fileID = reader.ReadInt32();
                //            SInt64 m_PathID[V(1) S(8) Array(False) 0x00800001]
                Int64 pathID = reader.ReadInt64();

                container.Add(new ContainerItem { path = key, fileID = fileID, pathID = pathID });
            }

            //  AssetInfo m_MainAsset[V(1) S(20) Array(False) 0x00000000]
            //    int preloadIndex[V(1) S(4) Array(False) 0x00000000]
            reader.ReadInt32();
            //    int preloadSize[V(1) S(4) Array(False) 0x00000000]
            reader.ReadInt32();
            //    PPtr<Object> asset[V(1) S(12) Array(False) 0x00000000]
            //      int m_FileID[V(1) S(4) Array(False) 0x00800001]
            reader.ReadInt32();
            //      SInt64 m_PathID[V(1) S(8) Array(False) 0x00800001]
            reader.ReadInt64();
            //  unsigned int m_RuntimeCompatibility[V(1) S(4) Array(False) 0x00000000]
            reader.ReadUInt32();
            //  string m_AssetBundleName[V(1) S(-1) Array(False) 0x00008000]
            //    Array Array[V(1) S(-1) Array(True) 0x00004001]
            //      int size[V(1) S(4) Array(False) 0x00000001]
            //      char data[V(1) S(1) Array(False) 0x00000001]
            assetBundleName = reader.ReadTypeString();
            //  vector m_Dependencies[V(1) S(-1) Array(False) 0x00008000]
            //    Array Array[V(1) S(-1) Array(True) 0x0000C000]
            //      int size[V(1) S(4) Array(False) 0x00000000]
            //      string data[V(1) S(-1) Array(False) 0x00008000]
            //        Array Array[V(1) S(-1) Array(True) 0x00004001]
            //          int size[V(1) S(4) Array(False) 0x00000001]
            //          char data[V(1) S(1) Array(False) 0x00000001]
            //  bool m_IsStreamedSceneAssetBundle[V(1) S(1) Array(False) 0x00004000]
            //  int m_ExplicitDataLayout[V(1) S(4) Array(False) 0x00000000]
            //  int m_PathFlags[V(1) S(4) Array(False) 0x00000000]
            //  map m_SceneHashes[V(1) S(-1) Array(False) 0x00008000]
            //    Array Array[V(1) S(-1) Array(True) 0x00008000]
            //      int size[V(1) S(4) Array(False) 0x00000000]
            //      pair data[V(1) S(-1) Array(False) 0x00008000]
            //        string first[V(1) S(-1) Array(False) 0x00008000]
            //          Array Array[V(1) S(-1) Array(True) 0x00004001]
            //            int size[V(1) S(4) Array(False) 0x00000001]
            //            char data[V(1) S(1) Array(False) 0x00000001]
            //        string second[V(1) S(-1) Array(False) 0x00008000]
            //          Array Array[V(1) S(-1) Array(True) 0x00004001]
            //            int size[V(1) S(4) Array(False) 0x00000001]
            //            char data[V(1) S(1) Array(False) 0x00000001]

        }

        public string GetContainerPath(Int64 pathID)
        {
            ContainerItem item = container.Find(item => item.pathID == pathID);
            if (item == null)
                return "";
            return item.path;
        }
    }
}
