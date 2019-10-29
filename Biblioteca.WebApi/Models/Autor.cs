using System;
using System.Collections.Generic;

namespace Biblioteca.WebApi.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Libro = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}
