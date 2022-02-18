using DLWAPI.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWAPI.Models.DataAccess
{
    public class DiaDao
    {
        public Dia ConsultarDia(string IdDia)
        {
            using (var contexto = new DadsLastWeekEntities())
            {
                Dia dia = new Dia();
                var consulta = (from d in contexto.Dia where d.Id_Dia == IdDia select d).FirstOrDefault();
                dia.Id_Dia = consulta.Id_Dia;
                dia.Nom_Dia = consulta.Nom_Dia;
                return dia;
            }
        }
    }
}