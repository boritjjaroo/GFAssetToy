using GFAssetLib.DataType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GFAssetLib
{
    public class AssetReader
    {
        private BinaryReader reader;
        public Stream BaseStream { get => reader.BaseStream; }
        private long length;
        private bool isBigEndian;
        public bool IsBigEndian
        {
            get => isBigEndian;
            set { isBigEndian = value; }
        }

        private long basePosition;
        private long alignBasePosition;

        public AssetReader(String path)
        {
            FileStream fs = File.Open(path, FileMode.Open);
            BufferedStream bufferedStream = new BufferedStream(fs);
            this.reader = new BinaryReader(bufferedStream);
            this.length = fs.Length;
            this.isBigEndian = true;
            this.basePosition = this.reader.BaseStream.Position;
            this.alignBasePosition = this.reader.BaseStream.Position;
        }

        public AssetReader(byte[] data, long offset)
        {
            this.reader = new BinaryReader(new MemoryStream(data));
            this.length = data.Length;
            this.isBigEndian = true;
            this.basePosition = this.reader.BaseStream.Position + offset;
            this.alignBasePosition = this.reader.BaseStream.Position;

            this.reader.BaseStream.Position = this.basePosition;
        }

        public long Position
        {
            get { return reader.BaseStream.Position - basePosition; }
            set { reader.BaseStream.Position = value + basePosition; }
        }

        public void SetAlignBasePosition()
        {
            alignBasePosition = reader.BaseStream.Position;
        }

        public void MoveToAlignedPosition(int size)
        {
            if (size <= 0)
                return;

            long newPosition = (reader.BaseStream.Position + (size - 1)) / size * size;
            reader.BaseStream.Position = newPosition;
        }

        public bool ReadBoolean()
        {
            return 0 < ReadByte();
        }

        public byte ReadByte()
        {
            return reader.ReadByte();
        }

        public Int16 ReadInt16()
        {
            if (this.isBigEndian)
            {
                byte[] buf = reader.ReadBytes(2);
                Array.Reverse(buf);
                return BitConverter.ToInt16(buf, 0);
            }
            else
            {
                return reader.ReadInt16();
            }
        }

        public Int32 ReadInt32()
        {
            if (this.isBigEndian)
            {
                byte[] buf = reader.ReadBytes(4);
                Array.Reverse(buf);
                return BitConverter.ToInt32(buf, 0);
            }
            else
            {
                return reader.ReadInt32();
            }
        }

        public Int64 ReadInt64()
        {
            if (this.isBigEndian)
            {
                byte[] buf = reader.ReadBytes(8);
                Array.Reverse(buf);
                return BitConverter.ToInt64(buf, 0);
            }
            else
            {
                return reader.ReadInt64();
            }
        }

        public UInt16 ReadUInt16()
        {
            if (this.isBigEndian)
            {
                byte[] buf = reader.ReadBytes(2);
                Array.Reverse(buf);
                return BitConverter.ToUInt16(buf, 0);
            }
            else
            {
                return reader.ReadUInt16();
            }
        }

        public UInt32 ReadUInt32()
        {
            if (this.isBigEndian)
            {
                byte[] buf = reader.ReadBytes(4);
                Array.Reverse(buf);
                return BitConverter.ToUInt32(buf, 0);
            }
            else
            {
                return reader.ReadUInt32();
            }
        }

        public UInt64 ReadUInt64()
        {
            if (this.isBigEndian)
            {
                byte[] buf = reader.ReadBytes(8);
                Array.Reverse(buf);
                return BitConverter.ToUInt64(buf, 0);
            }
            else
            {
                return reader.ReadUInt32();
            }
        }

        public float ReadFloat()
        {
            if (this.isBigEndian)
            {
                byte[] buf = reader.ReadBytes(4);
                Array.Reverse(buf);
                return BitConverter.ToSingle(buf, 0);
            }
            else
            {
                return reader.ReadSingle();
            }
        }

        public byte[] ReadBytes(int count)
        {
            return reader.ReadBytes(count);
        }

        public string ReadNullTerminatedString(int maxLength)
        {
            byte[] buffer = new byte[maxLength];
            int position = 0;

            while (!Eof() && position < maxLength)
            {
                byte value = reader.ReadByte();
                if (value == 0)
                {
                    byte[] result = new byte[position];
                    Array.Copy(buffer, result, position);
                    string str = Encoding.UTF8.GetString(result);
                    return str;
                }
                buffer[position] = value;
                position++;
            }

            throw new Exception("Invalid File Format");
        }

        //   bool <field-name>   [V(1) S(1) Array(False) 0x00004000]
        public bool ReadTypeBool()
        {
            var val = ReadByte();
            MoveToAlignedPosition(4);
            return 0 < val;
        }

        // UInt8 <field-name>  [V(1) S(1) Array(False) 0x00004101]
        public UInt16 ReadTypeUInt8()
        {
            var val = ReadByte();
            MoveToAlignedPosition(4);
            return val;
        }

        // string         [V(1) S(-1) Array(False) 0x00008000]
        //   Array Array  [V(1) S(-1) Array(True)  0x00004001]
        //     int size   [V(1) S( 4) Array(False) 0x00000001]
        //     char data  [V(1) S( 1) Array(False) 0x00000001]
        public string ReadTypeString()
        {
            int size = ReadInt32();
            byte[] buf = ReadBytes(size);
            string result = Encoding.UTF8.GetString(buf);
            MoveToAlignedPosition(4);
            return result;
        }

        //PPtr<T> <field-name>  [V(1) S(12) Array(False) 0x00000041]
        //  int m_FileID        [V(1) S( 4) Array(False) 0x00000041]
        //  SInt64 m_PathID     [V(1) S( 8) Array(False) 0x00000041]
        public PPtr ReadTypePPtr()
        {
            var pptr = new PPtr();
            pptr.fileID = ReadInt32();
            pptr.pathID = ReadInt64();
            return pptr;
        }

        public void Close()
        {
            reader.Close();
        }

        private bool Eof()
        {
            return this.length <= this.reader.BaseStream.Position;
        }
    }
}
