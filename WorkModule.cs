using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Application_Prototype
{
    public class WorkModule
    {
        public int Work_ID { get; set; }
        public int Client_ID { get; set; }
        public int Task_ID { get; set; }
        public int Staff_ID { get; set; }
        public string Message { get; set; }

        public string AddWorkModule(NameValueCollection NewWorkModuleData)
        {
            this.Client_ID = Convert.ToInt32(NewWorkModuleData["CtrlClientList"]);
            this.Task_ID = Convert.ToInt32(NewWorkModuleData["CtrlTaskList"]);
            this.Staff_ID = Convert.ToInt32(NewWorkModuleData["CtrlStaffList"]);

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand AddWorkModule = new SqlCommand
            {
                CommandText = "INSERT WORKMODULE (Client_ID, Task_ID, Staff_ID) VALUES ('" + Client_ID + "', '" + Task_ID + "', '" + Staff_ID + "' )",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = AddWorkModule.ExecuteNonQuery();
                if (a == 0)
                {
                    this.Message = "Query Failed";
                }
                else
                {
                    this.Message = "Query Succeeded";
                }
            }
            else
            {
                this.Message = "SQL DB CONNECT FAILED";
            }
            DBConnect.DropConn(con);
            return Message;
        }

        // no paramater is set as it will return all information not anything specific 
        public List<List<string>> GetWorkModule() //Setting method to a multidimensioan list 
        {
            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetAllWorkModule = new SqlCommand
            {
                CommandText = "SELECT * FROM WORKMODULE",
                CommandType = CommandType.Text,
                Connection = con
            };

            //MD List to hold all info 
            List<List<string>> AllWorkModule = new List<List<string>>();


            SqlDataReader r = GetAllWorkModule.ExecuteReader();

            if (r.HasRows) //checking if r has any rows and if it does then proceed 
            {
                while (r.Read()) //using a while loop and the read method to go through everything once at a time
                {
                    AllWorkModule.Add(new List<string> {r["Work_ID"].ToString(),
                        r["Task_ID"].ToString(), r["Staff_ID"].ToString(),});
                }
                r.Close(); //close above 
            }
            else //incase something goes wrong proceed with below
            {
                AllWorkModule = null; //if nothing is returned then just set it to null
            }
            DBConnect.DropConn(con); //drop connection when complete 
            return AllWorkModule;

        }

        public List<string> GetWorkModule(int WorkID)
        {
            this.Work_ID = WorkID;
            List<string> details = new List<string>(4); //expect 4 objects

            SqlConnection con = DBConnect.MakeConn();

            //Sql command to get the specific client details
            SqlCommand GetWorkModuleDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM WorkModule WHERE Work_ID = " + Work_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetWorkModuleDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["Work_ID"].ToString()); // Add Staff_ID to the list index position 0 
                    details.Add(r["Client_ID"].ToString()); // Add StaffName to the list index position 1
                    details.Add(r["Task_ID"].ToString()); // Add StaffSurname to the list index position 2
                    details.Add(r["Staff_ID"].ToString()); // Add StaffEmail to the list index position 3

                }
            }
            DBConnect.DropConn(con);
            return details;

        }

        public string UpdateWorkModule(NameValueCollection UpdateWorkModuleData)

        {
            this.Work_ID = Convert.ToInt32(UpdateWorkModuleData["CtrlWorkID"]);
            this.Client_ID = Convert.ToInt32(UpdateWorkModuleData["CtrlClientList"]);
            this.Task_ID = Convert.ToInt32(UpdateWorkModuleData["CtrlTaskList"]);
            this.Staff_ID = Convert.ToInt32(UpdateWorkModuleData["CtrlStaffList"]);


            SqlConnection con = DBConnect.MakeConn();

            SqlCommand UpdateStaff = new SqlCommand
            {
                CommandText = "UPDATE WORKMODULE SET Client_ID = '" + Client_ID + "', Task_ID = '" + Task_ID + "'," +
                " Staff_ID = '" + Staff_ID + "' WHERE Work_ID = " + Work_ID,
                CommandType = CommandType.Text,
                Connection = con

            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateStaff.ExecuteNonQuery();
                if (a == 0)
                {
                    this.Message = "Query Failed";
                }
                else
                {
                    this.Message = "Query Succeeded";
                }
            }
            else
            {
                this.Message = "SQL Database connection failed";
            }
            DBConnect.DropConn(con);
            return Message;
        }



    }
}