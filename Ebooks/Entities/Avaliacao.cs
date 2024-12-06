using System.Security.Cryptography;

namespace Ebooks.Entities
{
    public class Avaliacao
    {
        public Guid Id { get; set; }
        public string Comentarios { get; set; }
        public int Nota { get; set; }
        public DateTime DataAvaliacao { get; set; }
        public int Curtidas { get; set; }

        public int ArtigoId { get; set; }
        public int EbookId { get; set; }

        public void Update(string comentarios, int nota, int curtidas, DateTime dataAvaliacao, int artigoId, int ebookId)
        {
            Comentarios = comentarios;
            Nota = nota;
            Curtidas = curtidas;
            DataAvaliacao = dataAvaliacao;
            ArtigoId = artigoId;
            EbookId = ebookId;
        }
    }
}
