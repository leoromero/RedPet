using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedPet.Database.Migrations
{
    public partial class updateBooking2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Pets_PetId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "PetSizeId",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceTypeId",
                table: "Services",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Bookings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "ServiceType",
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
                    table.PrimaryKey("PK_ServiceType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_PetSizeId",
                table: "Services",
                column: "PetSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Pets_PetId",
                table: "Bookings",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_PetSizes_PetSizeId",
                table: "Services",
                column: "PetSizeId",
                principalTable: "PetSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceType_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Pets_PetId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_PetSizes_PetSizeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceType_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropIndex(
                name: "IX_Services_PetSizeId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PetSizeId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Bookings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Pets_PetId",
                table: "Bookings",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
