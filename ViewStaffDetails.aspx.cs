using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application_Prototype
{
    public partial class ViewStaffDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Code to get details of specific staff member from Staff Class
            //Request.Paramas to check if there was an ID passed and anything associateed with it and if != null then something was sent.
            // && can this item be made into an into using the TryParse method (refered to the value that is been passed.
            //Shorcut keyword called "out" asking if it can turn that item into an int that is called Client_ID
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Staff_ID))
            {
                Staff staff = new Staff(); //new object from client class
                _ = new List<string>(7);//expect 7 objects (list object)
                List<string> StaffData = staff.GetStaff(Staff_ID); //the list object from previous line called Staff Data (populate course data with GetStaff method) 
                bool isEmpty = AppUtilities.IsEmpty(StaffData); //refering to app utilities class (to see if it comes back true or false)

                if (isEmpty)
                {
                    Response.Write("Unexpected eror has occoured- no Client details wore found");
                }
                else
                {
                    Response.Write("Staff Member ID: " + StaffData[0] + "<br />");
                    Response.Write("Staff Member First Name: " + StaffData[1] + "<br />");
                    Response.Write("Staff Member Last Name: " + StaffData[2] + "<br />");
                    Response.Write("Staff Member Email: " + StaffData[3] + "<br />");
                    Response.Write("Staff Member Password: " + StaffData[4] + "<br />");
                    Response.Write("Staff Member Access Level: " + StaffData[5] + "<br />");
                    Response.Write("Staff Status: " + StaffData[6] + "<br />");
                    Response.Write("<br />"); // break here so it is spaced out well for link to update staff member
                    Response.Write("<a href='UpdateStaff.aspx?ID=" + StaffData[0] + "'>Update Staff Member Details</a>");
                }
            }
            else
            {
                Response.Write("ERROR: No ID in URL or couldnt Parse to an int");
            }
        }
    }
}