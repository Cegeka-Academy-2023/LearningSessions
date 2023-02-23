using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShelter.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnsById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Persons_DonatedById",
                table: "Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Persons_AdoptedById",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Persons_RescuedById",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "RescuedById",
                table: "Pets",
                newName: "RescuerId");

            migrationBuilder.RenameColumn(
                name: "AdoptedById",
                table: "Pets",
                newName: "AdopterId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_RescuedById",
                table: "Pets",
                newName: "IX_Pets_RescuerId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_AdoptedById",
                table: "Pets",
                newName: "IX_Pets_AdopterId");

            migrationBuilder.RenameColumn(
                name: "DonatedById",
                table: "Donations",
                newName: "DonorId");

            migrationBuilder.RenameIndex(
                name: "IX_Donations_DonatedById",
                table: "Donations",
                newName: "IX_Donations_DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Persons_DonorId",
                table: "Donations",
                column: "DonorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Persons_AdopterId",
                table: "Pets",
                column: "AdopterId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Persons_RescuerId",
                table: "Pets",
                column: "RescuerId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Persons_DonorId",
                table: "Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Persons_AdopterId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Persons_RescuerId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "RescuerId",
                table: "Pets",
                newName: "RescuedById");

            migrationBuilder.RenameColumn(
                name: "AdopterId",
                table: "Pets",
                newName: "AdoptedById");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_RescuerId",
                table: "Pets",
                newName: "IX_Pets_RescuedById");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_AdopterId",
                table: "Pets",
                newName: "IX_Pets_AdoptedById");

            migrationBuilder.RenameColumn(
                name: "DonorId",
                table: "Donations",
                newName: "DonatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Donations_DonorId",
                table: "Donations",
                newName: "IX_Donations_DonatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Persons_DonatedById",
                table: "Donations",
                column: "DonatedById",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Persons_AdoptedById",
                table: "Pets",
                column: "AdoptedById",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Persons_RescuedById",
                table: "Pets",
                column: "RescuedById",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
