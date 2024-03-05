using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GFA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProfileTableImageMayBeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Profiles",
                type: "image",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Profiles",
                type: "image",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "image",
                oldNullable: true);
        }
    }
}
