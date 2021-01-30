using System;
using MySql.Data.MySqlClient;

namespace ServerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试服务器的启动
            LogIn login = new LogIn();



            /*            //测试数据库
                        ConnDB connDB = new ConnDB("localhost", "3306", "root", "jinjiajia", "day05");
                        MySqlConnection conn = connDB.openDate();
                        string sqlStr = "select * from users where id=\"1\"";
                        //执行sql语句，并返回结果
                        MySqlCommand mycmd = new MySqlCommand(sqlStr, conn);
                        //从返回结果中提取数据
                        MySqlDataReader re = mycmd.ExecuteReader();
                        if (re.HasRows)
                        {
                            while (re.Read())
                            {
                                //读取三列数据
                                Console.WriteLine(re[1]);
                            }
                        }


                        connDB.closeDB();*/


        }
    }
}
