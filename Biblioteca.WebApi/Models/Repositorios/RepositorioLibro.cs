namespace Biblioteca.WebApi.Models.Repositorios
{
    public class RepositorioLibro : RepositorioBase<Libro>, IRepositorios.IRepositorioLibro
    {
        public RepositorioLibro(BibliotecaContext context) : base(context)
        {
        }
    }
}
