using Ebooks.Entities;
using Ebooks.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebooks.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsuarioController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _context.Usuarios.ToList();
            return Ok(usuarios);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Create( Usuario usuario)
        {
            usuario.DataRegistro = DateTime.UtcNow;
            _context.Usuarios.Add(usuario);

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id,  Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Usuário inválido.");
            }

            var usuarioExistente = _context.Usuarios.SingleOrDefault(u => u.Id == id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            // Atualizando as propriedades
            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Senha = usuario.Senha;
            usuarioExistente.TipoConta = usuario.TipoConta;
            // Atualizando as propriedades
            usuarioExistente.Update(usuario.Nome, usuario.Email, usuario.Senha, usuario.TipoConta, usuario.ArtigosIds, usuario.EbooksIds, usuario.AvaliacoesIds);
            return NoContent(); // Retorna 204 quando a atualização for bem-sucedida

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuario);
            return NoContent();
        }
    }
}
