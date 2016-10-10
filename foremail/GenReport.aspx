<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenReport.aspx.cs" Inherits="CarWashManager.GenReport" Culture = "ru-RU" UICulture="ru-RU" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/TopMenu.ascx" TagPrefix="UC" TagName = "TopMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Общий отчет</title>
    <style type = "text/css">

    </style>
    <link rel="stylesheet" type="text/css" href="~/style/ajax_calendar_extender_style.css" />
</head>

<body>

    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <div style = "margin:0 auto; width:100%">
                      <UC:TopMenu id="TopMenu1" runat="server"></UC:TopMenu>

    <br />
    </div>
    Общий отчет
        <table border = "1" width = "100%" id = "Conditions" >
        <tr>
            <td>
                <asp:CheckBox ID="chbAllTime" runat="server" Text = "За весь период" 
                    AutoPostBack = "true" oncheckedchanged="chbAllTime_CheckedChanged"  Font-Size = "X-Large" />
            </td>
        </tr>
        <tr>
            <td>
                 
                <asp:Label ID="Label1" runat="server" Text="За период с:"  Font-Size = "X-Large"></asp:Label>
                <asp:TextBox ID="tbStart" runat="server"  Font-Size = "X-Large" ></asp:TextBox> 
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID = "tbStart" CssClass ="MyPopupCalendar" >    
                </ajaxToolkit:CalendarExtender>
                <asp:Label ID="Label2" runat="server" Text="по :"  Font-Size = "X-Large"></asp:Label>
                <asp:TextBox ID="tbEnd" runat="server" Font-Size = "X-Large" ></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID = "tbEnd"  CssClass ="MyPopupCalendar">    
                </ajaxToolkit:CalendarExtender>
             </td>
        </tr>
                <tr>
            <td>
                <asp:Button ID="bShow" runat="server" Text="Показать отчёт" 
                    onclick="bShow_Click" Font-Size = "X-Large" />
            </td>
        </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
