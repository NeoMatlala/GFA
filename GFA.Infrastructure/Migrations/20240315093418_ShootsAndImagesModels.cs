using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GFA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ShootsAndImagesModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShootImage = table.Column<byte[]>(type: "Image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "Shoots",
                columns: table => new
                {
                    ShootId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImage = table.Column<byte[]>(type: "Image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoots", x => x.ShootId);
                });

            migrationBuilder.CreateTable(
                name: "ShootImages",
                columns: table => new
                {
                    ShootImagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShootId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShootImages", x => x.ShootImagesId);
                    table.ForeignKey(
                        name: "FK_ShootImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShootImages_Shoots_ShootId",
                        column: x => x.ShootId,
                        principalTable: "Shoots",
                        principalColumn: "ShootId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShootImages_ImageId",
                table: "ShootImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ShootImages_ShootId",
                table: "ShootImages",
                column: "ShootId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShootImages");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Shoots");
        }
    }
}
