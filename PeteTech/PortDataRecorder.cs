using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using WindivertDotnet;

namespace PeteTech
{
    public class PortDataRecorder
    {
        // Thread-safe queue for packets
        public event Action<string, double, double> DataUsageUpdated;
        private static ConcurrentQueue<(string, WinDivertPacket, WinDivertAddress)> packetQueue = new();
        private static bool isRunning = true;

        // Data counters
        private static ConcurrentDictionary<string, long> downloadBytes = new();
        private static ConcurrentDictionary<string, long> uploadBytes = new();

        public static string filter3074 = "udp.SrcPort == 3074 or udp.DstPort == 3074"; // Combined for both directions
        public static string filter27k = "udp.SrcPort >= 27015 and udp.SrcPort <= 27200 or udp.DstPort >= 27015 and udp.DstPort <= 27200";
        public static string filter7500 = "tcp.SrcPort >= 7500 and tcp.SrcPort <= 7509 or tcp.DstPort >= 7500 and tcp.DstPort <= 7509"; // Combined for both directions
        public static string filter30k = "tcp.SrcPort <= 30009 and tcp.SrcPort >= 30000 or tcp.SrcPort <= 30009 and tcp.SrcPort >= 30000";

        public async Task Start()
        {
            isRunning = true;

            // Start tasks without awaiting
            Task.Run(() => CapturePackets("3074", filter3074));
            Task.Run(() => CapturePackets("27k", filter27k));
            Task.Run(() => CapturePackets("7500", filter7500));
            Task.Run(() => CapturePackets("30k", filter30k));
            Task.Run(() => ProcessPackets());
            Task.Run(() => MonitorDataUsage());
        }

        public void Stop()
        {
            isRunning = false;
        }

        private async Task CapturePackets(string filterName, string filter)
        {
            try
            {
                using var winDivert = new WinDivert(filter, WinDivertLayer.Network);

                WinDivertPacket packet = new WinDivertPacket(65535);
                WinDivertAddress addr = new WinDivertAddress();

                while (isRunning)
                {
                    int packetLen = winDivert.Recv(packet, addr);
                    if (packetLen > 0)
                    {
                        packetQueue.Enqueue((filterName, packet.Clone(), addr.Clone()));
                        winDivert.Send(packet, addr);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CapturePackets ({filter}): {ex.Message}");
                isRunning = false;
            }
        }

        private async Task ProcessPackets()
        {
            try
            {
                while (isRunning)
                {
                    if (packetQueue.TryDequeue(out var packetData))
                    {
                        var (filterName, packet, addr) = packetData;

                        // Update counters
                        if (addr.Flags.HasFlag(WinDivertAddressFlag.Outbound))
                        {
                            uploadBytes.AddOrUpdate(filterName, packet.Length, (key, oldValue) => oldValue + packet.Length);
                        }
                        else
                        {
                            downloadBytes.AddOrUpdate(filterName, packet.Length, (key, oldValue) => oldValue + packet.Length);
                        }
                    }
                    else
                    {
                        await Task.Delay(10); // Prevent busy-waiting
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ProcessPackets: {ex.Message}");
                isRunning = false;
            }
        }

        private async Task MonitorDataUsage()
        {
            
            try
            {
                while (isRunning)
                {
                    foreach (var filterName in new[] { "3074", "27k", "7500", "30k" })
                    {
                        // Convert bytes to KB
                        double downloadKB = downloadBytes.GetOrAdd(filterName, 0) / 1024.0;
                        double uploadKB = uploadBytes.GetOrAdd(filterName, 0) / 1024.0;

                        // Display data usage
                        

                        DataUsageUpdated?.Invoke(filterName, downloadKB, uploadKB);

                        // Reset counters
                        downloadBytes[filterName] = 0;
                        uploadBytes[filterName] = 0;
                    }

                    // Wait for 1 second
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MonitorDataUsage: {ex.Message}");
                isRunning = false;
            }
        }
    }
}
