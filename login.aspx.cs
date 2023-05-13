using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application_Prototype
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {

            Staff staff = new Staff();
            _ = new List<string>(2);
            List<string> StaffDetails = staff.GetStaff(Request.Form["CtrlUserEmail"], Request.Form["CtrlUserPassword"]);
            bool isEmpty = AppUtilities.IsEmpty(StaffDetails);
            if (isEmpty)
            {
                Response.Write("No user found with these credentials. Return to <a href='login.aspx'>Login Page</a>");
            }
            else
            {
                // Response.Write("User Fname: " + UserDetails[0] + "<br />");
                // Response.Write("User_SysRole: " + UserDetails[1] + "<br />");
                ArrayList SessUser = new ArrayList
                            {
                                StaffDetails[0], // User First Name
                                StaffDetails[1] // User Access Level
                            };
                Session["CurrUser"] = SessUser;

                // Response.Write("User Fname in Session Var: " + SessUser[0] + "<br />");
                // Response.Write("User_SysRole in Session Var: " + SessUser[1] + "<br />");

                int.TryParse((string)SessUser[1], out int RoleID);
                // Response.Write("The Role ID is " + RoleID);

                switch (RoleID)
                {
                    case 0:
                        Response.Redirect("index.aspx");
                        break;
                    case 1:
                        Response.Redirect("index.aspx");
                        break;
                }
            }

        }
    }
}