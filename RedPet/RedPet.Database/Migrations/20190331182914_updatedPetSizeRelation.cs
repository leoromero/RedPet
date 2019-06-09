using Microsoft.EntityFrameworkCore.Migrations;

namespace RedPet.Database.Migrations
{
    public partial class updatedPetSizeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetSizes_WeightRanges_WeightRangeId",
                table: "PetSizes");

            migrationBuilder.AlterColumn<int>(
                name: "WeightRangeId",
                table: "PetSizes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PetSizes_WeightRanges_WeightRangeId",
                table: "PetSizes",
                column: "WeightRangeId",
                principalTable: "WeightRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetSizes_WeightRanges_WeightRangeId",
                table: "PetSizes");

            migrationBuilder.AlterColumn<int>(
                name: "WeightRangeId",
                table: "PetSizes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PetSizes_WeightRanges_WeightRangeId",
                table: "PetSizes",
                column: "WeightRangeId",
                principalTable: "WeightRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
