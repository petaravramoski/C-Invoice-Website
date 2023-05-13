using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Application_Prototype
{
    public class Staff
    {

        public int Staff_ID { get; set; }
        public string StaffName { get; set; }
        public string StaffSurname { get; set; }
        public string StaffEmail { get; set; }
        public string StaffPassword { get; set; }
        public string StaffAccessLevel { get; set; }
        public string StaffStatus { get; set; }
        public string Message { get; set; }


        public string AddStaff(NameValueCollection NewStaffData)
        {
            this.StaffName = NewStaffData["CtrlStaffName"];
            this.StaffSurname = NewStaffData["CtrlStaffSurname"];
            this.StaffEmail = NewStaffData["CtrlStaffEmail"];
            this.StaffPassword = NewStaffData["CtrlStaffPassword"];
            this.StaffAccessLevel = NewStaffData["CtrlStaffAccessLevel"];
            this.StaffStatus = NewStaffData["CtrlStaffStatus"];

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand AddStaff = new SqlCommand
            {
                CommandText = "INSERT STAFF (StaffName, StaffSurname, StaffEmail, StaffPassword, StaffAccessLevel, StaffStatus) " +
                "VALUES ('" + StaffName + "','" + StaffSurname + "', '" + StaffEmail + "', '" + StaffPassword + "', '" + StaffAccessLevel + "', '" + StaffStatus + "')",
                CommandType = CommandType.Text,
                Connection = con
                
            };

            // if statement to make sure if there is an error the sql statment wont execute 
            if (con.State == ConnectionState.Open)
            {
                int a = AddStaff.ExecuteNonQuery();
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

        // no paramater is set as it will return all information not anything specific 
        public List<List<string>> GetStaff() //Setting method to a multidimensioan list 
        {
            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetAllStaff = new SqlCommand
            {
                CommandText = "SELECT * FROM STAFF",
                CommandType = CommandType.Text,
                Connection = con
            };

            //MD List to hold all info 
            List<List<string>> AllStaff = new List<List<string>>();


            SqlDataReader r = GetAllStaff.ExecuteReader();

            if (r.HasRows) //checking if r has any rows and if it does then proceed 
            {
                while (r.Read()) //using a while loop and the read method to go through everything once at a time
                {
                    AllStaff.Add(new List<string> {r["Staff_ID"].ToString(),
                        r["StaffName"].ToString(), r["StaffSurname"].ToString(),
                        r["StaffEmail"].ToString(), r["StaffPassword"].ToString(), r["StaffAccessLevel"].ToString(),
                        r["StaffStatus"].ToString(),});
                }
                r.Close(); //close above 
            }
            else //incase something goes wrong proceed with below
            {
                AllStaff = null; //if nothing is returned then just set it to null
            }
            DBConnect.DropConn(con); //drop connection when complete 
            return AllStaff;

        }

        public List<string> GetStaff(int StaffID)
        {
            this.Staff_ID = StaffID;
            List<string> details = new List<string>(7); //expect 6 objects

            SqlConnection con = DBConnect.MakeConn();

            //Sql command to get the specific client details
            SqlCommand GetStaffDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM STAFF WHERE Staff_ID = " + Staff_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetStaffDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["Staff_ID"].ToString()); // Add Staff_ID to the list index position 0 
                    details.Add(r["StaffName"].ToString()); // Add StaffName to the list index position 1
                    details.Add(r["StaffSurname"].ToString()); // Add StaffSurname to the list index position 2
                    details.Add(r["StaffEmail"].ToString()); // Add StaffEmail to the list index position 3
                    details.Add(r["StaffPassword"].ToString()); // Add StaffPassword to the list index position 4
                    details.Add(r["StaffAccessLevel"].ToString()); // Add StaffAccessLevel to the list index position 5
                    details.Add(r["StaffStatus"].ToString()); // Add StaffStatus to the list index position 6

                }
            }
            DBConnect.DropConn(con);
            return details;

        }

        public string UpdateStaff(NameValueCollection UpdateStaffData)
        {
            this.Staff_ID = Convert.ToInt32(UpdateStaffData["CtrlStaffID"]);
            this.StaffName = UpdateStaffData["CtrlStaffName"];
            this.StaffSurname = UpdateStaffData["CtrlStaffSurname"];
            this.StaffEmail = UpdateStaffData["CtrlStaffEmail"];
            this.StaffAccessLevel = UpdateStaffData["CtrlStaffAccessLevel"];
            this.StaffStatus = UpdateStaffData["CtrlStaffStatus"];

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand UpdateStaff = new SqlCommand
            {
                CommandText = "UPDATE STAFF SET StaffName = '" + StaffName + "', StaffSurname = '" + StaffSurname + "'," +
                " StaffEmail = '" + StaffEmail + "', StaffAccessLevel = '" + StaffAccessLevel + "', StaffStatus = '" + StaffStatus + "' WHERE Staff_ID = " + Staff_ID,
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

        public List<string> GetStaff(string Staff_Email, string Staff_Password)
        {
            this.StaffEmail = Staff_Email;
            this.StaffPassword = Staff_Password;

            List<string> details = new List<string>(2);

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetStaffDetails = new SqlCommand
            {
                CommandText = "SELECT StaffName, StaffAccessLevel FROM [STAFF] WHERE StaffEmail = '" + StaffEmail + "' AND StaffPassword = '" + StaffPassword + "'",
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetStaffDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["StaffName"].ToString());
                    details.Add(r["StaffAccessLevel"].ToString());
                }
            }
            DBConnect.DropConn(con);
            return details;
        }
    }
}