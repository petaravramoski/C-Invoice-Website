using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application_Prototype
{
    public partial class ViewClientList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Instanciate New Client OBJ from the client class
            Client AllClients = new Client();

            //Assign returned results to multidimensioanl string list
            List<List<string>> allcli = AllClients.GetClient();

            //If statement incase no results are returned 
            if (allcli == null)
            {
                Response.Write("No Records Wore Found");
            }
            else
            {
                int results = allcli.Count;
                Response.Write("<h3>Current Client List</h3>");
                Response.Write("<p>"+results+" current clients</p>");

                Response.Write("<div class='crslistingcont'>");
                //Below all Clients will be displayed
                for (int i = 0; i <= results - 1; i++) //count starts at 0 becaue it is reading from an array, offset is also stated as -1, (i++ count one at a time upwards)
                {
                    Response.Write("<div class='crslistingrow'>"); //cell for row
                    Response.Write("<div class='crsid'>"+allcli[i][0]+"</div>"); //cell for client id
                    Response.Write("<div class='crsname'>" + allcli[i][1] + "</div>"); //cell for client name
                    Response.Write("<div class='crsviewdetails'><a href='ViewClientDetails.aspx?ID="+allcli[i][0]+"'>View</a></div>"); //cell for link
                    Response.Write("</div>"); //close div
                }
                Response.Write("</div>"); //close div
            }

        }
    }
}