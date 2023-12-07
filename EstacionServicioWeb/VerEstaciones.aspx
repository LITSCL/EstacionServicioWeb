<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerEstaciones.aspx.cs" Inherits="EstacionServicioWeb.VerEstaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="mt-5">
        <asp:DropDownList ID="CapacidadMaximaDdl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CapacidadMaximaDdl_SelectedIndexChanged">
            <asp:ListItem Value="30" Selected="True" Text="Capacidad (30<->39)"></asp:ListItem>
            <asp:ListItem Value="40" Selected="False" Text="Capacidad (40<->50)"></asp:ListItem>
        </asp:DropDownList>
        <asp:CheckBox ID="TodosChx" Checked="true" runat="server" AutoPostBack="true" OnCheckedChanged="TodosChx_CheckedChanged" Text="Ver todos" />
    </div>
    
    <div class="mt-5">
        <asp:GridView ID="EstacionesGrid" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowCommand="EstacionesGrid_RowCommand" EmptyDataText="No hay pestaciones registradas">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="id" />
                <asp:BoundField HeaderText="Capacidad Maxima" DataField="capacidadMaxima" />
                <asp:BoundField HeaderText="Ciudad" DataField="ciudad" />
                <asp:BoundField HeaderText="Comuna" DataField="comuna" />
                <asp:BoundField HeaderText="Calle" DataField="calle" />
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
