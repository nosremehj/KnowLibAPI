namespace Ebooks.Entities
{
    public class Categoria
    {
        public Categoria() { }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Icone { get; set; }
        public List<int> ArtigosIds { get; set; }
        public List<int> EbooksIds { get; set; }
        public void Update(string nome, string descricao, string icone, List<int> artigosIds, List<int> ebooksIds)
        {
            Nome = nome;
            Descricao = descricao;
            Icone = icone;
            ArtigosIds = artigosIds;
            EbooksIds = ebooksIds;
        }
    }

   
}
