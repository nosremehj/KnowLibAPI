using Ebooks.Entities;
using Ebooks.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebooks.Controllers
{
    [Route("api/avaliacao")]
    [ApiController]
    public class AvaliacaosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AvaliacaosController(ApplicationDbContext context)
        {
            this._context = context;
        }
        // 1. GET: Retorna todas as avaliações
        [HttpGet]
        public IActionResult GetAll()
        {
            var avaliacoes = _context.Avaliacoes.ToList();
            return Ok(avaliacoes);
        }

        // 2. GET: Retorna uma avaliação por ID
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var avaliacao = _context.Avaliacoes.SingleOrDefault(a => a.Id == id);
            if (avaliacao == null)
            {
                return NotFound(); // Retorna 404 se a avaliação não for encontrada
            }
            return Ok(avaliacao);
        }

        // 3. POST: Cria uma nova avaliação
        [HttpPost]
        public IActionResult Post(Avaliacao avaliacao)
        {
            if (avaliacao == null)
            {
                return BadRequest("A avaliação não pode ser nula.");
            }

            _context.Avaliacoes.Add(avaliacao);
            return CreatedAtAction(nameof(GetById), new { id = avaliacao.Id }, avaliacao);
        }

        // 4. PUT: Atualiza uma avaliação existente
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Avaliacao avaliacao)
        {
            if (avaliacao == null || avaliacao.Id != id)
            {
                return BadRequest("A avaliação não corresponde ao ID informado.");
            }

            var avaliacaoExistente = _context.Avaliacoes.SingleOrDefault(a => a.Id == id);
            if (avaliacaoExistente == null)
            {
                return NotFound(); // Retorna 404 se a avaliação não for encontrada
            }

            // Atualizando as propriedades
            avaliacaoExistente.Nota = avaliacao.Nota;
            avaliacaoExistente.Comentarios = avaliacao.Comentarios;
            avaliacaoExistente.Curtidas = avaliacao.Curtidas;   
            avaliacaoExistente.DataAvaliacao = DateTime.UtcNow;
            avaliacaoExistente.ArtigoId = avaliacao.ArtigoId;
            avaliacaoExistente.EbookId = avaliacao.EbookId;
            avaliacaoExistente.Update(avaliacao.Comentarios, avaliacao.Nota, avaliacao.Curtidas, avaliacao.DataAvaliacao, avaliacao.ArtigoId, avaliacao.EbookId);
            return NoContent(); // Retorna 204 quando a atualização for bem-sucedida
        }

        // 5. DELETE: Exclui uma avaliação
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var avaliacao = _context.Avaliacoes.SingleOrDefault(a => a.Id == id);
            if (avaliacao == null)
            {
                return NotFound(); // Retorna 404 se a avaliação não for encontrada
            }

            _context.Avaliacoes.Remove(avaliacao);
            return NoContent(); // Retorna 204 após a exclusão bem-sucedida
        }
    }
}
