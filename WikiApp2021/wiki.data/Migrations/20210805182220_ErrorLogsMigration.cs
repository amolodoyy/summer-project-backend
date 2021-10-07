using Microsoft.EntityFrameworkCore.Migrations;

namespace wiki.data.Migrations
{
    public partial class ErrorLogsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "ErrorLogs",
                 columns: table => new
                 {
                     ErrorLogsId = table.Column<int>(type: "int", nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                     Message = table.Column<string>(type: "varchar(max)", nullable: false),
                     StackTrace = table.Column<string>(type: "varchar(max)", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_ErrorLogs", x => x.ErrorLogsId);
                 });
        }
    

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "ErrorLogs");
        }
    }
}
