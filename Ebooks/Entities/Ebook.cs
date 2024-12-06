namespace Ebooks.Entities
{
    public class Ebook
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Isbn { get; set; }
        public string Arquivo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int NumeroPaginas { get; set; }
        public string Idioma { get; set; }

        public List<int> UsuariosIds { get; set; }
        public List<int> CategoriasIds { get; set; }
        public List<int> AvaliacoesIds { get; set; }

        public void Update(string titulo, string resumo, string isbn, string arquivo, int numeroPaginas, string idioma, List<int> usuariosIds,
            List<int> categoriasIds, List<int> avaliacoesIds)
        {
            Titulo = titulo;    
            Resumo = resumo;
            Isbn = isbn;
            Arquivo = arquivo;
            Isbn = isbn;
            Idioma = idioma;
            UsuariosIds = usuariosIds;
            CategoriasIds = categoriasIds;
            AvaliacoesIds = avaliacoesIds;
        }
    }
}
