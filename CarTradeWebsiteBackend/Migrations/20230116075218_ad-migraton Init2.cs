using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarTradeWebsite.Migrations
{
    /// <inheritdoc />
    public partial class admigratonInit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Posts",
                newName: "DateOfCreation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfCreation",
                table: "Posts",
                newName: "CreatedDate");
        }
    }
}
