using System;
using System.Collections;
using System.Collections.Specialized;



namespace Application_Prototype
{
    public partial class index : System.Web.UI.Page
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

        protected void BtnSubmitNewClient_Click(object sender, EventArgs e)
        {
   
            if (IsPostBack)
            {
                NameValueCollection NewClientData = Request.Form;
                Client NewClient = new Client();
                string Result = NewClient.AddClient(NewClientData);
                Response.Write(Result);
                AppUtilities.ClearForm(Form.Controls);


            }

            
        }
        
    }
}