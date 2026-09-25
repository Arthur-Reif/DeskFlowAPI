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
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private ICategoriaServices _categoriaService;

        public CategoriasController(CategoriaServices categoriaServices)
        {
            _categoriaService = categoriaServices;
        }

        [HttpGet]
        public async Task<IActionResult> Adicionar ([FromBody] Categoria categoria)
        {
            await _categoriaService.AdicionarAsync(categoria);
            return Created("/categoria", categoria);

        }

    }
}