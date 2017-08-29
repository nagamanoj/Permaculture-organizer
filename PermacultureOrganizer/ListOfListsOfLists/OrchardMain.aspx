<%@ Page Title="" Language="C#" MasterPageFile="~/Permaculture.Master" AutoEventWireup="true" CodeBehind="OrchardMain.aspx.cs" Inherits="PermacultureOrganizer.Account.OrchardMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div >
       <asp:Label ID="lblOrchardMain" runat="server" Text="Orchard Main Page" Font-Bold="True" Font-Names="Calibri" Font-Size="XX-Large"></asp:Label><br /><br />
    </div>
    <div>
        <asp:DropDownList ID="ddlOrchardType" runat="server" AutoPostBack ="True" DataTextField="OrchardTypeName" DataValueField="OrchardTypeID" OnSelectedIndexChanged="ddlOrchardType_SelectedIndexChanged">
        </asp:DropDownList>
    </div><br />
    <div>
        <asp:DropDownList ID="ddlSpecies" runat="server" AutoPostBack ="True" DataTextField="Species" DataValueField="OrchardItemID" OnSelectedIndexChanged="ddlSpecies_SelectedIndexChanged">
        </asp:DropDownList>
    </div><br />
    <div>
        <asp:DropDownList ID="ddlVariety" runat="server" AutoPostBack="true" DataTextField="Variety" DataValueField="OrchardItemID" OnSelectedIndexChanged="ddlVariety_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <br />
    <br />
    <asp:Label ID="lblAge" runat="server" Text="Please enter the AGE of the plant: "></asp:Label>
&nbsp;<asp:TextBox ID="txtBoxAge" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblYields" runat="server" Text="Please enter what the plant YIELDS:"></asp:Label>
&nbsp;<asp:TextBox ID="txtBoxYields" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblPlantedDate" runat="server" Text="Please enter the PLANTED DATE:"></asp:Label>
&nbsp;<asp:TextBox ID="txtBoxPlantedDate" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblPlantedFrom" runat="server" Text="Please enter what container the plant came from:"></asp:Label>
&nbsp;<asp:TextBox ID="txtBoxPlantedFrom" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnOrchardSubmit" runat="server" OnClick="btnOrchardSubmit_Click" Text="Submit" />
    <br />
    <asp:Label ID="lblSubmit" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnViewData" runat="server" OnClick="btnViewData_Click" Text="View Data" />
    <asp:GridView ID="grdOrchardView" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="OTypeName" HeaderText="OTypeName" SortExpression="OTypeName" />
            <asp:BoundField DataField="OSpecies" HeaderText="OSpecies" SortExpression="OSpecies" />
            <asp:BoundField DataField="OVariety" HeaderText="OVariety" SortExpression="OVariety" />
            <asp:BoundField DataField="OAge" HeaderText="OAge" SortExpression="OAge" />
            <asp:BoundField DataField="OYields" HeaderText="OYields" SortExpression="OYields" />
            <asp:BoundField DataField="OPlantDate" HeaderText="OPlantDate" SortExpression="OPlantDate" />
            <asp:BoundField DataField="OPlantFrom" HeaderText="OPlantFrom" SortExpression="OPlantFrom" />
            <asp:BoundField DataField="OTreeSpacing" HeaderText="OTreeSpacing" SortExpression="OTreeSpacing" />
            <asp:BoundField DataField="OFertilizingTimes" HeaderText="OFertilizingTimes" SortExpression="OFertilizingTimes" />
            <asp:BoundField DataField="OPruningTimes" HeaderText="OPruningTimes" SortExpression="OPruningTimes" />
            <asp:BoundField DataField="OWateringNeeds" HeaderText="OWateringNeeds" SortExpression="OWateringNeeds" />
            <asp:BoundField DataField="OPollination" HeaderText="OPollination" SortExpression="OPollination" />
            <asp:BoundField DataField="OFertilizer" HeaderText="OFertilizer" SortExpression="OFertilizer" />
            <asp:BoundField DataField="OPesticide" HeaderText="OPesticide" SortExpression="OPesticide" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_9DE518_PermacultureConnectionString2 %>" SelectCommand="SELECT [OTypeName], [OSpecies], [OVariety], [OAge], [OYields], [OPlantDate], [OPlantFrom], [OTreeSpacing], [OFertilizingTimes], [OPruningTimes], [OWateringNeeds], [OPollination], [OFertilizer], [OPesticide] FROM [tblUserOrchard]"></asp:SqlDataSource>
    <br />
</asp:Content>
