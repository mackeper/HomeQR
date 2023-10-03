using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeQR.Migrations
{
    /// <inheritdoc />
    public partial class qrcodeaddtargets4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetType",
                table: "QrCodeTargets");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "QrCodeTargets",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "QrCodeTargets",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "TargetType",
                table: "QrCodeTargets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
