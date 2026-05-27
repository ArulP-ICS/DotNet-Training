<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="FoodOrderManagement.MenuList" %>

<!DOCTYPE html>
<html>
<body>

<form runat="server">

<h3>Menu Items</h3>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">

<Columns>

<asp:BoundField DataField="ItemName" HeaderText="Item" />
<asp:BoundField DataField="Price" HeaderText="Price" />

<asp:HyperLinkField Text="View"
    DataNavigateUrlFields="MenuId"
    DataNavigateUrlFormatString="MenuDetails.aspx?MenuId={0}" />

<asp:HyperLinkField Text="Edit"
    DataNavigateUrlFields="MenuId"
    DataNavigateUrlFormatString="AddEditMenu.aspx?MenuId={0}" />

<asp:TemplateField>
<ItemTemplate>
<asp:Button Text="Delete"
    CommandArgument='<%# Eval("MenuId") %>'
    OnClick="Delete_Click"
    runat="server" />
</ItemTemplate>
</asp:TemplateField>

</Columns>

</asp:GridView>

<br />
<a href="AddEditMenu.aspx">Add Menu</a>

</form>
</body>
</html>
