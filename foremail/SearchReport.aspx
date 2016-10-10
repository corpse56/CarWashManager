<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchReport.aspx.cs" Inherits="CarWashManager.SearchReport" Culture = "ru-RU" UICulture="ru-RU" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/TopMenu.ascx" TagPrefix="UC" TagName = "TopMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
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
        <asp:Label ID="Label1" runat="server" Text="Общий поиск" Font-Size = "X-Large"></asp:Label>
    
        <table border = "1" width = "100%" id = "Conditions" >
        <tr>
            <td>
                <asp:CheckBox ID="chbAllTime" runat="server" Text = "За весь период" 
                    AutoPostBack = "true" oncheckedchanged="chbAllTime_CheckedChanged" Font-Size = "X-Large" />
            </td>
        </tr>
        <tr>
            <td>     
                <asp:Label ID="Label2" runat="server" Text="За период с:" Font-Size = "X-Large"></asp:Label>
                <asp:TextBox ID="tbStart" runat="server"  Font-Size = "X-Large" ></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID = "tbStart" CssClass ="MyPopupCalendar" >    
                </ajaxToolkit:CalendarExtender>
                <asp:Label ID="Label3" runat="server" Text="по :" Font-Size = "X-Large"></asp:Label>

                <asp:TextBox ID="tbEnd" runat="server" Font-Size = "X-Large" ></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID = "tbEnd"  CssClass ="MyPopupCalendar">    
                </ajaxToolkit:CalendarExtender>

             </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Отметьте нужные услуги" Font-Size = "X-Large"></asp:Label>
                <br />
                <asp:Button ID="bSelectAllServ" runat="server" Text="Выделить все" onclick="bSelectAllServ_Click"  Font-Size = "X-Large" 
                     />
                <asp:Button ID="bDeSelectAllServ" runat="server" Text="Снять выделение" onclick="bDeSelectAllServ_Click"  Font-Size = "X-Large"
                     />
                <br />
                <br />
                <asp:CheckBoxList ID="chblServ" runat="server" Font-Size = "X-Large">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Отметьте нужные классы автомобилей" Font-Size = "X-Large"></asp:Label>            
                <br />
                <asp:CheckBoxList ID="chblClass" runat="server"  Font-Size = "X-Large">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Отметьте нужные линии автомойки" Font-Size = "X-Large"></asp:Label>            
                <br />
                <asp:CheckBoxList ID="chblLine" runat="server"  Font-Size = "X-Large">
                </asp:CheckBoxList>
            </td>
        </tr>        
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Отметьте сотрудников" Font-Size = "X-Large"></asp:Label>            
                <br />
                <asp:Button ID="bSelectAllEmp" runat="server" Text="Выделить все" onclick="bSelectAllEmp_Click"   Font-Size = "X-Large"
                    />
                <asp:Button ID="bDeSelectAllEmp" runat="server" Text="Снять выделение" onclick="bDeSelectAllEmp_Click"   Font-Size = "X-Large"
                     />
                <br />
                <br />
                <asp:CheckBoxList ID="chblEmp" runat="server"  Font-Size = "X-Large">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="bShow" runat="server" Text="Найти"   Font-Size = "X-Large"
                    onclick="bShow_Click" />
            </td>
        </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
