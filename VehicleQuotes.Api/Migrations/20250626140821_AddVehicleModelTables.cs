﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VehicleQuotes.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleModelTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    make_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_models", x => x.id);
                    table.ForeignKey(
                        name: "fk_models_makes_make_id",
                        column: x => x.make_id,
                        principalTable: "makes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "model_styles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    model_id = table.Column<string>(type: "text", nullable: false),
                    body_type_id = table.Column<string>(type: "text", nullable: false),
                    size_id = table.Column<string>(type: "text", nullable: false),
                    model_id1 = table.Column<int>(type: "integer", nullable: false),
                    body_type_id1 = table.Column<int>(type: "integer", nullable: false),
                    size_id1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_model_styles", x => x.id);
                    table.ForeignKey(
                        name: "fk_model_styles_body_types_body_type_id1",
                        column: x => x.body_type_id1,
                        principalTable: "body_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_model_styles_models_model_id1",
                        column: x => x.model_id1,
                        principalTable: "models",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_model_styles_sizes_size_id1",
                        column: x => x.size_id1,
                        principalTable: "sizes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "model_style_years",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    year = table.Column<string>(type: "text", nullable: false),
                    model_style_id = table.Column<string>(type: "text", nullable: false),
                    model_style_id1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_model_style_years", x => x.id);
                    table.ForeignKey(
                        name: "fk_model_style_years_model_styles_model_style_id1",
                        column: x => x.model_style_id1,
                        principalTable: "model_styles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_model_style_years_model_style_id1",
                table: "model_style_years",
                column: "model_style_id1");

            migrationBuilder.CreateIndex(
                name: "ix_model_styles_body_type_id1",
                table: "model_styles",
                column: "body_type_id1");

            migrationBuilder.CreateIndex(
                name: "ix_model_styles_model_id1",
                table: "model_styles",
                column: "model_id1");

            migrationBuilder.CreateIndex(
                name: "ix_model_styles_size_id1",
                table: "model_styles",
                column: "size_id1");

            migrationBuilder.CreateIndex(
                name: "ix_models_make_id",
                table: "models",
                column: "make_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "model_style_years");

            migrationBuilder.DropTable(
                name: "model_styles");

            migrationBuilder.DropTable(
                name: "models");
        }
    }
}
