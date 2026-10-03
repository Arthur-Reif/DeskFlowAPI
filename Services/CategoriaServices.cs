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

        await _categoriaRepository.AdicionarAsync(categoria);

        return categoria;
        }

        public async Task<List<Categoria>> ListarTodosAsync()
        {
            return await _categoriaRepository.ListarTodosAsync();
        }

        public async Task<Categoria?> ObterPorIdAsync(int id)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(id);

            if (categoria is null)
                throw new KeyNotFoundException("Categoria não encontrada.");

            return categoria;
        }

        public async Task<Categoria> AtualizarAsync(int id,Categoria categoriaAtualizada)
        {
            var categoria =
                await _categoriaRepository.ObterPorIdAsync(id);

            if (categoria is null)
                throw new KeyNotFoundException("Categoria não encontrada.");

                categoria.Nome = categoriaAtualizada.Nome;

            return await _categoriaRepository.AtualizarAsync(categoria);
        }
        public async Task RemoverAsync(int id)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(id);

            if (categoria is null)
                throw new KeyNotFoundException("Categoria não encontrada.");

            var possuiChamados =
                await _categoriaRepository.PossuiChamadosAsync(id);

             if (possuiChamados)
                throw new InvalidOperationException("A categoria possui chamados associados e não pode ser excluída.");

                await _categoriaRepository.RemoverAsync(categoria);
        }
    }
}