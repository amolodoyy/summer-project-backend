using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wiki.data.Migrations
{
    public partial class LikesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                            name: "Likes",
                            columns: table => new
                            {
                                PagesId = table.Column<int>(type: "int", nullable: false)
                                    .Annotation("SqlServer:Identity", "1, 1"),
                                UserId = table.Column<string>(type: "varchar(36)", nullable: false),
                          },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_Likes", x => x.PagesId);
                            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Likes");
        }
    }
}
