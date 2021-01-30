using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ServerDemo
{
     
    class LogIn
    {
        //创建socket连接所用服务器地址和端口号
        private string ip = "127.0.0.1";
        private int port = 30000;
        /// <summary>
        /// 方便在实例化时直接执行相关操作
        /// </summary>
        public LogIn()
        {
            CreateServer server = new CreateServer(ip, port);
            Socket socket = server.StartSocket();
            Socket clider = socket.Accept();

            while (true)
            {              
                string strGet = GetReceive(clider);              
                string strSend = FindDate(strGet);
                Console.WriteLine(strSend);
                SendDate(clider, strSend);

            }
        }
        /// <summary>
        /// 获取客户端发送来的账号密码
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public string GetReceive(Socket socket)
        {
            string strGet = null;
            int maxBuffer = 1024;
            byte[] buffer = new byte[maxBuffer];
            try
            {
                
                int length = socket.Receive(buffer);
                
                strGet = Encoding.UTF8.GetString(buffer, 0, length);
                Console.WriteLine("收到内容:"+strGet);
                return strGet;               
               

            }
            catch (Exception e)
            {

                Console.WriteLine(" 获取内容失败：错误为：" + e.ToString());
            }
            return null;
        }

        private string hostDB = "localhost";
        private string portDB = "3306";
        private string userDB = "root";
        private string passwordDB = "jinjiajia";
        private string dateNameDB = "day05";

        /// <summary>
        /// 查询数据库，判断字符串是否存在
        /// </summary>
        /// <param name="strGet"></param>
        /// <returns></returns>
        private string FindDate(string strGet)
        {
            if(strGet==null)
            {
                Console.WriteLine("获取服务器字符串为空");
                return "null";
            }

            //处理输入的账号密码字符串
            string[] strGets = strGet.Split(" ");
            string userName = strGets[0];
            string password = strGets[1];
            

            //创建sql语言并执行查询
            try
            {
                
                ConnDB connDB = new ConnDB(hostDB, portDB, userDB, passwordDB, dateNameDB);
                MySqlConnection conn = connDB.openDate();

                string sql = string.Format("select * from Login where username=\"{0}\"", userName);
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                //对查询的返回结果进行读取
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) //判断查询结果是否为空
                {
                    
                    if (reader[1].Equals(password))
                    {
                        Console.WriteLine("成功查询到账号密码");
                        return "succes";
                    }
                    else
                    {
                        Console.WriteLine("有查询结果，但是与输入不同，判短输入密码错误");
                        return "passwordError";
                    }
                }
                else
                {
                    Console.WriteLine("查询为空,账号不存在");
                    return "userNameError";
                }               
            }
            catch (Exception e)
            {

                Console.WriteLine("连接数据库报错："+e.ToString());
            }
            Console.WriteLine("查询过程出错");
            return "error";
        }

        /// <summary>
        /// 向客户端返回查询结果
        /// </summary>
        private void SendDate(Socket socket,string strSend)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(strSend);
            socket.Send(bytes);

        }

    }
}
