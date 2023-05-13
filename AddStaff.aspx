<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStaff.aspx.cs" Inherits="Application_Prototype.AddStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Staff Member</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <h2>Add a New Staff Member</h2>
    <form id="form1" runat="server">
        <div class="frm_row_cont">
            <asp:Label ID="LblStaffName" runat="server" class="frmlabel" Text="New Staff Member First Name*"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffName" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvStaffName"
                ControlToValidate="CtrlStaffName"
                Display="Static" 
                runat="server" 
                ErrorMessage="Company Address Required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffSurname" runat="server" class="frmlabel" Text="New Staff Member Surname*"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffSurname" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvStaffSurname"
                ControlToValidate="CtrlStaffSurname"
                Display="Static" 
                runat="server" 
                ErrorMessage="Staff Surname Required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffEmail" runat="server" class="frmlabel" Text="New Staff Member Email*"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffEmail" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvStaffEmail"
                ControlToValidate="CtrlStaffEmail"
                Display="Static" 
                runat="server" 
                ErrorMessage="Staff Email Required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LalStaffPassword" runat="server" class="frmlabel" Text="New Staff Member Password*"></asp:Label><br />
            <asp:TextBox ID="CtrlStaffPassword" class="tbinput" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvStaffPassword"
                ControlToValidate="CtrlStaffPassword"
                Display="Static" 
                runat="server" 
                ErrorMessage="PASSWORD IS REQUIRED*">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffAccessLevel" runat="server" class="frmlabel" Text="Staff Access Level*"></asp:Label><br />
            <asp:DropDownList ID="CtrlStaffAccessLevel" class="tbinput" runat="server">
                <asp:ListItem>Staff</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffStatus" runat="server" class="frmlabel" Text="Staff Current Status*"></asp:Label><br />
            <asp:DropDownList ID="CtrlStaffStatus" class="tbinput" runat="server">
                <asp:ListItem>Active</asp:ListItem>
                <asp:ListItem>Inactive</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="frm_row_cont">
            <asp:Button ID="BtnSubmitNewStaff" runat="server" class="button" Text="Button" OnClick="BtnSubmitNewStaff_Click" />
        </div>
      
    </form>
</body>
</html>
