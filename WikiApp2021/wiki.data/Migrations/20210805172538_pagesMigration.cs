using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace wiki.data.Migrations
{
    public partial class pagesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Body = table.Column<string>(type: "varchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(36)", nullable: false),
                    UserEditId = table.Column<string>(type: "varchar(36)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    SpacesId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PagesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Pages");
        }
    }
}
