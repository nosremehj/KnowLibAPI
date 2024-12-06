using Ebooks.Entities;

namespace Ebooks.Persistence
{
    public class ApplicationDbContext
    {
        public List<Categoria> Categorias { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Artigo> Artigos { get; set; }
        public List<Ebook> Ebooks { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }
        public List<Autor> Autores { get; set; }

        public ApplicationDbContext()
        {
            Categorias = new List<Categoria>();
            Usuarios = new List<Usuario>();
            Artigos = new List<Artigo>();
            Ebooks = new List<Ebook>();
            Avaliacoes = new List<Avaliacao>();
            Autores = new List<Autor>();
        }
    }
}
