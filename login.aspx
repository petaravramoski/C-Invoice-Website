<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Application_Prototype.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <h3>Login</h3>
    <form id="UserLogin" runat="server">
        <div class="frm_row_cont">
            <asp:Label ID="LblUserEmail" runat="server" class="frmlabel" Text="Email Address"></asp:Label><br />
            <asp:TextBox ID="CtrlUserEmail" class="tbinput" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator
               ControlToValidate="CtrlUserEmail"
               Display="Static"
               ErrorMessage="An email address is required."
               ID="rfvUserEmail"
               RunAt="Server" />
            <asp:RegularExpressionValidator
                ControlToValidate="CtrlUserEmail"
                ErrorMessage="Invalid email address. Please try again."
                ID="revUserEmail"
                ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
                runat="server" />
        </div>
        <div class="frm_row_cont">
            <asp:Label ID="LblUserPassword" runat="server" class="frmlabel" Text="Password"></asp:Label><br />
            <asp:TextBox ID="CtrlUserPassword" class="tbinput" runat="server" TextMode="Password" ></asp:TextBox>
            <asp:RequiredFieldValidator
               ControlToValidate="CtrlUserPassword"
               Display="Static"
               ErrorMessage="A password is required."
               ID="rfvCtrlUserPassword"
               RunAt="Server" />
        </div>

        <div class="frm_row_cont">
            <asp:Button ID="BtnLogin" runat="server" class="button" Text="Login" OnClick="BtnLogin_Click" />
        </div>
    </form>
</body>
</html>
