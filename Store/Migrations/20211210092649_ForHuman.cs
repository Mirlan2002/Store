using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class ForHuman : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForWho",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ForHuman",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForHuman",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ForWho",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
