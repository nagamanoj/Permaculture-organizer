<%@ Page Language="C#" MasterPageFile="~/Permaculture.Master" AutoEventWireup="true" CodeBehind="UpdateTaskPage.aspx.cs" Inherits="PermacultureOrganizer.UpdateTaskPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    <form id="form1" >
    <div >
        <asp:ImageButton ID="ImageButton1" runat="server" style="z-index: 1;  position: absolute; top: 234px; left: 1066px; height: 28px; width: 33px;" ImageUrl="~/Images/CalendarImage.PNG" OnClick="ImageButton1_Click"/>
        <asp:TextBox ID="tbduedatedisplayID" runat="server" style="z-index: 1;  position: absolute; top: 235px; left: 890px;"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" style="z-index: 1;  position: absolute; top: 341px; left: 1197px;" BorderColor="Red" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblcategory1ID" runat="server" style="z-index: 1; left: 489px; top: 548px; position: absolute" Text="Category"></asp:Label>
        <asp:Label ID="lblfrequency1ID" runat="server" style="z-index: 1; left: 487px; top: 493px; position: absolute" Text="Frequency"></asp:Label>
        <asp:Label ID="lblstatus1ID" runat="server" style="z-index: 1; left: 488px; top: 442px; position: absolute" Text="Status"></asp:Label>
        <asp:Label ID="lblstarttime1ID" runat="server" style="z-index: 1; left: 488px; top: 595px; position: absolute" Text="Time Slot"></asp:Label>
        <asp:Label ID="lblduedate1ID" runat="server" style="z-index: 1; left: 899px; top: 215px; position: absolute" Text="Due Date"></asp:Label>
        <asp:DropDownList ID="ddstatus1ID" runat="server" style="z-index: 1; left: 635px; top: 440px; position: absolute" DataSourceID="SqlDataSource1" DataTextField="StatusName" DataValueField="StatusID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT [StatusID], [StatusName] FROM [tblStatus]"></asp:SqlDataSource>
        <asp:DropDownList ID="ddfrequency1ID" runat="server" style="z-index: 1; left: 634px; top: 492px; position: absolute" DataSourceID="SqlDataSource2" DataTextField="FrequencyName" DataValueField="FrequencyID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT [FrequencyID], [FrequencyName] FROM [tblFrequency]"></asp:SqlDataSource>
        <asp:DropDownList ID="ddcategory1ID" runat="server" style="z-index: 1; left: 636px; top: 548px; position: absolute" DataSourceID="SqlDataSource3" DataTextField="CategoryName" DataValueField="CategoryID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT [CategoryID], [CategoryName] FROM [tblCategory]"></asp:SqlDataSource>
        <asp:DropDownList ID="ddtimeslot1ID" runat="server" style="z-index: 1; left: 635px; top: 595px; position: absolute" DataSourceID="SqlDataSource4" DataTextField="TimeslotName" DataValueField="TimeslotID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT * FROM [tblTimeslot]"></asp:SqlDataSource>
        <asp:Calendar ID="duedatecalender1ID" runat="server" style="z-index: 1; left: 887px; top: 263px; position: absolute; height: 213px; width: 309px" OnSelectionChanged="duedatecalender1ID_SelectionChanged" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
        <asp:TextBox ID="tbtaskdesc1ID" runat="server" style="z-index: 1; left: 632px; top: 346px; position: absolute" TextMode="MultiLine"></asp:TextBox>
        <asp:TextBox ID="tbtaskname1ID" runat="server" style="z-index: 1; left: 631px; top: 267px; position: absolute"></asp:TextBox>
        <asp:Label ID="lbltaskname1ID" runat="server" style="z-index: 1; left: 473px; top: 267px; position: absolute" Text="Task Name"></asp:Label>
        <asp:Label ID="lbltaskdesc1ID" runat="server" style="z-index: 1; left: 470px; top: 357px; position: absolute" Text="Task Description"></asp:Label>
        <asp:Label ID="Label9" runat="server" style="z-index: 1; left: 365px; top: 196px; position: absolute; font-size: large; font-weight: 700; font-family: Arial; text-decoration: underline;" Text="Update Task" ForeColor="#993300"></asp:Label>
        <asp:Button ID="btnupdateID" runat="server" style="z-index: 1; left: 917px; top: 664px; position: absolute; width: 73px; height: 30px;" Text="Done" OnClick="btnupdateID_Click" BackColor="#993300" ForeColor="White" />
    
    </div>
    </form>
</body>
</html>
</asp:Content>
