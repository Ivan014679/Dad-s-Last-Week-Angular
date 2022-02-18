using DLWAPI.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWAPI.Models.DataAccess
{
    public class DecisionDao
    {
        public Decision Consultar(string DecisionTomada)
        {
            using (var contexto = new DadsLastWeekEntities())
            {
                Decision decision = new Decision();
                var consulta = (from d in contexto.Decision where d.Id_Decision == DecisionTomada select d).FirstOrDefault();
                decision.Id_Decision = consulta.Id_Decision;
                decision.Texto = consulta.Texto;
                decision.Dia = consulta.Dia;
                decision.Estado = consulta.Estado;
                decision.EventoFinal = consulta.Evento_Final;
                decision.Salud = consulta.Porcentaje_Salud;
                decision.Left = consulta.Left;
                decision.Right = consulta.Right;
                return decision;
            }
        }
    }
}