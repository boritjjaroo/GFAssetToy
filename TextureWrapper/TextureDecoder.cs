using System;
using System.Runtime.InteropServices;

namespace TextureWrapper
{
    public static unsafe class TextureDecoder
    {
        public static bool DecodeETC2A8(byte[] data, int width, int height, byte[] image)
        {
            fixed (byte* pData = data)
            {
                fixed (byte* pImage = image)
                {
                    return 0 < DecodeETC2A8(pData, width, height, pImage);
                }
            }
        }
        [DllImport("TextureDecoder.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int DecodeETC2A8(void* data, int width, int height, void* image);
    }
}
