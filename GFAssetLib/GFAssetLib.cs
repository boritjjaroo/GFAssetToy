using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFAssetLib
{
    public class GFAssetLib
    {
        private static GFAssetLib sInstance = new GFAssetLib();
        public static GFAssetLib GetInstance() { return sInstance; }

        public IGFLog log;

        private byte[] strings;

        public void LoadGlobalStrings(string path)
        {
            FileStream fs = File.Open(path, FileMode.Open);
            BinaryReader reader = new BinaryReader(fs);
            long size = fs.Length;
            strings = reader.ReadBytes((int)size);
            reader.Close();
        }

        public string GetGlobalString(int index)
        {
            if (index < 0 || strings.Length <= index)
            {
                return "";
            }

            int count = 0;
            while (strings[index + count] != '\0')
                count++;
            return Encoding.ASCII.GetString(strings, index, count);
        }
    }
}
