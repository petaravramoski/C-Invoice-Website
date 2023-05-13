<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddInvoice.aspx.cs" Inherits="Application_Prototype.AddInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generate New Invoice</title>
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="Scripts/jqrui/jquery-ui.min.css" />
    <script src="Scripts/jqrui/external/jquery/jquery.js"></script>
    <script src="Scripts/jqrui/jquery-ui.min.js"></script>
    <script>
        $(function () {
            $("#CtrlInvDate").datepicker({
                dateFormat: "dd/mm/yy",
                inline: true,
                showAnim: 'fadeIn',
                changeMonth: true,
                changeYear: true,
            });
            $("#CtrlInvDate2").datepicker({
                dateFormat: "dd/mm/yy",
                inline: true,
                showAnim: 'fadeIn',
                changeMonth: true,
                changeYear: true,
            });
            $("#CtrlInvDate3").datepicker({
                dateFormat: "dd/mm/yy",
                inline: true,
                showAnim: 'fadeIn',
                changeMonth: true,
                changeYear: true,
            });
            $("#CtrlInvDate4").datepicker({
                dateFormat: "dd/mm/yy",
                inline: true,
                showAnim: 'fadeIn',
                changeMonth: true,
                changeYear: true,
            });
        });
    </script>
</head>
<body>
    <h2 class="standardheader">Add New Client Invoice</h2>
    <form id="FrmAddInvoice" runat="server">
        <div class="frm_row_cont">
            <asp:Literal ID="ClientListPH" runat="server"></asp:Literal>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblInvDate" class="frmlabel" runat="server" Text="Select a Start Date"></asp:Label><br />
            <input type="text" class="dllist" id="CtrlInvDate" name="CtrlInvDate" />
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblInvDate2" class="frmlabel" runat="server" Text="Select a End Date"></asp:Label><br />
            <input type="text" class="dllist" id="CtrlInvDate2" name="CtrlInvDate2" />
        </div> 

        <div class="frm_row_cont">
            <asp:Label ID="LblInvDate3" class="frmlabel" runat="server" Text="Select a Payment Due Date"></asp:Label><br />
            <input type="text" class="dllist" id="CtrlInvDate3" name="CtrlInvDate3" />
        </div> 

        <div class="frm_row_cont">
            <asp:Label ID="LblInvDate4" class="frmlabel" runat="server" Text="Select Date Invoice Was Sent"></asp:Label><br />
            <input type="text" class="dllist" id="CtrlInvDate4" name="CtrlInvDate4" />
        </div> 

         <div class="frm_row_cont">
            <asp:Label ID="LblInvoiceStatus" runat="server" class="frmlabel" Text="Invoice Status*"></asp:Label><br />
            <asp:DropDownList ID="CtrlInvoiceStatus" class="tbinput" runat="server">
                <asp:ListItem>Complete</asp:ListItem>
                <asp:ListItem>Not Complete</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="frm_row_cont">
            <asp:Button ID="BtnSubNewInvoice" runat="server" class="button" Text="Add Invoice" OnClick="BtnSubNewInvoice_Click" />
        </div>

    </form>
</body>
</html>