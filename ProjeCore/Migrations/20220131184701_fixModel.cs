using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjeCore.Migrations
{
    public partial class fixModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Birims_BirimBrimId",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_BirimBrimId",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "BirimBrimId",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "BrimId",
                table: "Personels");

            migrationBuilder.AddColumn<int>(
                name: "BirimId",
                table: "Personels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personels_BirimId",
                table: "Personels",
                column: "BirimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Birims_BirimId",
                table: "Personels",
                column: "BirimId",
                principalTable: "Birims",
                principalColumn: "BrimId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Birims_BirimId",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_BirimId",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "BirimId",
                table: "Personels");

            migrationBuilder.AddColumn<int>(
                name: "BirimBrimId",
                table: "Personels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrimId",
                table: "Personels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personels_BirimBrimId",
                table: "Personels",
                column: "BirimBrimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Birims_BirimBrimId",
                table: "Personels",
                column: "BirimBrimId",
                principalTable: "Birims",
                principalColumn: "BrimId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
