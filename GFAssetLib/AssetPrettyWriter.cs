using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFAssetLib
{
    public class AssetPrettyWriter
    {
        private MemoryStream memoryStream;
        private StreamWriter writer;
        private int depth;
        private int tabCount;

        public AssetPrettyWriter(int tab)
        {
            this.memoryStream = new MemoryStream();
            this.writer = new StreamWriter(memoryStream);
            this.depth = 0;
            this.tabCount = tab;
        }

        public AssetPrettyWriter(Stream output, int tab)
        {
            this.memoryStream = null;
            this.writer = new StreamWriter(output);
            this.depth = 0;
            this.tabCount = tab;
        }

        public void WriteLine(string msg)
        {
            string padding = new string(' ', depth * tabCount);
            this.writer.Write(padding);
            this.writer.WriteLine(msg);
        }

        public void IncreaseDepth(int depth = 1)
        {
            this.depth += depth;
        }

        public void DecreaseDepth(int depth = 1)
        {
            if (0 <= this.depth - depth)
                this.depth -= depth;
        }

        public void Flush()
        {
            this.writer.Flush();
        }

        public void Close()
        {
            this.writer.Close();
        }

        public string GetString()
        {
            if (memoryStream != null)
            {
                writer.Flush();
                var buf = memoryStream.ToArray();
                var str = Encoding.UTF8.GetString(buf);
                return str;
            }
            return "";
        }
    }
}
