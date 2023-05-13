<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateTask.aspx.cs" Inherits="Application_Prototype.UpdateTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Task Details</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <div id="frmcont" runat="server">
    <div id="updatetaskheader" runat="server"></div>
    <form id="UpdateTask" runat="server">
    <asp:HiddenField ID="CtrlTaskID" runat="server" Value=""></asp:HiddenField >

        <div class="frm_row_cont">
            <asp:Label ID="LblTaskTitle" runat="server" class="frmlabel" Text="New Task Name*"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskTitle" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvTaskTitle"
                ControlToValidate="CtrlTaskTitle"
                Display="Static" 
                runat="server" 
                ErrorMessage="Task Name Required">
            </asp:RequiredFieldValidator>
        </div>

         <div class="frm_row_cont">
            <asp:Label ID="LblTaskDesc" runat="server" class="frmlabel" Text="New Task Description*"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskDesc" class="tbinput" TextMode="MultiLine" Height="100px" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvTaskDesc"
                ControlToValidate="CtrlTaskDesc"
                Display="Static" 
                runat="server" 
                ErrorMessage="Task Desc Required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblTaskRate" runat="server" class="frmlabel" Text="New Task Rate*"></asp:Label><br />
            <asp:TextBox ID="CtrlTaskRate" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvTaskRate"
                ControlToValidate="CtrlTaskRate"
                Display="Static" 
                runat="server" 
                ErrorMessage="Task Rate Required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Button ID="BtnUpdateTaskDetails" runat="server" class="button " Text="Update Task Details" OnClick="BtnUpdateTaskDetails_Click" />
        </div>

    </form>
    </div>
</body>
</html>
 