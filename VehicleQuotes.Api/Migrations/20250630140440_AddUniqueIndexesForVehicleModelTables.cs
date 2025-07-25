﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleQuotes.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexesForVehicleModelTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_models_name_make_id",
                table: "models",
                columns: new[] { "name", "make_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_model_styles_model_id_body_type_id_size_id",
                table: "model_styles",
                columns: new[] { "model_id", "body_type_id", "size_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_model_style_years_year_model_style_id",
                table: "model_style_years",
                columns: new[] { "year", "model_style_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_models_name_make_id",
                table: "models");

            migrationBuilder.DropIndex(
                name: "ix_model_styles_model_id_body_type_id_size_id",
                table: "model_styles");

            migrationBuilder.DropIndex(
                name: "ix_model_style_years_year_model_style_id",
                table: "model_style_years");
        }
    }
}
