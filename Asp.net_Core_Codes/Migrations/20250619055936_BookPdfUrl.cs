using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.net_Core_Codes.Migrations
{
    /// <inheritdoc />
    public partial class BookPdfUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookPdfUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookPdfUrl",
                table: "Books");
        }
    }
}
