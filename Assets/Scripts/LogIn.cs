using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

public class LogIn : MonoBehaviour
{

    //账号密码输入框
    public InputField userNameInput;
    public InputField passwordInput;

    public void loginButton()
    {
        //获取连个输入框输入并合并返回一个字符串
        string strSend = getInputDate();
        if (strSend != null)
        {
            //如果返回的字符串不为空，则将其发送给服务器端
            Socket socket = sendDateToServer(strSend);
            //接受服务器端返回的结果
            string strReturn = getReturnDate(socket);
            //处理服务端返回的结果
            showStatus(strReturn);
        }
        else
        {
            Debug.Log("账号或密码为空");
        }
    }

    /// <summary>
    /// 获取输入框内容
    /// </summary>
    public string getInputDate()
    {
        if (userNameInput.text != "" && passwordInput.text != "")
        {
            //获取输入框文本,并剔除掉空格
            string userName = userNameInput.text.Replace(" ", "");
            string password = passwordInput.text.Replace(" ", "");
            //将两个字符串合并
            string strSend = userName + " " + password;



            return strSend;
        }
        return null;
    }

    private bool isConn = false;
    private ConnServer connServer;
    private Socket socket;

    /// <summary>
    /// 向服务器发送数据
    /// </summary>
    /// <param name="strSend"></param>
    /// <returns></returns>
    public Socket sendDateToServer(string strSend)
    {


        byte[] bytes = Encoding.UTF8.GetBytes(strSend);
        //使用之前创建的连接服务器的类来连接到服务器
        if (isConn == false)
        {
            connServer = new ConnServer("127.0.0.1", 30000);

            socket = connServer.conn();

            isConn = true;
        }

        //向服务器发送数据
        socket.Send(bytes);
       
        return socket;
    }
    /// <summary>
    ///  获取服务器的返回结果
    /// </summary>
    /// <param name="socket"></param>
    /// <returns></returns>
    public string getReturnDate(Socket socketDemo)
    {
        byte[] bytes;
        string strGet = null;
        int maxBuffer = 1024;
        byte[] buffer = new byte[maxBuffer];
        try
        {
            int length = socketDemo.Receive(buffer);
            strGet = Encoding.UTF8.GetString(buffer, 0, length);
            
            return strGet;
        }
        catch (Exception e)
        {

            Debug.Log(" 获取服务器内容失败：错误为：" + e.ToString());
        }
        return "error";
    }
    /// <summary>
    /// 处理返回的字符串
    /// </summary>
    /// <param name="strGet"></param>
        public void showStatus(string strGet)
        {
            switch(strGet)
            {
                case "succes":

                    Debug.Log("查询成功");
                    break;
                case "userNameError":
                    Debug.Log("输入用户名错误");
                    break;
                case "passwordError":
                    Debug.Log("输入密码错误");
                    break;
                default:
                    Debug.Log("服务器连接错误");
                    break;
            }

        }
    
}
