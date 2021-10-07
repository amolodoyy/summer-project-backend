using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace wiki.data.Migrations
{
    public partial class usersEditMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersEdit",
                columns: table => new
                {
                    UsersEditId = table.Column<string>(type: "varchar(36)", nullable: false),

                    UserId = table.Column<string>(type: "varchar(36)", nullable: false),
                    DateEdit = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEdit", x => x.UsersEditId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "UsersEdit");
        }
    }
}
