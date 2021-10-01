using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorBasketballUdemy.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raptor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerNum = table.Column<int>(nullable: false),
                    PlayerName = table.Column<string>(nullable: true),
                    PlayerPosition = table.Column<string>(nullable: true),
                    PlayerHeight = table.Column<string>(nullable: true),
                    PlayerSalary = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raptor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Raptor");
        }
    }
}
