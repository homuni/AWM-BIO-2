using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AWM.bio.Web.Data.AWM.Migrations
{
    public partial class Kunden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KundeId",
                table: "Partien",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kunden",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Vorname = table.Column<string>(nullable: true),
                    Nachname = table.Column<string>(nullable: true),
                    KontaktAdresse = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunden", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partien_KundeId",
                table: "Partien",
                column: "KundeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partien_Kunden_KundeId",
                table: "Partien",
                column: "KundeId",
                principalTable: "Kunden",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partien_Kunden_KundeId",
                table: "Partien");

            migrationBuilder.DropTable(
                name: "Kunden");

            migrationBuilder.DropIndex(
                name: "IX_Partien_KundeId",
                table: "Partien");

            migrationBuilder.DropColumn(
                name: "KundeId",
                table: "Partien");
        }
    }
}
