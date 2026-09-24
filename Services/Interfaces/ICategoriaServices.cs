using DeskFlowAPI.Models.Entidades;

namespace DeskFlowAPI.Services.Interfaces
{
    public interface ICategoriaServices
    {
        Task<List<Categoria>> ListarTodosAsync();
        Task<Categoria> ObterPorIdAsync(string id);
        Task<Categoria> AdicionarAsync(Categoria categoria);
        Task RemoverAsync (Categoria categoria);
    }
}