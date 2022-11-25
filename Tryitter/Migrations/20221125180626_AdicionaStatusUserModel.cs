using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tryitter.Migrations
{
    public partial class AdicionaStatusUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusPersonalizado",
                table: "Users",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusPersonalizado",
                table: "Users");
        }
    }
}
