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
    public partial class RegistrarEstacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuardarBtn_Click(object sender, EventArgs e)
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

                new EstacionServicioDAL().Save(es);

                ExitoLbl.Visible = true;
            }
            else
            {
                ExitoLbl.Visible = false;
            }
        }

        protected void CustomValidatorIdTxt_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                int id = int.Parse(IdTxt.Text.Trim());
                EstacionServicio es = new EstacionServicioDAL().Find(id);

                if (es != null)
                {
                    CustomValidatorIdTxt.ErrorMessage = "El ID ya existe";
                    args.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                CustomValidatorIdTxt.ErrorMessage = "El ID no es válido";
                args.IsValid = false;
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
    }
}