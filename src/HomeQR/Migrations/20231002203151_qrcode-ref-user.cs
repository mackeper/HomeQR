using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeQR.Migrations
{
    /// <inheritdoc />
    public partial class qrcoderefuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "QrCodes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QrCodes_IdentityUserId",
                table: "QrCodes",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodes_AspNetUsers_IdentityUserId",
                table: "QrCodes",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrCodes_AspNetUsers_IdentityUserId",
                table: "QrCodes");

            migrationBuilder.DropIndex(
                name: "IX_QrCodes_IdentityUserId",
                table: "QrCodes");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "QrCodes");
        }
    }
}
