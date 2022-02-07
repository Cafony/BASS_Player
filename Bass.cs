using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace player
{
    /// <summary>
    /// Преде запуском программы необходимо поместить файл BASS.DLL рядом с .EXE файлом 
    /// </summary>
    class Bass
    {
        /// <summary>
        /// IMPORT BASS.DLL FUNCTIONS
        /// </summary>

        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool BASS_Init(int device, UInt32 freq, UInt32 flags, IntPtr win, IntPtr clsid);
        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool BASS_Free();
        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool BASS_StreamFree(UInt32 handle);
        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool BASS_MusicFree(UInt32 handle);
        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        private extern static UInt32 BASS_StreamCreateFile(Int32 mem, byte[] file, UInt64 offset, UInt64 length, UInt32 flags);
        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        private extern static UInt32 BASS_MusicLoad(Int32 mem, byte[] file, UInt64 offset, UInt32 length, UInt32 flags, UInt32 freq);
        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool BASS_ChannelPlay(UInt32 handle, Int32 restart);
        [DllImport("bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool BASS_ChannelSetPosition(UInt32 handle, UInt64 pos, UInt32 mode);

        /// <summary>
        /// MEMBERS
        /// </summary>

        private UInt32 bassStream = 0;
        private UInt32 bassMusic = 0;

        /// <summary>
        /// CONSTRUCTOR & DESTRUCTOR
        /// </summary>

        public Bass(IntPtr handle)
        {
            BASS_Init(-1, 44100, /*BASS_DEVICE_DEFAULT | BASS_DEVICE_LATENCY*/256, handle, IntPtr.Zero);
        }

        ~Bass()
        {
            Stop();
            BASS_Free();
        }

        /// <summary>
        /// METHODS
        /// </summary>

        public void Stop()
        {
            if (bassStream != 0) BASS_StreamFree(bassStream);
            if (bassMusic != 0) BASS_MusicFree(bassMusic);
        }

        public void Play(string name, ushort offset)
        {
            Stop();

            name = name.ToLower();

            if (name.EndsWith(".ogg") ||
                name.EndsWith(".mp3") ||
                name.EndsWith(".wav"))
            {
                bassStream = BASS_StreamCreateFile(0, Encoding.ASCII.GetBytes(name), 0, 0, 0);
                if (bassStream != 0)
                    BASS_ChannelPlay(bassStream, 0);
            }
            if (name.EndsWith(".mo3") ||
                name.EndsWith(".it") ||
                name.EndsWith(".xm") ||
                name.EndsWith(".s3m") ||
                name.EndsWith(".mtm") ||
                name.EndsWith(".mod") ||
                name.EndsWith(".umx"))
            {
                bassMusic = BASS_MusicLoad(0, Encoding.ASCII.GetBytes(name), 0, 0, /*BASS_MUSIC_RAMP*/512, 0);
                if (bassMusic != 0)
                {
                    BASS_ChannelSetPosition(bassMusic, MakeLong(offset, 0), /*BASS_POS_MUSIC_ORDER*/1);
                    BASS_ChannelPlay(bassMusic, 0);
                }
            }
        }

        private UInt32 MakeLong(UInt16 Low, UInt16 High)
        {
            return (UInt32)(Low | (UInt32)(High << 16));
        }
    } // class Bass
} // namespace player
