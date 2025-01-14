using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindivertDotnet;

namespace PeteTech
{
    public class ReconnectModule
    {
        private Dictionary<string, List<Packet>> connections = new();
        private bool isActivated;
        private DateTime startTime;
        
        

        public ReconnectModule()
        {
            isActivated = false;
            
            
        }

        public void Toggle()
        {
            isActivated = true;
            startTime = DateTime.Now;

            foreach (var addr in connections.Keys.ToArray())
            {
                try
                {
                    if (connections.TryGetValue(addr, out var q) && q is not null && DateTime.Now - q.LastOrDefault()?.CreatedAt < TimeSpan.FromSeconds(10))
                        Inject(addr);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            Task.Run(async () =>
            {
                await Task.Delay(150);
                isActivated = false;
            });
        }

        private void Inject(string addr)
        {
            var con = connections[addr];
            var outExample = con.LastOrDefault(x => !x.Inbound && x.Length != 0 && IsPortInRange(x));
            var inExample = con.LastOrDefault(x => x.Inbound && x.Length != 0 && IsPortInRange(x));

            if (outExample is null || inExample is null)
            {
                Console.WriteLine($"Can't kill {addr}");
                return;
            }

            // Outbound RST packet
            var p1 = outExample.BuildSameDirection();
            p1.TcpHeader.Rst = true;
            p1.Recalc();
            SendPacket(p1);

            // Inbound RST packet
            var p2 = inExample.BuildSameDirection();
            p2.TcpHeader.Rst = true;
            p2.Recalc();
            SendPacket(p2);
        }

        private bool IsPortInRange(Packet packet)
        {
            return (packet.TcpHeader.SrcPort >= 30000 && packet.TcpHeader.SrcPort <= 30009) ||
                   (packet.TcpHeader.DstPort >= 30000 && packet.TcpHeader.DstPort <= 30009);
        }

        private void SendPacket(Packet packet)
        {
            // Implement packet sending logic here
        }

        private class Packet
        {
            public bool Inbound { get; set; }
            public int Length { get; set; }
            public DateTime CreatedAt { get; set; }
            public TcpHeader TcpHeader { get; set; }

            public Packet BuildSameDirection()
            {
                // Implement packet cloning logic here
                return new Packet();
            }

            public void Recalc()
            {
                // Implement packet recalculation logic here
            }
        }

        private class TcpHeader
        {
            public int SrcPort { get; set; }
            public int DstPort { get; set; }
            public bool Rst { get; set; }
        }
    }
}
