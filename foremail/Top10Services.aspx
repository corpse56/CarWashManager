<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top10Services.aspx.cs" Inherits="CarWashManager.Top10Services" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register src="~/TopMenu.ascx" TagPrefix="UC" TagName = "TopMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                                                    <UC:TopMenu id="TopMenu1" runat="server"></UC:TopMenu>

    <br />
    <br />
       
    <asp:chart id="Chart1" runat="server"
             Height="700px" Width="1000px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Visible="true">
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
       
    <asp:chart id="Chart2" runat="server"
             Height="700px" Width="1000px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Visible="true">
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
