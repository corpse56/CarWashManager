<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CarWashManager.Edit" Culture = "ru-RU" UICulture="ru-RU" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/TopMenu.ascx" TagPrefix="UC" TagName = "TopMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Редактирование работ</title>
    <link rel="stylesheet" type="text/css" href="~/style/ajax_calendar_extender_style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>

    <div style = "margin:0 auto; width:100%">
          <UC:TopMenu id="TopMenu1" runat="server"></UC:TopMenu>

    <br />
    <br />
    </div>
    <div style = "margin:0 auto; width:100%">
        <asp:TextBox ID="tbDate" runat="server"  Font-Size = "X-Large" ></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID = "tbDate" CssClass ="MyPopupCalendar" >    
        </ajaxToolkit:CalendarExtender>
        <asp:Button ID="Button1" runat="server" Text="Выбрать" Font-Size = "X-Large" 
            onclick="Button1_Click" />
    </div>
    <div style = "margin:0 auto; width:100%">
        <asp:Table ID="tEdit" runat="server" BorderWidth = "1" Width = "100%" Font-Size ="Larger"
         style="border-color:Black;border-width:3px;border-style:Solid;color:Black;" GridLines = "Both">
        </asp:Table>
    </div>

    </form>
</body>
</html>
