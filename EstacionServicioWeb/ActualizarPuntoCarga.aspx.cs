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
    public partial class ActualizarPuntoCarga : System.Web.UI.Page
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
                else if (Request.QueryString["fechaVencimiento"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    IdTxt.Text = Request.QueryString["id"].ToString();
                    CapacidadMaximaTxt.Text = Request.QueryString["capacidadMaxima"].ToString();
                    FechaVencimientoTxt.Text = Request.QueryString["fechaVencimiento"].ToString();
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
                    if (capacidadMaxima < 1 || capacidadMaxima > 7)
                    {
                        CustomValidatorCapacidadMaximaTxt.ErrorMessage = "La capacidad máxima debe estar entre 1 y 7";
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
                string fechaVencimiento = FechaVencimientoTxt.Text.Trim();

                PuntoCarga pc = new PuntoCarga();
                pc.Id = id;
                pc.CapacidadMaxima = capacidadMaxima;
                pc.FechaVencimiento = fechaVencimiento;

                PuntoCargaDAL dalPuntoCarga = new PuntoCargaDAL();
                dalPuntoCarga.Update(pc);
                Response.Redirect("VerPuntosCarga.aspx");
            }
            else
            {

            }
        }
    }
}