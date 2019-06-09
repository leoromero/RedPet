using Microsoft.EntityFrameworkCore.Migrations;

namespace RedPet.Database.Migrations
{
    public partial class updateBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PetId",
                table: "Bookings",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Pets_PetId",
                table: "Bookings",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Pets_PetId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PetId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Bookings");
        }
    }
}
