using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFAssetLib
{
    public class AssetPrettyWriter
    {
        private StringWriter writer;
        private int depth;
        private int tabCount;

        public AssetPrettyWriter()
        {
            this.writer = new StringWriter();
            this.depth = 0;
            this.tabCount = 2;
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

        public override string ToString()
        {
            return this.writer.ToString();
        }
    }
}
