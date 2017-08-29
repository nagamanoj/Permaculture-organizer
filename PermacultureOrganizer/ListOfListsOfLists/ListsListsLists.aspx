<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListsListsLists.aspx.cs" Inherits="ListsListsLists"  MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            width: 857px;
        }
    </style>    
</head>
<body style="width: 856px">
    <form id="form1" runat="server" aria-atomic="False">
    <div style="width: 856px">        
        <asp:ListBox ID="foodGroupListBox" runat="server" style="z-index: 1; left: 13px; top: 72px; position: absolute; height: 188px; bottom: 266px;" Width="248px" AutoPostBack="True" OnSelectedIndexChanged="foodGroupListBox_SelectedIndexChanged"></asp:ListBox>
        <asp:ListBox ID="foodSourceListBox" runat="server" height="188px" style="top: 72px; left: 311px; position: absolute" width="248px" AutoPostBack="True" OnSelectedIndexChanged="foodSourceListBox_SelectedIndexChanged"></asp:ListBox>
        <asp:ListBox ID="dishListBox" runat="server" height="188px" style="z-index: 1; left: 611px; top: 72px; position: absolute" width="248px" AutoPostBack="True" OnSelectedIndexChanged="dishListBox_SelectedIndexChanged"></asp:ListBox>
    
        <asp:Label ID="foodGroupLabel" runat="server" style="z-index: 1; left: 14px; top: 45px; position: absolute; right: 665px;" Text="Food Groups" width="248px"></asp:Label>
        <asp:Label ID="dishLabel" runat="server" style="z-index: 1; left: 611px; top: 45px; position: absolute; width: 248px" Text="Dish"></asp:Label>
        <asp:Label ID="foodSourceLabel" runat="server" style="z-index: 1; left: 311px; top: 45px; position: absolute; right: 437px" Text="Living Food Source" width="248px"></asp:Label>
        <asp:Image ID="dishImage" runat="server" height="188px" style="z-index: 1; left: 611px; top: 283px; position: absolute" width="248px" />
        <asp:Image ID="foodGroupImage" runat="server" height="188px" style="z-index: 1; left: 13px; top: 283px; position: absolute; right: 666px;" width="248px" />
        <asp:Image ID="foodSourceImage" runat="server" height="188px" style="z-index: 1; left: 311px; top: 283px; position: absolute" width="248px" />
        <asp:TextBox ID="foodGroupTextBox" runat="server" style="z-index: 1; left: 13px; top: 493px; position: absolute; height: 129px; width: 243px" TextMode="MultiLine"></asp:TextBox>
        <asp:TextBox ID="foodSourceTextBox" runat="server" height="129px" style="z-index: 1; left: 311px; top: 493px; position: absolute; width: 241px;" TextMode="MultiLine"></asp:TextBox>
        <asp:Label ID="listWithinListsLabel" runat="server" height="19px" style="z-index: 1; left: 14px; top: 13px; position: absolute" Text="Lists within lists:" width="248px"></asp:Label>     
        <asp:TextBox ID="dishTextBox" runat="server" height="129px" style="z-index: 1; left: 611px; top: 493px; position: absolute" TextMode="MultiLine" width="241px"></asp:TextBox>
        <asp:Label ID="listOfListsLabel" runat="server" style="z-index: 1; left: 13px; top: 650px; position: absolute" Text="List of lists:" width="248px"></asp:Label>
        <asp:Label ID="foodGroupClassificationLabel" runat="server" height="19px" style="z-index: 1; left: 13px; top: 679px; position: absolute" Text="Food Group Classifications" width="248px"></asp:Label>
        <asp:DropDownList ID="foodGroupClassificationDropDownList" runat="server" style="z-index: 1; left: 13px; top: 709px; position: absolute; height: 30px; width: 242px" AutoPostBack="True" OnSelectedIndexChanged="foodGroupClassificationDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="foodGroupsByClassificationListLabel" runat="server" height="19px" style="z-index: 1; left: 311px; top: 650px; position: absolute" Text="Food Groups By Classification" width="248px"></asp:Label>
        <asp:Image ID="foodGroupInClassificationImage" runat="server" height="188px" style="z-index: 1; left: 611px; top: 679px; position: absolute" width="248px" />
        <asp:ListBox ID="foodGroupListListBox" runat="server" height="188px" style="z-index: 1; left: 311px; top: 679px; position: absolute" width="248px" AutoPostBack="True" OnSelectedIndexChanged="foodGroupListListBox_SelectedIndexChanged"></asp:ListBox>
    </div>
    </form>
</body>
</html>
