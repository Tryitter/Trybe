using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tryitter.Migrations
{
    public partial class PopulaDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // users
            migrationBuilder.Sql("Insert Into Users (Name, Email, Password, ModuloAtual, StatusPersonalizado) Values ('Carlos', 'carlos@carlos.com.br', '12345678', 'Modulo 1', 'Estudando')");
            migrationBuilder.Sql("Insert Into Users (Name, Email, Password, ModuloAtual, StatusPersonalizado) Values ('Paolo', 'paolo@paolo.com.br', '12345678', 'Modulo 1', 'Estudando')");
            migrationBuilder.Sql("Insert Into Users (Name, Email, Password, ModuloAtual, StatusPersonalizado) Values ('Luis', 'luis@luis.com.br', '12345678', 'Modulo 1', 'Estudando')");

            // posts
            migrationBuilder.Sql("Insert into Posts(Titulo, Descricao, ImageUrl, DataPost, UserId) Values ('Post do Carlos', 'Primeiro Post do Carlos', 'https://www.google.com.br/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png', now(), 1)");
            migrationBuilder.Sql("Insert into Posts(Titulo, Descricao, ImageUrl, DataPost, UserId) Values ('Post do Paolo', 'Primeiro Post do Paolo', 'https://www.google.com.br/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png', now(), 2)");
            migrationBuilder.Sql("Insert into Posts(Titulo, Descricao, ImageUrl, DataPost, UserId) Values ('Post do Paolo', 'Segundo Post do Paolo', 'https://www.google.com.br/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png', now(), 2)");
            migrationBuilder.Sql("Insert into Posts(Titulo, Descricao, ImageUrl, DataPost, UserId) Values ('Post do Luis', 'Primeiro Post do Luis', 'https://www.google.com.br/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png', now(), 3)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From Users Where Name In ('Carlos', 'Paolo', 'Luis')");
            migrationBuilder.Sql("Delete From Posts Where Titulo In ('Post do Carlos', 'Post do Paolo', 'Post do Luis')");
        }
    }
}
