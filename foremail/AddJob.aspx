<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="AddJob.aspx.cs" Inherits="CarWashManager.AddJob"  Culture = "ru-RU" UICulture="ru-RU"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/TopMenu.ascx" TagPrefix="UC" TagName = "TopMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Добавление работы. Шаг 1.</title>
</head>
<style type="text/css" >
    .watermarked {
    color:gray;
    font-style: italic;
    }
</style>
<body>
    <form id="form1" runat="server">
   
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div style = "margin:0 auto; width:100%">
      <UC:TopMenu id="TopMenu1" runat="server"></UC:TopMenu>

  
    <br />
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
        <asp:Label ID="title" runat="server" Text="Добавление работы. Шаг 1. Добавьте информацию об автомобиле. " Font-Size = "XX-Large"  ></asp:Label>
    </div>
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
                <asp:TextBox ID="tbPlate" runat="server" Font-Size = "X-Large"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID = "tbPlate" WatermarkText = "а888мр777" Enabled = "true" WatermarkCssClass = "watermarked">
                </asp:TextBoxWatermarkExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Выберите класс автомобиля" Font-Size = "X-Large"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlClass_SelectedIndexChanged" Font-Size = "X-Large"></asp:DropDownList>
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
                    ontextchanged="tbCar_TextChanged" OnClick="chbManual.=''"></asp:TextBox>                
            </td>
        </tr>
       <%-- <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Отметьте заказанные услуги" Font-Size = "X-Large"></asp:Label>
            </td>
            <td>
                <asp:CheckBoxList ID="chblPrice" runat="server" Font-Size = "X-Large" Height="180px">
                </asp:CheckBoxList>
            </td>
        </tr>--%>
        <!--<tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Отметьте дополнительные услуги" Font-Size = "X-Large"></asp:Label>
            </td>
            <td>
                <asp:CheckBoxList ID="chblAddServ" runat="server" Font-Size = "X-Large" Height="180px">
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
        </tr>-->
    </table>
    <br />
        <asp:Button ID="bAdd" runat="server" Text="Продолжить >>>" onclick="bAdd_Click" Font-Size = "X-Large"  />
        <br />
        <asp:Label ID="lError" runat="server" Text="" ForeColor = "Red" Font-Size = "X-Large"></asp:Label>
    </ContentTemplate>
    </asp:UpdatePanel>

    </form>
    
    
    
</body>
</html>
