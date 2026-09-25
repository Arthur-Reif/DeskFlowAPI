using DeskFlowAPI.Models.Entidades;
using DeskFlowAPI.Repositories;
using DeskFlowAPI.Services.Interfaces;

namespace DeskFlowAPI.Services
{
    public class CategoriaServices : ICategoriaServices
    {
        private ICategoriaRepository _categoriaRepository;

        public CategoriaServices(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<Categoria> AdicionarAsync(Categoria categoria)
        {
            return await _categoriaRepository.AdicionarAsync(categoria);
        }

        public async Task<List<Categoria>> ListarTodosAsync()
        {
            return await _categoriaRepository.ListarTodosAsync();
        }

        public async Task<Categoria> ObterPorIdAsync(int id)
        {
            return await _categoriaRepository.ObterPorIdAsync(id);
        }

        public async Task<Categoria> AtualizarAsync(int id, Categoria categoria)
        {
            return await _categoriaRepository.AtualizarAsync(id, categoria);
        }
        public async Task RemoverAsync(int id)
        {
            Categoria categoria = await _categoriaRepository.ObterPorIdAsync(id);

            if (categoria != null)
            {
                await _categoriaRepository.RemoverAsync(categoria);
            }
        }
    }
}