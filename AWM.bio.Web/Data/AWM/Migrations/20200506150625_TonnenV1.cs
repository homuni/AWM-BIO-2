using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AWM.bio.Web.Data.AWM.Migrations
{
    public partial class TonnenV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontrolleure",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontrolleure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schichtplaene",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SchichtDatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schichtplaene", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Arbeitsauftraege",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    KontrolleurId = table.Column<Guid>(nullable: true),
                    SchichtplanId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbeitsauftraege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arbeitsauftraege_Kontrolleure_KontrolleurId",
                        column: x => x.KontrolleurId,
                        principalTable: "Kontrolleure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Arbeitsauftraege_Schichtplaene_SchichtplanId",
                        column: x => x.SchichtplanId,
                        principalTable: "Schichtplaene",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gebiete",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SchichtplanId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebiete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gebiete_Schichtplaene_SchichtplanId",
                        column: x => x.SchichtplanId,
                        principalTable: "Schichtplaene",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partien",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Adresse = table.Column<string>(nullable: true),
                    Stellplatznotiz = table.Column<string>(nullable: true),
                    GebietId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partien_Gebiete_GebietId",
                        column: x => x.GebietId,
                        principalTable: "Gebiete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tonnen",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Volumen = table.Column<int>(nullable: false),
                    PartieId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tonnen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tonnen_Partien_PartieId",
                        column: x => x.PartieId,
                        principalTable: "Partien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bewertungen",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Notiz = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Foto = table.Column<byte[]>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    Defekt = table.Column<string>(nullable: true),
                    TonneId = table.Column<Guid>(nullable: true),
                    SchichtplanId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bewertungen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bewertungen_Schichtplaene_SchichtplanId",
                        column: x => x.SchichtplanId,
                        principalTable: "Schichtplaene",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bewertungen_Tonnen_TonneId",
                        column: x => x.TonneId,
                        principalTable: "Tonnen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arbeitsauftraege_KontrolleurId",
                table: "Arbeitsauftraege",
                column: "KontrolleurId");

            migrationBuilder.CreateIndex(
                name: "IX_Arbeitsauftraege_SchichtplanId",
                table: "Arbeitsauftraege",
                column: "SchichtplanId");

            migrationBuilder.CreateIndex(
                name: "IX_Bewertungen_SchichtplanId",
                table: "Bewertungen",
                column: "SchichtplanId");

            migrationBuilder.CreateIndex(
                name: "IX_Bewertungen_TonneId",
                table: "Bewertungen",
                column: "TonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebiete_SchichtplanId",
                table: "Gebiete",
                column: "SchichtplanId");

            migrationBuilder.CreateIndex(
                name: "IX_Partien_GebietId",
                table: "Partien",
                column: "GebietId");

            migrationBuilder.CreateIndex(
                name: "IX_Tonnen_PartieId",
                table: "Tonnen",
                column: "PartieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arbeitsauftraege");

            migrationBuilder.DropTable(
                name: "Bewertungen");

            migrationBuilder.DropTable(
                name: "Kontrolleure");

            migrationBuilder.DropTable(
                name: "Tonnen");

            migrationBuilder.DropTable(
                name: "Partien");

            migrationBuilder.DropTable(
                name: "Gebiete");

            migrationBuilder.DropTable(
                name: "Schichtplaene");
        }
    }
}
