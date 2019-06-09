using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedPet.Database.Migrations
{
    public partial class addedVet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "VaccinesUpToDate",
                table: "Pets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VetId",
                table: "Pets",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InactivationDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vet", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_VetId",
                table: "Pets",
                column: "VetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Vet_VetId",
                table: "Pets",
                column: "VetId",
                principalTable: "Vet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Vet_VetId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "Vet");

            migrationBuilder.DropIndex(
                name: "IX_Pets_VetId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "VaccinesUpToDate",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "VetId",
                table: "Pets");
        }
    }
}
