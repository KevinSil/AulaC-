using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberGuard.Migrations
{
    /// <inheritdoc />
    public partial class AddReportPeriodConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_RelatorioSeguranca_Periodo",
                table: "RelatoriosSeguranca",
                sql: "PeriodoFim IS NULL OR PeriodoFim >= PeriodoInicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_RelatorioSeguranca_Periodo",
                table: "RelatoriosSeguranca");
        }
    }
}
