using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionServicioModel
{
    public class PuntoCarga
    {
        private int id;
        private int capacidadMaxima;
        private string fechaVencimiento;

        public int Id { get => id; set => id = value; }
        public int CapacidadMaxima { get => capacidadMaxima; set => capacidadMaxima = value; }
        public string FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
    }
}
