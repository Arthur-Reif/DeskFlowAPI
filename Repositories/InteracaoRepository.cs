using DeskFlowAPI.Models.Entidades;

namespace DeskFlowAPI.Repositories
{
    public class InteracaoRepository : IInteracaoRepository
    {
        private readonly AppDbContext _context;

        public InteracaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Interacao> AdicionarAsync(Interacao interacao)
        {
            await _context.Interacoes.AddAsync(interacao);
            await _context.SaveChangesAsync();

            return interacao;
        }
    }
}