<%@ Page Language="C#" MasterPageFile="~/Permaculture.Master" AutoEventWireup="true" CodeBehind="TaskFilterPage.aspx.cs" Inherits="PermacultureOrganizer.TaskFilterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>




    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/themes/base/jquery-ui.css" type="text/css" media="all" />
			<link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />
			<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
			<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/jquery-ui.min.js" type="text/javascript"></script>


    <script type="text/javascript">
        $(function () {

            //alert("text");
            
            $("#<%= tbselecteddatedisplayID.ClientID  %>").datepicker({
                changeMonth: true,
                changeYear: true,
                showButtonPanel: false,
                dateFormat: 'yy-mm-dd',
                
            });

            $("#<%= tbmonthID.ClientID  %>").datepicker({
                changeMonth: true,
                changeYear: true,
                showButtonPanel: false,
                dateFormat: 'mm-yy',
                onClose: function (dateText, inst) {
                    $(this).datepicker('setDate', new Date(inst.selectedYear, inst.selectedMonth, 1));
                }
            });



            $("#<%= startdateID.ClientID  %>").datepicker({
                changeMonth: true,
                changeYear: true,
                showButtonPanel: false,
                dateFormat: 'yy-mm-dd',

            });


            $("#<%= enddateID.ClientID  %>").datepicker({
                changeMonth: true,
                changeYear: true,
                showButtonPanel: false,
                dateFormat: 'yy-mm-dd',

            });

        });
    </script>

 








</head>
<body>
    <form id="form1" >
    <div>
    
    </div>



        

        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 1135px; top: 267px; position: absolute" Text="Selected Date"></asp:Label>
        <asp:TextBox ID="tbselecteddatedisplayID" runat="server" style="z-index: 1; left: 1135px; top: 312px; position: absolute"></asp:TextBox>
        
        
        <asp:Label ID="lblerrmsgID" runat="server" Text=""></asp:Label>
        <asp:GridView ID="GridView2" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" style="height: 180px; width: 376px; z-index: 1; left: 432px; top: 291px; position: absolute" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="TaskName" HeaderText="TaskName" />
                <asp:BoundField DataField="TaskDueDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="TaskDueDate" />
                <asp:BoundField DataField="StatusName" HeaderText="Status" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="z-index: 1; left: 1145px; top: 518px; position: absolute" Text="Save" BackColor="#993300" BorderStyle="Solid" ForeColor="White" />
        <asp:Button ID="dayreportID" runat="server" OnClick="dayreportID_Click" style="z-index: 1; left: 418px; top: 188px; position: absolute" Text="Day Report" BackColor="#993300" BorderStyle="Solid" ForeColor="White" />
        <asp:Button ID="btncustomdatereportID" runat="server" style="z-index: 1; left: 919px; top: 191px; position: absolute" Text="Custom Date Report" OnClick="btncustomdatereportID_Click" BackColor="#993300" BorderStyle="Solid" ForeColor="White" />
        <asp:Button ID="btnmonthreportID" runat="server" OnClick="btnmonthreportID_Click" style="z-index: 1; left: 638px; top: 190px; position: absolute" Text="Monthly Report" BackColor="#993300" BorderStyle="Solid" ForeColor="White" />
        <asp:Button ID="btngenerateID" runat="server" OnClick="btngenerateID_Click" style="z-index: 1; left: 1237px; top: 517px; position: absolute" Text="Get Report" BackColor="#993300" BorderStyle="Solid" ForeColor="White" />
        <asp:TextBox ID="tbmonthID" runat="server" style="z-index: 1; left: 1136px; top: 312px; position: absolute"></asp:TextBox>
        
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PermaCultureConnection %>" SelectCommand="SELECT * FROM [tblStatus]"></asp:SqlDataSource>
        
         <asp:Label ID="monthlabelID" runat="server" style="z-index: 1; left: 1117px; top: 266px; position: absolute" Text="Select Month/Year"></asp:Label>
        <asp:Button ID="btnmonthlygenerateID" runat="server" style="z-index: 1; left: 1241px; top: 519px; position: absolute" Text="Get Report" OnClick="btnmonthlygenerateID_Click" BackColor="#993300" BorderStyle="Solid" ForeColor="White" />
        <asp:TextBox ID="enddateID" runat="server" style="z-index: 1; left: 1135px; top: 388px; position: absolute"></asp:TextBox>
       
        
         <asp:TextBox ID="startdateID" runat="server" style="z-index: 1; left: 1137px; top: 313px; position: absolute"></asp:TextBox>
        
            <asp:Label ID="todatelabelID" runat="server" style="z-index: 1; left: 1125px; top: 355px; position: absolute" Text="Selected Date to"></asp:Label>
        <asp:Label ID="fromdatelabelID" runat="server" style="z-index: 1; left: 1116px; top: 265px; position: absolute" Text="Selected Date from"></asp:Label>
        <asp:Button ID="btncustomreportID" runat="server" style="z-index: 1; left: 1255px; top: 520px; position: absolute" Text="Get Report" OnClick="btncustomreportID_Click" BackColor="#993300" BorderStyle="Solid" ForeColor="White" />
    </form>
</body>
</html>
</asp:Content>
