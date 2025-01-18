using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBoost.UI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDaysFromPermissionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Days",
                table: "PermissionRecords");

            migrationBuilder.AlterColumn<int>(
                name: "Days",
                table: "PermissionTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Days",
                table: "PermissionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "PermissionRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
