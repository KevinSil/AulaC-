using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberGuard.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    NIF = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Morada = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    CodigoPostal = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Localidade = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    SetorAtividade = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    DataRegisto = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Ativa = table.Column<bool>(type: "INTEGER", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Especialidade = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NivelExperiencia = table.Column<int>(type: "INTEGER", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    TipoEquipamento = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Marca = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    Modelo = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    NumeroSerie = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    SistemaOperativo = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    EnderecoIP = table.Column<string>(type: "TEXT", maxLength: 45, nullable: true),
                    EnderecoMAC = table.Column<string>(type: "TEXT", maxLength: 45, nullable: true),
                    DataRegisto = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UltimaVerificacao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistosAtividade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TecnicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoAtividade = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    EntidadeAfetada = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    IdentificadorEntidade = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    DataAtividade = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistosAtividade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistosAtividade_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistosAtividade_Tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelatoriosSeguranca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TecnicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    TipoRelatorio = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PeriodoInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PeriodoFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    NumeroIncidentes = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroVulnerabilidades = table.Column<int>(type: "INTEGER", nullable: false),
                    NivelSeguranca = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Recomendacoes = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatoriosSeguranca", x => x.Id);
                    table.CheckConstraint("CK_RelatorioSeguranca_NumeroIncidentes", "NumeroIncidentes >= 0");
                    table.CheckConstraint("CK_RelatorioSeguranca_NumeroVulnerabilidades", "NumeroVulnerabilidades >= 0");
                    table.ForeignKey(
                        name: "FK_RelatoriosSeguranca_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelatoriosSeguranca_Tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incidentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipamentoId = table.Column<int>(type: "INTEGER", nullable: true),
                    TecnicoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: false),
                    TipoIncidente = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    NivelGravidade = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DataDetecao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataResolucao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OrigemDetecao = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Impacto = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    MedidasAplicadas = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidentes", x => x.Id);
                    table.CheckConstraint("CK_Incidente_DataResolucao", "(DataResolucao IS NULL OR DataResolucao >= DataDetecao)");
                    table.ForeignKey(
                        name: "FK_Incidentes_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidentes_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidentes_Tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vulnerabilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpresaId = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipamentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TecnicoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: false),
                    CodigoCVE = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Categoria = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    NivelRisco = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PontuacaoCVSS = table.Column<decimal>(type: "decimal(3,1)", nullable: true),
                    DataIdentificacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataCorrecao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Recomendacao = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vulnerabilidades", x => x.Id);
                    table.CheckConstraint("CK_Vulnerabilidade_DataCorrecao", "(DataCorrecao IS NULL OR DataCorrecao >= DataIdentificacao)");
                    table.CheckConstraint("CK_Vulnerabilidade_PontuacaoCVSS", "(PontuacaoCVSS IS NULL OR (PontuacaoCVSS >= 0 AND PontuacaoCVSS <= 10))");
                    table.ForeignKey(
                        name: "FK_Vulnerabilidades_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vulnerabilidades_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vulnerabilidades_Tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Intervencoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TecnicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    IncidenteId = table.Column<int>(type: "INTEGER", nullable: true),
                    VulnerabilidadeId = table.Column<int>(type: "INTEGER", nullable: true),
                    DataIntervencao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TipoIntervencao = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    DescricaoTrabalho = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: false),
                    SolucaoAplicada = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    TempoTrabalho = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Resultado = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervencoes", x => x.Id);
                    table.CheckConstraint("CK_Intervencao_AtLeastOneAssociation", "(IncidenteId IS NOT NULL OR VulnerabilidadeId IS NOT NULL)");
                    table.CheckConstraint("CK_Intervencao_Custo", "Custo >= 0");
                    table.CheckConstraint("CK_Intervencao_TempoTrabalho", "TempoTrabalho >= 0");
                    table.ForeignKey(
                        name: "FK_Intervencoes_Incidentes_IncidenteId",
                        column: x => x.IncidenteId,
                        principalTable: "Incidentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Intervencoes_Tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Intervencoes_Vulnerabilidades_VulnerabilidadeId",
                        column: x => x.VulnerabilidadeId,
                        principalTable: "Vulnerabilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Email",
                table: "Empresas",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_NIF",
                table: "Empresas",
                column: "NIF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_EmpresaId",
                table: "Equipamentos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_NumeroSerie",
                table: "Equipamentos",
                column: "NumeroSerie",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_DataDetecao",
                table: "Incidentes",
                column: "DataDetecao");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_EmpresaId",
                table: "Incidentes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_EquipamentoId",
                table: "Incidentes",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_Estado",
                table: "Incidentes",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_NivelGravidade",
                table: "Incidentes",
                column: "NivelGravidade");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_TecnicoId",
                table: "Incidentes",
                column: "TecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Intervencoes_DataIntervencao",
                table: "Intervencoes",
                column: "DataIntervencao");

            migrationBuilder.CreateIndex(
                name: "IX_Intervencoes_IncidenteId",
                table: "Intervencoes",
                column: "IncidenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Intervencoes_TecnicoId",
                table: "Intervencoes",
                column: "TecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Intervencoes_VulnerabilidadeId",
                table: "Intervencoes",
                column: "VulnerabilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistosAtividade_DataAtividade",
                table: "RegistosAtividade",
                column: "DataAtividade");

            migrationBuilder.CreateIndex(
                name: "IX_RegistosAtividade_EmpresaId",
                table: "RegistosAtividade",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistosAtividade_TecnicoId",
                table: "RegistosAtividade",
                column: "TecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatoriosSeguranca_DataCriacao",
                table: "RelatoriosSeguranca",
                column: "DataCriacao");

            migrationBuilder.CreateIndex(
                name: "IX_RelatoriosSeguranca_EmpresaId",
                table: "RelatoriosSeguranca",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatoriosSeguranca_TecnicoId",
                table: "RelatoriosSeguranca",
                column: "TecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tecnicos_Email",
                table: "Tecnicos",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vulnerabilidades_DataIdentificacao",
                table: "Vulnerabilidades",
                column: "DataIdentificacao");

            migrationBuilder.CreateIndex(
                name: "IX_Vulnerabilidades_EmpresaId",
                table: "Vulnerabilidades",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vulnerabilidades_EquipamentoId",
                table: "Vulnerabilidades",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vulnerabilidades_NivelRisco",
                table: "Vulnerabilidades",
                column: "NivelRisco");

            migrationBuilder.CreateIndex(
                name: "IX_Vulnerabilidades_TecnicoId",
                table: "Vulnerabilidades",
                column: "TecnicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intervencoes");

            migrationBuilder.DropTable(
                name: "RegistosAtividade");

            migrationBuilder.DropTable(
                name: "RelatoriosSeguranca");

            migrationBuilder.DropTable(
                name: "Incidentes");

            migrationBuilder.DropTable(
                name: "Vulnerabilidades");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
