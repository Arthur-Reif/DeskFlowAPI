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
                
                categoria.HasKey(ca => ca.Id); // O 'ca' é de 'categoria'
                categoria.Property(ca => ca.Nome)
                .HasColumnName("nomeCategoria")
                .HasMaxLength(200)
                .IsRequired();
                
            });
            modelBuilder.Entity<Chamado>(chamado =>
            {
                chamado.ToTable("Tb_chamado");
                chamado.HasKey(ch => ch.Id); // O 'ch' é de 'chamado'

                chamado.Property(ch => ch.Titulo)
                .HasColumnName("tituloDoChamado")
                .HasMaxLength(200)
                .IsRequired();

                chamado.Property(ch => ch.Descricao)
                .HasColumnName("descricaoDoChamado")
                .HasMaxLength(1000)
                .IsRequired();

                chamado.Property(ch => ch.Prioridade)
                .HasColumnName("prioridadeDoChamado") //vai ser: Baixa, Media ou Alta
                .HasMaxLength(10)
                .IsRequired();

                chamado.Property(ch => ch.Status)
                .HasColumnName("statusDoChamado") //vai ser: Aberto, EmAndamento ou Fechado
                .HasMaxLength(20)
                .IsRequired();

                chamado.Property(ch => ch.SolicinanteNome)
                .HasColumnName("nomeDeQuemSolicitou")
                .HasMaxLength(50)
                .IsRequired();

                chamado.Property(ch => ch.Solucao)
                .HasColumnName("SolucaoDoChamado")
                .HasMaxLength(1000);
                
                chamado.HasOne(ch => ch.Categoria)
                .WithMany(ch => ch.Chamados)
                .HasForeignKey(ch => ch.CategoriaId);
            });
        }
    }
}