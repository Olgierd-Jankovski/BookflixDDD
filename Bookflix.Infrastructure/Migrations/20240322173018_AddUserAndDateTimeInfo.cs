using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookflix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAndDateTimeInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                table: "Books",
                newName: "DateTimeInfo_UpdatedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "Books",
                newName: "DateTimeInfo_CreatedDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                table: "BookReviews",
                newName: "DateTimeInfo_UpdatedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "BookReviews",
                newName: "DateTimeInfo_CreatedDateTime");

            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                table: "Authors",
                newName: "DateTimeInfo_UpdatedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "Authors",
                newName: "DateTimeInfo_CreatedDateTime");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    UserIdentityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuthorId",
                table: "Users",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "DateTimeInfo_UpdatedDateTime",
                table: "Books",
                newName: "UpdatedDateTime");

            migrationBuilder.RenameColumn(
                name: "DateTimeInfo_CreatedDateTime",
                table: "Books",
                newName: "CreatedDateTime");

            migrationBuilder.RenameColumn(
                name: "DateTimeInfo_UpdatedDateTime",
                table: "BookReviews",
                newName: "UpdatedDateTime");

            migrationBuilder.RenameColumn(
                name: "DateTimeInfo_CreatedDateTime",
                table: "BookReviews",
                newName: "CreatedDateTime");

            migrationBuilder.RenameColumn(
                name: "DateTimeInfo_UpdatedDateTime",
                table: "Authors",
                newName: "UpdatedDateTime");

            migrationBuilder.RenameColumn(
                name: "DateTimeInfo_CreatedDateTime",
                table: "Authors",
                newName: "CreatedDateTime");
        }
    }
}
