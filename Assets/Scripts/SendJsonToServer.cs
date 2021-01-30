using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System;
using UnityEngine;
using System.Text;

public class SendJsonToServer:MonoBehaviour 
{
    private Socket socket;
    IPEndPoint iep;
/*    private string ip;
    private int port;*/

    public void Update()
    {
        /*   this.ip = _ip;
           this.port = _port;

   */
        if(Input.GetKeyDown(KeyCode.J))
        {
            ConnServer();
        }
        
    }
    public void ConnServer()
    {
        try
        {
            socket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"),30000);
            socket.Connect(iep);
            Debug.Log("服务器连接成功");

            //向服务器发送数据

            string demoStr = "我是客户端";
            byte[] bytes = Encoding.UTF8.GetBytes(demoStr);
            socket.Send(bytes);

        }
        catch (Exception e)
        {
            Debug.Log("连接失败" + e.ToString());
        }
    }
   

/*    public void StartConnent()
    {
        IPEndPoint iep = null;
        try
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            iep = new IPEndPoint(IPAddress.Parse(ip), port);
        }
        catch (System.Exception)
        {

            Debug.Log("服务器连接错误");

        }
        Console.WriteLine("Yes,ok");
        

        socket.Bind(iep);
    }*/
    public void sendToServer()
    {
        
    }


}
