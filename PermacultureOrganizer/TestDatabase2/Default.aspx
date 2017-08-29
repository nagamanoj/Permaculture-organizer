<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="z-index: 1; left: 10px; top: 15px; position: absolute; right: 793px">
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="cubeTextBox" runat="server" style="z-index: 1; left: 161px; top: 15px; position: absolute"></asp:TextBox>
    
    </div>
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 118px; top: 15px; position: absolute" Text="Cube: "></asp:Label>
        <asp:LinkButton ID="databaseTestLinkButton" runat="server" style="z-index: 1; left: 10px; top: 80px; position: absolute; height: 23px; width: 207px" PostBackUrl="DatabaseConnectionTest.aspx">Database Connection Test Page</asp:LinkButton>
    </form>
</body>
</html>
