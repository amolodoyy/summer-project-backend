using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace wiki.data.Migrations
{
    public partial class commentsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "varchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(36)", nullable: false),
                    PagesId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "date", nullable: false),
                    DateEdit = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Comments");
        }
    }
}
