using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Configuration;
using System.Runtime.Remoting.Messaging;

namespace MyWeb.Web.SocketClient
{
    public class SocketClient
    {
        private static readonly int _port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
        private static IPAddress _ip = IPAddress.Parse(ConfigurationManager.AppSettings["IpAddress"]);
      

        public Socket socket;

        public SocketClient(string NickName)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(_ip, _port);
            }
            catch
            {
                throw new Exception("连接服务器失败!");
            }
            
            socket.Send(Encoding.Unicode.GetBytes(NickName));
        }
    }
}