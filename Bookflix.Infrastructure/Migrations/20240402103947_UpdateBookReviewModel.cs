using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookflix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookReviewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReviewerIdentityGuid",
                table: "BookReviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewerIdentityGuid",
                table: "BookReviews");
        }
    }
}
