using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    ConnServer connServer;
    public InputField userInput;
    public InputField passwordInput;
    private int timeDemo = 1;
    public Socket socket;

    private void Start()
    {

        
    }

    public void Login()
    {
        //连接服务器的socket
        connServer = new ConnServer("127.0.0.1", 30000);
        Socket socket = connServer.conn();
        
        string user = userInput.text;
        string password = passwordInput.text;
        //获取输入后将输入框清零
        userInput.text = "";
        passwordInput.text = "";
        //将数据合并，方便传送
        string sendText = string.Format("{0} {1}", user, password);
        Debug.Log(sendText);
        byte[] bytes = Encoding.UTF8.GetBytes(sendText);
        socket.Send(bytes);
        connServer.CloseServer(socket);
    }
    public void getnub()
    {
        
    }
}
