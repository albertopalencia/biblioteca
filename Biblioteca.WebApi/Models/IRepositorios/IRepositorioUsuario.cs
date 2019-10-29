using System.Threading.Tasks;

namespace Biblioteca.WebApi.Models.IRepositorios
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
       Task<Usuario> ValidarUsuario(string usuario, string password);
    }
}
