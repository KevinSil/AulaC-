using CyberGuard.Models;
using Microsoft.EntityFrameworkCore;

namespace CyberGuard.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Equipamento> Equipamentos => Set<Equipamento>();
    public DbSet<Tecnico> Tecnicos => Set<Tecnico>();
    public DbSet<Incidente> Incidentes => Set<Incidente>();
    public DbSet<Vulnerabilidade> Vulnerabilidades => Set<Vulnerabilidade>();
    public DbSet<Intervencao> Intervencoes => Set<Intervencao>();
    public DbSet<RelatorioSeguranca> RelatoriosSeguranca => Set<RelatorioSeguranca>();
    public DbSet<RegistoAtividade> RegistosAtividade => Set<RegistoAtividade>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.ToTable("Empresas");
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(200);
            entity.Property(e => e.NIF).IsRequired().HasMaxLength(9);
            entity.HasIndex(e => e.NIF).IsUnique();
            entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Telefone).HasMaxLength(30);
            entity.Property(e => e.Morada).HasMaxLength(200);
            entity.Property(e => e.CodigoPostal).HasMaxLength(20);
            entity.Property(e => e.Localidade).HasMaxLength(120);
            entity.Property(e => e.SetorAtividade).HasMaxLength(120);
            entity.Property(e => e.Observacoes).HasColumnType("TEXT");
            entity.Property(e => e.DataRegisto).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Equipamento>(entity =>
        {
            entity.ToTable("Equipamentos");
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(200);
            entity.Property(e => e.TipoEquipamento).HasConversion<string>().HasMaxLength(50);
            entity.Property(e => e.Estado).HasConversion<string>().HasMaxLength(50);
            entity.Property(e => e.Marca).HasMaxLength(120);
            entity.Property(e => e.Modelo).HasMaxLength(120);
            entity.Property(e => e.NumeroSerie).HasMaxLength(120);
            entity.HasIndex(e => e.NumeroSerie).IsUnique();
            entity.Property(e => e.SistemaOperativo).HasMaxLength(120);
            entity.Property(e => e.EnderecoIP).HasMaxLength(45);
            entity.Property(e => e.EnderecoMAC).HasMaxLength(45);
            entity.Property(e => e.Observacoes).HasColumnType("TEXT");
            entity.HasOne(e => e.Empresa)
                .WithMany(emp => emp.Equipamentos)
                .HasForeignKey(e => e.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(e => e.EmpresaId);
        });

        modelBuilder.Entity<Tecnico>(entity =>
        {
            entity.ToTable("Tecnicos");
            entity.Property(t => t.Nome).IsRequired().HasMaxLength(200);
            entity.Property(t => t.Email).IsRequired().HasMaxLength(255);
            entity.HasIndex(t => t.Email).IsUnique();
            entity.Property(t => t.Telefone).HasMaxLength(30);
            entity.Property(t => t.Especialidade).HasConversion<string>().HasMaxLength(100);
            entity.Property(t => t.Observacoes).HasColumnType("TEXT");
        });

        modelBuilder.Entity<Incidente>(entity =>
        {
            entity.ToTable("Incidentes", table =>
                table.HasCheckConstraint("CK_Incidente_DataResolucao", "(DataResolucao IS NULL OR DataResolucao >= DataDetecao)"));
            entity.Property(i => i.Titulo).IsRequired().HasMaxLength(200);
            entity.Property(i => i.Descricao).IsRequired().HasColumnType("TEXT");
            entity.Property(i => i.TipoIncidente).HasConversion<string>().HasMaxLength(80);
            entity.Property(i => i.NivelGravidade).HasConversion<string>().HasMaxLength(50);
            entity.Property(i => i.Estado).HasConversion<string>().HasMaxLength(50);
            entity.Property(i => i.OrigemDetecao).HasConversion<string>().HasMaxLength(50);
            entity.Property(i => i.Impacto).HasColumnType("TEXT");
            entity.Property(i => i.MedidasAplicadas).HasColumnType("TEXT");
            entity.Property(i => i.Observacoes).HasColumnType("TEXT");
            entity.HasOne(i => i.Empresa)
                .WithMany(emp => emp.Incidentes)
                .HasForeignKey(i => i.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(i => i.Equipamento)
                .WithMany(eq => eq.Incidentes)
                .HasForeignKey(i => i.EquipamentoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(i => i.Tecnico)
                .WithMany(t => t.Incidentes)
                .HasForeignKey(i => i.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(i => i.EmpresaId);
            entity.HasIndex(i => i.EquipamentoId);
            entity.HasIndex(i => i.Estado);
            entity.HasIndex(i => i.NivelGravidade);
            entity.HasIndex(i => i.DataDetecao);
        });

        modelBuilder.Entity<Vulnerabilidade>(entity =>
        {
            entity.ToTable("Vulnerabilidades", table =>
            {
                table.HasCheckConstraint("CK_Vulnerabilidade_PontuacaoCVSS", "(PontuacaoCVSS IS NULL OR (PontuacaoCVSS >= 0 AND PontuacaoCVSS <= 10))");
                table.HasCheckConstraint("CK_Vulnerabilidade_DataCorrecao", "(DataCorrecao IS NULL OR DataCorrecao >= DataIdentificacao)");
            });
            entity.Property(v => v.Titulo).IsRequired().HasMaxLength(200);
            entity.Property(v => v.Descricao).IsRequired().HasColumnType("TEXT");
            entity.Property(v => v.CodigoCVE).HasMaxLength(50);
            entity.Property(v => v.Categoria).HasConversion<string>().HasMaxLength(80);
            entity.Property(v => v.NivelRisco).HasConversion<string>().HasMaxLength(50);
            entity.Property(v => v.Estado).HasConversion<string>().HasMaxLength(50);
            entity.Property(v => v.Recomendacao).HasColumnType("TEXT");
            entity.Property(v => v.Observacoes).HasColumnType("TEXT");
            entity.Property(v => v.PontuacaoCVSS).HasColumnType("decimal(3,1)");
            entity.HasOne(v => v.Empresa)
                .WithMany(emp => emp.Vulnerabilidades)
                .HasForeignKey(v => v.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(v => v.Equipamento)
                .WithMany(eq => eq.Vulnerabilidades)
                .HasForeignKey(v => v.EquipamentoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(v => v.Tecnico)
                .WithMany(t => t.Vulnerabilidades)
                .HasForeignKey(v => v.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(v => v.EmpresaId);
            entity.HasIndex(v => v.EquipamentoId);
            entity.HasIndex(v => v.NivelRisco);
            entity.HasIndex(v => v.DataIdentificacao);
        });

        modelBuilder.Entity<Intervencao>(entity =>
        {
            entity.ToTable("Intervencoes", table =>
            {
                table.HasCheckConstraint("CK_Intervencao_TempoTrabalho", "TempoTrabalho >= 0");
                table.HasCheckConstraint("CK_Intervencao_Custo", "Custo >= 0");
                table.HasCheckConstraint("CK_Intervencao_AtLeastOneAssociation", "(IncidenteId IS NOT NULL OR VulnerabilidadeId IS NOT NULL)");
            });
            entity.Property(i => i.TipoIntervencao).HasConversion<string>().HasMaxLength(80);
            entity.Property(i => i.DescricaoTrabalho).IsRequired().HasColumnType("TEXT");
            entity.Property(i => i.SolucaoAplicada).HasColumnType("TEXT");
            entity.Property(i => i.Resultado).HasConversion<string>().HasMaxLength(50);
            entity.Property(i => i.Observacoes).HasColumnType("TEXT");
            entity.Property(i => i.TempoTrabalho).HasColumnType("decimal(18,2)");
            entity.Property(i => i.Custo).HasColumnType("decimal(18,2)");
            entity.HasOne(i => i.Tecnico)
                .WithMany(t => t.Intervencoes)
                .HasForeignKey(i => i.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(i => i.Incidente)
                .WithMany(inc => inc.Intervencoes)
                .HasForeignKey(i => i.IncidenteId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(i => i.Vulnerabilidade)
                .WithMany(v => v.Intervencoes)
                .HasForeignKey(i => i.VulnerabilidadeId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(i => i.TecnicoId);
            entity.HasIndex(i => i.IncidenteId);
            entity.HasIndex(i => i.VulnerabilidadeId);
            entity.HasIndex(i => i.DataIntervencao);
        });

        modelBuilder.Entity<RelatorioSeguranca>(entity =>
        {
            entity.ToTable("RelatoriosSeguranca", table =>
            {
                table.HasCheckConstraint("CK_RelatorioSeguranca_NumeroIncidentes", "NumeroIncidentes >= 0");
                table.HasCheckConstraint("CK_RelatorioSeguranca_NumeroVulnerabilidades", "NumeroVulnerabilidades >= 0");
                table.HasCheckConstraint("CK_RelatorioSeguranca_Periodo", "PeriodoFim IS NULL OR PeriodoFim >= PeriodoInicio");
            });
            entity.Property(r => r.Titulo).IsRequired().HasMaxLength(200);
            entity.Property(r => r.Descricao).HasColumnType("TEXT");
            entity.Property(r => r.TipoRelatorio).HasConversion<string>().HasMaxLength(80);
            entity.Property(r => r.Recomendacoes).HasColumnType("TEXT");
            entity.Property(r => r.Observacoes).HasColumnType("TEXT");
            entity.Property(r => r.NivelSeguranca).HasConversion<string>().HasMaxLength(50);
            entity.HasOne(r => r.Empresa)
                .WithMany(emp => emp.RelatoriosSeguranca)
                .HasForeignKey(r => r.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(r => r.Tecnico)
                .WithMany(t => t.RelatoriosSeguranca)
                .HasForeignKey(r => r.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(r => r.EmpresaId);
            entity.HasIndex(r => r.TecnicoId);
            entity.HasIndex(r => r.DataCriacao);
        });

        modelBuilder.Entity<RegistoAtividade>(entity =>
        {
            entity.ToTable("RegistosAtividade");
            entity.Property(r => r.TipoAtividade).HasConversion<string>().HasMaxLength(50);
            entity.Property(r => r.Descricao).IsRequired().HasMaxLength(1000);
            entity.Property(r => r.EntidadeAfetada).HasMaxLength(200);
            entity.Property(r => r.IdentificadorEntidade).HasMaxLength(200);
            entity.Property(r => r.Observacoes).HasColumnType("TEXT");
            entity.HasOne(r => r.Tecnico)
                .WithMany(t => t.RegistosAtividade)
                .HasForeignKey(r => r.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(r => r.Empresa)
                .WithMany(emp => emp.RegistosAtividade)
                .HasForeignKey(r => r.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(r => r.TecnicoId);
            entity.HasIndex(r => r.EmpresaId);
            entity.HasIndex(r => r.DataAtividade);
        });
    }
}
