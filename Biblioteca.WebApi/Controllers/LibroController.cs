using Biblioteca.WebApi.Models;
using Biblioteca.WebApi.Models.IRepositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [AllowAnonymous]
        [HttpGet]
        [Route("ListarLibros")]
        public async Task<IActionResult> ObtenerLibros()
        {
            var respuesta = await _repositorio.GetAll();
            return Ok(respuesta);
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
        public async Task<IActionResult> EliminarLibro(Libro entidad)
        {
            var respuesta = await _repositorio.Delete(entidad);
            return Ok(respuesta);
        }
    }
}