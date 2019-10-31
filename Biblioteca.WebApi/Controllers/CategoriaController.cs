using Biblioteca.WebApi.Models;
using Biblioteca.WebApi.Models.IRepositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        readonly IRepositorioCategoria _repositorio;
        public CategoriaController(IRepositorioCategoria repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("ListarCategorias")]
        public async Task<IActionResult> ObtenerCategorias()
        {
            var respuesta = await _repositorio.GetAll();
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("PostCategoria")]
        public async Task<IActionResult> GuardarCategoria([FromBody] Categoria entidad)
        {
            var respuesta = await _repositorio.Add(entidad);
            return Ok(respuesta);
        }

        
        [HttpPut]
        [Route("PutCategoria")]
        public async Task<IActionResult> EditarCategoria([FromBody] Categoria entidad)
        {
            var respuesta = await _repositorio.Update(entidad);
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("DeleteCategoria")]
        public async Task<IActionResult> EliminarCategoria(int Id)
        {
            Categoria categoria = await _repositorio.FindBy(c => c.Id == Id, s=> s.Libro);
            if (categoria == null)
            {
                return Ok(new { success = false, mensaje = "No se pudo eliminar la categoria, no existe el registro." });

            } else if(categoria.Libro.Any())
            {
                return Ok(new { success = false, mensaje = "La categoria tiene uno o varios libros asociados" });
            }            

            var respuesta = await _repositorio.Delete(categoria);
            return Ok(respuesta);
        }
    }
}