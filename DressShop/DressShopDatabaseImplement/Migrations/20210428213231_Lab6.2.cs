using Microsoft.EntityFrameworkCore.Migrations;

namespace DressShopDatabaseImplement.Migrations
{
    public partial class Lab62 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImplementerFIO",
                table: "Implementers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Implementers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Implementers");

            migrationBuilder.AddColumn<string>(
                name: "ImplementerFIO",
                table: "Implementers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
