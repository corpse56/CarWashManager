<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarsReport.aspx.cs" Inherits="CarWashManager.CarsReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="~/TopMenu.ascx" TagPrefix="UC" TagName = "TopMenu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Отчёт по автомобилям</title>
    <link rel="stylesheet" type="text/css" href="~/style/ajax_calendar_extender_style.css" /></head>
<body>
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <div style = "margin:0 auto; width:100%">
                      <UC:TopMenu id="TopMenu1" runat="server"></UC:TopMenu>

    <br />
    </div>
    Отчёт по автомобилям
        <table border = "1" width = "100%" id = "Conditions" >
        <tr>
            <td>
                <asp:CheckBox ID="chbAllTime" runat="server" Text = "За весь период" 
                    AutoPostBack = "true" oncheckedchanged="chbAllTime_CheckedChanged"  Font-Size = "X-Large" />
            </td>
        </tr>
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
        </tr>
            <tr>
            <td>
                <asp:Button ID="bShow" runat="server" Text="Показать отчёт" 
                    onclick="bShow_Click" Font-Size = "X-Large" />
            </td>
        </tr>
            <tr>
            <td>
               <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns = "False"  BorderWidth="3px"
         BorderStyle="Solid" BorderColor = "Black"   GridLines = "Both"
            RowStyle-Wrap ="true"  Font-Size = "20px" CellPadding="5" 
              >
<RowStyle Wrap="True"></RowStyle>
            <Columns>
                
                <asp:BoundField HeaderText="№№">
                <HeaderStyle BackColor="Silver" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Автомобиль" >
                <HeaderStyle BackColor="Silver" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Гос. номер" >
                <HeaderStyle BackColor="Silver" />
                </asp:BoundField>
                
                <asp:BoundField HeaderText="Дата" >
                <HeaderStyle BackColor="Silver" />
                </asp:BoundField>
                
                <asp:BoundField HeaderText="Сотрудник" >
                <HeaderStyle BackColor="Silver" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Услуги" >
                <HeaderStyle BackColor="Silver" />
                </asp:BoundField>

                <asp:BoundField HeaderText="Общая стоимость" >
                <HeaderStyle BackColor="Silver" />
                </asp:BoundField>
                
            </Columns>
            
        </asp:GridView>  
            </td>
        </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
