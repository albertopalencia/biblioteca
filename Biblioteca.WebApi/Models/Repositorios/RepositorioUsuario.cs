using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.WebApi.Models.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorios.IRepositorioUsuario
    {
        private  BibliotecaContext _contexto;

        public RepositorioUsuario(BibliotecaContext context) : base(context)
        {
            _contexto = context;
        }


        public async Task<Usuario> ValidarUsuario(string usuario, string password)
        {
            return await Task.Run( ()=> _contexto.Usuario.FirstOrDefault(s => s.Email == usuario && s.Password == password));
         
        }
    }
}
