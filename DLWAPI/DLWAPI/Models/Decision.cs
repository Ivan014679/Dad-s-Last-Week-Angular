using DLWAPI.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWAPI.Models
{
    public class Decision
    {
        public string Id_Decision { get; set; }
        public string Texto { get; set; }
        public string Dia { get; set; }
        public string Estado { get; set; }
        public string EventoFinal { get; set; }
        public int Salud { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }

        public Decision ObtenerDecision(string DecisionTomada)
        {
            DecisionDao dedao = new DecisionDao();
            return dedao.Consultar(DecisionTomada);
        }
    }
}