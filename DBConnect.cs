using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Application_Prototype
{
    public class DBConnect
    {

        public static SqlConnection MakeConn()   //method so we can connect to the database
        {
            string str = ConfigurationManager.ConnectionStrings["aprotodbcon"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            con.Open();
            return con;
        }

        public static void DropConn(SqlConnection con) //method so we can drop connection from database
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
                con.Dispose();
                 
        }


    }
}