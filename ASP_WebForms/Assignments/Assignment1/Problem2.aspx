<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Problem2.aspx.cs" Inherits="Assignment1.Problem2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Application</title>
</head>
<body>
    <form id="form1" runat="server">

        <div>

            <h2>Product Store</h2>

            <asp:DropDownList ID="ddlProducts"
                runat="server"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
            </asp:DropDownList>

            <br /><br />

            <asp:Image ID="imgProduct"
                runat="server"
                Width="250px"
                Height="250px" />

            <br /><br />

            <asp:Button ID="btnPrice"
                runat="server"
                Text="Get Price"
                OnClick="btnPrice_Click" />

            <br /><br />

     
            <asp:Label ID="lblPrice"
                runat="server"
                Font-Bold="true"
                ForeColor="Blue">
            </asp:Label>

        </div>

    </form>
</body>
</html>