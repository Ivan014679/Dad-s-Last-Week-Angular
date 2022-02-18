using DLWAPI.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWAPI.Models
{
    public class Dia
    {
        public string Nom_Dia { get; set; }
        public string Id_Dia { get; set; }

        public Dia ObtenerDia(string IdDia)
        {
            DiaDao didao = new DiaDao();
            return didao.ConsultarDia(IdDia);
        }
    }
}