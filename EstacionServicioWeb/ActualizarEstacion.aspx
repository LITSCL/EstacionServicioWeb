<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarEstacion.aspx.cs" Inherits="EstacionServicioWeb.ActualizarEstacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row mt-5">
        <div class="col-12 col-md-6 col-lg-5 mx-auto">
            <div class="card">
                <div class="card-header bg-success text-white text-center">
                    <h5>Actualizar Estación</h5>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <label class="form-label" for="IdTxt">ID</label>
                        <asp:TextBox runat="server" ID="IdTxt" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label" for="CapacidadMaximaTxt">Capacidad Maxima</label>
                        <asp:TextBox runat="server" ID="CapacidadMaximaTxt" CssClass="form-control"></asp:TextBox>
                    </div>
                        <asp:CustomValidator ID="CustomValidatorCapacidadMaximaTxt" CssClass="text-danger" runat="server" ErrorMessage="CustomValidator" ControlToValidate="CapacidadMaximaTxt"
                            OnServerValidate="CustomValidatorCapacidadMaximaTxt_ServerValidate" ValidateEmptyText="true">
                        </asp:CustomValidator>
                    <div class="mb-3">
                        <label class="form-label" for="CiudadTxt">Ciudad</label>
                        <asp:TextBox runat="server" ID="CiudadTxt" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCiudadTxt" CssClass="text-danger" runat="server" ErrorMessage="Debes ingresar la ciudad" ControlToValidate="CiudadTxt">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <label class="form-label" for="ComunaTxt">Comuna</label>
                        <asp:TextBox runat="server" ID="ComunaTxt" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorComunaTxt" CssClass="text-danger" runat="server" ErrorMessage="Debes ingresar la comuna" ControlToValidate="ComunaTxt">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">
                        <label class="form-label" for="CalleTxt">Calle</label>
                        <asp:TextBox runat="server" ID="CalleTxt" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCalleTxt" CssClass="text-danger" runat="server" ErrorMessage="Debes ingresar la calle" ControlToValidate="CalleTxt">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="card-footer d-grid gap-1">
                    <asp:Button runat="server" ID="ActualizarBtn" CssClass="btn btn-dark" Text="Actualizar" OnClick="ActualizarBtn_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
