using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Application_Prototype
{
    public partial class UpdateWorkModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Code to get details of specific course from Client Class
            //Request.Paramas to check if there was an ID passed and anything associateed with it and if != null then something was sent.
            // && can this item be made into an into using the TryParse method (refered to the value that is been passed.
            //Shorcut keyword called out asking if it can turn that item into an int that is called Client_ID
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Work_ID))
            {
                WorkModule workModule = new WorkModule(); //new object from client class
                _ = new List<string>(4); //expect 6 objects (list object)
                List<string> WorkModuleData = workModule.GetWorkModule(Work_ID); //the list object from above called Client Data (populate course data with GetClient method 
                bool isEmpty = AppUtilities.IsEmpty(WorkModuleData); //refering to app utilities class (to see if it comes back true or false)


                this.updateworkmoduleheader.InnerHtml = "<h3>Work Module Data for " + WorkModuleData[1] + "</hr>";

                if (isEmpty)
                {
                    Response.Write("Unexpected eror has occoured- The Work Module Details wore not found");
                }
                else
                {
                    this.CtrlWorkModuleID.Value = WorkModuleData[0].ToString();
                    this.ClientListPH.Text = WorkModuleData[1];
                    this.TaskListPH.Text = WorkModuleData[2];
                    this.StaffListPH.Text = WorkModuleData[3];
                  
                }
            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }

        }

        protected void BtnUpdateWorkModule_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateWorkModuleData = Request.Form;
                WorkModule UpdateWorkModule = new WorkModule();
                string Result = UpdateWorkModule.UpdateWorkModule(UpdateWorkModuleData);
                if (Result == "Query Succeeded")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Staff Details Updated Succsessfully.</span><br />");
                    Response.Write("<a href='ViewWorkModuleList.aspx'>Return to Staff Members List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; staff member details have not been changed.</span><br />");
                    Response.Write("<a href='ViewWorkModuleList.aspx'>Return to Staff Members List</a>");
                }
            }

        }
    }
}