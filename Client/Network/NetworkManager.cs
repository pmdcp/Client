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


namespace Client.Logic.Network
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PMDCP.Core;
    using PMDCP.Sockets;
    using Tcp = PMDCP.Sockets.Tcp;
    using System.Threading;

    class NetworkManager
    {
        #region Fields

        internal static PacketModifiers packetModifiers;

        private static Tcp.TcpClient tcpClient;
        static int lastConnectionAttempt;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the TCP client.
        /// </summary>
        /// <value>The TCP client.</value>
        public static Tcp.TcpClient TcpClient
        {
            get { return tcpClient; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Connects to the server.
        /// </summary>
        public static void Connect()
        {
            try
            {
                string hostName = IO.Options.ConnectionIP;

                if (tcpClient.SocketState == Tcp.TcpSocketState.Idle)
                {
                    tcpClient.Connect(hostName, IO.Options.ConnectionPort);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static bool ShouldAttemptReconnect()
        {
            if (SdlDotNet.Core.Timer.TicksElapsed > lastConnectionAttempt + 60000)
            {
                lastConnectionAttempt = SdlDotNet.Core.Timer.TicksElapsed;
            }
            else
            {
                return false;
            }
            if (tcpClient != null && tcpClient.Socket.Connected)
            {
                return false;
            }
            return false;
        }

        public static void Disconnect()
        {
            tcpClient.Close();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpManager"/> class.
        /// </summary>
        public static void InitializeTcp()
        {
            if (tcpClient != null)
            {
                if (tcpClient.Socket.Connected)
                {
                    tcpClient.Close();
                }
                tcpClient.DataReceived -= new EventHandler<Tcp.DataReceivedEventArgs>(tcpClient_DataReceived);
            }
            tcpClient = new Tcp.TcpClient();
            tcpClient.CustomHeaderSize = GetCustomPacketHeaderSize();
            tcpClient.DataReceived += new EventHandler<Tcp.DataReceivedEventArgs>(tcpClient_DataReceived);

            //packetSecurity.SetKey("abcdefgh76876bfgjhgfy8u7iy");
        }

        private static int GetCustomPacketHeaderSize()
        {
            return
                1 // [byte] Compression enabled
                + 1 // [byte] Encryption enabled
                + 1 // [byte] Send as packet list
                ;
        }

        public static void InitializePacketSecurity()
        {
            packetModifiers = new PacketModifiers();
        }

        public static void SendData(IPacket packet)
        {
            SendData(packet, false, false);
        }

        public static void SendData(IPacket packet, bool compress, bool encrypt)
        {
            SendData(ByteEncoder.StringToByteArray(packet.PacketString), compress, encrypt, false);
        }

        public static void SendData(PacketList packetList)
        {
            SendData(packetList.CombinePackets(), false, false, true);
        }

        public static void SendData(byte[] packet, bool compress, bool encrypt, bool isPacketList)
        {
            if (tcpClient != null && tcpClient.Socket.Connected)
            {
                byte[] customHeader = new byte[GetCustomPacketHeaderSize()];
                if (encrypt)
                {
                    packet = packetModifiers.EncryptPacket(packet);
                    customHeader[1] = 1;
                }

                if (packet.Length > 2000)
                {
                    if (compress == false)
                    {
                        compress = true;
                    }
                }

                if (compress)
                {
                    packet = packetModifiers.CompressPacket(packet);
                    customHeader[0] = 1;
                }

                if (isPacketList)
                {
                    customHeader[2] = 1;
                }
                else
                {
                    customHeader[2] = 0;
                }
                tcpClient.Send(packet, customHeader);
            }
        }

        static void tcpClient_DataReceived(object sender, Tcp.DataReceivedEventArgs e)
        {
            try
            {
                bool compression = false;
                if (e.CustomHeader[0] == 1)
                {
                    compression = true;
                }
                bool encryption = false;
                if (e.CustomHeader[1] == 1)
                {
                    encryption = true;
                }
                byte[] packetBytes = e.ByteData;
                if (compression)
                {
                    packetBytes = packetModifiers.DecompressPacket(packetBytes);
                }
                if (encryption)
                {
                    packetBytes = packetModifiers.DecompressPacket(packetBytes);
                }
                if (e.CustomHeader[2] == 1)
                {
                    // This was a packet list, process it
                    int position = 0;
                    while (position < packetBytes.Length)
                    {
                        int segmentSize = ByteEncoder.ByteArrayToInt(packetBytes, position);
                        position += 4;
                        MessageProcessor.HandleData(ByteEncoder.ByteArrayToString(packetBytes, position, segmentSize));
                        position += segmentSize;
                    }
                }
                else
                {
                    MessageProcessor.HandleData(ByteEncoder.ByteArrayToString(packetBytes));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Packet:");
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }

        #endregion Methods
    }
}