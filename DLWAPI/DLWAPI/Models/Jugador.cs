using DLWAPI.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWAPI.Models
{
    public class Jugador
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public byte[] Imagen { get; set; }
        public string NomPersonaje { get; set; }
        public string Dia { get; set; }
        public string Decision { get; set; }

        public void RegistrarJugador()
        {
            JugadorDao judao = new JugadorDao();
            judao.Registrar(this);
        }

        public List<Jugador> ObtenerJugadores()
        {
            JugadorDao judao = new JugadorDao();
            return judao.Consultar();
        }

        public Jugador ObtenerJugador(int id)
        {
            JugadorDao judao = new JugadorDao();
            return judao.ObtenerJugador(id);
        }

        public Jugador DatosSesion(string NUsuario, string Password)
        {
            JugadorDao judao = new JugadorDao();
            return judao.InicioSesion(NUsuario, Password);
        }

        public void GuardarProgresos()
        {
            JugadorDao judao = new JugadorDao();
            judao.Actualizar(this);
        }
    }
}