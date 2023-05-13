using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Application_Prototype
{
    public partial class AddStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmitNewStaff_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection NewStaffData = Request.Form;
                Staff NewStaff = new Staff();
                string Result = NewStaff.AddStaff(NewStaffData);
                Response.Write(Result);
                AppUtilities.ClearForm(Form.Controls);

            }
        }
    }
}