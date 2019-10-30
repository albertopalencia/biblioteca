using System;

namespace Biblioteca.WebApi.Models.DTO
{
    public class UsuarioInfo
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
    }
}
