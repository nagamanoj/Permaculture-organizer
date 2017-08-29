<%@ Page Language="C#" MasterPageFile="~/Permaculture.Master" AutoEventWireup="true" CodeBehind="MyTasks.aspx.cs" Inherits="PermacultureOrganizer.MyTasks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>

    <style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 10pt;
    }
    .GridPager a, .GridPager span
    {
        display: block;
        height: 18px;
        width: 15px;
        font-weight: bold;
        text-align: center;
        text-decoration: none;
    }
    .GridPager a
    {
        background-color: #F7DFB5;
        color: #A55129;
            }
    .GridPager span
    {
        background-color: #F7DFB5;
        color: #A55129;
        border: 1px solid #A55129;
    }
</style>


<body>
    <form id="form1" >
    <div>
    
        
    
    </div>
        <asp:Label ID="lblselectcategoryID" runat="server" Text="Select Category" style="z-index: 1; left: 636px; top: 184px; position: absolute"></asp:Label>
        <asp:Label ID="lblselectstatuID" runat="server" Text="Select Status" style="z-index: 1; left: 636px; top: 184px; position: absolute"></asp:Label>
        <asp:Button ID="Button2" runat="server" Text="Search" style="z-index: 1; left: 1122px; top: 206px; position: absolute" OnClick="Button2_Click" />
        <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; left: 935px; top: 207px; position: absolute" ></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Search By Task Name" style="z-index: 1; left: 937px; top: 184px; position: absolute" Font-Italic="True" Font-Size="Smaller" Font-Underline="True" ForeColor="#006600" ></asp:Label>
        <asp:GridView ID="gvtasksID" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="SqlDataSource1" style="z-index: 1; left: 365px; top: 285px; position: absolute; height: 363px; width: 869px" AllowSorting="True">
            <Columns>
                <asp:TemplateField ShowHeader="False" HeaderText="TaskID">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" OnClick="linkButton1_Click" runat="server" CausesValidation="false" CommandName="" Text='<%#Eval("TaskID") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TaskName" SortExpression="TaskName">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("TaskName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TaskDueDate" HeaderText="TaskDueDate" SortExpression="TaskDueDate" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="TaskDescription" HeaderText="TaskDescription" SortExpression="TaskDescription" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" CssClass = "GridPager" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
            
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT [TaskName], [TaskDueDate], [TaskID], [TaskDescription] FROM [tblTask]" DeleteCommand="DELETE FROM [tblTask] WHERE [TaskID] = @TaskID" InsertCommand="INSERT INTO [tblTask] ([TaskName], [TaskDueDate], [TaskDescription]) VALUES (@TaskName, @TaskDueDate, @TaskDescription)" UpdateCommand="UPDATE [tblTask] SET [TaskName] = @TaskName, [TaskDueDate] = @TaskDueDate, [TaskDescription] = @TaskDescription WHERE [TaskID] = @TaskID">
            <DeleteParameters>
                <asp:Parameter Name="TaskID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="TaskName" Type="String" />
                <asp:Parameter DbType="Date" Name="TaskDueDate" />
                <asp:Parameter Name="TaskDescription" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="TaskName" Type="String" />
                <asp:Parameter DbType="Date" Name="TaskDueDate" />
                <asp:Parameter Name="TaskDescription" Type="String" />
                <asp:Parameter Name="TaskID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
         <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" AutoGenerateColumns="False" style="z-index: 1; left: 366px; top: 284px; position: absolute; height: 363px; width: 869px; right: 107px;" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" >
             <Columns>


        
                 <asp:TemplateField ShowHeader="False" HeaderText="TaskID" >
                     <ItemTemplate>
                         <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="" Text='<%# Eval("TaskID") %>'></asp:LinkButton>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="TaskName" HeaderText="TaskName" />
                 <asp:BoundField DataField="TaskDueDate" HeaderText="TaskDueDate" DataFormatString="{0:MM/dd/yyyy}" />
                 <asp:BoundField DataField="StatusName" HeaderText="Status" />
                 <asp:BoundField DataField="CategoryName" HeaderText="Category" />
             </Columns>
             <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
             <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
             <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" CssClass = "GridPager" />
             <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
             <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#FFF1D4" />
             <SortedAscendingHeaderStyle BackColor="#B95C30" />
             <SortedDescendingCellStyle BackColor="#F1E5CE" />
             <SortedDescendingHeaderStyle BackColor="#93451F" />
             </asp:GridView>
              <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT [TaskID], [TaskName], [TaskDescription], [TaskDueDate] FROM [tblTask] WHERE ([StatusID] = @StatusID)">
                  <SelectParameters>
                      <asp:FormParameter FormField="ddstatusID" Name="StatusID" Type="Int32" />
                  </SelectParameters>
        </asp:SqlDataSource>
              <asp:Label ID="lbltasksID" runat="server" style="z-index: 1; left: 370px; top: 173px; position: absolute; font-size: large; font-family: Arial; height: 26px;" Text="Tasks"></asp:Label>
        
    <asp:DropDownList ID="ddstatusID" runat="server" DataSourceID="SqlDataSource2" DataTextField="StatusName" DataValueField="StatusID" AutoPostBack="true" OnSelectedIndexChanged="ddstatusID_SelectedIndexChanged" style="z-index: 1; left: 638px; top: 218px; position: absolute"></asp:DropDownList>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT * FROM [tblStatus]"></asp:SqlDataSource>

        <asp:DropDownList ID="ddcategoryID" runat="server" DataSourceID="SqlDataSource5" DataTextField="CategoryName" DataValueField="CategoryID" AutoPostBack="True" OnSelectedIndexChanged="ddcategoryID_SelectedIndexChanged" style="z-index: 1; left: 637px; top: 218px; position: absolute"></asp:DropDownList>

        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT [CategoryID], [CategoryName] FROM [tblCategory]"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT [CategoryID], [CategoryName] FROM [tblCategory]"></asp:SqlDataSource>

        <asp:DropDownList ID="ddSortID" runat="server" DataSourceID="SqlDataSource6" DataTextField="SortName" DataValueField="SortID" AutoPostBack="True" OnSelectedIndexChanged="ddSortID_SelectedIndexChanged" style="z-index: 1; left: 475px; top: 221px; position: absolute"></asp:DropDownList>
  
              <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT * FROM [tblSort]"></asp:SqlDataSource>
        <asp:Label ID="lblsearchID" runat="server" Text="Search By" BackColor="#993300" BorderStyle="Double" ForeColor="White" style="z-index: 1; left: 373px; top: 218px; position: absolute" BorderColor="#993300"></asp:Label>
              <asp:Button ID="Button1" runat="server" style="z-index: 1; left: 694px; top: 678px; position: absolute; width: 182px; height: 32px;" Text="Add a New Task" BackColor="#993300" ForeColor="White" OnClick="Button1_Click" />
    </form>
    
</body>
</html>
</asp:Content>
