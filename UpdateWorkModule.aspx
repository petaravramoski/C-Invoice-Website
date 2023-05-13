<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateWorkModule.aspx.cs" Inherits="Application_Prototype.UpdateWorkModule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Work Module</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <div id="frmcont" runat="server">
    <div id="updateworkmoduleheader" runat="server"></div>
    <form id="UpdateWorkModule" runat="server">
    <asp:HiddenField ID="CtrlWorkModuleID" runat="server" Value=""></asp:HiddenField >

        <div class="frm_row_cont">
            <asp:Label ID="LblClient" runat="server" Text="Client Name"></asp:Label>
            <asp:Literal ID="ClientListPH" runat="server"></asp:Literal>
        </div>

        <div class="frm_row_cont">
            <asp:Literal ID="TaskListPH" runat="server"></asp:Literal>
        </div>

        <div class="frm_row_cont">
            <asp:Literal ID="StaffListPH" runat="server"></asp:Literal>
        </div>

        <div class="frm_row_cont">
            <asp:Button ID="BtnUpdateWorkModule" runat="server" class="button " Text="Update Work Module Details" OnClick="BtnUpdateWorkModule_Click" />
        </div>

    </form>
    </div>
</body>
</html>
