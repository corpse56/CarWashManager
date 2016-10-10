<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FullReportShow.aspx.cs" Inherits="CarWashManager.FullReportShow" %>
<%@ Register src="~/TopMenu.ascx" TagPrefix="UC" TagName = "TopMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
     
    td.column_style_left
    {
        border-left:  4px double black;
    }    
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
               <UC:TopMenu id="TopMenu1" runat="server"></UC:TopMenu>

        <br />
    <br />
    <center>
        <asp:Label ID="Label1" runat="server" Text="Полный отчёт" Font-Size = "X-Large"></asp:Label>
        </center>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns = "False"  BorderWidth="3px"
         BorderStyle="Solid" BorderColor = "Black" Width = "100%"
            RowStyle-Wrap ="true"  Font-Size = "20px" CellPadding="3"  RowHeaderColumn = "null"
             HeaderStyle-BackColor = "Silver" 
            onrowdatabound="GridView1_RowDataBound"  >
            <RowStyle Wrap="True"></RowStyle>
            <Columns>
             
                <asp:BoundField HeaderText="Сотрудник" />
                <asp:BoundField HeaderText="Гос. номер" />
                <asp:BoundField HeaderText="Дата" />
                <asp:BoundField HeaderText="Услуги" />
                <asp:BoundField HeaderText="Авто" />
                <asp:BoundField HeaderText="Сумма" />
                <asp:TemplateField>
                <HeaderTemplate>Сотрудник</HeaderTemplate>
                <ItemStyle CssClass="column_style_left"  />
                
                <ItemTemplate>
                <%#Eval("EMP2")%>
                    <!-- whatever you want here -->
                </ItemTemplate>
            </asp:TemplateField>
                <asp:BoundField HeaderText="Гос. номер" />
                <asp:BoundField HeaderText="Дата" />
                <asp:BoundField HeaderText="Услуги" />
                <asp:BoundField HeaderText="Авто" />
                <asp:BoundField HeaderText="Сумма" />
                
            </Columns>
            </asp:GridView>
                    <asp:Label ID="Label2" runat="server" Text="Итого: " Font-Size = "X-Large"></asp:Label>
        </center>

    </div>
    </form>
</body>
</html>
