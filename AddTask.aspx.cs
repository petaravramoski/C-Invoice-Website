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
    public partial class AddTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddNewTask_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection NewTaskData = Request.Form;
                Task NewTask = new Task();
                string Result = NewTask.AddTask(NewTaskData);
                Response.Write(Result);
                AppUtilities.ClearForm(Form.Controls);
               
            }
        }
    }
}