namespace Biblioteca.WebApi.Models.Repositorios
{
    public class RepositorioCategoria : RepositorioBase<Categoria>, IRepositorios.IRepositorioCategoria
    {
        public RepositorioCategoria(BibliotecaContext context) : base(context)
        {
        }
    }
}
