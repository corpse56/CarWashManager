<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemovedJobs.aspx.cs" Inherits="CarWashManager.RemovedJobs" %>
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
    <center>
        <asp:Label ID="Label1" runat="server" Text="Удалённые задания в порядке убывания по дате" Font-Size = "X-Large"></asp:Label>
    </center>
        <br />
    <br />
<asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns = "False"  BorderWidth="3px"
            BorderStyle="Solid" BorderColor = "Black" Width = "100%"
            RowStyle-Wrap ="true"  Font-Size = "20px" CellPadding="0"  RowHeaderColumn = "null"
             HeaderStyle-BackColor = "Silver"  >
            <RowStyle Wrap="True"></RowStyle>
            <Columns>
             
                <asp:BoundField HeaderText="Номер работы" />
                <asp:BoundField HeaderText="Дата" />
                <asp:BoundField HeaderText="Сотрудник" />
                <asp:BoundField HeaderText="Автомобиль" />
                <asp:BoundField HeaderText="Линия" />
                <asp:BoundField HeaderText="Класс" />
                <asp:BoundField HeaderText="Гос. номер" />
                <asp:BoundField HeaderText="Стоимость" />
                <asp:BoundField HeaderText="Дата удаления работы" />
                
            </Columns>
            </asp:GridView>        </div>
    </form>
</body>
</html>
