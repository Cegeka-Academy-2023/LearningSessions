using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShelter.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddFundraiser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FundraiserId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fundraisers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GoalValue = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CurrentDonation = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundraisers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fundraisers_Persons_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FundraiserId",
                table: "Persons",
                column: "FundraiserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fundraisers_OwnerId",
                table: "Fundraisers",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Fundraisers_FundraiserId",
                table: "Persons",
                column: "FundraiserId",
                principalTable: "Fundraisers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Fundraisers_FundraiserId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Fundraisers");

            migrationBuilder.DropIndex(
                name: "IX_Persons_FundraiserId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "FundraiserId",
                table: "Persons");
        }
    }
}
