using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleQuotes.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "body_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_body_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "makes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_makes", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sizes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "ix_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_body_types_name",
                table: "body_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_makes_name",
                table: "makes",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_model_style_years_model_style_id1",
                table: "model_style_years",
                column: "model_style_id1");

            migrationBuilder.CreateIndex(
                name: "ix_model_style_years_year_model_style_id",
                table: "model_style_years",
                columns: new[] { "year", "model_style_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_model_styles_body_type_id1",
                table: "model_styles",
                column: "body_type_id1");

            migrationBuilder.CreateIndex(
                name: "ix_model_styles_model_id_body_type_id_size_id",
                table: "model_styles",
                columns: new[] { "model_id", "body_type_id", "size_id" },
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "ix_models_name_make_id",
                table: "models",
                columns: new[] { "name", "make_id" },
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "ix_sizes_name",
                table: "sizes",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "quote_overrides");

            migrationBuilder.DropTable(
                name: "quote_rules");

            migrationBuilder.DropTable(
                name: "quotes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "model_style_years");

            migrationBuilder.DropTable(
                name: "model_styles");

            migrationBuilder.DropTable(
                name: "body_types");

            migrationBuilder.DropTable(
                name: "models");

            migrationBuilder.DropTable(
                name: "sizes");

            migrationBuilder.DropTable(
                name: "makes");
        }
    }
}
