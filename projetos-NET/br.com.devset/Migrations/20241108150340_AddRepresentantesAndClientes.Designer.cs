﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using br.com.devset.Data;

#nullable disable

namespace br.com.devset.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241108150340_AddRepresentantesAndClientes")]
    partial class AddRepresentantesAndClientes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("br.com.devset.Models.ClienteModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Observacao")
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)");

                    b.Property<int?>("RepresentanteId")
                        .IsRequired()
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ClienteId");

                    b.HasIndex("RepresentanteId");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("br.com.devset.Models.RepresentanteModel", b =>
                {
                    b.Property<int>("RepresentanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RepresentanteId"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("NomeRepresentante")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("RepresentanteId");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("Representates", (string)null);
                });

            modelBuilder.Entity("br.com.devset.Models.ClienteModel", b =>
                {
                    b.HasOne("br.com.devset.Models.RepresentanteModel", "Representante")
                        .WithMany()
                        .HasForeignKey("RepresentanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Representante");
                });
#pragma warning restore 612, 618
        }
    }
}