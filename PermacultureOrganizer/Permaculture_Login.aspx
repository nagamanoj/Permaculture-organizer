<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Permaculture_Login.aspx.cs" Inherits="Permaculture_Garden_Planning.Webpages.Permaculture_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Permaculture</title>
    <link rel="stylesheet" href="css/style-login.css">
</head>
<body>
    
    
 <div class="container">


      <div id="login">

        <form id="form1" runat="server">
            
          <fieldset class="clearfix">

            <p><span class="fontawesome-user"></span>
            <asp:TextBox ID="UserName" runat="server" value="User Name"></asp:TextBox>
            </p> <!-- JS because of IE support; better: placeholder="Username" -->
            <p><span class="fontawesome-lock"></span>
            <asp:TextBox ID="Password" runat="server" value="Password"></asp:TextBox>
            <p>
     <asp:Button ID="btnLogin" runat="server" Text="SignIn" OnClick="Button1_Click" /></p>

          </fieldset>

        </form>

        <p>Not a member? <a href="Permaculture_SignUp.aspx" class="blue">Sign up now</a><span class="fontawesome-arrow-right"></span></p>

      </div> <!-- end login -->

    </div>
    <div class="bottom">  <h3>Permaculture</h3></div>
    
    
    
    
    
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    
    
    
    
    
</body>
</html>
