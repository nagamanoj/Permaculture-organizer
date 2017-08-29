<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DatabaseConnectionTest.aspx.cs" Inherits="DatabaseConnectionTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Testing Database Connection"></asp:Label>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PersonID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="PersonID" HeaderText="PersonID" InsertVisible="False" ReadOnly="True" SortExpression="PersonID" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="Pswd" HeaderText="Pswd" SortExpression="Pswd" />
                <asp:BoundField DataField="Telephone" HeaderText="Telephone" SortExpression="Telephone" />
                <asp:BoundField DataField="PersonAddress" HeaderText="PersonAddress" SortExpression="PersonAddress" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="LinkButton1" runat="server" style="z-index: 1; left: 12px; top: 230px; position: absolute; width: 309px" PostBackUrl="Default.aspx">Home Page</asp:LinkButton>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PermacultureConnectionString %>" SelectCommand="SELECT * FROM [tblPerson] ORDER BY [LastName], [FirstName]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
