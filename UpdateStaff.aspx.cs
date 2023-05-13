using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Application_Prototype
{
    public partial class UpdateStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Code to get details of specific course from Client Class
            //Request.Paramas to check if there was an ID passed and anything associateed with it and if != null then something was sent.
            // && can this item be made into an into using the TryParse method (refered to the value that is been passed.
            //Shorcut keyword called out asking if it can turn that item into an int that is called Client_ID
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Staff_ID))
            {
                Staff staff = new Staff(); //new object from client class
                _ = new List<string>(6); //expect 6 objects (list object)
                List<string> StaffData = staff.GetStaff(Staff_ID); //the list object from above called Client Data (populate course data with GetClient method 
                bool isEmpty = AppUtilities.IsEmpty(StaffData); //refering to app utilities class (to see if it comes back true or false)


                this.updatestaffheader.InnerHtml = "<h3>Update Details for " + StaffData[1] + "</hr>";


                if (isEmpty)
                {
                    Response.Write("Unexpected eror has occoured- The Staff Member Details wore not found");
                }
                else
                {
                    this.CtrlStaffID.Value = StaffData[0].ToString();
                    this.CtrlStaffName.Text = StaffData[1];
                    this.CtrlStaffSurname.Text = StaffData[2];
                    this.CtrlStaffEmail.Text = StaffData[3];

                    string accesslevel = StaffData[4].Replace(" ", String.Empty);
                    string status = StaffData[5].Replace(" ", String.Empty);


                    string dlcaccesslevel;
                    if (accesslevel == "Admin")
                    {
                        dlcaccesslevel = "<select class='tbinput' name='CtrlStaffAccessLevel' id='CtrlStaffAccessLevel'>";
                        dlcaccesslevel += "<option value='Admin' selected='selected'>Admin</option>";
                        dlcaccesslevel += "<option value='Staff'>Staff</option>";
                        dlcaccesslevel += "</select>";
                    }
                    else
                    {
                        dlcaccesslevel = "<select class='tbinput' name='CtrlStaffAccessLevel' id='CtrlStaffAccessLevel'>";
                        dlcaccesslevel += "<option value='Admin'>Admin</option>";
                        dlcaccesslevel += "<option value='Staff' selected='selected'>Staff</option>";
                        dlcaccesslevel += "</select>";

                    }
                    StaffAccessLevelPH.Text = dlcaccesslevel;



                    string dlcstaffstatus;
                    if (status == "Active")
                    {
                        dlcstaffstatus = "<select class='tbinput' name='CtrlStaffStatus' id='CtrlStaffStatus'>";
                        dlcstaffstatus += "<option value='Active' selected='selected'>Active</option>";
                        dlcstaffstatus += "<option value='Inactive'>Inactive</option>";
                        dlcstaffstatus += "</select>";
                    }
                    else
                    {
                        dlcstaffstatus = "<select class='tbinput' name='CtrlStaffStatus' id='CtrlStaffStatus'>";
                        dlcstaffstatus += "<option value='Active'>Active</option>";
                        dlcstaffstatus += "<option value='Inactive' selected='selected'>Inactive</option>";
                        dlcstaffstatus += "</select>";

                    }
                    StaffStatusPH.Text = dlcstaffstatus;
                }
            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }
        }


        protected void BtnUpdateStaffDetails_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateStaffData = Request.Form;
                Staff UpdateStaff = new Staff();
                string Result = UpdateStaff.UpdateStaff(UpdateStaffData);
                if (Result == "Query Succeeded")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Staff Details Updated Succsessfully.</span><br />");
                    Response.Write("<a href='ViewStaffList.aspx'>Return to Staff Members List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; staff member details have not been changed.</span><br />");
                    Response.Write("<a href='ViewStaffList.aspx'>Return to Staff Members List</a>");
                }
            }
        }
    }
}