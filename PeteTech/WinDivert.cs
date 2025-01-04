using System.Collections.Concurrent;
using System.Diagnostics;
using WindivertDotnet;

namespace PeteTech
{
    internal class WinDiverts : Macros
    {


        // Thread-safe queue for packets
        private static ConcurrentQueue<(WinDivertPacket, WinDivertAddress)> packetQueue = new();
        private static bool isRunning = true;

        // Data counters
        private static long downloadBytes = 0;
        private static long uploadBytes = 0;


        private static WinDivert? l3074;
        private static WinDivert? l27k;
        private static WinDivert? l7500;
        private static WinDivert? l30k;

       

        public bool Buffering;

        public Macros macros = new Macros();


        //Morgan's code


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

        // 30k Filters
        public static string filter30k = "tcp.SrcPort <= 30009 and tcp.SrcPort >= 30000 or tcp.SrcPort <= 30009 and tcp.SrcPort >= 30000";
        public static string filter30kIN = "tcp.SrcPort <= 30009 and tcp.SrcPort >= 30000";
        public static string filter30kOUT = "tcp.SrcPort <= 30009 and tcp.SrcPort >= 30000";

        

        public bool unlimit = true;

        // Cancellation token to control loop termination
        private static CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

       




        public static async void Start3074(bool Enabled, string Status, bool BUFF)
        {
            

            try
            {
                // Check if Enabled is false, exit immediately
                if (!Enabled)
                {
                    if (l3074 != null)
                    {
                        l3074.Dispose();
                        l3074 = null;
                    }

                    // Cancel all loops and tasks
                    _cancellationTokenSource.Cancel();
                    return;
                }

                // Reset the cancellation token if Enabled is true
                _cancellationTokenSource = new CancellationTokenSource();

                // Initialize l3074 based on the status
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

               
                

                // Handle buffering logic
                if (!BUFF && Enabled && !_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    l3074.Send(packet, addr, new CancellationToken());
                    

                  
                }
                else
                {

                    
                    // Buffering logic with cancellation and Enabled checks
                    Random rand = new Random();
                    int randUnlimit = rand.Next(100, 200);
                    int randLimit = rand.Next(4000, 5000);

                    while (BUFF && Enabled && !_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                       
                        //UpdateDownloadStatus?.Invoke(download);

                        // Dispose and recreate WinDivert if necessary
                        if (l3074 != null)
                        {
                            l3074.Dispose();
                            l3074 = null;
                        }

                        await Task.Delay(randUnlimit, _cancellationTokenSource.Token);

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

                       
                       
                        l3074.Send(packet, addr, _cancellationTokenSource.Token);

                        await Task.Delay(randLimit, _cancellationTokenSource.Token);

                        if (l3074 != null)
                        {
                            l3074.Dispose();
                            l3074 = null;
                        }

                        Debug.WriteLine($"Bufferbloat enabled. Packet Length: {packetLen} bytes");

                        

                        // Break if Enabled is false
                        if (!Enabled || !BUFF)
                        {
                            break;
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation canceled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }




        public static async void Start7500(bool Enabled, string Status, bool BUFF)
        {
            try
            {
                if (!Enabled)
                {
                    if (l7500 != null)
                    {
                        l7500.Dispose();
                        l7500 = null;
                    }

                    _cancellationTokenSource.Cancel();
                    return;
                }

                _cancellationTokenSource = new CancellationTokenSource();

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

                if (!BUFF)
                {
                    Console.WriteLine($"Packet received: Length {packetLen} bytes");
                    l7500.Send(packet, addr, new CancellationToken());
                }
                else
                {
                    Random rand = new Random();
                    int randUnlimit = rand.Next(300, 500);
                    int randLimit = rand.Next(3000, 4000);

                    while (BUFF && Enabled && !_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        if (l7500 != null)
                        {
                            l7500.Dispose();
                            l7500 = null;
                        }
                        await Task.Delay(randUnlimit, _cancellationTokenSource.Token);

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

                        l7500.Send(packet, addr, _cancellationTokenSource.Token);

                        await Task.Delay(randLimit, _cancellationTokenSource.Token);

                        if (l7500 != null)
                        {
                            l7500.Dispose();
                            l7500 = null;
                        }

                        Debug.WriteLine($"Bufferbloat is now enabled. Packet Length: {packetLen} bytes");

                        if (!Enabled || !BUFF)
                        {
                            break;
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation canceled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static async void Start30k(bool Enabled, string Status, bool BUFF)
        {
            try
            {
                if (!Enabled)
                {
                    if (l30k != null)
                    {
                        l30k.Dispose();
                        l30k = null;
                    }

                    _cancellationTokenSource.Cancel();
                    return;
                }

                _cancellationTokenSource = new CancellationTokenSource();

                if (l30k == null)
                {
                    if (Status == "in/out")
                    {
                        l30k = new WinDivert(filter30k, WinDivertLayer.Network);
                    }
                    else if (Status == "in")
                    {
                        l30k = new WinDivert(filter30kIN, WinDivertLayer.Network);
                    }
                    else if (Status == "out")
                    {
                        l30k = new WinDivert(filter30kOUT, WinDivertLayer.Network);
                    }
                }

                WinDivertPacket packet = new WinDivertPacket(65535);
                WinDivertAddress addr = new WinDivertAddress();
                int packetLen = l30k.Recv(packet, addr);

                if (!BUFF)
                {
                    Console.WriteLine($"Packet received: Length {packetLen} bytes");
                    l30k.Send(packet, addr, new CancellationToken());
                }
                else
                {
                    Random rand = new Random();
                    int randUnlimit = rand.Next(50, 80);
                    int randLimit = rand.Next(3000, 4000);

                    while (BUFF && Enabled && !_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        if (l30k != null)
                        {
                            l30k.Dispose();
                            l30k = null;
                        }

                        await Task.Delay(randUnlimit, _cancellationTokenSource.Token);

                        if (l30k == null)
                        {
                            if (Status == "in/out")
                            {
                                l30k = new WinDivert(filter30k, WinDivertLayer.Network);
                            }
                            else if (Status == "in")
                            {
                                l30k = new WinDivert(filter30kIN, WinDivertLayer.Network);
                            }
                            else if (Status == "out")
                            {
                                l30k = new WinDivert(filter30kOUT, WinDivertLayer.Network);
                            }
                        }

                        l30k.Send(packet, addr, _cancellationTokenSource.Token);

                        await Task.Delay(randLimit, _cancellationTokenSource.Token);

                        if (l30k != null)
                        {
                            l30k.Dispose();
                            l30k = null;
                        }

                        Debug.WriteLine($"Bufferbloat is now enabled. Packet Length: {packetLen} bytes");

                        if (!Enabled || !BUFF)
                        {
                            break;
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation canceled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static async void Start27K(bool Enabled, string Status, bool BUFF)
        {
            try
            {
                if (!Enabled)
                {
                    if (l27k != null)
                    {
                        l27k.Dispose();
                        l27k = null;
                    }

                    _cancellationTokenSource.Cancel();
                    return;
                }

                _cancellationTokenSource = new CancellationTokenSource();

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

                if (!BUFF)
                {
                    Console.WriteLine($"Packet received: Length {packetLen} bytes");
                    l27k.Send(packet, addr, new CancellationToken());
                }
                else
                {
                    Random rand = new Random();
                    int randUnlimit = rand.Next(50, 80);
                    int randLimit = rand.Next(3000, 4000);

                    while (BUFF && Enabled && !_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        if (l27k != null)
                        {
                            l27k.Dispose();
                            l27k = null;
                        }

                        await Task.Delay(randUnlimit, _cancellationTokenSource.Token);

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

                        l27k.Send(packet, addr, _cancellationTokenSource.Token);

                        await Task.Delay(randLimit, _cancellationTokenSource.Token);

                        if (l27k != null)
                        {
                            l27k.Dispose();
                            l27k = null;
                        }

                        Debug.WriteLine($"Bufferbloat is now enabled. Packet Length: {packetLen} bytes");

                        if (!Enabled || !BUFF)
                        {
                            break;
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation canceled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

}
