using DeskFlowAPI.Models.DTOs;
using DeskFlowAPI.Models.Entidades;
using DeskFlowAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlowAPI.Controllers
{
    [ApiController]
    [Route("api/chamados")]
    public class ChamadosController : ControllerBase
    {
        private readonly IChamadoServices _chamadoServices;

        public ChamadosController(IChamadoServices chamadoServices)
        {
            _chamadoServices = chamadoServices;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos(StatusChamado? status, Prioridade? prioridade, int? categoriaId)
        {
            var chamados =
                await _chamadoServices.ListarTodosAsync(status, prioridade, categoriaId);

            return Ok(chamados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var chamado = await _chamadoServices.ObterPorIdAsync(id);

            return Ok(chamado);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(
            [FromBody] CriarChamadoDto chamadoDto)
        {
            var novoChamado = await _chamadoServices.AdicionarAsync(chamadoDto);

            return CreatedAtAction(nameof(ObterPorId), new { id = novoChamado.Id }, novoChamado);
        }

        [HttpPatch("{id}/iniciar")]
        public async Task<IActionResult> Iniciar(int id)
        {
            await _chamadoServices.IniciarAsync(id);

            return NoContent();
        }

        [HttpPatch("{id}/encerrar")]
        public async Task<IActionResult> Encerrar(int id, [FromBody] EncerrarChamadoDto chamadoDto)
        {
            await _chamadoServices.EncerrarAsync(id, chamadoDto);

            return NoContent();
        }
    }
}