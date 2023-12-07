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
    public partial class VerEstaciones : System.Web.UI.Page
    {
        private EstacionServicioDAL dalEstacionServicio = new EstacionServicioDAL();

        private void CargarTabla(List<EstacionServicio> estaciones)
        {
            EstacionesGrid.DataSource = estaciones;
            EstacionesGrid.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla(dalEstacionServicio.GetAll());
            }
        }

        protected void EstacionesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idEliminar = int.Parse(e.CommandArgument.ToString());
                dalEstacionServicio.Delete(idEliminar);
                CargarTabla(dalEstacionServicio.GetAll());
            }

            if (e.CommandName == "Actualizar")
            {
                int idBuscar = int.Parse(e.CommandArgument.ToString());
                EstacionServicio es = dalEstacionServicio.Find(idBuscar);
                Response.Redirect("ActualizarEstacion.aspx?id=" + es.Id + "&capacidadMaxima=" + es.CapacidadMaxima + "&ciudad=" + es.Ciudad + "&comuna=" + es.Comuna + "&calle=" + es.Calle);
            }
        }

        protected void CapacidadMaximaDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int capacidadMinima = Convert.ToInt32(CapacidadMaximaDdl.SelectedValue);
            List<EstacionServicio> estacionesServicioFiltradas = dalEstacionServicio.GetAll(capacidadMinima);
            CargarTabla(estacionesServicioFiltradas);
        }

        protected void TodosChx_CheckedChanged(object sender, EventArgs e)
        {
            CapacidadMaximaDdl.Enabled = !TodosChx.Checked;

            if (TodosChx.Checked)
            {
                CargarTabla(dalEstacionServicio.GetAll());
            }
        }
    }
}