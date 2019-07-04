using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedPet.Database.Migrations
{
    public partial class addedFrecuency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecurrentService",
                table: "Services");

            migrationBuilder.AddColumn<int>(
                name: "FrecuencyId",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrecuendyId",
                table: "Services",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Frecuency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InactivationDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frecuency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_FrecuencyId",
                table: "Services",
                column: "FrecuencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Frecuency_FrecuencyId",
                table: "Services",
                column: "FrecuencyId",
                principalTable: "Frecuency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Frecuency_FrecuencyId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Frecuency");

            migrationBuilder.DropIndex(
                name: "IX_Services_FrecuencyId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "FrecuencyId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "FrecuendyId",
                table: "Services");

            migrationBuilder.AddColumn<bool>(
                name: "RecurrentService",
                table: "Services",
                nullable: false,
                defaultValue: false);
        }
    }
}
