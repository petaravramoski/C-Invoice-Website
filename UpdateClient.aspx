<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateClient.aspx.cs" Inherits="Application_Prototype.UpdateClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Client Details</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <div id="frmcont" runat="server">
    <div id="updateclientheader" runat="server"></div>
    <form id="UpdateClient" runat="server">
    <asp:HiddenField ID="CtrlClientID" runat="server" Value=""></asp:HiddenField >

        <div class="frm_row_cont">
            <asp:Label ID="LblCompName" runat="server" class="frmlabel" Text="CompName" ></asp:Label>
            <asp:TextBox ID="CtrlCompName" class="tbinput" runat="server" ReadOnly ="true" ></asp:TextBox>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblCompAdd1" runat="server" class="frmlabel" Text="Address Line 1"></asp:Label><br /> 
            <asp:TextBox ID="CtrlCompAdd1" runat="server" class="tbinput"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvCompAdd1"
                ControlToValidate="CtrlCompAdd1"
                Display="Static" 
                runat="server" 
                ErrorMessage="Company Address Required">
            </asp:RequiredFieldValidator>
        </div>

           <div class="frm_row_cont">
            <asp:Label ID="LblCompAdd2" runat="server" class="frmlabel" Text="New Address 2*"></asp:Label><br />
            <asp:TextBox ID="CtrlCompAdd2" class="tbinput" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                ID="rfvCompAdd2"
                ControlToValidate="CtrlCompAdd2"
                Display="Static" 
                runat="server" 
                ErrorMessage="Company Address 2 Required">
            </asp:RequiredFieldValidator>
        </div>

         <div class="frm_row_cont">
            <asp:Label ID="LblCompLocation" runat="server" class="frmlabel" Text="Company Location*"></asp:Label><br />
            <asp:TextBox ID="CtrlCompLocation" class="tbinput" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                ID="rfvCompLocation"
                ControlToValidate="CtrlCompLocation"
                Display="Static" 
                runat="server" 
                ErrorMessage="Company Location Required">
            </asp:RequiredFieldValidator>
        </div>

          <div class="frm_row_cont">
            <asp:Label ID="LblCompPcode" runat="server" class="frmlabel" Text="Company Post Code*"></asp:Label><br />
            <asp:TextBox ID="CtrlCompPcode" class="tbinput" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                ID="rfvCompPcode"
                ControlToValidate="CtrlCompPcode"
                Display="Static" 
                runat="server" 
                ErrorMessage="Company Post Code Required">
            </asp:RequiredFieldValidator>
        </div>

         <div class="frm_row_cont">
            <asp:Label ID="LblContactFname" runat="server" class="frmlabel" Text="Contact First Name*"></asp:Label><br />
            <asp:TextBox ID="CtrlContactFname" class="tbinput" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                ID="rfvContactFname"
                ControlToValidate="CtrlContactFname"
                Display="Static" 
                runat="server" 
                ErrorMessage="Last Name Required">
            </asp:RequiredFieldValidator>
        </div>

          <div class="frm_row_cont">
            <asp:Label ID="LblContactLname" runat="server" class="frmlabel" Text="Contact Last Name*"></asp:Label><br />
            <asp:TextBox ID="CtrlContactLname" class="tbinput" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                ID="rfvContactLname"
                ControlToValidate="CtrlContactLname"
                Display="Static" 
                runat="server" 
                ErrorMessage="Last Name Required">
            </asp:RequiredFieldValidator>
        </div>

         <div class="frm_row_cont">
            <asp:Label ID="LblContactEmail" runat="server" class="frmlabel" Text="Contact Email*"></asp:Label><br />
            <asp:TextBox ID="CtrlContactEmail" class="tbinput" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                ID="rfvContactEmail"
                ControlToValidate="CtrlContactEmail"
                Display="Static" 
                runat="server" 
                ErrorMessage="Email Required">
            </asp:RequiredFieldValidator>
        </div>

          <div class="frm_row_cont">
            <asp:Label ID="LblMobile" runat="server" class="frmlabel" Text="Mobile Phone Number*"></asp:Label><br />
            <asp:TextBox ID="CtrlMobile" class="tbinput" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                ID="rfvMobile"
                ControlToValidate="CtrlMobile"
                Display="Static" 
                runat="server" 
                ErrorMessage="Mobile Phone Number Required">
            </asp:RequiredFieldValidator>
        </div>

         <div class="frm_row_cont">
            <asp:Label ID="LblBillTo" runat="server" class="frmlabel" Text="Billing Details*"></asp:Label><br />
            <asp:TextBox ID="CtrlBillTo" class="tbinput" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                ID="rfvBillTo"
                ControlToValidate="CtrlBillTo"
                Display="Static" 
                runat="server" 
                ErrorMessage="Billing Deatils Required">
            </asp:RequiredFieldValidator>
        </div>

        <div class="frm_row_cont">
            <asp:Label ID="LblStatus" runat="server" Text="Client Status"></asp:Label>
            <asp:Literal ID="ClientStatusPH" runat="server"></asp:Literal>
        </div>

        <div class="frm_row_cont">
            <asp:Button ID="BtnUpdateClientDetails" runat="server" class="button " Text="Update Client Details" OnClick="BtnUpdateClientDetails_Click" />
        </div>

    </form>
    </div>
</body>
</html>
