using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarTradeWebsite.Migrations
{
    /// <inheritdoc />
    public partial class kur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MotorDisplacement",
                table: "Posts",
                newName: "EngineLayout");

            migrationBuilder.AddColumn<string>(
                name: "EngineDisplacement",
                table: "Posts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineDisplacement",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "EngineLayout",
                table: "Posts",
                newName: "MotorDisplacement");
        }
    }
}
