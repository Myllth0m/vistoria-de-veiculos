using Microsoft.EntityFrameworkCore;
using VistoriaDeVeiculos.Models.Entities;

namespace VistoriaDeVeiculos.DataContext
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<FormularioDeInspecao> FormularioDeInspecao { get; set; }
        public DbSet<Motorista> Motorista { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Pergunta> Pergunta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormularioDeInspecao>(x =>
            {
                x.ToTable("FormularioDeInspecao");

                x.HasKey(x => x.Id);

                x.Property(x => x.Id)
                    .HasColumnName("Id")
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                x.OwnsOne(x => x.DadosDoFormulario, x =>
                {
                    x.Property(y => y.PeriodicaSemanal)
                        .HasColumnName("PeriodicalSemanal")
                        .HasColumnType("varchar(50)")
                        .IsRequired();

                    x.Property(y => y.TipoDeTransferencia)
                        .HasColumnName("TipoDeTranferencia")
                        .HasColumnType("varchar(50)")
                        .IsRequired();
                });
            });

            modelBuilder.Entity<Motorista>(x =>
            {
                x.ToTable("Motorista");

                x.HasKey(x => x.Id);

                x.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                x.Property(x => x.Cnh)
                    .HasColumnName("CNH")
                    .HasColumnType("varchar(50)")
                    .IsRequired();

                x.Property(x => x.Categoria)
                    .HasColumnName("Categoria")
                    .HasColumnType("varchar(50)")
                    .IsRequired();

                x.HasOne(x => x.FormularioDeInspecao)
                    .WithOne(y => y.DadosDoMotorista)
                    .HasForeignKey<Motorista>(x => x.FormularioId);
            });

            modelBuilder.Entity<Veiculo>(x =>
            {
                x.ToTable("Veiculo");

                x.HasKey(x => x.Id);

                x.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                x.Property(x => x.Placa)
                    .HasColumnName("Placa")
                    .HasColumnType("varchar(50)")
                    .IsRequired();

                x.Property(x => x.UltimaRevisao)
                    .HasColumnName("UltimaRevisao")
                    .HasColumnType("varchar(50)")
                    .IsRequired();

                x.HasOne(x => x.FormularioDeInspecao)
                    .WithOne(y => y.DadosDoVeiculo)
                    .HasForeignKey<Veiculo>(x => x.FormularioId);
            });

            modelBuilder.Entity<Pergunta>(x =>
            {
                x.ToTable("Pergunta");

                x.HasKey(x => x.Id);

                x.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                x.Property(x => x.Titulo)
                    .HasColumnName("Titulo")
                    .HasColumnType("varchar(50)")
                    .IsRequired();

                x.Property(x => x.Descricao)
                    .HasColumnName("Descricao")
                    .HasColumnType("varchar(300)");

                x.Property(x => x.TipoDeResposta)
                    .HasColumnName("Resposta")
                    .HasColumnType("varchar(50)")
                    .IsRequired();

                x.HasOne(x => x.FormularioDeInspecao)
                    .WithMany(y => y.Perguntas)
                    .HasForeignKey(x => x.FormularioId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
