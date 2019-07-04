using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedPet.Database.Migrations
{
    public partial class addedFrecuencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Frecuency_FrecuencyId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_FrecuencyId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "FrecuencyId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "FrecuendyId",
                table: "Services");

            migrationBuilder.CreateTable(
                name: "ServiceFrecuency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InactivationDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ServicePriceId = table.Column<int>(nullable: false),
                    FrecuencyId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceFrecuency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceFrecuency_Frecuency_FrecuencyId",
                        column: x => x.FrecuencyId,
                        principalTable: "Frecuency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceFrecuency_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFrecuency_FrecuencyId",
                table: "ServiceFrecuency",
                column: "FrecuencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFrecuency_ServiceId",
                table: "ServiceFrecuency",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceFrecuency");

            migrationBuilder.AddColumn<int>(
                name: "FrecuencyId",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrecuendyId",
                table: "Services",
                nullable: false,
                defaultValue: 0);

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
    }
}
