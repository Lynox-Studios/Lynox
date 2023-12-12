using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Network;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4.UDP.DNS;
using Cosmos.System.Network.IPv4;
using Cosmos.HAL;
using System.IO;
using System.Security.Policy;
using CosmosHttp.Client;

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
                dnsClient = new DnsClient();

                dnsClient.Connect(DNSConfig.DNSNameservers[0]);





            }
            else
            {
                start = 0;
            }

            int end = url.IndexOf("/", start);
            if (end == -1)
            {
                end = url.Length;
            }

            dnsClient.SendAsk(site);

            Address address = dnsClient.Receive();

            return HttpGET(Data);
            return HttpGET(Data);
            return HttpGET(Data);
            return HttpGET(Data);

                return httpresponse;
            }
            catch (Exception ex)
            dnsClient.Close();
            dnsClient.Close();
            tcpClient.Close();
            dnsClient.Close();
            tcpClient.Close();
            dnsClient.Close();
            tcpClient.Close();
            dnsClient.Close();
            tcpClient.Close();

        }

    }
}
