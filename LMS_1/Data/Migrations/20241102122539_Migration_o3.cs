using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_1.Data.Migrations
{
    public partial class Migration_o3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookIssuers_Events_IssuerName",
                table: "bookIssuers");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Books_BookId",
                table: "Events");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Events_IssuerName",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_BookId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookIssuers",
                table: "bookIssuers");

            migrationBuilder.DropIndex(
                name: "IX_bookIssuers_IssuerName",
                table: "bookIssuers");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IssuerName",
                table: "bookIssuers");

            migrationBuilder.AlterColumn<string>(
                name: "IssuerName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "bookIssuers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookIssuers",
                table: "bookIssuers",
                columns: new[] { "BookId", "EventId" });

            migrationBuilder.CreateIndex(
                name: "IX_bookIssuers_EventId",
                table: "bookIssuers",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookIssuers_Events_EventId",
                table: "bookIssuers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookIssuers_Events_EventId",
                table: "bookIssuers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookIssuers",
                table: "bookIssuers");

            migrationBuilder.DropIndex(
                name: "IX_bookIssuers_EventId",
                table: "bookIssuers");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "bookIssuers");

            migrationBuilder.AlterColumn<string>(
                name: "IssuerName",
                table: "Events",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IssuerName",
                table: "bookIssuers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Events_IssuerName",
                table: "Events",
                column: "IssuerName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookIssuers",
                table: "bookIssuers",
                columns: new[] { "BookId", "IssuerName" });

            migrationBuilder.CreateIndex(
                name: "IX_Events_BookId",
                table: "Events",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_bookIssuers_IssuerName",
                table: "bookIssuers",
                column: "IssuerName");

            migrationBuilder.AddForeignKey(
                name: "FK_bookIssuers_Events_IssuerName",
                table: "bookIssuers",
                column: "IssuerName",
                principalTable: "Events",
                principalColumn: "IssuerName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Books_BookId",
                table: "Events",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
