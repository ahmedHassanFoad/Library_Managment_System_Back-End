using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_1.Data.Migrations
{
    public partial class AddBookIsserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IssuerName",
                table: "Events",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Events_IssuerName",
                table: "Events",
                column: "IssuerName");

            migrationBuilder.CreateTable(
                name: "bookIssuers",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    IssuerName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookIssuers", x => new { x.BookId, x.IssuerName });
                    table.ForeignKey(
                        name: "FK_bookIssuers_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookIssuers_Events_IssuerName",
                        column: x => x.IssuerName,
                        principalTable: "Events",
                        principalColumn: "IssuerName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookIssuers_IssuerName",
                table: "bookIssuers",
                column: "IssuerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookIssuers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Events_IssuerName",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "IssuerName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
