using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class Medias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medias_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "76cd1fba-4bef-4336-b021-c595e38c6bd1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7609bb7e-2f8b-4c2b-bb4f-4bee12c30c53", "AQAAAAEAACcQAAAAEBm2xLh/OulbJNZbyynt88HHVsqbNy8FpurUyRTY+eAkaoJd0a2w/BAMSjBjbYfPLw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_ProductId",
                table: "Medias",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af10569-b018-4fe7-a380-7d6a14c70b74",
                column: "ConcurrencyStamp",
                value: "b177b4c3-a459-4782-b425-e3705b979085");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c773b6fe-775b-43cd-b499-2225943a5845", "AQAAAAEAACcQAAAAECzpm3mNoPIJ70sS+OvAKC8q+HhvXTWYM3NoomzuvX8ew8OmFZixOLjTm4/dkocE9Q==" });
        }
    }
}
