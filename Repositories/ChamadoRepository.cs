using DeskFlowAPI.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DeskFlowAPI.Repositories
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly AppDbContext _context;

        public ChamadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Chamado>> ListarTodosAsync(StatusChamado? status, Prioridade? prioridade, int? categoriaId)
        {
            var query = _context.Chamados
                .Include(ch => ch.Categoria)
                .AsQueryable();

            if (status.HasValue)
            {
                query = query.Where(
                    ch => ch.Status == status.Value);
            }

            if (prioridade.HasValue)
            {
                query = query.Where(
                    ch => ch.Prioridade == prioridade.Value);
            }

            if (categoriaId.HasValue)
            {
                query = query.Where(
                    ch => ch.CategoriaId == categoriaId.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<Chamado?> ObterPorIdAsync(int id)
        {
            return await _context.Chamados
                .Include(ch => ch.Categoria)
                .Include(ch => ch.Interacoes)
                .FirstOrDefaultAsync(ch => ch.Id == id);
        }

        public async Task<Chamado> AdicionarAsync(
            Chamado chamado)
        {
            await _context.Chamados.AddAsync(chamado);

            await _context.SaveChangesAsync();

            return chamado;
        }

        public async Task<Chamado> AtualizarAsync(
            Chamado chamado)
        {
            _context.Chamados.Update(chamado);

            await _context.SaveChangesAsync();

            return chamado;
        }
    }
}