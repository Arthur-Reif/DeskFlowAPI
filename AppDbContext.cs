using DeskFlowAPI.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DeskFlowAPI
{
    public class AppDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Interacao> Interacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Tb_categoria");
                
                categoria.HasKey(c => c.Id);
                categoria.Property(c => c.Nome)
                .HasColumnName("nomeCategoria")
                .HasMaxLength(200)
                .IsRequired();
                
            });
        }
    }
}