<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateInvoice.aspx.cs" Inherits="Application_Prototype.UpdateInvoice" %>

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
    <div id="frmcont" runat="server">
    <div id="updateinvoiceheader" runat="server"></div>
    <form id="UpdateInvoice" runat="server">
    <asp:HiddenField ID="CtrlInvoiceID" runat="server" Value=""></asp:HiddenField >

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
            <asp:Label ID="LblInvoiceStatus" runat="server" Text="Invoice Status"></asp:Label>
            <asp:Literal ID="InvoiceStatusPH" runat="server"></asp:Literal>
        </div>

        <div class="frm_row_cont">
            <asp:Button ID="BtnUpdateInvoiceDetails" runat="server" class="button " Text="Update Invoice Details" OnClick="BtnUpdateInvoiceDetails_Click" />
        </div>

    </form>
    </div>
</body>
</html>

