<%@ Page Title="" Language="C#" MasterPageFile="~/Permaculture.Master" AutoEventWireup="true" CodeBehind="IndividualAnimal.aspx.cs" Inherits="PermacultureOrganizer.Animals.IndividualAnimal" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
    <table style="width:100%;background-color:yellow; height:inherit;">
        <tr style="background-color:#57360D;height:50px">
            <td colspan="4">
                    <h1 style="color:#fff;text-align:center;height:100%">
                        <asp:Label runat="server" ID="IndividualAnimalName"></asp:Label>
                    </h1>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel runat="server" ID="IndividualAnimalUpdatePanel">
                    <ContentTemplate>
                        <fieldset>
                            <asp:HiddenField runat="server" ID="IndividualAnimalID" />
                            <table>
                                <tr>
                                    <td>
                                        
                                        <button type="button" class="btn btn-info" data-toggle="modal" data-target="#UpdateIndividualAnimalModal">Update Animal</button>
                                    </td>
                                </tr>
                                <%-- added by Ocllo--%>
                                <tr>
                                    <td colspan="2" style="padding-left:10px;padding-top:30px;">
                                        <asp:RadioButtonList ID="rbAdditionalData" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbAdditionalData_SelectedIndexChanged">
                                            <asp:ListItem Selected="True" Value="Note">Notes</asp:ListItem>
                                            <asp:ListItem Value="Event">Events</asp:ListItem>
                                            <asp:ListItem Value="Web">Web Resources</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:ListBox ID="lbAdditionalData" runat="server" style="width:inherit;min-width:250px"></asp:ListBox>
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="Delete" OnClick="DeleteAnimal" Text="Delete" />
                                    </td>
                                </tr>
                            </table>

                            <div id="UpdateIndividualAnimalModal" class="modal fade" role="dialog">
                                <div class="modal-dialog">

                                    <!-- Modal content-->
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h4 class="modal-title">Add Livestock</h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:HiddenField runat="server" ID="hfIndividualAnimalID" />
                                            <asp:Label runat="server" ID="lblIndividualAnimalName" Text="Name: "></asp:Label>
                                            <asp:TextBox runat="server" ID="txtIndividualAnimalName"></asp:TextBox>
                                            <p></p>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button runat="server" ID="IndividualAnimalUpdate" OnClick="IndividualAnimalUpdate_Click" Class="btn btn-default" Text="Save" />
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

</asp:Content>
