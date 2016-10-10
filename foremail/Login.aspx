<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CarWashManager.Login" %>
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
     <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/adminpage.aspx" 
        DisplayRememberMe="False" Font-Size="X-Large" ForeColor="Black" Height="110px" 
        LoginButtonText="Войти" OnAuthenticate="Login1_Authenticate" 
        PasswordLabelText="Пароль:" RememberMeText="" TitleText="Авторизация" 
        UserNameLabelText="Логин :" 
        UserNameRequiredErrorMessage="Поле &quot;Логин&quot; является обязательным." 
        Width="500px">
         <TextBoxStyle Font-Size="XX-Large" Font-Underline="False" />
         <LoginButtonStyle Font-Size="XX-Large" Height="50px" Width="100px" />
    </asp:Login>
    </center>
    </div>
    </form>
</body>
</html>
