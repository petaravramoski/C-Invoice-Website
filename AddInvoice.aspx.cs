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
    public partial class AddInvoice : System.Web.UI.Page
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

                dlclient = "<span id='LblClientList' class='frmlabel'>Select a Client</span><br />";
                dlclient += "<select class='dllist' name='CtrlClientList'>";
                dlclient += "<option value='0'>--Please make a selection--</option>";

                for (int i = 0; i <= clientcnt - 1; i++)
                {
                    dlclient += "<option value='" + allcli[i][0] + "'>" + allcli[i][1] + "</option>";
                }

                dlclient += "</select>";
                ClientListPH.Text = dlclient;



            }
        }

        protected void BtnSubNewInvoice_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NameValueCollection NewInvoiceData = Request.Form;
                Invoice NewInvoice = new Invoice();
                string Result = NewInvoice.AddInvoice(NewInvoiceData);
                Response.Write(Result);
                AppUtilities.ClearForm(Form.Controls);
            }
        }
    }
}