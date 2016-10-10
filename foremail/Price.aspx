<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Price.aspx.cs" Inherits="CarWashManager.Price" Culture = "ru-RU" UICulture="ru-RU"%>
<%@ Register src="~/TopMenu.ascx" TagPrefix="UC" TagName = "TopMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Менеджер автомойки</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style = "margin:0 auto; width:100%">
                            <UC:TopMenu id="TopMenu1" runat="server"></UC:TopMenu>

    <br />
    <br />
    </div>
    <asp:Table ID="tPrice" runat="server" BorderWidth = "1" Width = "100%" Font-Size ="Larger"
    style="border-color:Black;border-width:3px;border-style:Solid;color:Black;" GridLines = "Horizontal" >
    </asp:Table>

    </form>
</body>
</html>
