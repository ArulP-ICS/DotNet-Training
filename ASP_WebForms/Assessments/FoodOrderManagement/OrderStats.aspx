<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderStats.aspx.cs" Inherits="FoodOrderManagement.OrderStats" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Total Visitors: <%= Application["TotalVisitors"] %>
        </div>
    </form>
</body>
</html>
