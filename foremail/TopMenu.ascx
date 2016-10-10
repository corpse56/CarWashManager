<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopMenu.ascx.cs" Inherits="CarWashManager.TopMenu" %>

       <h2><asp:LinkButton ID="lbMain" runat="server" PostBackUrl ="~/Default.aspx">На главную</asp:LinkButton>&nbsp&nbsp
    <asp:LinkButton ID="lbAdd" runat="server" PostBackUrl ="~/AddJob.aspx"  >Добавить</asp:LinkButton>&nbsp&nbsp
    <asp:LinkButton ID="lbReports" runat="server" PostBackUrl ="~/Reports.aspx">Отчеты</asp:LinkButton>&nbsp&nbsp
    <!--<asp:LinkButton ID="lbSearch" runat="server" PostBackUrl = "~/SearchReport.aspx">Поиск</asp:LinkButton>&nbsp&nbsp-->
    <asp:LinkButton ID="lbPrice" runat="server" PostBackUrl = "~/Price.aspx">Прайс</asp:LinkButton>&nbsp&nbsp
    <!--<asp:LinkButton ID="lbAddServ" runat="server" PostBackUrl = "~/AddServ.aspx">Допы</asp:LinkButton>&nbsp&nbsp-->
    <asp:LinkButton ID="lbEdit" runat="server" PostBackUrl = "~/Edit.aspx">Редактирование</asp:LinkButton>&nbsp&nbsp
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl = "~/adminpage.aspx">Панель администратора</asp:LinkButton>
    </h2>
