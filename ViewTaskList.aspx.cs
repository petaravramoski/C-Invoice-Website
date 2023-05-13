using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application_Prototype
{
    public partial class ViewTaskList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Task AllTask = new Task();

            List<List<string>> alltask = AllTask.GetTask();

            if (alltask == null)
            {
                Response.Write("No Records Wore Found");
            }
            else
            {
                int results = alltask.Count;
                Response.Write("<h3>Current Task List</h3>"); //new header
                Response.Write("<p>" + results + " current task</p>");

                Response.Write("<div class='crslistingcont'>");
                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div class='crslistingrow'>"); //cell for row (class called form style sheet) 
                    Response.Write("<div class='crsid'>" + alltask[i][0] + "</div>"); //cell for client id (class called from style sheet)
                    Response.Write("<div class='crsname'>" + alltask[i][1] + "</div>"); //cell for client name
                    Response.Write("<div class='crsviewdetails'><a href='ViewTaskDetails.aspx?ID=" + alltask[i][0] + "'>View</a></div>"); //cell for link
                    Response.Write("</div>"); //close div
                }
                Response.Write("</div>"); //close div
            }

        }
    }
}