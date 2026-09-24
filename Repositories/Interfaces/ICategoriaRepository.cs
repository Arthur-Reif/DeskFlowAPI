using DeskFlowAPI.Models.Entidades;

namespace DeskFlowAPI.Repositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ListarTodosAsync();
        Task<Categoria> ObterPorIdAsync(string id);
        Task<Categoria> AdicionarAsync(Categoria categoria);
        Task RemoverAsync (Categoria categoria);
        Task <bool> PossuiChamadosAsync(int CategoriaId);      
    }
}