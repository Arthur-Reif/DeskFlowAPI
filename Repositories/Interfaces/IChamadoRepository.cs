using DeskFlowAPI.Models.Entidades;

namespace DeskFlowAPI.Repositories
{
    public interface IChamadoRepository
    {
        Task<List<Chamado>> ListarTodosAsync(
            StatusChamado? status,
            Prioridade? prioridade,
            int? categoriaId);

        Task<Chamado?> ObterPorIdAsync(int id);

        Task<Chamado> AdicionarAsync(Chamado chamado);

        Task<Chamado> AtualizarAsync(Chamado chamado);
    }
}