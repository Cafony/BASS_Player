using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace player
{
    class ShellFileInfo
    {
        /// <summary>
        /// TYPEDEFS
        /// </summary>

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        /// <summary>
        /// DATAS
        /// </summary>

        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_DISPLAYNAME = 0x200;
        private const uint SHGFI_TYPENAME = 0x400;
        private const uint SHGFI_LARGEICON = 0x0;    // Icons size 32x32
        private const uint SHGFI_SMALLICON = 0x1;    // Icons size 16x16
        private const uint SHGFI_OPENICON = 0x2;     // Icons size 48x48

        public Icon IconImage { get; private set; }
        public int IconIndex { get; private set; }
        public string FileName { get; private set; }
        public string FileType { get; private set; }

        /// <summary>
        /// FUNCTIONS
        /// </summary>

        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, 
            ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyIcon(IntPtr hIcon);

        public ShellFileInfo(string fname)
        {
            SHFILEINFO info = new SHFILEINFO();
            SHGetFileInfo(fname, 0, ref info, (uint)Marshal.SizeOf(info), 
                   SHGFI_ICON | SHGFI_DISPLAYNAME | SHGFI_SMALLICON | SHGFI_TYPENAME);

            IconImage = (Icon)Icon.FromHandle(info.hIcon).Clone();
            IconIndex = info.iIcon.ToInt32();

            FileName = info.szDisplayName;
            FileType = info.szTypeName;

            DestroyIcon(info.hIcon);
        }
    }
}
