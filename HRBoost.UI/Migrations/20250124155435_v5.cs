using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBoost.UI.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessStar",
                table: "Businesses");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "UserPhoto",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserPhoto",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "BusinessStar",
                table: "Businesses",
                type: "int",
                nullable: true);
        }
    }
}
