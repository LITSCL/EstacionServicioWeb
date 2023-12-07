using EstacionServicioModel;
using EstacionServicioModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstacionServicioWeb
{
    public partial class VerPuntosCarga : System.Web.UI.Page
    {
        private PuntoCargaDAL dalPuntoCarga = new PuntoCargaDAL();

        private void CargarTabla(List<PuntoCarga> puntos)
        {
            PuntosGrid.DataSource = puntos;
            PuntosGrid.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla(dalPuntoCarga.GetAll());
            }
        }

        protected void PuntosGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idEliminar = int.Parse(e.CommandArgument.ToString());
                dalPuntoCarga.Delete(idEliminar);
                CargarTabla(dalPuntoCarga.GetAll());
            }

            if (e.CommandName == "Actualizar")
            {
                int idBuscar = int.Parse(e.CommandArgument.ToString());
                PuntoCarga pc = dalPuntoCarga.Find(idBuscar);
                Response.Redirect("ActualizarPuntoCarga.aspx?id=" + pc.Id + "&capacidadMaxima=" + pc.CapacidadMaxima + "&fechaVencimiento=" + pc.FechaVencimiento);
            }
        }

        protected void CapacidadMaximaDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int capacidadMinima = Convert.ToInt32(CapacidadMaximaDdl.SelectedValue);
            List<PuntoCarga> puntosDeCargaFiltrados = dalPuntoCarga.GetAll(capacidadMinima);
            CargarTabla(puntosDeCargaFiltrados);
        }

        protected void TodosChx_CheckedChanged(object sender, EventArgs e)
        {
            CapacidadMaximaDdl.Enabled = !TodosChx.Checked;

            if (TodosChx.Checked)
            {
                CargarTabla(dalPuntoCarga.GetAll());
            }
        }
    }
}