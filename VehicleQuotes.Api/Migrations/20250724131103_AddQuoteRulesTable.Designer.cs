﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VehicleQuotes.Api.Data;

#nullable disable

namespace VehicleQuotes.Api.Migrations
{
    [DbContext(typeof(VehicleQuotesContext))]
    [Migration("20250724131103_AddQuoteRulesTable")]
    partial class AddQuoteRulesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VehicleQuotes.Api.Models.BodyType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_body_types");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_body_types_name");

                    b.ToTable("body_types", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Api.Models.Make", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_makes");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_makes_name");

                    b.ToTable("makes", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Api.Models.Model", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("MakeID")
                        .HasColumnType("integer")
                        .HasColumnName("make_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_models");

                    b.HasIndex("MakeID")
                        .HasDatabaseName("ix_models_make_id");

                    b.HasIndex("Name", "MakeID")
                        .IsUnique()
                        .HasDatabaseName("ix_models_name_make_id");

                    b.ToTable("models", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Api.Models.ModelStyle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("BodyTypeID")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("body_type_id");

                    b.Property<int>("BodyTypeID1")
                        .HasColumnType("integer")
                        .HasColumnName("body_type_id1");

                    b.Property<string>("ModelID")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("model_id");

                    b.Property<int>("ModelID1")
                        .HasColumnType("integer")
                        .HasColumnName("model_id1");

                    b.Property<string>("SizeID")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("size_id");

                    b.Property<int>("SizeID1")
                        .HasColumnType("integer")
                        .HasColumnName("size_id1");

                    b.HasKey("ID")
                        .HasName("pk_model_styles");

                    b.HasIndex("BodyTypeID1")
                        .HasDatabaseName("ix_model_styles_body_type_id1");

                    b.HasIndex("ModelID1")
                        .HasDatabaseName("ix_model_styles_model_id1");

                    b.HasIndex("SizeID1")
                        .HasDatabaseName("ix_model_styles_size_id1");

                    b.HasIndex("ModelID", "BodyTypeID", "SizeID")
                        .IsUnique()
                        .HasDatabaseName("ix_model_styles_model_id_body_type_id_size_id");

                    b.ToTable("model_styles", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Api.Models.ModelStyleYear", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ModelStyleID")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("model_style_id");

                    b.Property<int>("ModelStyleID1")
                        .HasColumnType("integer")
                        .HasColumnName("model_style_id1");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("year");

                    b.HasKey("ID")
                        .HasName("pk_model_style_years");

                    b.HasIndex("ModelStyleID1")
                        .HasDatabaseName("ix_model_style_years_model_style_id1");

                    b.HasIndex("Year", "ModelStyleID")
                        .IsUnique()
                        .HasDatabaseName("ix_model_style_years_year_model_style_id");

                    b.ToTable("model_style_years", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Api.Models.QuoteOverride", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ModelStyleYearID")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("model_style_year_id");

                    b.Property<int>("ModelStyleYearID1")
                        .HasColumnType("integer")
                        .HasColumnName("model_style_year_id1");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.HasKey("ID")
                        .HasName("pk_quote_overrides");

                    b.HasIndex("ModelStyleYearID")
                        .IsUnique()
                        .HasDatabaseName("ix_quote_overrides_model_style_year_id");

                    b.HasIndex("ModelStyleYearID1")
                        .HasDatabaseName("ix_quote_overrides_model_style_year_id1");

                    b.ToTable("quote_overrides", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Api.Models.QuoteRule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("FeatureType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("feature_type");

                    b.Property<string>("FeatureValue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("feature_value");

                    b.Property<decimal>("PriceModifier")
                        .HasColumnType("numeric")
                        .HasColumnName("price_modifier");

                    b.HasKey("ID")
                        .HasName("pk_quote_rules");

                    b.HasIndex("FeatureType", "FeatureValue")
                        .IsUnique()
                        .HasDatabaseName("ix_quote_rules_feature_type_feature_value");

                    b.ToTable("quote_rules", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Api.Models.Size", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_sizes");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_sizes_name");

                    b.ToTable("sizes", (string)null);
                });

            modelBuilder.Entity("VehicleQuotes.Api.Models.Model", b =>
                {
                    b.HasOne("VehicleQuotes.Api.Models.Make", "Make")
                        .WithMany()
                        .HasForeignKey("MakeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_models_makes_make_id");

                    b.Navigation("Make");
                });

            modelBuilder.Entity("VehicleQuotes.Api.Models.ModelStyle", b =>
                {
                    b.HasOne("VehicleQuotes.Api.Models.BodyType", "BodyType")
                        .WithMany()
                        .HasForeignKey("BodyTypeID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_model_styles_body_types_body_type_id1");

                    b.HasOne("VehicleQuotes.Api.Models.Model", "Model")
                        .WithMany("ModelStyles")
                        .HasForeignKey("ModelID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_model_styles_models_model_id1");

                    b.HasOne("VehicleQuotes.Api.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_model_styles_sizes_size_id1");

                    b.Navigation("BodyType");

                    b.Navigation("Model");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("VehicleQuotes.Api.Models.ModelStyleYear", b =>
                {
                    b.HasOne("VehicleQuotes.Api.Models.ModelStyle", "ModelStyle")
                        .WithMany("ModelStyleYears")
                        .HasForeignKey("ModelStyleID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_model_style_years_model_styles_model_style_id1");

                    b.Navigation("ModelStyle");
                });

            modelBuilder.Entity("VehicleQuotes.Api.Models.QuoteOverride", b =>
                {
                    b.HasOne("VehicleQuotes.Api.Models.ModelStyleYear", "ModelStyleYear")
                        .WithMany()
                        .HasForeignKey("ModelStyleYearID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_quote_overrides_model_style_years_model_style_year_id1");

                    b.Navigation("ModelStyleYear");
                });

            modelBuilder.Entity("VehicleQuotes.Api.Models.Model", b =>
                {
                    b.Navigation("ModelStyles");
                });

            modelBuilder.Entity("VehicleQuotes.Api.Models.ModelStyle", b =>
                {
                    b.Navigation("ModelStyleYears");
                });
#pragma warning restore 612, 618
        }
    }
}
