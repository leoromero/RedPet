using Microsoft.EntityFrameworkCore.Migrations;

namespace RedPet.Database.Migrations
{
    public partial class removedHairTypeFromPet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_HairTypes_HairTypeId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_HairTypeId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "HairTypeId",
                table: "Pets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HairTypeId",
                table: "Pets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_HairTypeId",
                table: "Pets",
                column: "HairTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_HairTypes_HairTypeId",
                table: "Pets",
                column: "HairTypeId",
                principalTable: "HairTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
