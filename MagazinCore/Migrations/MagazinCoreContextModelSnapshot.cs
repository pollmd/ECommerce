﻿// <auto-generated />
using System;
using MagazinCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MagazinCore.Migrations
{
    [DbContext(typeof(MagazinCoreContext))]
    partial class MagazinCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MagazinCore.Models.Cos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Creare")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UtilizatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UtilizatorId");

                    b.ToTable("Cos");
                });

            modelBuilder.Entity("MagazinCore.Models.Produs", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Acciz")
                        .HasColumnType("real");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<string>("Culoare")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Denumire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descriere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndReducere")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imagine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Reducere")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartReducere")
                        .HasColumnType("datetime2");

                    b.Property<float>("Tva")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Produs");
                });

            modelBuilder.Entity("MagazinCore.Models.Utilizatori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Creare")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parola")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utilizatori");
                });

            modelBuilder.Entity("MagazinCore.Models.Cos", b =>
                {
                    b.HasOne("MagazinCore.Models.Utilizatori", "Utilizator")
                        .WithMany()
                        .HasForeignKey("UtilizatorId");
                });
#pragma warning restore 612, 618
        }
    }
}