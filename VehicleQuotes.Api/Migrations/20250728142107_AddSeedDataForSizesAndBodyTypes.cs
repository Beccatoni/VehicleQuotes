using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleQuotes.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataForSizesAndBodyTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quotes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    model_style_year_id = table.Column<int>(type: "integer", nullable: true),
                    year = table.Column<string>(type: "text", nullable: false),
                    make = table.Column<string>(type: "text", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    body_type_id = table.Column<int>(type: "integer", nullable: false),
                    size_id = table.Column<int>(type: "integer", nullable: false),
                    it_moves = table.Column<bool>(type: "boolean", nullable: false),
                    has_all_wheels = table.Column<bool>(type: "boolean", nullable: false),
                    has_alloy_wheels = table.Column<bool>(type: "boolean", nullable: false),
                    has_all_tires = table.Column<bool>(type: "boolean", nullable: false),
                    has_key = table.Column<bool>(type: "boolean", nullable: false),
                    has_title = table.Column<bool>(type: "boolean", nullable: false),
                    requires_pickup = table.Column<bool>(type: "boolean", nullable: false),
                    has_engine = table.Column<bool>(type: "boolean", nullable: false),
                    has_transmission = table.Column<bool>(type: "boolean", nullable: false),
                    has_complete_interior = table.Column<bool>(type: "boolean", nullable: false),
                    offered_quote = table.Column<decimal>(type: "numeric", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_quotes", x => x.id);
                    table.ForeignKey(
                        name: "fk_quotes_body_types_body_type_id",
                        column: x => x.body_type_id,
                        principalTable: "body_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_quotes_model_style_years_model_style_year_id",
                        column: x => x.model_style_year_id,
                        principalTable: "model_style_years",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_quotes_sizes_size_id",
                        column: x => x.size_id,
                        principalTable: "sizes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "body_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Coupe" },
                    { 2, "Sedan" },
                    { 3, "Hatchback" },
                    { 4, "Wagon" },
                    { 5, "Convertible" },
                    { 6, "SUV" },
                    { 7, "Truck" },
                    { 8, "Mini Van" },
                    { 9, "Roadster" }
                });

            migrationBuilder.InsertData(
                table: "sizes",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Subcompact" },
                    { 2, "Compact" },
                    { 3, "Mid Size" },
                    { 5, "Full Size" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_quotes_body_type_id",
                table: "quotes",
                column: "body_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_quotes_model_style_year_id",
                table: "quotes",
                column: "model_style_year_id");

            migrationBuilder.CreateIndex(
                name: "ix_quotes_size_id",
                table: "quotes",
                column: "size_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quotes");

            migrationBuilder.DeleteData(
                table: "body_types",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "body_types",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "body_types",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "body_types",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "body_types",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "body_types",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "body_types",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "body_types",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "body_types",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "sizes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "sizes",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "sizes",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "sizes",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
