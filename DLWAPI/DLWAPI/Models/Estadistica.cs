using DLWAPI.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWAPI.Models
{
    public class Estadistica
    {
        public int Id { get; set; }
        public string Jugador { get; set; }
        public string Nom_Personaje { get; set; }
        public short Porcentaje_Salud { get; set; }
        public string Estado { get; set; }
        public string Decision_Final { get; set; }

        public void Guardar()
        {
            EstadisticaDao edao = new EstadisticaDao();
            edao.Guardar(this);
        }

        public List<Estadistica> Obtener()
        {
            EstadisticaDao edao = new EstadisticaDao();
            return edao.Consultar();
        }
    }
}