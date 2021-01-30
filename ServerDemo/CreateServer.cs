using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerDemo
{
    class CreateServer
    {
        //服务器地址和端口号
        private string ip;
        private int port;

        private Socket socket = null;

        /// <summary>
        /// 构造函数获取服务器地址和端口号
        /// </summary>
        /// <param name="_ip"></param>
        /// <param name="_port"></param>
        public CreateServer(string _ip, int _port)
        {
            this.ip = _ip;
            this.port = _port;

        }

        /// <summary>
        /// 创建Socket，并开启监控
        /// </summary>
        /// <returns></returns>
        public Socket StartSocket()
        {
        
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ip), port);
                socket.Bind(iep);
                socket.Listen(1000);
                Console.WriteLine("服务器开启成功！");
            }
            catch (Exception e)
            {
                Console.WriteLine("服务器开启失败,原因为："+e.ToString());
            }
            return socket;
        }
        public void CloseSocket(Socket socket)
        {
            //禁用某 Socket 上的发送和接收，Both代表双向关闭
            socket.Shutdown(SocketShutdown.Both);
            //直接关闭服务
            socket.Close();
        }
    }
}
