using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace Application_Prototype
{
    public class Task
    {

        public int Task_ID { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public int TaskRate { get; set; }
        public string Message { get; set; }

        public string AddTask(NameValueCollection NewTaskData)
        {
            this.TaskTitle = NewTaskData["CtrlTaskTitle"];
            this.TaskDescription = NewTaskData["CtrlTaskDesc"];
            this.TaskRate = Convert.ToInt32(NewTaskData["CtrlTaskRate"]);

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand AddTask = new SqlCommand
            {
                CommandText = "INSERT TASK (TaskTitle, TaskDescription, TaskRate) " +
                "VALUES ('" + TaskTitle + "', '" + TaskDescription + "', '" + TaskRate + "')",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = AddTask.ExecuteNonQuery();
                if (a == 0)
                {
                    this.Message = "Query Has Failed";
                }
                else
                {
                    this.Message = "Query Has Succeeded";
                }
            }
            else
            {
                this.Message = "DataBase Connection Failed";
            }
            DBConnect.DropConn(con);
            return Message;
        }

        public List<List<string>> GetTask() //The return type is set to a multidimensional list as its going to hold alot of information 
        {
            SqlConnection con = DBConnect.MakeConn();

            //Sql command to get all tasks in database
            SqlCommand GetAllTasks = new SqlCommand
            {
                CommandText = "SELECT * FROM TASK",
                CommandType = CommandType.Text,
                Connection = con
            };

            // Multidimensional list that will hold query results 
            List<List<string>> AllTask = new List<List<string>>();

            // Get results 
            //Data reader called to read the data 
            SqlDataReader r = GetAllTasks.ExecuteReader();

            // r is short for reader
            if (r.HasRows) //If data found with HasRows, then proceed
            {
                while (r.Read()) //read method going through r and reading everything once at a time
                {
                    //add each record found in the list (multiple components listed below)
                    AllTask.Add(new List<string> {r["Task_ID"].ToString(), //Task ID is an int in DB so its converted to string
                        r["TaskTitle"].ToString(), r["TaskDescription"].ToString(), r["TaskRate"].ToString(),});
                }
                r.Close();
            }
            else //else statement incase something goes wrong
            {
                AllTask = null; //if nothing returend just set to null and let user know
            }

            DBConnect.DropConn(con);
            return AllTask; //return multiD list

        }

        public List<string> GetTask(int TaskID)
        {
            this.Task_ID = TaskID;
            List<string> details = new List<string>(4); //expect 6 objects

            SqlConnection con = DBConnect.MakeConn();

            //Sql command to get the specific client details
            SqlCommand GetTaskDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM TASK WHERE Task_ID = " + Task_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetTaskDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["Task_ID"].ToString()); // Add Staff_ID to the list index position 0 
                    details.Add(r["TaskTitle"].ToString()); // Add StaffName to the list index position 1
                    details.Add(r["TaskDescription"].ToString()); // Add StaffSurname to the list index position 2
                    details.Add(r["TaskRate"].ToString()); // Add StaffEmail to the list index position 3
    
                }
            }
            DBConnect.DropConn(con);
            return details;

        }

        public string UpdateTask(NameValueCollection UpdateTaskData)
        {
            this.Task_ID = Convert.ToInt32(UpdateTaskData["CtrlTaskID"]);
            this.TaskTitle = UpdateTaskData["CtrlTaskTitle"];
            this.TaskDescription = UpdateTaskData["CtrlTaskDesc"];
            this.TaskRate = Convert.ToInt32(UpdateTaskData["CtrlTaskRate"]);

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand UpdateTask = new SqlCommand
            {
                CommandText = "UPDATE TASK SET TaskTitle = '" + TaskTitle + "', TaskDescription = '" + TaskDescription + "'," +
                " TaskRate = '" + TaskRate + "' WHERE Task_ID = " + Task_ID,
                CommandType = CommandType.Text,
                Connection = con

            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateTask.ExecuteNonQuery();
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
