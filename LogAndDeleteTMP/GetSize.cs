using System;
using System.Runtime.InteropServices;

namespace LogAndDeleteTMP
{
    class GetSize
    {
        public static ulong GetFileSizeOnDisk(string file)
        {
            uint low_bytes = GetCompressedFileSizeW(file, out uint high_bytes);
            ulong size = (ulong)high_bytes << 32 | low_bytes;

            Console.WriteLine(low_bytes);

            return size;
        }
        


        [DllImport("kernel32.dll")]
        static extern uint GetCompressedFileSizeW([In, MarshalAs(UnmanagedType.LPWStr)] string lpFileName, [Out, MarshalAs(UnmanagedType.U4)] out uint lpFileSizeHigh);

        public static string ShortFileSize(ulong bytes)
        {
            int count = 0;

            string[] unit = new string[] { "bytes", "kilabytes", "megabytes", "gigabytes" };

            while (bytes >= 1024)
            {
                bytes /= 1024;
                count++;
            }

            return bytes + " " + unit[count];
        }
    }
}