<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateStaff.aspx.cs" Inherits="Application_Prototype.UpdateStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Staff Member Details</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <div id="frmcont" runat="server">
    <div id="updatestaffheader" runat="server"></div>
    <form id="UpdateStaff" runat="server">
    <asp:HiddenField ID="CtrlStaffID" runat="server" Value=""></asp:HiddenField >

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffName" runat="server" class="frmlabel" Text="Staff Member First Name" ></asp:Label>
            <asp:TextBox ID="CtrlStaffName" class="tbinput" runat="server" ReadOnly ="true" ></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvStaffName"
                ControlToValidate="CtrlStaffName"
                Display="Static" 
                runat="server" 
                ErrorMessage="Staff Member Name Required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffSurname" runat="server" class="frmlabel" Text="Staff Member Surname"></asp:Label><br /> 
            <asp:TextBox ID="CtrlStaffSurname" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvStaffSurname"
                ControlToValidate="CtrlStaffSurname"
                Display="Static" 
                runat="server" 
                ErrorMessage="Staff Member Surname Required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffEmail" runat="server" class="frmlabel" Text="Staff Member Email"></asp:Label><br /> 
            <asp:TextBox ID="CtrlStaffEmail" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvStaffEmail"
                ControlToValidate="CtrlStaffEmail"
                Display="Static" 
                runat="server" 
                ErrorMessage="Staff Member Email Required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStaffAccessLevel" runat="server" Text="Staff Access Level"></asp:Label>
            <asp:Literal ID="StaffAccessLevelPH" runat="server"></asp:Literal>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStatus" runat="server" Text="Client Status"></asp:Label>
            <asp:Literal ID="StaffStatusPH" runat="server"></asp:Literal>
        </div>


        <div class="frm_row_cont">
            <asp:Button ID="BtnUpdateStaffDetails" runat="server" class="button " Text="Update Staff Details" OnClick="BtnUpdateStaffDetails_Click" />
        </div>

    </form>
    </div>
</body>
</html>
