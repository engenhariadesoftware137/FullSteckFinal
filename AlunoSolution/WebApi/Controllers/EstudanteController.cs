using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servico;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudanteController : ControllerBase
    {
        private readonly IEstudanteServico _servico;

        public EstudanteController(IEstudanteServico servico)
        {
            _servico = servico;
        }

        // POST api/estudante
        // (O seu método Post estava quase certo, só precisa chamar o método de serviço correto)
        [HttpPost]
        public IActionResult Post(Estudante estudante)
        {
            _servico.AdicionarEstudante(estudante);
            // Retornar CreatedAtAction é uma prática melhor para POST
            return CreatedAtAction(nameof(GetPorId), new { id = estudante.Id }, estudante);
        }

        // GET api/estudante
        // (O seu método Get estava quase certo, só precisa chamar o método de serviço correto)
        [HttpGet]
        public IActionResult GetTodos()
        {
            return Ok(_servico.ListarTodos());
        }

        // GET api/estudante/5
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var estudante = _servico.ObterPorId(id);
            if (estudante == null)
            {
                return NotFound("Estudante não encontrado.");
            }
            return Ok(estudante);
        }

        // PUT api/estudante/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Estudante estudante)
        {
            if (id != estudante.Id)
            {
                return BadRequest("ID da URL não confere com o ID do objeto.");
            }

            var existente = _servico.ObterPorId(id);
            if (existente == null)
            {
                return NotFound("Estudante não encontrado para atualização.");
            }

            _servico.AtualizarEstudante(estudante);
            return NoContent(); // Resposta padrão para PUT bem-sucedido
        }

        // DELETE api/estudante/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existente = _servico.ObterPorId(id);
            if (existente == null)
            {
                return NotFound("Estudante não encontrado para exclusão.");
            }

            _servico.RemoverEstudante(id);
            return NoContent(); // Resposta padrão para DELETE bem-sucedido
        }
    }
}
