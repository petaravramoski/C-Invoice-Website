using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application_Prototype
{
    public partial class ViewClientDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Code to get details of specific course from Client Class
            //Request.Paramas to check if there was an ID passed and anything associateed with it and if != null then something was sent.
            // && can this item be made into an into using the TryParse method (refered to the value that is been passed.
            //Shorcut keyword called out asking if it can turn that item into an int that is called Client_ID
            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Client_ID))
            {

                Client client = new Client(); //new object from client class
                _ = new List<string>(12); //expect 12 objects (list object)
                List<string> ClientData = client.GetClient(Client_ID); //the list object from above called Client Data (populate course data with GetClient method 
                bool isEmpty = AppUtilities.IsEmpty(ClientData); //refering to app utilities class (to see if it comes back true or false)

                if (isEmpty)
                {
                    Response.Write("Unexpected eror has occoured- no Client details wore found");
                }
                else //if not empty then proceed
                {
                    //results from get course (with paramater) method in Client Class
                    Response.Write("Client ID: " + ClientData[0] + "<br />");
                    Response.Write("Company Name: " + ClientData[1] + "<br />");
                    Response.Write("Address One: " + ClientData[2] + "<br />");
                    Response.Write("Address Two: " + ClientData[3] + "<br />");
                    Response.Write("Company Location: " + ClientData[4] + "<br />");
                    Response.Write("Company Post Code: " + ClientData[5] + "<br />");
                    Response.Write("Contact First Name: " + ClientData[6] + "<br />");
                    Response.Write("Contact Last Name: " + ClientData[7] + "<br />");
                    Response.Write("Contact Email: " + ClientData[8] + "<br />");
                    Response.Write("Contact Mobile: " + ClientData[9] + "<br />");
                    Response.Write("Bill To: " + ClientData[10] + "<br />");
                    Response.Write("Status: " + ClientData[11] + "<br />");
                    Response.Write("<br />");
                    Response.Write("<a href='UpdateClient.aspx?ID=" + ClientData[0] + "'>Update Client Details</a>");

                }

            }
            else //if someting goes wrong then do this 
            {
                Response.Write("ERROR: No ID in URL or couldnt Parse to an int");
            }
        }
    }
}