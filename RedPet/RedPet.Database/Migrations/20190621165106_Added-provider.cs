using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedPet.Database.Migrations
{
    public partial class Addedprovider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Taxes",
                table: "Services",
                newName: "WeeklyPrice");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Services",
                newName: "MonthlyPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "DailyPrice",
                table: "Services",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProviderId",
                table: "Services",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IdentificationType",
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
                    table.PrimaryKey("PK_IdentificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InactivationDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Nation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InactivationDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Identification = table.Column<string>(nullable: true),
                    NationalityId = table.Column<int>(nullable: false),
                    IdentificationTypeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provider_IdentificationType_IdentificationTypeId",
                        column: x => x.IdentificationTypeId,
                        principalTable: "IdentificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Provider_Nationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Provider_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_ProviderId",
                table: "Services",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_IdentificationTypeId",
                table: "Provider",
                column: "IdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_NationalityId",
                table: "Provider",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_UserId",
                table: "Provider",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Provider_ProviderId",
                table: "Services",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Provider_ProviderId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "IdentificationType");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropIndex(
                name: "IX_Services_ProviderId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DailyPrice",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "WeeklyPrice",
                table: "Services",
                newName: "Taxes");

            migrationBuilder.RenameColumn(
                name: "MonthlyPrice",
                table: "Services",
                newName: "Price");
        }
    }
}
