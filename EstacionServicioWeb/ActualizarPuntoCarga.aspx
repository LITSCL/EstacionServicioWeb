<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarPuntoCarga.aspx.cs" Inherits="EstacionServicioWeb.ActualizarPuntoCarga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
     <div class="row mt-5">
        <div class="col-12 col-md-6 col-lg-5 mx-auto">
            <div class="card">
                <div class="card-header bg-success text-white text-center">
                    <h5>Actualizar Punto</h5>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <label class="form-label" for="IdTxt">ID</label>
                        <asp:TextBox runat="server" ID="IdTxt" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label" for="CapacidadMaximaTxt">Capacidad Maxima</label>
                        <asp:TextBox runat="server" ID="CapacidadMaximaTxt" CssClass="form-control"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidatorCapacidadMaximaTxt" CssClass="text-danger" runat="server" ErrorMessage="CustomValidator" ControlToValidate="CapacidadMaximaTxt"
                            OnServerValidate="CustomValidatorCapacidadMaximaTxt_ServerValidate" ValidateEmptyText="true">
                        </asp:CustomValidator>
                    </div>
                    <div class="mb-3">
                        <label class="form-label" for="FechaVencimientoTxt">Fecha Vencimiento</label>
                        <asp:TextBox runat="server" ID="FechaVencimientoTxt" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFechaVencimientoTxt" CssClass="text-danger" runat="server" ErrorMessage="Debes ingresar la fecha de vencimiento" ControlToValidate="FechaVencimientoTxt">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="card-footer d-grid gap-1">
                        <asp:Button runat="server" ID="ActualizarBtn" CssClass="btn btn-dark" Text="Actualizar" OnClick="ActualizarBtn_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
