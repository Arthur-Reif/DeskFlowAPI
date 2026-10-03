using DeskFlowAPI.Models.Entidades;

namespace DeskFlowAPI.Repositories
{
    public interface IInteracaoRepository
    {
        Task<Interacao> AdicionarAsync(Interacao interacao);
    }
}