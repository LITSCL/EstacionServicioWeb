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
    public partial class RegistrarPuntoCarga : System.Web.UI.Page
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
                string fechaVencimiento = FechaVencimientoTxt.Text.Trim();

                PuntoCarga pc = new PuntoCarga();
                pc.Id = id;
                pc.CapacidadMaxima = capacidadMaxima;
                pc.FechaVencimiento = fechaVencimiento;

                new PuntoCargaDAL().Save(pc);

                ExitoLbl.Visible = true;
            } else
            {
                ExitoLbl.Visible = false;
            }
        }

        protected void CustomValidatorIdTxt_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                int id = int.Parse(IdTxt.Text.Trim());
                PuntoCarga pc = new PuntoCargaDAL().Find(id);

                if (pc != null)
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
    }
}