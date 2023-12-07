<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerPuntosCarga.aspx.cs" Inherits="EstacionServicioWeb.VerPuntosCarga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="mt-5">
        <asp:DropDownList ID="CapacidadMaximaDdl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CapacidadMaximaDdl_SelectedIndexChanged">
            <asp:ListItem Value="1" Selected="True" Text="Capacidad (1<->3)"></asp:ListItem>
            <asp:ListItem Value="4" Selected="False" Text="Capacidad (4<->7)"></asp:ListItem>
        </asp:DropDownList>
        <asp:CheckBox ID="TodosChx" Checked="true" runat="server" AutoPostBack="true" OnCheckedChanged="TodosChx_CheckedChanged" Text="Ver todos" />
    </div>
    
    <div class="mt-5">
        <asp:GridView ID="PuntosGrid" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowCommand="PuntosGrid_RowCommand" EmptyDataText="No hay puntos de carga registrados">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="id" />
                <asp:BoundField HeaderText="Capacidad Maxima" DataField="capacidadMaxima" />
                <asp:BoundField HeaderText="Fecha Vencimiento" DataField="fechaVencimiento" />
                <asp:TemplateField HeaderText="Acción 1">
                    <ItemTemplate>
                        <asp:Button ID="Eliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Acción 2">
                    <ItemTemplate>
                        <asp:Button ID="Actualizar" runat="server" Text="Actualizar" CssClass="btn btn-warning" CommandName="Actualizar" CommandArgument='<%# Eval("Id") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
   
</asp:Content>
