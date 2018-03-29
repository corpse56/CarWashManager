<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditJob.aspx.cs" Inherits="CarWashManager.EditJob" Culture = "ru-RU" UICulture="ru-RU"%>
<%@ Register src="~/TopMenu.ascx" TagPrefix="UC" TagName = "TopMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Редактирование работы</title>
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = null;
            confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            confirm_value.value = null;
            if (confirm("Вы уверены, что хотите удалить текущую работу?")) {
                confirm_value.value = null;
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = null;
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
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
    <table border = "1" width = "100%" >
         <tr>
            <td>
                
                <asp:Label ID="Label8" runat="server" Text="Спец. транспорт: " Font-Size = "X-Large"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSpecial" runat="server" Font-Size = "X-Large"> 
                <asp:ListItem>НЕТ</asp:ListItem>
                <asp:ListItem>ДА</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td> 
                <asp:Label ID="Label1" runat="server" Text="Выберите линию: " Font-Size = "X-Large"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlLine" runat="server" Font-Size = "X-Large"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label2" runat="server" Text="Выберите сотрудника: " Font-Size = "X-Large"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlEmployees" runat="server"  Font-Size = "X-Large"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Введите гос номер автомобиля" Font-Size = "X-Large"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbPlate" runat="server" Font-Size = "X-Large" 
                    ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Выберите класс автомобиля" Font-Size = "X-Large"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlClass_SelectedIndexChanged" 
                    Font-Size = "X-Large" Enabled="False"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Выберите автомобиль из списка" Font-Size = "X-Large"></asp:Label>
                <br />
                <asp:Label ID="Label6" runat="server" Text="либо впишите вручную" Font-Size = "X-Large"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCar" runat="server" Font-Size = "X-Large"></asp:DropDownList> &nbsp&nbsp&nbsp
                <asp:CheckBox ID="chbManual" runat="server" AutoPostBack="True"  Font-Size = "X-Large"
                    oncheckedchanged="chbManual_CheckedChanged" /><asp:TextBox ID="tbCar" 
                    runat="server" Enabled ="false"  Font-Size = "X-Large" 
                     ></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Отметьте заказанные услуги" Font-Size = "X-Large"></asp:Label>
            </td>
            <td>
                <asp:CheckBoxList ID="chblPrice" runat="server" Font-Size = "X-Large" Enabled = "false"
                    Height="180px" onselectedindexchanged="chblPrice_SelectedIndexChanged" AutoPostBack = "true">
                </asp:CheckBoxList>
            </td>
        </tr>            
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Отметьте дополнительные услуги" Font-Size = "X-Large"></asp:Label>
            </td>
            <td>
                <asp:CheckBoxList ID="chblAddServ" runat="server" Font-Size = "X-Large" 
                    Height="180px"  AutoPostBack = "true"  
                    onselectedindexchanged="chblAddServ_SelectedIndexChanged">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="+ 50 %" Font-Size = "X-Large"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chbPlus_50"  Text = "Прибавить 50% к итоговой стоимости" runat="server" Font-Size = "X-Large" Height="180px" Checked = "false">
                </asp:CheckBox>
            </td>
        </tr>        
        <tr>
            <td>
                <div style = "float:left"><asp:Button ID="bAdd" runat="server" Text="Отредактировать" onclick="bAdd_Click" Font-Size = "X-Large"  /></div>
            </td>
            <td>
                <div style = "float:right"><asp:Button ID="bDelete" runat="server" Text="Удалить текущую работу" Font-Size = "X-Large"
                OnClick = "OnConfirm" OnClientClick = "Confirm()" Enabled = "false"   /></div>
            </td>
        </tr>
    </table>
        
        <br />
        <br />
        <asp:Label ID="lError" runat="server" Text="" ForeColor = "Red" Font-Size = "X-Large"></asp:Label>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
