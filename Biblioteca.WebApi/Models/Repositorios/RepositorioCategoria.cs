namespace Biblioteca.WebApi.Models.Repositorios
{
    public class RepositorioCategoria : RepositorioBase<Categoria>, IRepositorios.IRepositorioCategoria
    {
        private BibliotecaContext _contexto;
        public RepositorioCategoria(BibliotecaContext context) : base(context)
        {
            _contexto = context;
        }
    }
}
