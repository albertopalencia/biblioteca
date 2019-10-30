using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.WebApi.Models
{
    public partial class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdAutor { get; set; }
        public int IdCategoria { get; set; }
        public string Isnb { get; set; }

        public virtual Autor IdAutorNavigation { get; set; }
        public virtual Categoria IdCategoriaNavigation { get; set; }
    }
}
