using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tryitter.Migrations
{
    public partial class PopulaDbComStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Users (Name, Email, Password, ModuloAtual, StatusPersonalizado) Values ('Carlos', 'carlos@carlos.com.br', '12345678', 'Modulo 1', 'Estudando')");
            migrationBuilder.Sql("Insert Into Users (Name, Email, Password, ModuloAtual, StatusPersonalizado) Values ('Paolo', 'paolo@paolo.com.br', '12345678', 'Modulo 1', 'Estudando')");
            migrationBuilder.Sql("Insert Into Users (Name, Email, Password, ModuloAtual, StatusPersonalizado) Values ('Luis', 'luis@luis.com.br', '12345678', 'Modulo 1', 'Estudando')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From Users Where Name In ('Carlos', 'Paolo', 'Luis')");
        }
    }
}
