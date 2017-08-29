<%@ Page Title="" Language="C#" MasterPageFile="~/Permaculture.Master" AutoEventWireup="true" CodeBehind="Breeds.aspx.cs" Inherits="PermacultureOrganizer.Animals.Breeds" %>

<asp:Content ID="BreedContent" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
    <table style="width:100%;background-color:yellow; height:inherit;">
        <tr style="background-color:#57360D;height:50px">
            <td colspan="4">
                    <h1 style="color:#fff;text-align:center;height:100%">
                        <asp:Label runat="server" ID="lblLiveStockBreed"></asp:Label>

                    </h1>
            </td>
        </tr>
        <tr>
            <td>               
                <asp:UpdatePanel ID="BreedsUpdatePanel" runat="server">
                    <ContentTemplate>
                        <fieldset>
                            <asp:HiddenField runat="server" ID="hfLiveStockID" />
                            <table>
                                <tr>
                                    <td colspan="1" style="width:50%;padding-left:10px;padding-top:10px;border-width:3px;border-color:black">
                                        <asp:ListBox ID="lbBreeds" CssClass="list-group" runat="server" style="min-width:100px;height:100%;width:100%;" OnSelectedIndexChanged="lbBreeds_SelectedIndexChanged"></asp:ListBox>
                                    </td>
                                    <td colspan="1" style="width:50%;padding-left:20px;border-width:3px;border-color:black;min-width:250px">
                                        <div>
                                            <asp:Label ID="lblCount" runat="server">Count:</asp:Label>
                                            <asp:Label ID="lblBreedsCount" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                    <td>
                                        
                                        <button type="button" class="btn btn-info" data-toggle="modal" data-target="#UpdateBreedModal">Update Breed</button>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding-left:10px;padding-top:30px;">
                                        <h3>Individual Animals</h3>
                                        <asp:ListBox ID="lbIndividualAnimal" runat="server" style="width:inherit;min-width:250px"></asp:ListBox>

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
                                        <asp:Button runat="server" ID="Delete" OnClick="DeleteBreed" Text="Delete" />
                                    </td>
                                </tr>
                            </table>

                            <div id="UpdateBreedModal" class="modal fade" role="dialog">
                                <div class="modal-dialog">

                                    <!-- Modal content-->
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h4 class="modal-title">Add Livestock</h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:HiddenField runat="server" ID="hfBreedID" />
                                            <asp:Label runat="server" ID="lblBreedName" Text="Name: "></asp:Label>
                                            <asp:TextBox runat="server" ID="txtBreedName"></asp:TextBox>
                                            <p></p>
                                            <asp:Label runat="server" ID="lbBreedCount" Text="Count: "></asp:Label>
                                            <asp:TextBox runat="server" ID="txtBreedCount"></asp:TextBox>
                                            <p></p>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button runat="server" ID="BreedUpdate" OnClick="BreedUpdate_Click" Class="btn btn-default" Text="Save" />
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
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#Content_lbIndividualAnimal > option').each(function () {
                $(this).click(function () { RedirectToIndividualAnimal(); });
            });

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(UpdateBreedsModalComplete);
        })

        function UpdateBreedsModalComplete() {
            $('div.modal-backdrop').remove();
        }

        $('#Content_BreedsUpdatePanel').change(function () {
            $('#Content_lbIndividualAnimal > option').each(function () {
                $(this).click(function () { RedirectToIndividualAnimal(); });
            });
        });

        function RedirectToIndividualAnimal() {
            location.href = '/Animals/IndividualAnimal.aspx?IndividualAnimalID=' + $('#Content_lbIndividualAnimal :selected').val();
        }
    </script> 
</asp:Content>
