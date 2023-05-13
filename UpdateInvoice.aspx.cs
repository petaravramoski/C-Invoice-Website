using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application_Prototype
{
    public partial class UpdateInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request.Params["ID"] != null && int.TryParse(Request.Params["ID"], out int Invoice_ID))
            {
                Invoice invoice = new Invoice(); //new object from client class
                _ = new List<string>(7); //expect 6 objects (list object)
                List<string> InvoiceData = invoice.GetInvoice(Invoice_ID); //the list object from above called Client Data (populate course data with GetClient method 
                bool isEmpty = AppUtilities.IsEmpty(InvoiceData); //refering to app utilities class (to see if it comes back true or false)


                this.updateinvoiceheader.InnerHtml = "<h3>Update Details for " + InvoiceData[1] + "</hr>";


                if (isEmpty)
                {
                    Response.Write("Unexpected eror has occoured- The Invoice Member Details wore not found");
                }
                else
                {
                    this.CtrlInvoiceID.Value = InvoiceData[0].ToString();

                }

            }

        }















        protected void BtnUpdateInvoiceDetails_Click(object sender, EventArgs e)
        {

        }
    }
}