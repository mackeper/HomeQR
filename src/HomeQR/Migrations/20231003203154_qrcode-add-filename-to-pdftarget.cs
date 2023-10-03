using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeQR.Migrations
{
    /// <inheritdoc />
    public partial class qrcodeaddfilenametopdftarget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "QrCodeTargets",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "QrCodeTargets");
        }
    }
}
