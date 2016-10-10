<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServReportShow.aspx.cs" Inherits="CarWashManager.ServReportShow"  Culture = "ru-RU" UICulture="ru-RU"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register src="~/TopMenu.ascx" TagPrefix="UC" TagName = "TopMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style = "margin:0 auto; width:100%">
                                  <UC:TopMenu id="TopMenu1" runat="server"></UC:TopMenu>

    <br />
    </div>
    
    <div style = "margin:0 auto; width:100%;height:100%">
        <CR:CrystalReportViewer ID="RepViewer" runat="server" AutoDataBind="true" 
            DisplayGroupTree="False" HasCrystalLogo="False" HasDrillUpButton="False" 
            HasGotoPageButton="False" HasRefreshButton="True" HasSearchButton="False" 
            HasToggleGroupTreeButton="False" HasViewList="False" 
              BestFitPage = "false" width = "1500px"
            HasZoomFactorList="true" SeparatePages="False" PageZoomFactor = "125" />
        
    </div>    
    </form>
</body>
</html>
