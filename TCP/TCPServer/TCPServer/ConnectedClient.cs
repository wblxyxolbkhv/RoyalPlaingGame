using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace TCPServer
{
    public class ConnectedClient
    {
        public ConnectedClient(string n, EndPoint ip)
        {
            Name = n;
            IP = ip;
        }
        public EndPoint IP { get; set; }
        public string Name { get; set; }
    }
}
