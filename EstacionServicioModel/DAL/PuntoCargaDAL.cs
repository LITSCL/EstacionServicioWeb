using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionServicioModel.DAL
{
    public class PuntoCargaDAL
    {
        private static List<PuntoCarga> puntosCarga = new List<PuntoCarga>();

        public void Save(PuntoCarga pc)
        {
            puntosCarga.Add(pc);
        }

        public List<PuntoCarga> GetAll()
        {
            return puntosCarga;
        }

        public List<PuntoCarga> GetAll(int capacidadMinima)
        {
            if (capacidadMinima == 1)
            {
                return puntosCarga.FindAll(es => es.CapacidadMaxima <= 3);
            }
            else
            {
                return puntosCarga.FindAll(es => es.CapacidadMaxima > 3);
            }
        }

        public void Delete(int id)
        {
            PuntoCarga puntoCarga = puntosCarga.Find(pc => pc.Id == id);
            puntosCarga.Remove(puntoCarga);
        }

        public PuntoCarga Find(int id)
        {
            PuntoCarga puntoCarga = puntosCarga.Find(pc => pc.Id == id);
            return puntoCarga;
        }

        public void Update(PuntoCarga pc)
        {
            foreach (PuntoCarga puntoCarga in puntosCarga)
            {
                if (puntoCarga.Id == pc.Id)
                {
                    puntosCarga.Remove(puntoCarga);
                    puntosCarga.Add(pc);
                    break;
                }

            }
        }
    }
}
