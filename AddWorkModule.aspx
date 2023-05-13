<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWorkModule.aspx.cs" Inherits="Application_Prototype.AddWorkModule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Work Module</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <h2>Add a New Work Module</h2>
    <form id="frmAddWorkModule" runat="server">

        <div class="frm_row_cont">
            <asp:Literal ID="ClientListPH" runat="server"></asp:Literal>
        </div>

        <div class="frm_row_cont">
            <asp:Literal ID="TaskListPH" runat="server"></asp:Literal>
        </div>

        <div class="frm_row_cont">
            <asp:Literal ID="StaffListPH" runat="server"></asp:Literal>
        </div>

        <div class="frm_row_cont">
            <asp:Button ID="BtnAddNewWorkMod" runat="server" class="button" Text="Add WorkModule" OnClick="BtnAddNewWorkMod_Click" />
        </div>

    </form>
</body>
</html>
