﻿// <auto-generated />
using System;
using AWM.bio.Web.Data.AWM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AWM.bio.Web.Data.AWM.Migrations
{
    [DbContext(typeof(TonnenDbContext))]
    partial class TonnenDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AWM.bio.Web.Data.AWM.Arbeitsauftrag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("KontrolleurId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SchichtplanId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("KontrolleurId");

                    b.HasIndex("SchichtplanId");

                    b.ToTable("Arbeitsauftraege");
                });

            modelBuilder.Entity("AWM.bio.Web.Data.AWM.Bewertung", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Defekt")
                        .HasColumnType("text");

                    b.Property<string>("FileType")
                        .HasColumnType("text");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("bytea");

                    b.Property<string>("Notiz")
                        .HasColumnType("text");

                    b.Property<Guid?>("SchichtplanId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TonneId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SchichtplanId");

                    b.HasIndex("TonneId");

                    b.ToTable("Bewertungen");
                });

            modelBuilder.Entity("AWM.bio.Web.Data.AWM.Gebiet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("SchichtplanId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SchichtplanId");

                    b.ToTable("Gebiete");
                });

            modelBuilder.Entity("AWM.bio.Web.Data.AWM.Kontrolleur", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Kontrolleure");
                });

            modelBuilder.Entity("AWM.bio.Web.Data.AWM.Kunde", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("KontaktAdresse")
                        .HasColumnType("text");

                    b.Property<string>("Nachname")
                        .HasColumnType("text");

                    b.Property<string>("Vorname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Kunden");
                });

            modelBuilder.Entity("AWM.bio.Web.Data.AWM.Partie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Adresse")
                        .HasColumnType("text");

                    b.Property<Guid?>("GebietId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("KundeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Stellplatznotiz")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GebietId");

                    b.HasIndex("KundeId");

                    b.ToTable("Partien");
                });

            modelBuilder.Entity("AWM.bio.Web.Data.AWM.Schichtplan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("SchichtDatum")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Schichtplaene");
                });

            modelBuilder.Entity("AWM.bio.Web.Data.AWM.Tonne", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PartieId")
                        .HasColumnType("uuid");

                    b.Property<int>("Volumen")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PartieId");

                    b.ToTable("Tonnen");
                });

            modelBuilder.Entity("AWM.bio.Web.Data.AWM.Arbeitsauftrag", b =>
                {
                    b.HasOne("AWM.bio.Web.Data.AWM.Kontrolleur", "Kontrolleur")
                        .WithMany("Arbeitsauftraege")
                        .HasForeignKey("KontrolleurId");

                    b.HasOne("AWM.bio.Web.Data.AWM.Schichtplan", "Schichtplan")
                        .WithMany("Arbeitsauftraege")
                        .HasForeignKey("SchichtplanId");
                });

            modelBuilder.Entity("AWM.bio.Web.Data.AWM.Bewertung", b =>
                {
                    b.HasOne("AWM.bio.Web.Data.AWM.Schichtplan", "Schichtplan")
                        .WithMany("Bewertungen")
                        .HasForeignKey("SchichtplanId");

                    b.HasOne("AWM.bio.Web.Data.AWM.Tonne", "Tonne")
                        .WithMany("Bewertungen")
                        .HasForeignKey("TonneId");
                });

            modelBuilder.Entity("AWM.bio.Web.Data.AWM.Gebiet", b =>
                {
                    b.HasOne("AWM.bio.Web.Data.AWM.Schichtplan", null)
                        .WithMany("Gebiete")
                        .HasForeignKey("SchichtplanId");
                });

            modelBuilder.Entity("AWM.bio.Web.Data.AWM.Partie", b =>
                {
                    b.HasOne("AWM.bio.Web.Data.AWM.Gebiet", "Gebiet")
                        .WithMany("Partien")
                        .HasForeignKey("GebietId");

                    b.HasOne("AWM.bio.Web.Data.AWM.Kunde", null)
                        .WithMany("Partien")
                        .HasForeignKey("KundeId");
                });

            modelBuilder.Entity("AWM.bio.Web.Data.AWM.Tonne", b =>
                {
                    b.HasOne("AWM.bio.Web.Data.AWM.Partie", "Partie")
                        .WithMany("Tonnen")
                        .HasForeignKey("PartieId");
                });
#pragma warning restore 612, 618
        }
    }
}
