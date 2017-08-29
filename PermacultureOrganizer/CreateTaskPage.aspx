
<%@ Page Title="" Language="C#" MasterPageFile="~/Permaculture.Master" AutoEventWireup="true" CodeBehind="CreateTaskPage.aspx.cs" Inherits="PermacultureOrganizer.CreateTaskPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">



<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <style type="text/css">
        #TextArea1 {
            z-index: 1;
            left: 203px;
            top: 200px;
            position: absolute;
        }
        #tataskdescID {
            z-index: 1;
            left: 242px;
            top: 193px;
            position: relative;
            height: 41px;
            width: 225px;
        }
        #tbtaskdescID {
            z-index: 1;
            left: 245px;
            top: 203px;
            position: absolute;
        }
    </style>
</head>

<body>
    <form id="form1" >
        
    <div >
    
        <asp:Label ID="createtasktitleID" runat="server" style="z-index: 1; left: 287px; top: 172px; position: absolute; font-weight: 700; text-decoration: underline; font-size: x-large; font-family: Arial;" Text="Create New Task" ForeColor="#990000"></asp:Label>
        <asp:Label ID="Label2" runat="server" style="z-index: 1;  position: absolute; top: 376px; left: 1204px;" BorderColor="Red" ForeColor="Red"></asp:Label>
        <asp:Label ID="lbltasknameID" runat="server" style="z-index: 1; left: 323px; top: 241px; position: absolute" Text="Task Name"></asp:Label>
        <asp:Label ID="lbltaskdescID" runat="server" style="z-index: 1; left: 316px; top: 344px; position: absolute; margin-top: 0px;" Text="Task Description"></asp:Label>
        <asp:Label ID="lblduedateId" runat="server" style="z-index: 1; left: 944px; top: 195px; position: absolute" Text="Due Date"></asp:Label>
        <asp:Label ID="lblstarttimeID" runat="server" style="z-index: 1; left: 324px; top: 640px; position: absolute" Text="Time Slot"></asp:Label>
        <asp:Label ID="lblcategoryID" runat="server" style="z-index: 1; left: 328px; top: 587px; position: absolute" Text="Category"></asp:Label>
        <asp:Label ID="lblfrequencyID" runat="server" style="z-index: 1; left: 325px; top: 523px; position: absolute" Text="Frequency"></asp:Label>
        <asp:Label ID="lblstatusID" runat="server" style="z-index: 1; left: 337px; top: 455px; position: absolute" Text="Status"></asp:Label>
        <asp:TextBox  ID="tbtasknameID"  runat="server" style="z-index: 1; left: 570px; top: 238px; position: absolute; height: 36px; width: 189px; "></asp:TextBox>
        <asp:RequiredFieldValidator 
             id="RequiredFieldValidator1" runat="server" 
            style="z-index: 1; left: 780px; top: 238px; position: absolute; height: 36px; width: 200px; color:red"
             ErrorMessage="Required!" 
             ControlToValidate="tbtasknameID" ValidateRequestMode="Enabled" ></asp:RequiredFieldValidator>
        <asp:DropDownList ID="ddstatusID" runat="server" DataSourceID="SqlDataSource1" DataTextField="StatusName" DataValueField="StatusID" style="z-index: 1; left: 568px; top: 459px; position: absolute">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT [StatusName], [StatusID] FROM [tblStatus]"></asp:SqlDataSource>
        <asp:DropDownList ID="ddfrequencyID" runat="server" DataSourceID="SqlDataSource2" DataTextField="FrequencyName" DataValueField="FrequencyID" style="z-index: 1; left: 569px; top: 526px; position: absolute">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT [FrequencyName], [FrequencyID] FROM [tblFrequency]"></asp:SqlDataSource>
        <asp:DropDownList ID="ddcategoryID" runat="server" DataSourceID="SqlDataSource3" DataTextField="CategoryName" DataValueField="CategoryID" style="z-index: 1; left: 571px; top: 590px; position: absolute">
        </asp:DropDownList>
        <asp:DropDownList ID="ddtimeslotID" runat="server" DataSourceID="SqlDataSource4" DataTextField="TimeslotName" DataValueField="TimeslotID" style="z-index: 1; left: 571px; top: 642px; position: absolute">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT * FROM [tblTimeslot]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT [CategoryID], [CategoryName] FROM [tblCategory]"></asp:SqlDataSource>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/CalendarImage.PNG" OnClick="ImageButton1_Click" style="z-index: 1; left: 1163px; top: 234px; position: absolute; height: 30px; width: 42px" />
        <asp:TextBox ID="tbduedatedisplayID" runat="server" style="z-index: 1; left: 942px; top: 234px; position: absolute"></asp:TextBox>
        <asp:Button ID="btncreate" runat="server" style="z-index: 1; left: 1022px; top: 675px; position: absolute; height: 35px; width: 93px; background-color: #FFFFFF;" Text="Create" OnClick="btncreate_Click" BackColor="#993300" ForeColor="Black" />
        <asp:TextBox ID="tbtaskdescID" runat="server" style="z-index: 1; left: 563px; top: 328px; position: absolute" TextMode="MultiLine" ValidateRequestMode="Enabled"></asp:TextBox>
        <asp:RequiredFieldValidator 
             id="RequiredFieldValidator4" runat="server" 
            style="z-index: 1; left: 780px; top: 328px; position: absolute; height: 36px; width: 200px; color:red"
             ErrorMessage="Required!" 
             ControlToValidate="tbtaskdescID" >
            </asp:RequiredFieldValidator>
        <asp:Calendar ID="duedatecalenderID" runat="server" style="z-index: 1; left: 942px; top: 273px; position: absolute; height: 165px; width: 244px" VisibleDate="2016-03-21" OnSelectionChanged="duedatecalenderID_SelectionChanged" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px" >
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
    
    </div>
    </form>
    
</body>
      
    
</html>
</asp:Content>
  

  