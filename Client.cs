using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace Application_Prototype
{
    public class Client
    {
        //Fields that match database 
        public int Client_ID { get; set; } //reason for INT here is because it is implmeneted as an INT in the database
        public string CompName { get; set; }
        public string CompAdd1 { get; set; }
        public string CompAdd2 { get; set; }
        public string CompLocation { get; set; }
        public string CompPcode { get; set; }
        public string ContactFname { get; set; }
        public string ContactLname { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMobile { get; set; }
        public string BillTo { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        // This method below is to add a new client to the system 
        public string AddClient(NameValueCollection NewClientData)
        {

            this.CompName = NewClientData["CtrlCompName"];//name of fields that got passed through in (html)
            this.CompAdd1 = NewClientData["CtrlCompAdd1"];
            this.CompAdd2 = NewClientData["CtrlCompAdd2"];
            this.CompLocation = NewClientData["CtrlCompLocation"];
            this.CompPcode = NewClientData["CtrlCompPcode"];
            this.ContactFname = NewClientData["CtrlContactFname"];
            this.ContactLname = NewClientData["CtrlContactLname"];
            this.ContactEmail = NewClientData["CtrlContactEmail"];
            this.ContactMobile = NewClientData["CtrlMobile"];
            this.BillTo = NewClientData["CtrlBillTo"];
            this.Status = NewClientData["CtrlStatus"];

            SqlConnection con = DBConnect.MakeConn(); //creating new SQL Connection using DBConnect (connection is called con) 

            SqlCommand AddClient = new SqlCommand
            {
                CommandText = "INSERT CLIENT (CompName, CompAdd1, CompAdd2, CompLocation, CompPcode, ContactFname, ContactLname, ContactEmail, ContactMobile, BillTo, Status)" +
                " VALUES ('" + CompName + "', '" + CompAdd1 + "', '" + CompAdd2 + "', '" + CompLocation + "', '" + CompPcode + "', '" + ContactFname + "', '" + ContactLname + "'," +
                "'" + ContactEmail + "', '" + ContactMobile + "', '" + BillTo + "', '" + Status + "' )",
                CommandType = CommandType.Text,
                Connection = con
            };

            // if statement to make sure if there is an error the sql statment wont execute 
            if (con.State == ConnectionState.Open)
            {
                int a = AddClient.ExecuteNonQuery();
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

        //list all clients in database
        // the method below has no paramater because it will retreive all clients
        public List<List<string>> GetClient() //The return type is set to a multidimensional list as its going to hold alot of information 
        {
            SqlConnection con = DBConnect.MakeConn();

            //Sql command to get all clients in database
            SqlCommand GetAllClients = new SqlCommand
            {
                CommandText = "SELECT * FROM CLIENT",
                CommandType = CommandType.Text,
                Connection = con
            };

            // Multidimensional list that will hold query results 
            List<List<string>> AllClients = new List<List<string>>();

            // Get results 
            //SQL Data reader called to read the data 
            SqlDataReader r = GetAllClients.ExecuteReader();

            // r is short for reader
            if (r.HasRows) //If data found with HasRows, then proceed
            {
                while (r.Read()) //read method going through r and reading everything once at a time
                {
                    //add each record found in the list (multiple components listed below)
                    AllClients.Add(new List<string> {r["Client_ID"].ToString(), //Client ID is an int in DB so its converted to string
                        r["CompName"].ToString(), r["CompAdd1"].ToString(), r["CompAdd2"].ToString(),
                        r["CompLocation"].ToString(), r["CompPcode"].ToString(), r["ContactFname"].ToString(),
                        r["ContactLname"].ToString(), r["ContactEmail"].ToString(), r["ContactMobile"].ToString(),
                        r["BillTo"].ToString(), r["Status"].ToString(),}); 
                }
                r.Close();
            }
            else //else statement incase something goes wrong
            {
                AllClients = null; //if nothing returend just set to null and let user know
            }

            DBConnect.DropConn(con);
            return AllClients; //return multiD list

        }

        // Method below displays specific client details
        public List<string> GetClient(int ClientID)
        {
            this.Client_ID = ClientID;
            List<string> details = new List<string>(12); //expect 12 objects

            SqlConnection con = DBConnect.MakeConn();

            //Sql command to get the specific client details
            SqlCommand GetClientDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM CLIENT WHERE Client_ID = " + Client_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            //SQL Data reader called to read the data 
            SqlDataReader r = GetClientDetails.ExecuteReader();

            //if r has no rows returned then proceed
            if (!r.HasRows)
            {
                details = null;
            }
            else //else if rows arent empty then proceed
            {
                while (r.Read()) //read method going through r and reading everything once at a time
                {
                    details.Add(r["Client_ID"].ToString()); // Add Client_ID to the list index position 0 
                    details.Add(r["CompName"].ToString()); // Add CompName to the list index position 1
                    details.Add(r["CompAdd1"].ToString()); // Add CompAdd1 to the list index position 2
                    details.Add(r["CompAdd2"].ToString()); // Add CompAdd2 to the list index position 3
                    details.Add(r["CompLocation"].ToString()); // Add CompLocation to the list index position 4
                    details.Add(r["CompPcode"].ToString()); // Add CompPcode to the list index position 5
                    details.Add(r["ContactFname"].ToString()); // Add ContactFname to the list index position 6
                    details.Add(r["ContactLname"].ToString()); // Add ContactLname to the list index position 7
                    details.Add(r["ContactEmail"].ToString()); // Add ContactEmail to the list index position 8
                    details.Add(r["ContactMobile"].ToString()); // Add Contact Mobile to the list index position 9
                    details.Add(r["BillTo"].ToString()); // Add BilLTo to the list index position 10
                    details.Add(r["Status"].ToString()); // Add Status to the list index position 11
                }
            }
            DBConnect.DropConn(con);
            return details;

        }

        public string UpdateClient(NameValueCollection UpdateClientData)
        {
            this.Client_ID = Convert.ToInt32(UpdateClientData["CtrlClientID"]);//INT32 used because its an self incremetning int in the database
            this.CompName = UpdateClientData["CtrlCompName"];//name of fields that got passed through in (html)
            this.CompAdd1 = UpdateClientData["CtrlCompAdd1"];
            this.CompAdd2 = UpdateClientData["CtrlCompAdd2"];
            this.CompLocation = UpdateClientData["CtrlCompLocation"];
            this.CompPcode = UpdateClientData["CtrlCompPcode"];
            this.ContactFname = UpdateClientData["CtrlContactFname"];
            this.ContactLname = UpdateClientData["CtrlContactLname"];
            this.ContactEmail = UpdateClientData["CtrlContactEmail"];
            this.ContactMobile = UpdateClientData["CtrlContactMobile"];
            this.BillTo = UpdateClientData["CtrlBillTo"];
            this.Status = UpdateClientData["CtrlStatus"];

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand UpdateClient = new SqlCommand
            {//sql command below calling update to update all the collumns 
                CommandText = "UPDATE CLIENT SET CompName = '"+ CompName + "', CompAdd1 = '" + CompAdd1 + "'," +
                "CompAdd2 = '" + CompAdd2 + "', CompLocation = '" + CompLocation + "', CompPcode = '" + CompPcode + "'," +
                "ContactFname = '" + ContactFname + "', ContactLname = '" + ContactLname + "', ContactEmail = '" + ContactEmail + "', " +
                "ContactMobile = '" + ContactMobile + "', BillTo = '" + BillTo + "', Status = '" + Status + "' WHERE Client_ID = " + Client_ID, 
                CommandType = CommandType.Text,
                Connection = con

            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateClient.ExecuteNonQuery();
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