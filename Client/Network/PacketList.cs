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
using PMDCP.Core;
using PMDCP.Sockets;

namespace Client.Logic.Network
{
    class PacketList
    {
        List<TcpPacket> packets;

        public List<TcpPacket> Packets
        {
            get { return packets; }
        }

        public PacketList()
        {
            packets = new List<TcpPacket>();
        }

        public void AddPacket(TcpPacket packet)
        {
            packets.Add(packet);
        }

        public byte[] CombinePackets()
        {
            ByteArray[] packetBytes = new ByteArray[packets.Count];
            int totalSize = 0;
            for (int i = 0; i < packets.Count; i++)
            {
                packetBytes[i] = new ByteArray(ByteEncoder.StringToByteArray(packets[i].PacketString));
                totalSize += packetBytes[i].Length() + GetPacketSegmentHeaderSize();
            }
            byte[] packet = new byte[totalSize];
            int position = 0;
            for (int i = 0; i < packetBytes.Length; i++)
            {
                // Add the size of the packet segment
                Array.Copy(ByteArray.IntToByteArray(packetBytes[i].Length()), 0, packet, position, 4);
                position += 4;
                // Add the packet data
                Array.Copy(packetBytes[i].ToArray(), 0, packet, position, packetBytes[i].Length());
                position += packetBytes[i].Length();
            }
            return packet;
        }

        public int GetPacketSegmentHeaderSize()
        {
            return
                4 // [int32] Size of the packet segment
                ;
        }
    }
}
