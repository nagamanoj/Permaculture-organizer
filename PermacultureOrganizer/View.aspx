<%@ Page Language="C#" MasterPageFile="~/Permaculture.Master" AutoEventWireup="true"  CodeBehind="View.aspx.cs" Inherits="PermacultureOrganizer.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
    <title></title>

     
    <style>
     
        .auto-style4 {
            z-index: 1;
            left: 692px;
            top: 226px;
            position: absolute;
            height: 337px;
            width: 444px;
            border-style: solid;
            border-width: 1px;
        }
        .auto-style5 {
            width: 213px;
        }
        .auto-style6 {
            width: 186px;
        }
     
    </style>

</head>

<body>


    <form id="form1">
    <div>
    
    </div>
        
<p id="rcorners2"></p>
        <asp:Label ID="lbltaskID"  runat ="server" style="z-index: 1; left: 513px; top: 245px; position: absolute; display: none; " Text="TaskID"></asp:Label>
        <asp:Button ID="btnupdate" runat="server" OnClick="btnupdate_Click" style="z-index: 1; left: 859px; top: 633px; position: absolute" Text="Update" />
        <asp:Button ID="btndeleteID" runat="server" style="z-index: 1;  position: absolute; top: 629px; left: 997px;" Text="Delete" OnClientClick = "return confirm('Are you sure you want to Delete?');" OnClick="btndeleteID_Click"/>
        <asp:Label ID="Label17" runat="server" Text="Label" Visible="False" ></asp:Label>
        

        <table align="center" border="1" class="auto-style4" style="border: thin double #800000; background-color: #FFFFFF; color: #000000">
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label1" runat="server" Text="Task Name"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label9" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label2" runat="server" Text="Task Description"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label10" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label3" runat="server" Text="Status"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label11" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label4" runat="server" Text="Frequency"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label12" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label5" runat="server" Text="Category"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label13" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label6" runat="server" Text="Due Date"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label14" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    Time Slot</td>
                <td class="auto-style5">
                    <asp:Label ID="Label15" runat="server"></asp:Label>
                </td>
            </tr>
            </table>

        

    </form>
    
</body>
</html>
</asp:Content>
    