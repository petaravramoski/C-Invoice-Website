using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application_Prototype
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["CurrUser"] != null)
            {
                Session.Abandon();
                Response.Redirect("login.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}