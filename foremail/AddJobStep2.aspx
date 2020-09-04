<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="AddJobStep2.aspx.cs" Inherits="CarWashManager.AddJobStep2"  Culture = "ru-RU" UICulture="ru-RU"%>
<%@ Register src="~/TopMenu.ascx" TagPrefix="UC" TagName = "TopMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Добавление работы. Шаг 2.</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div style = "margin:0 auto; width:100%">
      <UC:TopMenu id="TopMenu1" runat="server"></UC:TopMenu>

  
    <br />
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:Label ID="title" runat="server" Text="Добавление работы. Шаг 2. Добавьте услуги для автомобиля. " Font-Size = "XX-Large"  ></asp:Label>
    </div>
    <br />
    <table border = "1" width = "100%" >
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Отметьте заказанные услуги" Font-Size = "X-Large"></asp:Label>
            </td>
            <td>
                <asp:CheckBoxList ID="chblPrice" runat="server" Font-Size = "X-Large" Height="180px">
                </asp:CheckBoxList>
            </td>
        </tr>
        
    </table>
    <br />
        <asp:Button ID="bAdd" runat="server" Text="Завершить" onclick="bAdd_Click" Font-Size = "X-Large"  />
        <br />
        <asp:Label ID="lError" runat="server" Text="" ForeColor = "Red" Font-Size = "X-Large"></asp:Label>
    </ContentTemplate>
    </asp:UpdatePanel>

    </form>
</body>
</html>
