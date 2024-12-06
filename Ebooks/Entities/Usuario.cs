namespace Ebooks.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataRegistro { get; set; }
        public string TipoConta { get; set; }
        public List<int> ArtigosIds { get; set; }
        public List<int> EbooksIds { get; set; }
        public List<int> AvaliacoesIds { get; set; }
        public void Update(string nome, string email, string senha, string tipoConta, List<int> artigosIds, List<int> ebooksIds,
            List<int> avaliacoesIds)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            TipoConta = tipoConta;
            ArtigosIds = artigosIds;
            EbooksIds = ebooksIds;
            AvaliacoesIds = avaliacoesIds;
        }

      
    }
}
