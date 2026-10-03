using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeskFlowAPI.Models.Entidades;
using DeskFlowAPI.Services;
using DeskFlowAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace DeskFlowAPI.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private ICategoriaServices _categoriaService;

        public CategoriasController(ICategoriaServices categoriaServices)
        {
            _categoriaService = categoriaServices;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var categorias = await _categoriaService.ListarTodosAsync();
            return Ok(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Categoria categoria)
        {
            Categoria novaCategoria = await _categoriaService.AdicionarAsync(categoria);
            return Created("/categoria", novaCategoria);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            Categoria? categoria = await _categoriaService.ObterPorIdAsync(id);
            return Ok(categoria);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Categoria categoriaAtualizada)
        {
            var categoriaDb = await _categoriaService.AtualizarAsync(id, categoriaAtualizada);
            return Ok(categoriaDb);
        }



        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _categoriaService.RemoverAsync(id);
            return NoContent();
        }



    }
}