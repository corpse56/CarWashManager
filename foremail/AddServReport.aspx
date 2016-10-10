<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddServReport.aspx.cs" Inherits="CarWashManager.AddServReport" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/TopMenu.ascx" TagPrefix="UC" TagName = "TopMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Отчет по дополнительным услугам</title>
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
    <asp:Label ID="Label1" runat="server" Text="Отчет по дополнительным услугам" Font-Size ="X-Large" ></asp:Label>
        <table border = "1" width = "100%" id = "Conditions" >
        <tr>
            <td>
                <asp:CheckBox ID="chbAllTime" runat="server" Text = "За весь период" 
                    AutoPostBack = "true" oncheckedchanged="chbAllTime_CheckedChanged" Font-Size ="X-Large" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="За период с:" Font-Size ="X-Large" ></asp:Label>
                 
                <asp:TextBox ID="tbStart" runat="server"  Font-Size ="X-Large" ></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID = "tbStart"  CssClass ="MyPopupCalendar">    
                </ajaxToolkit:CalendarExtender>
                <asp:Label ID="Label3" runat="server" Text="по :" Font-Size ="X-Large" ></asp:Label>

                <asp:TextBox ID="tbEnd" runat="server" Font-Size ="X-Large" ></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID = "tbEnd" CssClass ="MyPopupCalendar">    
                </ajaxToolkit:CalendarExtender>

             </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="bSelectAll" runat="server" Text="Выделить все"  Font-Size ="X-Large"
                    onclick="bSelectAll_Click" />
                <asp:Button ID="bDeSelectAll" runat="server" Text="Снять выделение"  Font-Size ="X-Large"
                    onclick="bDeSelectAll_Click" />
                <br />
                <br />
                <asp:CheckBoxList ID="chblEmp" runat="server" Font-Size ="X-Large">
                </asp:CheckBoxList>
            </td>
        </tr>        
        <tr>
            <td>
                <asp:Button ID="bShow" runat="server" Text="Показать отчёт"  Font-Size ="X-Large"
                    onclick="bShow_Click" />
            </td>
        </tr>
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
