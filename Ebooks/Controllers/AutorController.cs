using Ebooks.Entities;
using Ebooks.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebooks.Controllers
{
    [Route("api/autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AutorController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var autores = _context.Autores.ToList();
            return Ok(autores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var autor = _context.Autores.SingleOrDefault(a => a.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        [HttpPost]
        public IActionResult Post(Autor autor)
        {
            _context.Autores.Add(autor);
            return CreatedAtAction(nameof(GetById), new { id = autor.Id }, autor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Autor autor)
        {
            if (autor == null || autor.Id != id)
            {
                return BadRequest("Autor inválido.");
            }

            var autorExistente = _context.Autores.SingleOrDefault(a => a.Id == id);
            if (autorExistente == null)
            {
                return NotFound();
            }

            // Atualizando as propriedades
            autorExistente.Nome = autor.Nome;
            autorExistente.Instituicao = autor.Instituicao;
            autorExistente.EmailContato = autor.EmailContato;
            autorExistente.Bio = autor.Bio;
            autorExistente.OrcId = autor.OrcId;
            autorExistente.ArtigosId = autor.ArtigosId;

            autorExistente.Update(autor.Nome, autor.Instituicao, autor.EmailContato, autor.Bio, autor.OrcId, autor.ArtigosId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var autor = _context.Autores.SingleOrDefault(a => a.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(autor);
            return NoContent();
        }
    }
}
