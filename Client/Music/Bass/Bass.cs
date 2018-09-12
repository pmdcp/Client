// This file is part of Mystery Dungeon eXtended.

// Copyright (C) 2015 Pikablu, MDX Contributors, PMU Staff

// Mystery Dungeon eXtended is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// Mystery Dungeon eXtended is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with Mystery Dungeon eXtended.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Client.Logic.Music.Bass
{
    class Bass
    {
        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int BASS_ChannelGetLength(IntPtr handle, int mode);

        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int BASS_ChannelGetPosition(IntPtr handle, int mode);

        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool BASS_ChannelPlay(IntPtr handle, bool restart);

        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool BASS_ChannelStop(IntPtr handle);

        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool BASS_ChannelPause(IntPtr handle);

        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool BASS_Free();

        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool BASS_Init(int device, uint freq, uint flags, IntPtr win, uint clsid);

        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool BASS_SampleFree(IntPtr handle);

        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr BASS_SampleGetChannel(IntPtr handle, bool onlynew);

        [DllImport("bass.dll", EntryPoint = "BASS_SampleLoad", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr BASS_SampleLoad(bool mem, string file, uint offset, uint offsethigh, uint length, uint max, uint flags);

        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool BASS_SampleStop(IntPtr handle);

        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool BASS_SetVolume(float volume);

        [DllImport("bass.dll", EntryPoint = "BASS_StreamCreateFile", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr BASS_StreamCreateFile(bool mem, string file, uint offset, uint offsethigh, uint length, uint lengthhigh, uint flags);

        [DllImport("bass.dll", EntryPoint = "BASS_StreamCreateURL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr BASS_StreamCreateURL(string url, uint offset, uint flags, Delegate callback, IntPtr user);

        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool BASS_StreamFree(IntPtr handle);

        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr BASS_PluginLoad(string file);

        [DllImport("bass.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool BASS_ChannelSlideAttribute(IntPtr handle, uint attrib, int value, uint time);
    }
}
