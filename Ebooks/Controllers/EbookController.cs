using Ebooks.Entities;
using Ebooks.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebooks.Controllers
{
    [Route("api/ebook")]
    [ApiController]
    public class EbookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EbookController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var ebooks = _context.Ebooks.ToList();
            return Ok(ebooks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var ebook = _context.Ebooks.SingleOrDefault(e => e.Id == id);
            if (ebook == null)
            {
                return NotFound();
            }
            return Ok(ebook);
        }

        [HttpPost]
        public IActionResult Post(Ebook ebook)
        {
            _context.Ebooks.Add(ebook);
            return CreatedAtAction(nameof(GetById), new { id = ebook.Id }, ebook);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Ebook ebook)
        {
            if (ebook == null || ebook.Id != id)
            {
                return BadRequest("Ebook inválido.");
            }

            var ebookExistente = _context.Ebooks.SingleOrDefault(e => e.Id == id);
            if (ebookExistente == null)
            {
                return NotFound();
            }

            // Atualizando as propriedades
            ebookExistente.Titulo = ebook.Titulo;
            ebookExistente.Resumo = ebook.Resumo;
            ebookExistente.Isbn = ebook.Isbn;
            ebookExistente.Arquivo = ebook.Arquivo;
            ebookExistente.NumeroPaginas = ebook.NumeroPaginas;
            ebookExistente.Idioma = ebook.Idioma;

            ebookExistente.Update(ebook.Titulo, ebook.Resumo, ebook.Isbn, ebook.Arquivo, ebook.NumeroPaginas, ebook.Idioma,
                ebook.UsuariosIds, ebook.CategoriasIds, ebook.AvaliacoesIds);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var ebook = _context.Ebooks.SingleOrDefault(e => e.Id == id);
            if (ebook == null)
            {
                return NotFound();
            }

            _context.Ebooks.Remove(ebook);
            return NoContent();
        }
    }
}
