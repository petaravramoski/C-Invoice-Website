using System;
using System.Collections.Generic;
using System.Collections;   
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application_Prototype
{
    public partial class index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (System.Web.HttpContext.Current.Session["CurrUser"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                _ = new ArrayList();
                ArrayList staffdet = (ArrayList)Session["CurrUser"];
                int.TryParse((string)staffdet[1], out int RoleID);
                // Response.Write("The Role ID is " + RoleID);

                switch (RoleID)
                {
                    case 0:
                        Response.Write("Hello " + staffdet[0] + " | <a href='Logout.aspx'>Log out</a>");
                        break;
                }
            }


        }
    }
}