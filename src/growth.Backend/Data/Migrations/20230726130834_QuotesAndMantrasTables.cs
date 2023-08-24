using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace growth.Backend.Migrations
{
    /// <inheritdoc />
    public partial class QuotesAndMantrasTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: new Guid("2b01ffc9-3a65-478f-b25d-cc6fdc47583c"));

            migrationBuilder.DeleteData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: new Guid("d0103e84-1a22-4faf-a6fd-a532a159335c"));

            migrationBuilder.CreateTable(
                name: "Mantras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Mantra = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Quote = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "Quote" },
                values: new object[,]
                {
                    { new Guid("ac6363a3-3cdb-44cd-a86c-bd7447e65d24"), "Nicole Kidman", "Life has got all those twists and turns. You've got to hold on tight and off you go." },
                    { new Guid("c27f3b2a-ccec-42b5-986f-84167e8370bd"), "Winston Churchill", "Success is not final, failure is not fatal: it is the courage to continue that counts." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mantras");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.InsertData(
                table: "Journals",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2b01ffc9-3a65-478f-b25d-cc6fdc47583c"), "Test" },
                    { new Guid("d0103e84-1a22-4faf-a6fd-a532a159335c"), "Test2" }
                });
        }
    }
}
