namespace Ebooks.Entities
{
    public class Autor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Instituicao { get; set; }
        public string EmailContato { get; set; }
        public string Bio { get; set; }
        public string OrcId { get; set; }

        public int ArtigosId { get; set; }

        public void Update(string nome, string instituicao, string emailContato, string bio, string orcId, int artigosIds)
        {
            Nome = nome;
            Instituicao = instituicao;
            EmailContato = emailContato;
            Bio = bio;
            OrcId = orcId;
            ArtigosId = artigosIds;
        }
    }
}
