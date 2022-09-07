using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LifeShare.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    Dt_Entrada = table.Column<DateTime>(nullable: false),
                    Dt_Saida = table.Column<DateTime>(nullable: true),
                    Placa = table.Column<string>(maxLength: 8, nullable: false),
                    Cor_Carro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Cliente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Cliente");
        }
    }
}
