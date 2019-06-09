using Microsoft.EntityFrameworkCore.Migrations;

namespace RedPet.Database.Migrations
{
    public partial class addedWeightrangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WeightRanges",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "WeightRanges");
        }
    }
}
