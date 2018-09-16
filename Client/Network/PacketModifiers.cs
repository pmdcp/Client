﻿// This file is part of Mystery Dungeon eXtended.

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
using PMDCP.Sockets;
using Client.Logic.Security;
using System.IO;
using System.IO.Compression;

namespace Client.Logic.Network
{
    class PacketModifiers
    {
        Security.Encryption crypt;
        bool obtainedKey;

        bool encryptionEnabled = true;

        const string DEFAULT_KEY = "abcdefgh!6876b)(gjhgfy8u7y";//"abcdefgh76876bfgjhgfy8u7iy";

        public bool ObtainedKey
        {
            get { return obtainedKey; }
        }

        public PacketModifiers()
        {
            crypt = new Security.Encryption();
            crypt.SetKey(DEFAULT_KEY);
        }

        public void SetKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                encryptionEnabled = false;
            }
            else
            {
                if (!obtainedKey)
                {
                    crypt = new Encryption(key);
                    obtainedKey = true;
                }
            }
        }

        //public string DecryptPacket(string data) {
        //    if (encryptionEnabled) {
        //        return crypt.DecryptData(data);
        //    } else {
        //        return data;
        //    }
        //}

        public byte[] DecryptPacket(byte[] packet)
        {
            return crypt.DecryptBytes(packet);
        }

        //public string EncryptPacket(IPacket packet) {
        //    if (encryptionEnabled) {
        //        return crypt.EncryptData(packet.PacketString);
        //    } else {
        //        return packet.PacketString;
        //    }
        //}

        public byte[] EncryptPacket(byte[] packet)
        {
            return crypt.EncryptBytes(packet);
        }

        public byte[] CompressPacket(byte[] packet)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(ms, CompressionMode.Compress, true))
                {
                    gzip.Write(packet, 0, packet.Length);
                }
                return ms.ToArray();
            }
        }

        public byte[] DecompressPacket(byte[] packet)
        {
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            using (GZipStream stream = new GZipStream(new MemoryStream(packet), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }
    }
}
