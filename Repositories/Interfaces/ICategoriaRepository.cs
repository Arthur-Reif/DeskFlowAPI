using DeskFlowAPI.Models.Entidades;

namespace DeskFlowAPI.Repositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ListarTodosAsync();
        Task<Categoria> ObterPorIdAsync(int id);
        Task<Categoria> AdicionarAsync(Categoria categoria);
        Task<Categoria> AtualizarAsync(int id, Categoria categoria);
        Task RemoverAsync (Categoria categoria);
        Task <bool> PossuiChamadosAsync(int CategoriaId);      
    }
}