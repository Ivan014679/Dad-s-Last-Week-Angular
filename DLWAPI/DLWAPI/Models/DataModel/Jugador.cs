//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DLWAPI.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Jugador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jugador()
        {
            this.Estadistica = new HashSet<Estadistica>();
        }
    
        public int Id { get; set; }
        public string Nom_Usuario { get; set; }
        public string Contrasena { get; set; }
        public byte[] Imagen { get; set; }
        public string Nom_Personaje { get; set; }
        public string Dia { get; set; }
        public string Decision { get; set; }
    
        public virtual Decision Decision1 { get; set; }
        public virtual Dia Dia1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estadistica> Estadistica { get; set; }
    }
}
