using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace ServerDemo
{
    class ConnDB
    {
        //定义连接地址、端口号、登录用户名、密码、数据库名
        private string server;
        private string port;
        private string user;
        private string password;
        private string datename;

        private MySqlConnection conn;
        //构造函数接收参数
        public ConnDB(string _server,string _port,string _user,string _password,string _datename)
        {
            this.server = _server;
            this.port = _port;
            this.user = _user;
            this.password = _password;
            this.datename = _datename;
        } 
       // 
       /// <summary>
       ///  连接打开数据库
       /// </summary>
        public MySqlConnection openDate()
        {
            try
            {
                string connStr = string.Format("server={0};port={1};user={2};password={3}; database={4};", server, port, user, password, datename);
                //连接数据库
                conn = new MySqlConnection(connStr);
                //打开
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("连接数据库错误,原因为：" + e.ToString());
            }
            return conn;            
        }

        public void closeDB()
        {
            //关闭数据库
            conn.Close();
        }

       


    }
}
