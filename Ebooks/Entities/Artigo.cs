namespace Ebooks.Entities
{
    public class Artigo
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Doi { get; set; }
        public string Arquivo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Revista { get; set; }
        public int Volume { get; set; }
        public int Edicao { get; set; }

        public List<int> UsuariosId { get; set; }
        public List<int> AutoresId { get; set; }
        public List<int> CategoriasId { get; set; }
        public List<int> AvaliacoesId { get; set; }

        public void Update(string titulo, string resumo, string doi, string arquivo, string revista, int volume, int edicao, List<int> usuariosId,
            List<int> autoresId, List<int> categoriasId, List<int> avaliacoesId)
        {
            titulo = Titulo;
            Resumo = resumo;
            Doi = doi;
            Arquivo = arquivo;
            Revista = revista;
            Volume = volume;
            Edicao = edicao;
            UsuariosId = UsuariosId;
            AutoresId = AutoresId;
            CategoriasId = CategoriasId;
            AvaliacoesId = AvaliacoesId;
        }
    }
}
