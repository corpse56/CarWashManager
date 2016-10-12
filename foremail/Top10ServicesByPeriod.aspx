<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top10ServicesByPeriod.aspx.cs" Inherits="CarWashManager.Top10ServicesByPeriod" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
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

    <div>
                                                    <UC:TopMenu id="TopMenu1" runat="server"></UC:TopMenu>

    <br />
    <br />
       
       
    <table>
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
        <td>
                <asp:Button ID="Button2" runat="server"
                    Text="Показать" onclick="Button2_Click" Font-Size = "X-Large" />
        </td>
    </tr>
    </table>       
    <br />
    <br />
       
    <asp:chart id="Chart1" runat="server" Visible = "false"
             Height="700px" Width="1000px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" >
  <titles>
    <asp:Title ShadowOffset="1" Name="Title1" Font="Times New Roman, 25pt, style=Bold, Italic" />
  </titles>
  <legends>
    <asp:Legend Alignment="Center" Docking="Bottom"
                IsTextAutoFit="False" Name="Default"
                LegendStyle="Table" Font="Times New Roman, 18pt" />
  </legends>
  <series>
    <asp:Series Name="Default" />
  </series>
  <chartareas>
    <asp:ChartArea Name="ChartArea1"
                     BorderWidth="0" />
  </chartareas>
</asp:chart>
    <br />
    <br />
       
    <asp:chart id="Chart2" runat="server" Visible = "false"
             Height="700px" Width="1000px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" >
  <titles>
    <asp:Title ShadowOffset="1" Name="Title1" Font="Times New Roman, 25pt, style=Bold, Italic" />
  </titles>
  <legends>
    <asp:Legend Alignment="Center" Docking="Bottom"
                IsTextAutoFit="False" Name="Default"
                LegendStyle="Table" Font="Times New Roman, 18pt" />
  </legends>
  <series>
    <asp:Series Name="Default" />
  </series>
  <chartareas>
    <asp:ChartArea Name="ChartArea1"
                     BorderWidth="0" />
  </chartareas>
</asp:chart>
    
    </div>
    </form>
</body>
</html>
