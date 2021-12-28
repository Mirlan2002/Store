using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class ForWho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForWho",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForWho",
                table: "Products");
        }
    }
}
