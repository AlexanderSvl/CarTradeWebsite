using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarTradeWebsite.Migrations
{
    /// <inheritdoc />
    public partial class next : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageModel_Posts_PostModelID",
                table: "ImageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionModel_Posts_PostModelID",
                table: "OptionModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OptionModel",
                table: "OptionModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageModel",
                table: "ImageModel");

            migrationBuilder.RenameTable(
                name: "OptionModel",
                newName: "Options");

            migrationBuilder.RenameTable(
                name: "ImageModel",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_OptionModel_PostModelID",
                table: "Options",
                newName: "IX_Options_PostModelID");

            migrationBuilder.RenameIndex(
                name: "IX_ImageModel_PostModelID",
                table: "Images",
                newName: "IX_Images_PostModelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Posts_PostModelID",
                table: "Images",
                column: "PostModelID",
                principalTable: "Posts",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Posts_PostModelID",
                table: "Options",
                column: "PostModelID",
                principalTable: "Posts",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Posts_PostModelID",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Posts_PostModelID",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Options",
                newName: "OptionModel");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "ImageModel");

            migrationBuilder.RenameIndex(
                name: "IX_Options_PostModelID",
                table: "OptionModel",
                newName: "IX_OptionModel_PostModelID");

            migrationBuilder.RenameIndex(
                name: "IX_Images_PostModelID",
                table: "ImageModel",
                newName: "IX_ImageModel_PostModelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptionModel",
                table: "OptionModel",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageModel",
                table: "ImageModel",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageModel_Posts_PostModelID",
                table: "ImageModel",
                column: "PostModelID",
                principalTable: "Posts",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionModel_Posts_PostModelID",
                table: "OptionModel",
                column: "PostModelID",
                principalTable: "Posts",
                principalColumn: "ID");
        }
    }
}
