using DLWAPI.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWAPI.Models.DataAccess
{
    public class EstadisticaDao
    {
        public List<Estadistica> Consultar()
        {
            List<Estadistica> estadisticas = new List<Estadistica>();
            using (var contexto = new DadsLastWeekEntities())
            {
                var consulta = (from d in contexto.Estadistica select d).ToList();
                foreach (var item in consulta)
                {
                    Estadistica x = new Estadistica();
                    x.Id = item.Id;
                    x.Jugador = item.Jugador1.Nom_Usuario;
                    x.Nom_Personaje = item.Nom_Personaje;
                    x.Porcentaje_Salud = item.Porcentaje_Salud;
                    x.Estado = item.Estado;
                    x.Decision_Final = item.Decision.Evento_Final;

                    estadisticas.Add(x);
                }
            }
            return estadisticas;
        }

        public void Guardar(Estadistica e)
        {
            using (var contexto = new DadsLastWeekEntities())
            {
                DataModel.Estadistica est = new DataModel.Estadistica();
                est.Jugador = Convert.ToInt32(e.Jugador);
                est.Nom_Personaje = e.Nom_Personaje;
                est.Porcentaje_Salud = e.Porcentaje_Salud;
                est.Estado = e.Estado;
                est.Decision_Final = e.Decision_Final;

                contexto.Estadistica.Add(est);
                contexto.SaveChanges();
            }
        }
    }
}