using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application_Prototype
{
    public partial class ViewInvoiceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Invoice AllInvoice = new Invoice();

            List<List<string>> allinv = AllInvoice.GetInvoice(); // new multi dimensional list called all staff, calling GetStaff Method for Staff (CLASS)

            //if statment incase someting goes wrong
            if (allinv == null)
            {
                Response.Write("No Records Wore Found");
            }
            else
            {
                int results = allinv.Count;
                Response.Write("<h3>Current Invoice List</h3>"); //new header
                Response.Write("<p>" + results + " current invoices</p>");

                Response.Write("<div class='crslistingcont'>");
                for (int i = 0; i <= results - 1; i++) //count starts at 0 becaue it is reading from an array, offset is also stated as -1, (i++ count one at a time upwards)
                {
                    Response.Write("<div class='crslistingrow'>"); //cell for row (class called form style sheet) 
                    Response.Write("<div class='crsname'> Invoice ID </div>"); //cell for client name
                    Response.Write("<div class='crsid'>" + allinv[i][0] + "</div>"); //cell for client id (class called from style sheet)
                    Response.Write("<div class='crsname'> Client ID </div>"); //cell for client name
                    Response.Write("<div class='crsname'>" + allinv[i][6] + "</div>"); //cell for client name
                    Response.Write("<div class='crsviewdetails'><a href='ViewInvoiceDetails.aspx?ID=" + allinv[i][0] + "'>View</a></div>"); //cell for link
                    Response.Write("</div>"); //close div

                }
                Response.Write("</div>"); //close div
            }

        }
    }
}