using DeskFlowAPI.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DeskFlowAPI
{
    public class AppDbContext : DbContext
    {
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Interacao> Interacoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}