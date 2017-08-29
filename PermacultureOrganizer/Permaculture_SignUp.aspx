<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Permaculture_SignUp.aspx.cs" Inherits="Permaculture_Garden_Planning.Webpages.Permaculture_SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Permaculture</title>
    <link rel="stylesheet" href="css/style-login.css">
</head>
<body>

    <asp:Label ID="Label1" runat="server"></asp:Label>

    <div class="container">
        

        <div id="login">
            <form id="form1" runat="server">
                <fieldset class="clearfix">
                    <table style="margin-left:-200px;width:650px;margin-top:100px;">
                        <tr>
                            <td>
                                <p>
                                    <span class="fontawesome-user"></span>
                                    <asp:TextBox ID="FirstName" runat="server" value="First Name"></asp:TextBox>
                                </p>
                            </td>
                            <td>
                                <p>
                                    <span class="fontawesome-user"></span>
                                    <asp:TextBox ID="LastName" runat="server" value="Last Name"></asp:TextBox>

                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    <span class="fontawesome-user"></span>
                                    <asp:TextBox ID="UserName" runat="server" value="User Name"></asp:TextBox>
                                </p>
                            </td>
                            <td>
                                <p>
                                    <span class="fontawesome-lock"></span>
                                    <asp:TextBox ID="Pswd" runat="server" value="Password"></asp:TextBox>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    <span class="fontawesome-phone"></span>
                                    <asp:TextBox ID="Telephone" runat="server" value="Phone Number"></asp:TextBox>
                                </p>
                            </td>
                            <td>
                                <p>
                                    <span class="fontawesome-map-marker"></span>
                                    <asp:TextBox ID="PersonAddress" runat="server" value="Address"></asp:TextBox>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    <span class="fontawesome-envelope"></span>
                                    <asp:TextBox ID="Email" runat="server" value="Email"></asp:TextBox>
                                </p>
                            </td>
                            </tr>
                        <tr>
                            <td>
                                <p>
                                    <asp:Button ID="btnSignUp" runat="server" OnClick="Button1_Click" Text="Sign Up" />
&nbsp;</p>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </form>
            <p><a href="Permaculture_Login.aspx" class="blue">Click here to login</a><span class="fontawesome-arrow-right"></span></p>
        </div>
    </div>
    <div class="bottom">  <h3>Permaculture Registration</h3></div>
</body>
</html>
