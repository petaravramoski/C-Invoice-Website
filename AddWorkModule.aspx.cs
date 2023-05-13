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
    public partial class AddWorkModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dlclient;

            Client AllClients = new Client();

            List<List<string>> allcli = AllClients.GetClient();

            if (allcli == null)
            {
                ClientListPH.Text = "Error - no Clients returned";
            }
            else
            {
                int clientcnt = allcli.Count;

                dlclient = "<span id='LblClientList' class='frmlabel'></span><br />";
                dlclient += "<select class='dllist' name='CtrlClientList'>";
                dlclient += "<option value='0'>--Please Select A Clinet--</option>";

                for (int i = 0; i <= clientcnt - 1; i++)
                {
                    dlclient += "<option value='" + allcli[i][0] + "'>" + allcli[i][1] + "</option>";
                }

                dlclient += "</select>";
                ClientListPH.Text = dlclient;

            }

            string dltask;

            Task AllTasks = new Task();

            List<List<string>> alltask = AllTasks.GetTask();

            if (alltask == null)
            {
                TaskListPH.Text = "Error - no Tasks returned";
            }
            else
            {
                int taskcnt = alltask.Count;
                dltask = "<span id='LblTaskList' class='frmlabel'>Select a Task</span><br />";
                dltask = "<select class='dllist' name='CtrlTaskList'>";
                dltask += "<option value='0'>--Please Select a Task--</option>";

                for (int i = 0; i <= taskcnt - 1; i++)
                {
                    dltask += "<option value='" + alltask[i][0] + "'>" + alltask[i][1] + "</option>";
                }
                dltask += "</select>";
                TaskListPH.Text = dltask;
            }

            string dlstaff;

            Staff AllStaff = new Staff();

            List<List<string>> allstaff = AllStaff.GetStaff();

            if (allstaff == null)
            {
                StaffListPH.Text = "Error - no Staff Member returned";
            }
            else
            {
                int staffcnt = allstaff.Count;
                dlstaff = "<span id='LblStaffList' class='frmlabel'>Select a Staff Member</span><br />";
                dlstaff = "<select class='dllist' name='CtrlStaffList'>";
                dlstaff += "<option value='0'>--Please Select a Staff Member--</option>";

                for (int i = 0; i <= staffcnt - 1; i++)
                {
                    dlstaff += "<option value='" + allstaff[i][0] + "'>" + allstaff[i][1] + "</option>";
                }
                dlstaff += "</select>";
                StaffListPH.Text = dlstaff;
            }


        }

        protected void BtnAddNewWorkMod_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection NewWorkModuleData = Request.Form;
                WorkModule NewWorkModule = new WorkModule();
                string Result = NewWorkModule.AddWorkModule(NewWorkModuleData);
                Response.Write(Result);
                AppUtilities.ClearForm(Form.Controls);
            }
        }
    }

}