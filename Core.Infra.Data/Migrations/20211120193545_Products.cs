using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Infra.Data.Migrations
{
    public partial class Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
                "VALUES('Caderno', 'Caderno Espiral', 7.50, 50, 'caderno.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
                "VALUES('Estojo', 'Estojo escolar', 4.99, 20, 'estojo.jpg', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
