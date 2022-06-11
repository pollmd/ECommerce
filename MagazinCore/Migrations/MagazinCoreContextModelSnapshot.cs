﻿// <auto-generated />
using System;
using MagazinCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MagazinCore.Migrations
{
    [DbContext(typeof(MagazinCoreContext))]
    partial class MagazinCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MagazinCore.Models.Cos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Creare")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("UtilizatorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UtilizatorId");

                    b.ToTable("Cos");
                });

            modelBuilder.Entity("MagazinCore.Models.CosElemente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Cantitate")
                        .HasColumnType("integer");

                    b.Property<int>("CosId")
                        .HasColumnType("integer");

                    b.Property<int>("ProdusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CosId");

                    b.HasIndex("ProdusId");

                    b.ToTable("CosElemente");
                });

            modelBuilder.Entity("MagazinCore.Models.Produs", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<float>("Acciz")
                        .HasColumnType("real");

                    b.Property<int>("Cantitate")
                        .HasColumnType("integer");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<string>("Culoare")
                        .HasColumnType("text");

                    b.Property<string>("Denumire")
                        .HasColumnType("text");

                    b.Property<string>("Descriere")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndReducere")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Imagine")
                        .HasColumnType("text");

                    b.Property<string>("Marime")
                        .HasColumnType("text");

                    b.Property<float>("Reducere")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartReducere")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("Tva")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Produs");
                });

            modelBuilder.Entity("MagazinCore.Models.Utilizatori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Creare")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nume")
                        .HasColumnType("text");

                    b.Property<string>("Parola")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Telefon")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Utilizatori");
                });

            modelBuilder.Entity("MagazinCore.Models.Cos", b =>
                {
                    b.HasOne("MagazinCore.Models.Utilizatori", "Utilizator")
                        .WithMany()
                        .HasForeignKey("UtilizatorId");
                });

            modelBuilder.Entity("MagazinCore.Models.CosElemente", b =>
                {
                    b.HasOne("MagazinCore.Models.Cos", "Cos")
                        .WithMany()
                        .HasForeignKey("CosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MagazinCore.Models.Produs", "Produs")
                        .WithMany()
                        .HasForeignKey("ProdusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
