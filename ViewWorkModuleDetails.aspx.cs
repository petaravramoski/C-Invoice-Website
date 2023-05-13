using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application_Prototype
{
    public partial class ViewWorkModuleDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Code to get details of specific staff member from Staff Class
            //Request.Paramas to check if there was an ID passed and anything associateed with it and if != null then something was sent.
            // && can this item be made into an into using the TryParse method (refered to the value that is been passed.
            //Shorcut keyword called "out" asking if it can turn that item into an int that is called Client_ID
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Work_ID))
            {
                WorkModule workmodule = new WorkModule(); //new object from client class
                _ = new List<string>(4);//expect 7 objects (list object)
                List<string> WorkModuleData = workmodule.GetWorkModule(Work_ID); //the list object from previous line called Staff Data (populate course data with GetStaff method) 
                bool isEmpty = AppUtilities.IsEmpty(WorkModuleData); //refering to app utilities class (to see if it comes back true or false)

                if (isEmpty)
                {
                    Response.Write("Unexpected eror has occoured- no Client details wore found");
                }
                else
                {
                    Response.Write("WorkModule ID: " + WorkModuleData[0] + "<br />");
                    Response.Write("Client ID: " + WorkModuleData[1] + "<br />");
                    Response.Write("Task ID: " + WorkModuleData[2] + "<br />");
                    Response.Write("Staff Member ID: " + WorkModuleData[3] + "<br />");

                    Response.Write("<br />"); // break here so it is spaced out well for link to update staff member
                    Response.Write("<a href='UpdateWorkModule.aspx?ID=" + WorkModuleData[0] + "'>Update Task Member Details</a>");
                }
            }
            else
            {
                Response.Write("ERROR: No ID in URL or couldnt Parse to an int");
            }

        }
    }
}