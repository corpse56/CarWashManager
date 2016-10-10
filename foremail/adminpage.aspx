<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminpage.aspx.cs" Inherits="CarWashManager.adminpage" %>
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
          <div style="text-align:right">
            <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">Выход</asp:LinkButton> 
            </div>
             <br />
    <asp:LinkButton ID="lbTime" runat="server" PostBackUrl = "~/CanceledServices.aspx"  Font-Size = "X-Large">Отменённые задания</asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl = "~/Top10Services.aspx"  Font-Size = "X-Large">Десятка самых популярных услуг за всё время</asp:LinkButton>

    </div>
    </form>
</body>
</html>
