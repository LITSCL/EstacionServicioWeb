using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionServicioModel
{
    public class EstacionServicio
    {
        private int id;
        private int capacidadMaxima;
        private string ciudad;
        private string comuna;
        private string calle;

        public int Id { get => id; set => id = value; }
        public int CapacidadMaxima { get => capacidadMaxima; set => capacidadMaxima = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Comuna { get => comuna; set => comuna = value; }
        public string Calle { get => calle; set => calle = value; }
    }
}
