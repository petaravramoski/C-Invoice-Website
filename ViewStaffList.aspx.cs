using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application_Prototype
{
    public partial class ViewStaffList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Staff AllStaff = new Staff();

            List<List<string>> allstaff = AllStaff.GetStaff(); // new multi dimensional list called all staff, calling GetStaff Method for Staff (CLASS)

            //if statment incase someting goes wrong
            if (allstaff == null)
            {
                Response.Write("No Records Wore Found");
            }
            else
            {
                int results = allstaff.Count;
                Response.Write("<h3>Current Staff List</h3>"); //new header
                Response.Write("<p>" + results + " current staff</p>");

                Response.Write("<div class='crslistingcont'>");
                for (int i = 0; i <= results - 1; i++) //count starts at 0 becaue it is reading from an array, offset is also stated as -1, (i++ count one at a time upwards)
                {
                    Response.Write("<div class='crslistingrow'>"); //cell for row (class called form style sheet) 
                    Response.Write("<div class='crsid'>" + allstaff[i][0] + "</div>"); //cell for client id (class called from style sheet)
                    Response.Write("<div class='crsname'>" + allstaff[i][1] + "</div>"); //cell for client name
                    Response.Write("<div class='crsviewdetails'><a href='ViewStaffDetails.aspx?ID=" + allstaff[i][0] + "'>View</a></div>"); //cell for link
                    Response.Write("</div>"); //close div

                }
                Response.Write("</div>"); //close div
            }
        }
    }
}