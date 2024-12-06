using Ebooks.Entities;
using Ebooks.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebooks.Controllers
{
    [Route("api/artigo")]
    [ApiController]
    public class ArtigoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ArtigoController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var artigos = _context.Artigos.ToList();
            return Ok(artigos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var artigo = _context.Artigos.SingleOrDefault(a => a.Id == id);
            if (artigo == null)
            {
                return NotFound();
            }
            return Ok(artigo);
        }

        [HttpPost]
        public IActionResult Post(Artigo artigo)
        {
            _context.Artigos.Add(artigo);
            return CreatedAtAction(nameof(GetById), new { id = artigo.Id }, artigo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Artigo artigo)
        {
            if (artigo == null || artigo.Id != id)
            {
                return BadRequest("Artigo inválido.");
            }

            var artigoExistente = _context.Artigos.SingleOrDefault(a => a.Id == id);
            if (artigoExistente == null)
            {
                return NotFound();
            }

            // Atualizando as propriedades
            artigoExistente.Titulo = artigo.Titulo;
            artigoExistente.Resumo = artigo.Resumo;
            artigoExistente.Doi = artigo.Doi;
            artigoExistente.Arquivo = artigo.Arquivo;
            artigoExistente.Revista = artigo.Revista;
            artigoExistente.Volume = artigo.Volume;
            artigoExistente.Edicao = artigo.Edicao;
            artigoExistente.UsuariosId = artigo.UsuariosId;
            artigoExistente.AutoresId = artigo.AutoresId;
            artigoExistente.CategoriasId = artigo.CategoriasId;
            artigoExistente.AvaliacoesId = artigo.AvaliacoesId;

            artigoExistente.Update(artigo.Titulo, artigo.Resumo, artigo.Doi, artigo.Arquivo, artigo.Revista, artigo.Volume, artigo.Edicao, artigo.UsuariosId, artigo.AutoresId, artigo.CategoriasId, artigo.AvaliacoesId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var artigo = _context.Artigos.SingleOrDefault(a => a.Id == id);
            if (artigo == null)
            {
                return NotFound();
            }

            _context.Artigos.Remove(artigo);
            return NoContent();
        }
    }
}
