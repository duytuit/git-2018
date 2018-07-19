<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HTQuanLyFilm.Author.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
             <p>
                <asp:Login ID="myLogin" runat="server"
                    RememberMeSet="false"
                    TitleText=""
                    UserNameLabelText="Username:" OnAuthenticate="myLogin_Authenticate"
                    OnLoginError="myLogin_LoginError" OnLoggedIn="myLogin_LoggedIn">
                    <LayoutTemplate>
                        <table border="0" "
                            style="border-collapse: collapse;">
                            <tr>
                                <td>
                                    <table border="0" >
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                                                    ControlToValidate="UserName" ErrorMessage="User Name is required."
                                                    ToolTip="User Name is required." ValidationGroup="myLogin">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                                    ControlToValidate="Password" ErrorMessage="Password is required."
                                                    ToolTip="Password is required." ValidationGroup="myLogin">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                      
                                        <tr>
                                            <td colspan="2">
                                                <asp:CheckBox ID="RememberMe" runat="server" Checked="True"
                                                    Text="Remember me next time." />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color: Red;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In"
                                                    ValidationGroup="myLogin"/>
                                            </td>
                                        </tr>
               
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                </asp:Login>
            </p>
    </div>
    </form>
</body>
</html>
