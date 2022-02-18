using DLWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DLWAPI.Controllers
{
    [RoutePrefix("Api/Jugador")]
    public class JugadorController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public List<Jugador> ObtenerJugadores()
        {
            Jugador jugador = new Jugador();
            return jugador.ObtenerJugadores();
        }

        [HttpGet]
        [Route("Get/{Id}")]
        public Jugador ObtenerJugador(int Id)
        {
            Jugador jugador = new Jugador();
            return jugador.ObtenerJugador(Id);
        }

        [HttpGet]
        [Route("Login/{NombreUsuario}-{Contrasena}")]
        public Jugador AutenticarJugador(string NombreUsuario, string Contrasena)
        {
            Jugador jugador = new Jugador();
            return jugador.DatosSesion(NombreUsuario, Contrasena);
        }

        [HttpPost]
        [Route("Set")]
        public IHttpActionResult RegistrarJugador(Jugador jugador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            jugador.RegistrarJugador();
            return Ok(jugador);
        }
    }
}
