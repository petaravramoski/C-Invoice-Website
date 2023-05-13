using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application_Prototype
{
    public partial class ViewWorkModuleList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            WorkModule AllWorkModule = new WorkModule();

            List<List<string>> allworkmodule = AllWorkModule.GetWorkModule();

            if (allworkmodule == null)
            {
                Response.Write("No Records Wore Found");
            }
            else
            {
                int results = allworkmodule.Count;
                Response.Write("<h3>Current Work Module List</h3>"); //new header
                Response.Write("<p>" + results + " current Work Module</p>");

                Response.Write("<div class='crslistingcont'>");
                for (int i = 0; i <= results - 1; i++)
                {
                    Response.Write("<div class='crslistingrow'>"); //cell for row (class called form style sheet) 
                    Response.Write("<div class='crslistingrow'> Task_ID");
                    Response.Write("<div class='crsid'>" + allworkmodule[i][0] + "</div>"); //cell for client id (class called from style sheet)
                    Response.Write("<div class='crslistingrow'> Staff Memeber ID working on WM:");
                    Response.Write("<div class='crsname'>" + allworkmodule[i][1] + "</div>"); //cell for client name
                    Response.Write("<div class='crsviewdetails'><a href='ViewWorkModuleDetails.aspx?ID=" + allworkmodule[i][0] + "'>View</a></div>"); //cell for link
                    Response.Write("</div>"); //close div
                }
                Response.Write("</div>"); //close div
            }

        }
    }
}