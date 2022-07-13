using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SchoolManagement
{
    class Connetion
    {
        SqlConnection connec = new SqlConnection();

        static string Server;
        static string Db;
        static string User;
        static string Password;
        static string Port;

        string strConnec = "Data source" + Server + ", " + Port + ";" + "User ID" + User + ";" + "Password= " + Password + ";" + "Initial Catalog" + Db + ";";

        public SqlConnection SetConnec() {
            try
            {
                connec.ConnectionString = strConnec;
                connec.Open();
                Console.WriteLine("Connected");
            }
            catch (SqlException e) {
                Console.WriteLine(e.Message);
            }
            return connec;
        }
    }
}
