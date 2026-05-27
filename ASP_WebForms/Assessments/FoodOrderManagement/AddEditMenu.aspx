<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditMenu.aspx.cs" Inherits="FoodOrderManagement.AddEditMenu" %>

<!DOCTYPE html>
<html>
<body>

<form runat="server">

<h3>Add / Edit Menu</h3>

Item Name:
<asp:TextBox ID="txtName" runat="server" /><br /><br />

Price:
<asp:TextBox ID="txtPrice" runat="server" /><br /><br />

<asp:Button ID="btnSave" runat="server" Text="Save"
    OnClick="btnSave_Click" />

</form>

</body>
</html>