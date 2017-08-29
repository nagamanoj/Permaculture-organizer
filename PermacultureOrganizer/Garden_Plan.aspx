<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Garden_Plan.aspx.cs" 
    Inherits="Permaculture_Garden_Planning.Webpages.Garden_Plan" MasterPageFile="Permaculture.Master" %>


    <asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server"> 
    
    <div style=" width: 1291px; height: 510px; margin-left:200px; z-index: 1; left: 368px; top: 151px; position: absolute;">
    <h3>
        Garden Plan
    </h3>
        </br>

        
        <asp:Label ID="Label3" runat="server" Text="Months"></asp:Label>
        &nbsp;<asp:DropDownList ID="ddlMonths" runat="server" AutoPostBack ="true"
            DataTextField ="month" DataValueField="planting_month_id" Height="28px" OnSelectedIndexChanged="ddlMonths_SelectedIndexChanged" Width="185px">
        </asp:DropDownList>
        </br>
        </br>

        
&nbsp;</br>
        <asp:Label ID="Label2" runat="server" Text="Garden"></asp:Label>
        <asp:DropDownList ID="ddlGardens" runat="server" 
            DataTextField ="name" DataValueField="garden_id" Height="29px" Width="199px">
        </asp:DropDownList>
        </br>
        </br>

        
        <asp:Label ID="Label1" runat="server" Text="Vegetables"></asp:Label>
        
        <asp:DropDownList ID="ddlVegetables" runat="server" Height="26px" Width="218px"
            DataTextField ="name" DataValueField="vegetable_id">
        </asp:DropDownList>
        </br>
        </br>
        
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"  />
        </div>
    
    </asp:Content>
