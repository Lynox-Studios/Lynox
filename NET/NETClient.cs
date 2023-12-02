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
        TcpClient tcpClient;

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
                tcpClient = new TcpClient();

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

            tcpClient.Connect(address, port);

        }

        public string HttpGET(string Data)
        {

            tcpClient.Send(Encoding.ASCII.GetBytes(Data));

            var ep = new EndPoint(Address.Zero, 0);
            var data = tcpClient.Receive(ref ep);

            string httpresponse = Encoding.ASCII.GetString(data);


            string[] responseParts = httpresponse.Split(new[] { "\r\n\r\n" }, 2, StringSplitOptions.None);

            if (responseParts.Length == 2)
            {
                string headers = responseParts[0];
                string content = responseParts[1];
                return content;
            }
            else
            {
                return "";
            }

        }

        public string ConnectAndGet(string site, int port, string Data)
        {

            Connect(site, port);
            return HttpGET(Data);

        }

        public void Close()
        {

            dnsClient.Close();
            tcpClient.Close();

        }

    }
}
