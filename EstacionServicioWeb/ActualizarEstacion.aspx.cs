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
    public partial class ActualizarEstacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IdTxt.Enabled = false;

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else if (Request.QueryString["capacidadMaxima"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else if (Request.QueryString["ciudad"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else if (Request.QueryString["comuna"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else if (Request.QueryString["calle"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    IdTxt.Text = Request.QueryString["id"].ToString();
                    CapacidadMaximaTxt.Text = Request.QueryString["capacidadMaxima"].ToString();
                    CiudadTxt.Text = Request.QueryString["ciudad"].ToString();
                    ComunaTxt.Text = Request.QueryString["comuna"].ToString();
                    CalleTxt.Text = Request.QueryString["calle"].ToString();
                }
            }
        }

        protected void CustomValidatorCapacidadMaximaTxt_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (CapacidadMaximaTxt.Text.Trim() == "")
            {
                CustomValidatorCapacidadMaximaTxt.ErrorMessage = "Debes ingresar la capacidad máxima";
                args.IsValid = false;
            }
            else
            {
                try
                {
                    int capacidadMaxima = int.Parse(CapacidadMaximaTxt.Text.Trim());
                    if (capacidadMaxima < 30 || capacidadMaxima > 50)
                    {
                        CustomValidatorCapacidadMaximaTxt.ErrorMessage = "La capacidad máxima debe estar entre 30 y 50";
                        args.IsValid = false;
                    }
                }
                catch (Exception ex)
                {
                    CustomValidatorCapacidadMaximaTxt.ErrorMessage = "La capacidad máxima debe ser un número";
                    args.IsValid = false;
                }
            }
        }

        protected void ActualizarBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int id = int.Parse(IdTxt.Text.Trim());
                int capacidadMaxima = int.Parse(CapacidadMaximaTxt.Text.Trim());
                string ciudad = CiudadTxt.Text.Trim();
                string comuna = ComunaTxt.Text.Trim();
                string calle = CalleTxt.Text.Trim();

                EstacionServicio es = new EstacionServicio();
                es.Id = id;
                es.CapacidadMaxima = capacidadMaxima;
                es.Ciudad = ciudad;
                es.Comuna = comuna;
                es.Calle = calle;

                EstacionServicioDAL dalEstacionServicio = new EstacionServicioDAL();
                dalEstacionServicio.Update(es);
                Response.Redirect("VerEstaciones.aspx");
            }
            else
            {

            }
        }
    }
}