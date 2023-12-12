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

        public NETClient()
        {

            using (var xClient = new DHCPClient())
            {
                /** Send a DHCP Discover packet **/
                //This will automatically set the IP config after DHCP response
                xClient.SendDiscoverPacket();
            }

        }

        private string ExtractDomainNameFromUrl(string url)
        {
            int start;
            if (url.Contains("://"))
            {
                start = url.IndexOf("://") + 3;
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

            return url[start..end];
        }


        private string ExtractPathFromUrl(string url)
        {
            int start;
            if (url.Contains("://"))
            {
                start = url.IndexOf("://") + 3;
            }
            else
            {
                start = 0;
            }

            int indexOfSlash = url.IndexOf("/", start);
            if (indexOfSlash != -1)
            {
                return url.Substring(indexOfSlash);
            }
            else
            {
                return "/";
            }
        }

        public string GET(string site, int port)
        {

            try
            {
                var dnsClient = new DnsClient();

                dnsClient.Connect(DNSConfig.DNSNameservers[0]);
                dnsClient.SendAsk(ExtractDomainNameFromUrl(site));
                Address address = dnsClient.Receive();
                dnsClient.Close();

                HttpRequest request = new();
                request.IP = address.ToString();
                request.Path = ExtractPathFromUrl(site);
                request.Method = "GET";
                request.Send();

                string httpresponse = request.Response.Content;

                return httpresponse;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

    }
}
