using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Network;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4.UDP.DNS;
using Cosmos.System.Network.IPv4.TCP;
using Cosmos.System.Network.IPv4;
using Cosmos.HAL;

namespace Lynox.net
{
    public class NETClient
    {

        DnsClient dnsClient;

        public NETClient()
        {

            using (var xClient = new DHCPClient())
            {
                /** Send a DHCP Discover packet **/
                //This will automatically set the IP config after DHCP response
                xClient.SendDiscoverPacket();
            }

            try
            {

                dnsClient = new DnsClient();

                dnsClient.Connect(DNSConfig.DNSNameservers[0]);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public void Connect(string site, int port)
        {

            dnsClient.SendAsk(site);

            Address address = dnsClient.Receive();


        }

        public void Close()
        {

            dnsClient.Close();

        }

    }
}
