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
    public class Invoice
    {

        public int Invoice_ID { get; set; }
        public int Client_ID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DateSent{ get; set; }
        public string PaymentDueDate { get; set; }
        public string InvoiceStatus { get; set; }
        public string Message { get; set; }


        public string AddInvoice(NameValueCollection NewInvoiceData)
        {
            this.Client_ID = Convert.ToInt32(NewInvoiceData["CtrlClientList"]);
            this.StartDate = DateTime.ParseExact(NewInvoiceData["CtrlInvDate"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.EndDate = DateTime.ParseExact(NewInvoiceData["CtrlInvDate2"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.DateSent = DateTime.ParseExact(NewInvoiceData["CtrlInvDate3"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.PaymentDueDate = DateTime.ParseExact(NewInvoiceData["CtrlInvDate4"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.InvoiceStatus = (NewInvoiceData["CtrlInvoiceStatus"]);

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand AddInvoice = new SqlCommand
            {
                CommandText = "INSERT INVOICE (StartDate, EndDate, DateSent, PaymentDueDate, InvoiceStatus, Client_ID) VALUES ('" + StartDate + "', '" + EndDate + "', '" + DateSent + "', '" + PaymentDueDate + "', '" + InvoiceStatus + "', '" + Client_ID + "' )",
                CommandType = CommandType.Text,
                Connection = con
            };

            if (con.State == ConnectionState.Open)
            {
                int a = AddInvoice.ExecuteNonQuery();
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

        public List<List<string>> GetInvoice() //Setting method to a multidimensioan list 
        {
            SqlConnection con = DBConnect.MakeConn();

            SqlCommand GetAllInvoice = new SqlCommand
            {
                CommandText = "SELECT * FROM INVOICE",
                CommandType = CommandType.Text,
                Connection = con
            };

            //MD List to hold all info 
            List<List<string>> AllInvoice = new List<List<string>>();


            SqlDataReader r = GetAllInvoice.ExecuteReader();

            if (r.HasRows) //checking if r has any rows and if it does then proceed 
            {
                while (r.Read()) //using a while loop and the read method to go through everything once at a time
                {
                    AllInvoice.Add(new List<string> {r["Invoice_ID"].ToString(),
                        r["StartDate "].ToString(), r["EndDate "].ToString(),
                        r["DateSent "].ToString(), r["PaymentDueDate "].ToString(), r["InvoiceStatus "].ToString(),
                        r["Client_ID"].ToString(),});
                }
                r.Close(); //close above 
            }
            else //incase something goes wrong proceed with below
            {
                AllInvoice = null; //if nothing is returned then just set it to null
            }
            DBConnect.DropConn(con); //drop connection when complete 
            return AllInvoice;

        }

        public List<string> GetInvoice(int InvoiceID)
        {
            this.Invoice_ID = InvoiceID;
            List<string> details = new List<string>(7); //expect 6 objects

            SqlConnection con = DBConnect.MakeConn();

            //Sql command to get the specific client details
            SqlCommand GetInvoiceDetails = new SqlCommand
            {
                CommandText = "SELECT * FROM INVOICE WHERE Invoice_ID = " + Invoice_ID,
                CommandType = CommandType.Text,
                Connection = con
            };

            SqlDataReader r = GetInvoiceDetails.ExecuteReader();

            if (!r.HasRows)
            {
                details = null;
            }
            else
            {
                while (r.Read())
                {
                    details.Add(r["Invoice_ID"].ToString()); // Add Staff_ID to the list index position 0 
                    details.Add(r["StartDate "].ToString()); // Add StaffName to the list index position 1
                    details.Add(r["EndDate "].ToString()); // Add StaffSurname to the list index position 2
                    details.Add(r["DateSent "].ToString()); // Add StaffEmail to the list index position 3
                    details.Add(r["PaymentDueDate "].ToString()); // Add StaffPassword to the list index position 4
                    details.Add(r["InvoiceStatus "].ToString()); // Add StaffAccessLevel to the list index position 5
                    details.Add(r["Client_ID"].ToString()); // Add StaffStatus to the list index position 6

                }
            }
            DBConnect.DropConn(con);
            return details;

        }

        public string UpdateInvoice(NameValueCollection UpdateInvoiceData)
        {
            this.Invoice_ID = Convert.ToInt32(UpdateInvoiceData["CtrlClientList"]);
            this.StartDate = DateTime.ParseExact(UpdateInvoiceData["CtrlInvDate"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.EndDate = DateTime.ParseExact(UpdateInvoiceData["CtrlInvDate2"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.DateSent = DateTime.ParseExact(UpdateInvoiceData["CtrlInvDate3"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.PaymentDueDate = DateTime.ParseExact(UpdateInvoiceData["CtrlInvDate4"], "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            this.InvoiceStatus = (UpdateInvoiceData["CtrlInvoiceStatus"]);
            this.Client_ID = Convert.ToInt32(UpdateInvoiceData["CtrlClientList"]);

            SqlConnection con = DBConnect.MakeConn();

            SqlCommand UpdateInvoice = new SqlCommand
            {
                CommandText = "UPDATE INVOICE SET StartDate = '" + StartDate + "', EndDate = '" + EndDate + "'," +
                " DateSent = '" + DateSent + "', PaymentDueDate = '" + PaymentDueDate + "', InvoiceStatus = '" + InvoiceStatus + "' Client_ID = '" + Client_ID + "' WHERE Invoice_ID = " + Invoice_ID,
                CommandType = CommandType.Text,
                Connection = con

            };

            if (con.State == ConnectionState.Open)
            {
                int a = UpdateInvoice.ExecuteNonQuery();
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