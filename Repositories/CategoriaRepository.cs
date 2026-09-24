using DeskFlowAPI.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DeskFlowAPI.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private AppDbContext _context;
        public CategoriaRepository (AppDbContext context)
        {
            _context = context;
        }
        public async Task<Categoria> AdicionarAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<List<Categoria>> ListarTodosAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> ObterPorIdAsync(string id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<bool> PossuiChamadosAsync(int categoriaId)
        {
            return await _context.Chamados.AnyAsync(ch => ch.CategoriaId == categoriaId);
        }

        public async Task RemoverAsync(Categoria categoria)
        {
             _context.Categorias.Remove(categoria);
             await _context.SaveChangesAsync();
            
        }
    }
}