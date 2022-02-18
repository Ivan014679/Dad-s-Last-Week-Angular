using DLWAPI.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWAPI.Models.DataAccess
{
    public class JugadorDao
    {
        public void Registrar(Jugador j)
        {
            using (var contexto = new DadsLastWeekEntities())
            {
                DataModel.Jugador ju = new DataModel.Jugador();
                ju.Nom_Usuario = j.NombreUsuario;
                ju.Contrasena = j.Contrasena;
                ju.Imagen = null;
                ju.Nom_Personaje = "nuevopersonaje";
                ju.Dia = "D000";
                ju.Decision = "A000";

                contexto.Jugador.Add(ju);
                contexto.SaveChanges();
            }
        }

        public List<Jugador> Consultar()
        {
            List<Jugador> listajugadores = new List<Jugador>();
            using (var contexto = new DadsLastWeekEntities())
            {
                var consulta = (from d in contexto.Jugador select d).ToList();
                foreach (var item in consulta)
                {
                    Jugador x = new Jugador();
                    x.Id = item.Id;
                    x.NombreUsuario = item.Nom_Usuario;
                    x.Contrasena = item.Contrasena;
                    x.Imagen = item.Imagen;
                    x.NomPersonaje = item.Nom_Personaje;
                    x.Dia = item.Dia;
                    x.Decision = item.Decision;

                    listajugadores.Add(x);
                }
            }
            return listajugadores;
        }

        public Jugador ObtenerJugador(int id)
        {
            using (var context = new DadsLastWeekEntities())
            {
                Jugador jugador = new Jugador();
                var record = (from d in context.Jugador select d).Where(d => d.Id.Equals(id)).FirstOrDefault();
                jugador.Id = record.Id;
                jugador.NombreUsuario = record.Nom_Usuario;
                jugador.Contrasena = record.Contrasena;
                jugador.Imagen = record.Imagen;
                jugador.NomPersonaje = record.Nom_Personaje;
                jugador.Dia = record.Dia;
                jugador.Decision = record.Decision;
                return jugador;
            }
        }

        public Jugador InicioSesion(string NUsuario, string Password)
        {
            using (var contexto = new DadsLastWeekEntities())
            {
                var consulta = (from d in contexto.Jugador where d.Nom_Usuario == NUsuario && d.Contrasena == Password select d).FirstOrDefault();
                if (consulta != null)
                {
                    return this.ObtenerJugador(consulta.Id);
                }
                else
                {
                    return null;
                }
            }
        }

        public void Actualizar(Jugador j)
        {
            using (var contexto = new DadsLastWeekEntities())
            {
                var consulta = (from d in contexto.Jugador select d).Where(d => d.Id.Equals(j.Id)).FirstOrDefault();
                consulta.Nom_Usuario = j.NombreUsuario;
                consulta.Contrasena = j.Contrasena;
                consulta.Imagen = j.Imagen;
                consulta.Nom_Personaje = j.NomPersonaje;
                consulta.Dia = j.Dia;
                consulta.Decision = j.Decision;
                contexto.SaveChanges();
            }
        }
    }
}