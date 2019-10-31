using Biblioteca.WebApi.Models;
using Biblioteca.WebApi.Models.Entidades.DTO;
using Biblioteca.WebApi.Models.IRepositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        readonly IRepositorioLibro _repositorio;
        public LibroController(IRepositorioLibro repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("ListarLibros")]
        public async Task<IActionResult> ObtenerLibros([FromQuery] FiltroLibro entidad)
        {
            var respuesta = await _repositorio.GetAll(s=> s.IdAutorNavigation, c=> c.IdCategoriaNavigation);

            if (!string.IsNullOrWhiteSpace(entidad.Nombre))
            {
                 respuesta =  respuesta.Where(s => s.Nombre.StartsWith(entidad.Nombre)).ToList();
            }

            if (entidad.IdAutor != default)
            {
                 respuesta = respuesta.Where(s => s.IdAutor == entidad.IdAutor).ToList();
            }

            if (entidad.IdCategoria != default)
            {
                 respuesta = respuesta.Where(s =>  s.IdCategoria == entidad.IdCategoria).ToList();
            }


            return Ok(respuesta.ToList());
        }

        [HttpPost]
        [Route("PostLibro")]
        public async Task<IActionResult> GuardarLibro([FromBody] Libro entidad)
        {
            var respuesta = await _repositorio.Add(entidad);
            return Ok(respuesta);
        }

            
        [HttpPut]
        [Route("PutLibro")]
        public async Task<IActionResult> EditarLibro([FromBody] Libro entidad)
        {
            var respuesta = await _repositorio.Update(entidad);
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("DeleteLibro")]
        public async Task<IActionResult> EliminarLibro(int Id)
        {
            Libro libro = await _repositorio.FindBy(c => c.Id == Id);
            if (libro == null)
            {
                return Ok(new { success = false, mensaje = "No se pudo eliminar el libro, no existe el registro." });

            }

            var respuesta = await _repositorio.Delete(libro);
            return Ok(respuesta);
        }
    }
}