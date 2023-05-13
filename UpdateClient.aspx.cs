using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Application_Prototype
{
    public partial class UpdateClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Code to get details of specific course from Client Class
            //Request.Paramas to check if there was an ID passed and anything associateed with it and if != null then something was sent.
            // && can this item be made into an into using the TryParse method (refered to the value that is been passed.
            //Shorcut keyword called out asking if it can turn that item into an int that is called Client_ID
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Client_ID))
            {

                Client client = new Client(); //new object from client class
                _ = new List<string>(12); //expect 12 objects (list object)
                List<string> ClientData = client.GetClient(Client_ID); //the list object from above called Client Data (populate course data with GetClient method 
                bool isEmpty = AppUtilities.IsEmpty(ClientData); //refering to app utilities class (to see if it comes back true or false)

                //Custom header
                this.updateclientheader.InnerHtml = "<h3>Update Details for " + ClientData[1] + "</hr>";


                if (isEmpty)
                {
                    Response.Write("Unexpected eror has occoured- no Client details wore not found");

                }
                else //if not empty then proceed
                {

                    // Write user details to matching target controls in form
                    this.CtrlClientID.Value = ClientData[0].ToString();
                    this.CtrlCompName.Text = ClientData[1];
                    this.CtrlCompAdd1.Text = ClientData[2];
                    this.CtrlCompAdd2.Text = ClientData[3];
                    this.CtrlCompLocation.Text = ClientData[4];
                    this.CtrlCompPcode.Text = ClientData[5];
                    this.CtrlContactFname.Text = ClientData[6];
                    this.CtrlContactLname.Text = ClientData[7];
                    this.CtrlContactEmail.Text = ClientData[8];
                    this.CtrlMobile.Text = ClientData[9];
                    this.CtrlBillTo.Text = ClientData[10];
                 
                    // string status = CrsData[3];
                    string status = ClientData[11].Replace(" ", String.Empty);
                    // Response.Write("The contents of status is " + status + "<br />");
                    // Response.Write("The length of status is " + status.Length + "<br />");

                    string dlclientstatus;
                    if (status == "Active")
                    {
                        dlclientstatus = "<select class='tbinput' name='CtrlClientStatus' id='CtrlClientStatus'>";
                        dlclientstatus += "<option value='Active' selected='selected'>Active</option>";
                        dlclientstatus += "<option value='Inactive'>Inactive</option>";
                        dlclientstatus += "</select>";
                    }
                    else
                    {
                        dlclientstatus = "<select class='tbinput' name='CtrlClientStatus' id='CtrlClientStatus'>";
                        dlclientstatus += "<option value='Active'>Active</option>";
                        dlclientstatus += "<option value='Inactive' selected='selected'>Inactive</option>";
                        dlclientstatus += "</select>";
                    }

                    ClientStatusPH.Text = dlclientstatus;

                }
            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }

        }

        protected void BtnUpdateClientDetails_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateCrsData = Request.Form;
                Client UpdateCrs = new Client();
                string Result = UpdateCrs.UpdateClient(UpdateCrsData);
                if (Result == "Query Succeeded")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Client details updated successfully.</span><br />");
                    Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; client details have not been changed.</span><br />");
                    Response.Write("<a href='ViewClientList.aspx'>Return to Client List</a>");
                }

            }

        }
    }
}