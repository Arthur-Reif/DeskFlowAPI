using DeskFlowAPI.Models.Entidades;

namespace DeskFlowAPI.Services.Interfaces
{
    public interface ICategoriaServices
    {
        Task<List<Categoria>> ListarTodosAsync();
        Task<Categoria> ObterPorIdAsync(int id);
        Task<Categoria> AdicionarAsync(Categoria categoria);
        Task<Categoria> AtualizarAsync(int id, Categoria categoria);
        Task RemoverAsync (int id);
    }
}