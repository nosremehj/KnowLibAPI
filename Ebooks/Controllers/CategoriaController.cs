using Ebooks.Entities;
using Ebooks.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebooks.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoriaController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {;
            var categoria = _context.Categorias.ToList();
            return Ok(categoria);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var categoria = _context.Categorias.SingleOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                return NotFound(); // Retorna 404 caso a categoria não seja encontrada
            }
            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult Post(Categoria categoria)
        {
            categoria.Id = Guid.NewGuid(); // Garantir que o ID seja atribuído
            _context.Categorias.Add(categoria);

            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }
        // 4. PUT: Atualiza uma categoria existente
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Categoria categoria)
        {
            if (categoria == null || categoria.Id != id)
            {
                return BadRequest("Categoria inválida.");
            }

            var categoriaExistente = _context.Categorias.SingleOrDefault(c => c.Id == id);
            if (categoriaExistente == null)
            {
                return NotFound(); // Retorna 404 se a categoria não existir
            }

            // Atualizando as propriedades
            categoriaExistente.Update(categoria.Nome, categoria.Descricao, categoria.Icone, categoria.ArtigosIds, categoria.EbooksIds);

            return NoContent(); // Retorna 204 quando a atualização for bem-sucedida
        }

        // 5. DELETE: Exclui uma categoria
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var categoria = _context.Categorias.SingleOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                return NotFound(); // Retorna 404 se a categoria não for encontrada
            }

            _context.Categorias.Remove(categoria);
            return NoContent(); // Retorna 204 após a exclusão bem-sucedida
        }
    }
}
