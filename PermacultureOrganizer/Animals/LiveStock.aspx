<%@ Page Title="" Language="C#" MasterPageFile="../Permaculture.Master" AutoEventWireup="true" CodeBehind="LiveStock.aspx.cs" Inherits="PermacultureOrganizer.Animals.LiveStock" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 100%; background-color: yellow; height: inherit;">
        <tr style="background-color: #57360D; height: 50px">
            <td colspan="4">
                <h1 style="color: #fff; text-align: center; height: 100%">Livestock</h1>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="LiveStockUpdatePanel" runat="server">
                    <ContentTemplate>
                        <fieldset>
                            <asp:HiddenField runat="server" ID="LiveStockID" />
                            <table>
                                <tr>
                                    <td colspan="1" style="width: 50%; padding-left: 10px; padding-top: 10px; border-width: 3px; border-color: black">
                                        <asp:ListBox ID="lbLiveStock" CssClass="form-control" runat="server" Style="min-width: 100px; height: 100%; width: 100%;" OnSelectedIndexChanged="lbLiveStock_SelectedIndexChanged"></asp:ListBox>
                                    </td>
                                    <td colspan="1" style="width: 50%; padding-left: 20px; border-width: 3px; border-color: black; min-width: 250px">
                                        <div>
                                            <asp:Label ID="lblCount" runat="server">Count:</asp:Label>
                                            <asp:Label ID="lblLiveStockCount" runat="server"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblDiet" runat="server">Diet Type:</asp:Label>
                                            <asp:Label ID="lblLiveStockDiet" runat="server"></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="lblFood" runat="server">Food Per Animal:</asp:Label>
                                            <asp:Label ID="lblLiveStockFoodPerAnimal" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                    <td>
                                        
                                        <button type="button" class="btn btn-info" data-toggle="modal" data-target="#UpdateLiveStockModal">Update Livestock</button>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding-left: 10px; padding-top: 30px;">
                                        <h3>Breeds</h3>
                                        <asp:ListBox ID="lbBreedList" runat="server" CssClass="form-control" Style="width: inherit; min-width: 250px"></asp:ListBox>

                                    </td>
                                </tr>
                                <%-- added by Ocllo--%>
                                <tr>
                                    <td colspan="2" style="padding-left:10px;padding-top:30px;">
                                        <asp:RadioButtonList ID="rbAdditionalData" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbAdditionalData_SelectedIndexChanged">
                                            <asp:ListItem Value="Note" Selected="True">Notes</asp:ListItem>
                                            <asp:ListItem Value="Event">Events</asp:ListItem>
                                            <asp:ListItem Value="Web">Web Resources</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:ListBox ID="lbAdditionalData" runat="server" style="width:inherit;min-width:250px"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>

                            <div id="UpdateLiveStockModal" class="modal fade" role="dialog">
                                <div class="modal-dialog">

                                    <!-- Modal content-->
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h4 class="modal-title">Update Livestock</h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:HiddenField runat="server" ID="hfLiveStockID" />
                                            <asp:Label runat="server" ID="lblLiveStockName" Text="Name: "></asp:Label>
                                            <asp:TextBox runat="server" ID="txtbxLiveStockName"></asp:TextBox>
                                            <p></p>
                                            <asp:Label runat="server" ID="lbLiveStockCount" Text="Count: "></asp:Label>
                                            <asp:TextBox runat="server" ID="txtbxLiveStockCount"></asp:TextBox>
                                            <p></p>
                                            <asp:Label runat="server" ID="lbLiveStockDietType" Text="Diet Type: "></asp:Label>
                                            <asp:TextBox runat="server" ID="txtbxLiveStockDietType"></asp:TextBox>
                                            <p></p>
                                            <asp:Label runat="server" ID="lbLiveStockFoodPerAnimal" Text="Food Per Animal"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtbxLiveStockFoodPerAnimal"></asp:TextBox>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button runat="server" ID="LiveStockUpdate" OnClick="LiveStockUpdate_Click" Class="btn btn-default" Text="Save" />
                                            <button id="btnUpdateCancel" type="button" class="btn btn-default" data-dismiss="modal">Close</button>
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
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(UpdateLiveStockModalComplete);
        });        

        function UpdateLiveStockModalComplete() {
            $('div.modal-backdrop').remove();
        }

        $('#Content_LiveStockUpdatePanel').change(function () {
            $('#Content_lbBreedList > option').each(function () {
                $(this).click(function () { RedirectToBreeds(); });
                
            });
        });

        function RedirectToBreeds() {
            location.href = '/Animals/Breeds.aspx?BreedID=' + $('#Content_lbBreedList :selected').val() + '&LiveStockID=' + $('#Content_lbLiveStock :selected').val();
        }
    </script>
</asp:Content>


<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style2 {
            width: 56%;
        }
    </style>
</asp:Content>
