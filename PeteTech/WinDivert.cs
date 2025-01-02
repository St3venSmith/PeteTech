using System;
using ProcessManagement;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using WindivertDotnet;
using System.Net.Sockets;
using System.Configuration;

namespace PeteTech
{
    internal class WinDiverts : Macros
    {
        

        private static WinDivert? l3074;
        private static WinDivert? l27k;
        private static WinDivert? l7500;

        /// <summary>
        /// Filters for download (in) and upload (out)
        /// </summary>

        // 3074 Filters
        public static string filter3074 = "udp.SrcPort == 3074 or udp.DstPort == 3074"; // Combined for both directions
        public static string filter3074IN = "udp.SrcPort == 3074"; // Download (in)
        public static string filter3074OUT = "udp.DstPort == 3074"; // Upload (out)

        // 27k Filters
        public static string filter27k = "udp.SrcPort >= 27015 and udp.SrcPort <= 27200 or udp.DstPort >= 27015 and udp.DstPort <= 27200";
        public static string filter27kIN = "udp.SrcPort >= 27015 and udp.SrcPort <= 27200"; // Download (in)
        public static string filter27kOUT = "udp.DstPort >= 27015 and udp.DstPort <= 27200"; // Upload (out)

        // 7500 Filters
        public static string filter7500 = "tcp.SrcPort >= 7500 and tcp.SrcPort <= 7509 or tcp.DstPort >= 7500 and tcp.DstPort <= 7509"; // Combined for both directions
        public static string filter7500IN = "tcp.SrcPort >= 7500 and tcp.SrcPort <= 7509"; // Download (in)
        public static string filter7500OUT = "tcp.DstPort >= 7500 and tcp.DstPort <= 7509"; // Upload (out)

        public bool unlimit = true;

        public static void Start3074(bool Enabled, string Status)
        {
            try
            {
                if (Enabled)
                {
                    if (l3074 == null)
                    {
                        if (Status == "in/out")
                        {
                            l3074 = new WinDivert(filter3074, WinDivertLayer.Network);
                            
                        }
                        else if (Status == "in")
                        {
                            l3074 = new WinDivert(filter3074IN, WinDivertLayer.Network);
                        }
                        else if (Status == "out")
                        {
                            l3074 = new WinDivert(filter3074OUT, WinDivertLayer.Network);
                        }
                    }

                    WinDivertPacket packet = new WinDivertPacket(65535);
                    WinDivertAddress addr = new WinDivertAddress();

                    int packetLen = l3074.Recv(packet, addr);
                    Console.WriteLine($"Packet received: Length {packetLen} bytes");

                    l3074.Send(packet, addr, new CancellationToken());
                   
                }
                else
                {
                    if (l3074 != null)
                    {
                        l3074.Dispose();
                        l3074 = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void Start7500(bool Enabled, string Status)
        {
            try
            {
                if (Enabled)
                {
                    if (l7500 == null)
                    {
                        if (Status == "in/out")
                        {
                            l7500 = new WinDivert(filter7500, WinDivertLayer.Network);
                        }
                        else if (Status == "in")
                        {
                            l7500 = new WinDivert(filter7500IN, WinDivertLayer.Network);
                        }
                        else if (Status == "out")
                        {
                            l7500 = new WinDivert(filter7500OUT, WinDivertLayer.Network);
                        }
                    }
                    
                    WinDivertPacket packet = new WinDivertPacket(65535);
                    WinDivertAddress addr = new WinDivertAddress();

                    int packetLen = l7500.Recv(packet, addr);
                    Console.WriteLine($"Packet received: Length {packetLen} bytes");

                    l7500.Send(packet, addr, new CancellationToken());
                }
                else
                {
                    if (l7500 != null)
                    {
                        l7500.Dispose(); 
                        l7500 = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void Start27K(bool Enabled, string Status)
        {
            try
            {
                if (Enabled)
                {
                    if (l27k == null)
                    {
                        if (Status == "in/out")
                        {
                            l27k = new WinDivert(filter27k, WinDivertLayer.Network);
                        }
                        else if (Status == "in")
                        {
                            l27k = new WinDivert(filter27kIN, WinDivertLayer.Network);
                        }
                        else if (Status == "out")
                        {
                            l27k = new WinDivert(filter27kOUT, WinDivertLayer.Network);
                        }
                    }

                    WinDivertPacket packet = new WinDivertPacket(65535);
                    WinDivertAddress addr = new WinDivertAddress();

                    int packetLen = l27k.Recv(packet, addr);
                    Console.WriteLine($"Packet received: Length {packetLen} bytes");

                    l27k.Send(packet, addr, new CancellationToken());
                }
                else
                {
                    if (l27k != null)
                    {
                        l27k.Dispose();
                        l27k = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
