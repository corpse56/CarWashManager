<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="CarWashManager.Reports" Culture = "ru-RU" UICulture="ru-RU" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style = "margin:0 auto; width:100%">
       <h2><asp:LinkButton ID="lbMain" runat="server" PostBackUrl ="~/Default.aspx">На главную</asp:LinkButton>&nbsp&nbsp
    <asp:LinkButton ID="lbAdd" runat="server" PostBackUrl ="~/AddJob.aspx"  >Добавить</asp:LinkButton>&nbsp&nbsp
    <asp:LinkButton ID="lbReports" runat="server" PostBackUrl ="~/Reports.aspx">Отчеты</asp:LinkButton>&nbsp&nbsp
    <!--<asp:LinkButton ID="lbSearch" runat="server" PostBackUrl = "~/SearchReport.aspx">Поиск</asp:LinkButton>&nbsp&nbsp-->
    <asp:LinkButton ID="lbPrice" runat="server" PostBackUrl = "~/Price.aspx">Прайс</asp:LinkButton>&nbsp&nbsp
    <!--<asp:LinkButton ID="lbAddServ" runat="server" PostBackUrl = "~/AddServ.aspx">Допы</asp:LinkButton>&nbsp&nbsp-->
    <asp:LinkButton ID="lbEdit" runat="server" PostBackUrl = "~/Edit.aspx">Редактирование</asp:LinkButton>&nbsp&nbsp
    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl = "~/Login.aspx">Вход для администратора</asp:LinkButton>
    </h2>
    </div>
    <br />
    <asp:LinkButton ID="lbTime" runat="server" PostBackUrl = "~/GenReport.aspx"  Font-Size = "X-Large">Отчет по времени</asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="lbTeam" runat="server" PostBackUrl = "~/TeamReport.aspx"  Font-Size = "X-Large">Отчет по бригадам</asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="lbServ" runat="server" PostBackUrl = "~/ServReport.aspx"  Font-Size = "X-Large">Отчет по услугам</asp:LinkButton>
    <br />
    <br />
    <!--<asp:LinkButton ID="lbAddServR" runat="server" PostBackUrl = "~/AddServReport.aspx"  Font-Size = "X-Large">Отчет по дополнительным услугам</asp:LinkButton>
    <br />
    <br />-->
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl = "~/SearchReport.aspx"  Font-Size = "X-Large">Поиск</asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl = "~/FullReport.aspx"  Font-Size = "X-Large">Полный отчёт</asp:LinkButton>

    </form>
</body>
</html>
