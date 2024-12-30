using System;
using ProcessManagement;
using System.Diagnostics;
using System.Runtime.InteropServices;


using System.Text;
using System.Threading;
using System.Reflection.Metadata;
using WindivertDotnet;

namespace PeteTech
{
    internal class WinDiverts : Macros
    {
        private static WinDivert? divert;

        public static string filter = "ip"; // Define your packet filter (adjust as needed)



      


        public static void Start(bool Enabled)
        {
            try
            {

                divert = new WinDivert(Filter.True.And(x => x.IsUdp && x.Network.RemotePort == 3074), WinDivertLayer.Network);
                
                if (Enabled)
                {
                    divert = new WinDivert(Filter.True.And(x => x.IsUdp && x.Network.RemotePort == 3074), WinDivertLayer.Network);
                }
                else
                {
                    divert.Shutdown();
                }
                WinDivertPacket packet = new WinDivertPacket(65535); // Create a WinDivertPacket instance
                WinDivertAddress addr = new WinDivertAddress(); // Create a WinDivertAddress instance

                while (Enabled)
                {
                    MessageBox.Show("Enabled");
                    int packetLen = divert.Recv(packet, addr); // Receive packet

                    Console.WriteLine($"Packet received: Length {packetLen} bytes");


                    if (!Enabled)
                    {
                        MessageBox.Show("Disabled");
                        DropPacket(packet, addr);

                    }
                    else
                    {
                        SendPacket(packet, addr, packetLen);
                    }
                }
                if (!Enabled)
                {
                    DropPacket(packet, addr);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void SendPacket(WinDivertPacket packet, WinDivertAddress addr, int packetLen)
        {
            divert.Send(packet, addr, new CancellationToken()); // Pass a CancellationToken instead of int
            MessageBox.Show($"Sent");
        }

        private static void DropPacket(WinDivertPacket packet, WinDivertAddress addr)
        {
            divert.Shutdown(); // Close the WinDivert handle
            // Packets are dropped by not sending them
            Console.WriteLine("Packet dropped.");
        }
    }
}