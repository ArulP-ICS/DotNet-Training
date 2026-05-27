<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FoodOrderManagement.Login" %>

<!DOCTYPE html>
<html>
<body>
<form runat="server">

<h3>Login</h3>

Username:
<asp:TextBox ID="txtUsername" runat="server" /><br />

Password:
<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br />

<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>

<br />
<asp:Label ID="lblMsg" runat="server" ForeColor="Red"/>

</form>
</body>
</html>