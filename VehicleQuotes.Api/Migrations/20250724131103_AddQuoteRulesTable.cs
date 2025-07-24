using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VehicleQuotes.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddQuoteRulesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quote_overrides",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    model_style_year_id = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    model_style_year_id1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quote_overrides", x => x.id);
                    table.ForeignKey(
                        name: "fk_quote_overrides_model_style_years_model_style_year_id1",
                        column: x => x.model_style_year_id1,
                        principalTable: "model_style_years",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quote_rules",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    feature_type = table.Column<string>(type: "text", nullable: false),
                    feature_value = table.Column<string>(type: "text", nullable: false),
                    price_modifier = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quote_rules", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_quote_overrides_model_style_year_id",
                table: "quote_overrides",
                column: "model_style_year_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_quote_overrides_model_style_year_id1",
                table: "quote_overrides",
                column: "model_style_year_id1");

            migrationBuilder.CreateIndex(
                name: "ix_quote_rules_feature_type_feature_value",
                table: "quote_rules",
                columns: new[] { "feature_type", "feature_value" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quote_overrides");

            migrationBuilder.DropTable(
                name: "quote_rules");
        }
    }
}
