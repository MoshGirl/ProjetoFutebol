﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFutebol.Infraestrutura;

#nullable disable

namespace ProjetoFutebol.Infraestrutura.Migrations
{
    [DbContext(typeof(ProjetoFutebolDbContext))]
    partial class ProjetoFutebolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetoFutebol.Dominio.Entidades.TimeModels.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AreaId"));

                    b.Property<string>("AreaPai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "parentArea");

                    b.Property<int?>("AreaPaiId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "parentAreaId");

                    b.Property<string>("Bandeira")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "flag");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "code");

                    b.Property<string>("CodigoPais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "countryCode");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("AreaId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("ProjetoFutebol.Dominio.Entidades.TimeModels.AreaFilha", b =>
                {
                    b.Property<int>("AreaFilhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AreaFilhaId"));

                    b.Property<int?>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("AreaPai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "parentArea");

                    b.Property<int>("AreaPaiId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "parentAreaId");

                    b.Property<string>("Bandeira")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "flag");

                    b.Property<string>("CodigoPais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "countryCode");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("AreaFilhaId");

                    b.HasIndex("AreaId");

                    b.ToTable("AreaFilhas");

                    b.HasAnnotation("Relational:JsonPropertyName", "childAreas");
                });

            modelBuilder.Entity("ProjetoFutebol.Dominio.Entidades.TimeModels.AreaFilha", b =>
                {
                    b.HasOne("ProjetoFutebol.Dominio.Entidades.TimeModels.Area", null)
                        .WithMany("AreasFilhas")
                        .HasForeignKey("AreaId");
                });

            modelBuilder.Entity("ProjetoFutebol.Dominio.Entidades.TimeModels.Area", b =>
                {
                    b.Navigation("AreasFilhas");
                });
#pragma warning restore 612, 618
        }
    }
}
