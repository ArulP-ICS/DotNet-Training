<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankForm.aspx.cs" Inherits="BankingApplication.BankForm" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Bank Application</title>

    <style>
        body {
            font-family: Arial;
            background-color: #eef2f7;
        }

        .container {
            width: 750px;
            margin: auto;
            background: white;
            padding: 20px;
            border-radius: 10px;
        }

        table {
            width: 100%;
        }

        td {
            padding: 8px;
        }

        .btn {
            background-color: #007bff;
            color: white;
            padding: 8px;
            border: none;
            width: 100%;
        }

        .error {
            color: red;
        }

        h2, h3 {
            text-align: center;
        }
    </style>
</head>

<body>
<form id="form1" runat="server">

<div class="container">

<h2>Bank Application</h2>


<asp:ValidationSummary 
    runat="server" 
    CssClass="error"
    HeaderText="Please fix the errors:"
    ValidationGroup="vg1" />

<h3>Register</h3>

<table>

<tr>
<td>Full Name</td>
<td>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator 
        ControlToValidate="txtName"
        ErrorMessage="Name is required"
        CssClass="error"
        ValidationGroup="vg1"
        runat="server"/>
</td>
</tr>

<tr>
<td>Gender</td>
<td>
    <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Vertical">
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:RadioButtonList>
</td>
</tr>

<tr>
<td>Address</td>
<td>
    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
</td>
</tr>

<tr>
<td>Mobile</td>
<td>
    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator 
        ControlToValidate="txtMobile"
        ErrorMessage="Mobile is required"
        CssClass="error"
        ValidationGroup="vg1"
        runat="server"/>
</td>
</tr>

<tr>
<td>Email</td>
<td>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
</td>
</tr>

<tr>
<td>Re-enter Email</td>
<td>
    <asp:TextBox ID="txtReEmail" runat="server"></asp:TextBox><br />
    <asp:CompareValidator 
        ControlToValidate="txtReEmail"
        ControlToCompare="txtEmail"
        ErrorMessage="Emails do not match"
        CssClass="error"
        ValidationGroup="vg1"
        runat="server"/>
</td>
</tr>

<tr>
<td>Password</td>
<td>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
</td>
</tr>

<tr>
<td>Re-enter Password</td>
<td>
    <asp:TextBox ID="txtRePassword" runat="server" TextMode="Password"></asp:TextBox><br />
    <asp:CompareValidator 
        ControlToValidate="txtRePassword"
        ControlToCompare="txtPassword"
        ErrorMessage="Passwords do not match"
        CssClass="error"
        ValidationGroup="vg1"
        runat="server"/>
</td>
</tr>

<tr>
<td>PAN</td>
<td>
    <asp:TextBox ID="txtPAN" runat="server"></asp:TextBox>
</td>
</tr>

<tr>
<td>Aadhaar</td>
<td>
    <asp:TextBox ID="txtAadhaar" runat="server"></asp:TextBox>
</td>
</tr>

<tr>
<td>Upload Photo</td>
<td>
    <asp:FileUpload ID="fuImage" runat="server" />
</td>
</tr>

<tr>
<td colspan="2">
    <asp:Button 
        ID="btnRegister"
        runat="server"
        Text="Register"
        CssClass="btn"
        ValidationGroup="vg1"
        OnClick="btnRegister_Click" />
</td>
</tr>

</table>

<hr />


<h3>Login</h3>

<table>

<tr>
<td>Account Number / Mobile</td>
<td>
    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
</td>
</tr>

<tr>
<td>Password</td>
<td>
    <asp:TextBox ID="txtLoginPass" runat="server" TextMode="Password"></asp:TextBox>
</td>
</tr>

<tr>
<td colspan="2">
    <asp:Button 
        ID="btnLogin"
        runat="server"
        Text="Login"
        CssClass="btn"
        OnClick="btnLogin_Click" />
</td>
</tr>

</table>

<br />


<asp:Label ID="lblMsg" runat="server"></asp:Label>

<hr />


<asp:GridView ID="gvUsers" 
    runat="server" 
    AutoGenerateColumns="False" 
    Visible="false"
    Width="100%">

<Columns>

    <asp:BoundField DataField="FullName" HeaderText="Name" />
    <asp:BoundField DataField="Gender" HeaderText="Gender" />
    <asp:BoundField DataField="Email" HeaderText="Email" />
    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
    <asp:BoundField DataField="AccountNumber" HeaderText="Account No" />

    <asp:TemplateField HeaderText="Photo">
        <ItemTemplate>
            <asp:Image 
                ID="imgUser" 
                runat="server"
                ImageUrl='<%# Eval("ImagePath") %>'
                Width="80px" Height="80px" />
        </ItemTemplate>
    </asp:TemplateField>

</Columns>

</asp:GridView>

</div>

</form>
</body>
</html>