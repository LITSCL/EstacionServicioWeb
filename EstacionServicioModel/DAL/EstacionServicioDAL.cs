using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionServicioModel.DAL
{
    public class EstacionServicioDAL
    {
        private static List<EstacionServicio> estacionesServicio = new List<EstacionServicio>();

        public void Save(EstacionServicio es)
        {
            estacionesServicio.Add(es);
        }

        public List<EstacionServicio> GetAll()
        {
            return estacionesServicio;
        }

        public List<EstacionServicio> GetAll(int capacidadMinima)
        {
            if (capacidadMinima == 30)
            {
                return estacionesServicio.FindAll(es => es.CapacidadMaxima <= 39);
            }
            else
            {
                return estacionesServicio.FindAll(es => es.CapacidadMaxima > 39);
            }
        }

        public void Delete(int id)
        {
            EstacionServicio estacionServicio = estacionesServicio.Find(es =>  es.Id == id);
            estacionesServicio.Remove(estacionServicio);
        }

        public EstacionServicio Find(int id)
        {
            EstacionServicio estacionServicio = estacionesServicio.Find(es => es.Id == id);
            return estacionServicio;
        }

        public void Update(EstacionServicio es)
        {
            foreach (EstacionServicio estacionServicio in estacionesServicio)
            {
                if (estacionServicio.Id == es.Id)
                {
                    estacionesServicio.Remove(estacionServicio);
                    estacionesServicio.Add(es);
                    break;
                }
                
            }
        }
    }
}
