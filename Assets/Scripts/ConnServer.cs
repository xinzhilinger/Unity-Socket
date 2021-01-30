using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class ConnServer
{
    private Socket socket;
    private IPEndPoint ipe;
    //ip地址和端口号,需要和服务器端保持一致
    private string ip;
    private int port;

    public ConnServer(string _ip,int _port)
    {
        this.ip = _ip;
        this.port = _port;
    }

    public Socket conn()
    {
        try
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ipe = new IPEndPoint(IPAddress.Parse(ip), port);
            //Connect()为连接服务器端方法
            socket.Connect(ipe);
            Debug.Log("连接服务器成功");

        }
        catch (System.Exception e)
        {
            Debug.Log("连接服务器错误，原因为：" + e.ToString());
            
        }
        
        return socket;
    }

    public void CloseServer(Socket socket)
    {
        //禁用某 Socket 上的发送和接收，Both代表双向关闭
        socket.Shutdown(SocketShutdown.Both);
        //直接关闭服务
        socket.Close();
    }

}
