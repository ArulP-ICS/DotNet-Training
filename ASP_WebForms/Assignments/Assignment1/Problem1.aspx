<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Problem1.aspx.cs" Inherits="Assignment1.Problem1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation Form</title>

    <style>
        body { font-family: Arial; }

        table { margin-top: 20px; }

        td { padding: 8px; }

        .error { color: red; }

        .success { color: green; font-weight: bold; }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div>

            <h2>Insert your details :</h2>

            <table>

                <tr>
                    <td>Name :</td>
                    <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server"
                            ControlToValidate="txtName"
                            ErrorMessage="Name is required"
                            CssClass="error" />
                    </td>
                </tr>

                <tr>
                    <td>Family Name :</td>
                    <td><asp:TextBox ID="txtFamily" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvFamily" runat="server"
                            ControlToValidate="txtFamily"
                            ErrorMessage="Family Name is required"
                            CssClass="error" />
                    </td>
                </tr>

            
                <tr>
                    <td>Address :</td>
                    <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server"
                            ControlToValidate="txtAddress"
                            ErrorMessage="Address is required"
                            CssClass="error" />
                        <br />
                        <asp:RegularExpressionValidator ID="revAddress" runat="server"
                            ControlToValidate="txtAddress"
                            ValidationExpression=".{2,}"
                            ErrorMessage="Address must be at least 2 characters"
                            CssClass="error" />
                    </td>
                </tr>

           
                <tr>
                    <td>City :</td>
                    <td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server"
                            ControlToValidate="txtCity"
                            ErrorMessage="City is required"
                            CssClass="error" />
                        <br />
                        <asp:RegularExpressionValidator ID="revCity" runat="server"
                            ControlToValidate="txtCity"
                            ValidationExpression=".{2,}"
                            ErrorMessage="City must be at least 2 characters"
                            CssClass="error" />
                    </td>
                </tr>

         
                <tr>
                    <td>ZIP Code :</td>
                    <td><asp:TextBox ID="txtZip" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvZip" runat="server"
                            ControlToValidate="txtZip"
                            ErrorMessage="ZIP Code is required"
                            CssClass="error" />
                        <br />
                        <asp:RegularExpressionValidator ID="revZip" runat="server"
                            ControlToValidate="txtZip"
                            ValidationExpression="^\d{6}$"
                            ErrorMessage="ZIP Code must be 6 digits"
                            CssClass="error" />
                    </td>
                </tr>

            
                <tr>
                    <td>Phone :</td>
                    <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server"
                            ControlToValidate="txtPhone"
                            ErrorMessage="Phone is required"
                            CssClass="error" />
                        <br />
                        <asp:RegularExpressionValidator ID="revPhone" runat="server"
                            ControlToValidate="txtPhone"
                            ValidationExpression="^\d{10}$"
                            ErrorMessage="Phone must be 10 digits"
                            CssClass="error" />
                    </td>
                </tr>

           
                <tr>
                    <td>E-Mail :</td>
                    <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                            ControlToValidate="txtEmail"
                            ErrorMessage="Email is required"
                            CssClass="error" />
                        <br />
                        <asp:RegularExpressionValidator ID="revEmail" runat="server"
                            ControlToValidate="txtEmail"
                            ValidationExpression="\w+([.-]?\w+)*@\w+([.-]?\w+)*\.\w{2,3}"
                            ErrorMessage="Invalid email format"
                            CssClass="error" />
                    </td>
                </tr>

        
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnCheck" runat="server"
                            Text="Check"
                            OnClick="btnCheck_Click" />
                    </td>
                </tr>

            
                <tr>
                    <td colspan="3">
                        <asp:ValidationSummary ID="ValidationSummary1"
                            runat="server"
                            HeaderText="Validation Summary"
                            CssClass="error" />
                    </td>
                </tr>

                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </td>
                </tr>

            </table>

        </div>

    </form>
</body>
</html>