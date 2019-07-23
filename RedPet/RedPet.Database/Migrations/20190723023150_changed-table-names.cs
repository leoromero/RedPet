using Microsoft.EntityFrameworkCore.Migrations;

namespace RedPet.Database.Migrations
{
    public partial class changedtablenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceFrecuency_Frecuency_FrecuencyId",
                table: "ServiceFrecuency");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceFrecuency_Services_ServiceId",
                table: "ServiceFrecuency");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePricePetSizes_PetSizes_PetSizeId",
                table: "ServicePricePetSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePricePetSizes_Services_ServiceId",
                table: "ServicePricePetSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePriceServiceSubTypes_Services_ServiceId",
                table: "ServicePriceServiceSubTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePriceServiceSubTypes_ServiceSubTypes_ServiceSubTypeId",
                table: "ServicePriceServiceSubTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicePriceServiceSubTypes",
                table: "ServicePriceServiceSubTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicePricePetSizes",
                table: "ServicePricePetSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceFrecuency",
                table: "ServiceFrecuency");

            migrationBuilder.DropColumn(
                name: "ServicePriceId",
                table: "ServicePricePetSizes");

            migrationBuilder.DropColumn(
                name: "ServicePriceId",
                table: "ServiceFrecuency");

            migrationBuilder.RenameTable(
                name: "ServicePriceServiceSubTypes",
                newName: "ServiceSubServices");

            migrationBuilder.RenameTable(
                name: "ServicePricePetSizes",
                newName: "ServicePetSizes");

            migrationBuilder.RenameTable(
                name: "ServiceFrecuency",
                newName: "ServiceFrecuencies");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePriceServiceSubTypes_ServiceSubTypeId",
                table: "ServiceSubServices",
                newName: "IX_ServiceSubServices_ServiceSubTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePriceServiceSubTypes_ServiceId",
                table: "ServiceSubServices",
                newName: "IX_ServiceSubServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePricePetSizes_ServiceId",
                table: "ServicePetSizes",
                newName: "IX_ServicePetSizes_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePricePetSizes_PetSizeId",
                table: "ServicePetSizes",
                newName: "IX_ServicePetSizes_PetSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceFrecuency_ServiceId",
                table: "ServiceFrecuencies",
                newName: "IX_ServiceFrecuencies_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceFrecuency_FrecuencyId",
                table: "ServiceFrecuencies",
                newName: "IX_ServiceFrecuencies_FrecuencyId");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServicePetSizes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServiceFrecuencies",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceSubServices",
                table: "ServiceSubServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicePetSizes",
                table: "ServicePetSizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceFrecuencies",
                table: "ServiceFrecuencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceFrecuencies_Frecuency_FrecuencyId",
                table: "ServiceFrecuencies",
                column: "FrecuencyId",
                principalTable: "Frecuency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceFrecuencies_Services_ServiceId",
                table: "ServiceFrecuencies",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePetSizes_PetSizes_PetSizeId",
                table: "ServicePetSizes",
                column: "PetSizeId",
                principalTable: "PetSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePetSizes_Services_ServiceId",
                table: "ServicePetSizes",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceSubServices_Services_ServiceId",
                table: "ServiceSubServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceSubServices_ServiceSubTypes_ServiceSubTypeId",
                table: "ServiceSubServices",
                column: "ServiceSubTypeId",
                principalTable: "ServiceSubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceFrecuencies_Frecuency_FrecuencyId",
                table: "ServiceFrecuencies");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceFrecuencies_Services_ServiceId",
                table: "ServiceFrecuencies");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePetSizes_PetSizes_PetSizeId",
                table: "ServicePetSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePetSizes_Services_ServiceId",
                table: "ServicePetSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceSubServices_Services_ServiceId",
                table: "ServiceSubServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceSubServices_ServiceSubTypes_ServiceSubTypeId",
                table: "ServiceSubServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceSubServices",
                table: "ServiceSubServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServicePetSizes",
                table: "ServicePetSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceFrecuencies",
                table: "ServiceFrecuencies");

            migrationBuilder.RenameTable(
                name: "ServiceSubServices",
                newName: "ServicePriceServiceSubTypes");

            migrationBuilder.RenameTable(
                name: "ServicePetSizes",
                newName: "ServicePricePetSizes");

            migrationBuilder.RenameTable(
                name: "ServiceFrecuencies",
                newName: "ServiceFrecuency");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceSubServices_ServiceSubTypeId",
                table: "ServicePriceServiceSubTypes",
                newName: "IX_ServicePriceServiceSubTypes_ServiceSubTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceSubServices_ServiceId",
                table: "ServicePriceServiceSubTypes",
                newName: "IX_ServicePriceServiceSubTypes_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePetSizes_ServiceId",
                table: "ServicePricePetSizes",
                newName: "IX_ServicePricePetSizes_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServicePetSizes_PetSizeId",
                table: "ServicePricePetSizes",
                newName: "IX_ServicePricePetSizes_PetSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceFrecuencies_ServiceId",
                table: "ServiceFrecuency",
                newName: "IX_ServiceFrecuency_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceFrecuencies_FrecuencyId",
                table: "ServiceFrecuency",
                newName: "IX_ServiceFrecuency_FrecuencyId");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServicePricePetSizes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ServicePriceId",
                table: "ServicePricePetSizes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServiceFrecuency",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ServicePriceId",
                table: "ServiceFrecuency",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicePriceServiceSubTypes",
                table: "ServicePriceServiceSubTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServicePricePetSizes",
                table: "ServicePricePetSizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceFrecuency",
                table: "ServiceFrecuency",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceFrecuency_Frecuency_FrecuencyId",
                table: "ServiceFrecuency",
                column: "FrecuencyId",
                principalTable: "Frecuency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceFrecuency_Services_ServiceId",
                table: "ServiceFrecuency",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePricePetSizes_PetSizes_PetSizeId",
                table: "ServicePricePetSizes",
                column: "PetSizeId",
                principalTable: "PetSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePricePetSizes_Services_ServiceId",
                table: "ServicePricePetSizes",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePriceServiceSubTypes_Services_ServiceId",
                table: "ServicePriceServiceSubTypes",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePriceServiceSubTypes_ServiceSubTypes_ServiceSubTypeId",
                table: "ServicePriceServiceSubTypes",
                column: "ServiceSubTypeId",
                principalTable: "ServiceSubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
