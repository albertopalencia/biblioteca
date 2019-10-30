namespace Biblioteca.WebApi.Models.Repositorios
{
    public class RepositorioAutor: RepositorioBase<Autor>, IRepositorios.IRepositorioAutor
    {
        public RepositorioAutor(BibliotecaContext context) : base(context)
        {
        }
    }
}
