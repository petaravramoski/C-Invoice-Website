using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Application_Prototype
{
    public partial class UpdateTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Task_ID))
            {
                Task task = new Task(); //new object from client class
                _ = new List<string>(6); //expect 6 objects (list object)
                List<string> TaskData = task.GetTask(Task_ID); //the list object from above called Client Data (populate course data with GetClient method 
                bool isEmpty = AppUtilities.IsEmpty(TaskData); //refering to app utilities class (to see if it comes back true or false)

                this.updatetaskheader.InnerHtml = "<h3>Update Details for " + TaskData[1] + "</hr>";

                if (isEmpty)
                {
                    Response.Write("Unexpected eror has occoured- The Task Details wore not found");
                }
                {
                    this.CtrlTaskID.Value = TaskData[0].ToString();
                    this.CtrlTaskTitle.Text = TaskData[1];
                    this.CtrlTaskDesc.Text = TaskData[2];
                    this.CtrlTaskRate.Text = TaskData[3];
                }

            }
            else
            {
                Response.Write("No ID in url OR couldn't parse url parameter to an int");
            }



        }

        protected void BtnUpdateTaskDetails_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection UpdateTaskData = Request.Form;
                Task UpdateTask = new Task();
                string Result = UpdateTask.UpdateTask(UpdateTaskData);
                if (Result == "Query Succeeded")
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='success'>Task Details Updated Succsessfully.</span><br />");
                    Response.Write("<a href='ViewTaskList.aspx'>Return to Task List</a>");
                }
                else
                {
                    this.frmcont.Visible = false;
                    Response.Write("<span class='error'>Update failed; task details have not been changed.</span><br />");
                    Response.Write("<a href='ViewTaskList.aspx'>Return to TaskList</a>");
                }
            }
        }
    }
}