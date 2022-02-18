using DLWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DLWAPI.Controllers
{
    [RoutePrefix("Api/Juego")]
    public class JuegoController : ApiController
    {
        [HttpPost]
        [Route("{Id}")]
        public Decision JuegoNuevo(int Id)
        {
            Jugador jugador = new Jugador();
            jugador = jugador.ObtenerJugador(Id);
            jugador.Decision = "A001";
            jugador.Dia = "D000";
            jugador.GuardarProgresos();
            return new Decision().ObtenerDecision("A001");
        }

        [HttpPost]
        [Route("{Id}-{DecisionTomada}")]
        public Decision ContinuarJuego(int Id, string DecisionTomada)
        {
            Jugador jugador = new Jugador();
            jugador = jugador.ObtenerJugador(Id);
            if (new Decision().ObtenerDecision(DecisionTomada).Left == null)
            {
                Estadistica estadistica = new Estadistica();
                Decision d = new Decision();
                d = d.ObtenerDecision(DecisionTomada);
                estadistica.Jugador = jugador.Id.ToString();
                estadistica.Nom_Personaje = jugador.NomPersonaje;
                estadistica.Porcentaje_Salud = Convert.ToInt16(d.Salud);
                estadistica.Estado = d.Estado;
                estadistica.Decision_Final = d.Id_Decision;
                estadistica.Guardar();
                jugador.Dia = "D000";
                jugador.Decision = "A000";
                jugador.GuardarProgresos();

                return new Decision().ObtenerDecision(DecisionTomada);
            }
            Decision decision = new Decision();
            decision = decision.ObtenerDecision(DecisionTomada);
            jugador.Decision = decision.Id_Decision;
            jugador.Dia = new Dia().ObtenerDia(decision.Dia).Id_Dia;
            jugador.GuardarProgresos();
            return new Decision().ObtenerDecision(DecisionTomada);
        }

        [HttpPost]
        [Route("Dia/{DiaDecision}")]
        public Dia ObtenerDia(string DiaDecision)
        {
            Decision decision = new Decision();
            decision = decision.ObtenerDecision(DiaDecision);
            return new Dia().ObtenerDia(decision.Dia);
        }
    }
}
