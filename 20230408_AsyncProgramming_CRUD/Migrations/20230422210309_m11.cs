using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _20230408_AsyncProgramming_CRUD.Migrations
{
    public partial class m11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreateCategoryDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateCategoryDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpdatePageDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdatePageDTO", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryVM");

            migrationBuilder.DropTable(
                name: "CreateCategoryDTO");

            migrationBuilder.DropTable(
                name: "ProductVM");

            migrationBuilder.DropTable(
                name: "UpdatePageDTO");
        }
    }
}
