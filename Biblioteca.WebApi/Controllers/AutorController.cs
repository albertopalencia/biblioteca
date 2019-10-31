using Biblioteca.WebApi.Models;
using Biblioteca.WebApi.Models.IRepositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        readonly IRepositorioAutor _repositorio;
        public AutorController(IRepositorioAutor repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("ListarAutores")]
        public async Task<IActionResult> ObtenerAutores()
        {
            var respuesta = await _repositorio.GetAll();
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("PostAutor")]
        public async Task<IActionResult> GuardarAutor([FromBody] Autor entidad)
        {
            var respuesta = await _repositorio.Add(entidad);
            return Ok(respuesta);
        }

        
        [HttpPut]
        [Route("PutAutor")]
        public async Task<IActionResult> EditarAutor([FromBody] Autor entidad)
        {
            var respuesta = await _repositorio.Update(entidad);
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("DeleteAutor")]
        public async Task<IActionResult> EliminarAutor(int Id)
        {
            Autor autor = await _repositorio.FindBy(a => a.Id == Id, s => s.Libro);
            if (autor == null)
            {
                return Ok(new { success = false, mensaje = "No se pudo eliminar el autor, no existe el registro." });

            }
            else if (autor.Libro.Any())
            {
                return Ok(new { success = false, mensaje = "El autor tiene uno o varios libros asociados" });
            }

            var respuesta = await _repositorio.Delete(autor);
            return Ok(new { success = respuesta });
        }
    }
}