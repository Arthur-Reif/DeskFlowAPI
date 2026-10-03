using DeskFlowAPI.Models.DTOs;
using DeskFlowAPI.Models.Entidades;

namespace DeskFlowAPI.Services.Interfaces
{
    public interface IChamadoServices
    {
        Task<List<Chamado>> ListarTodosAsync(StatusChamado? status, Prioridade? prioridade, int? categoriaId);

        Task<Chamado> ObterPorIdAsync(int id);

        Task<Chamado> AdicionarAsync(CriarChamadoDto chamadoDto);

        Task IniciarAsync(int id);
        Task<Interacao> AdicionarInteracaoAsync(int chamadoId, CriarInteracaoDto interacaoDto);
        Task EncerrarAsync(int id, EncerrarChamadoDto chamadoDto);

    }
}