using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRBoost.UI.Migrations
{
    /// <inheritdoc />
    public partial class ahmet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PermissionRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

           

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRequest_UserId",
                table: "PermissionRequest",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRequest_AspNetUsers_UserId",
                table: "PermissionRequest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRequest_AspNetUsers_UserId",
                table: "PermissionRequest");

            migrationBuilder.DropIndex(
                name: "IX_PermissionRequest_UserId",
                table: "PermissionRequest");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("382881dc-724f-4d26-8daf-f566633a8e8f"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("6bd79f56-ac79-456c-8f6e-ae2c90e844af"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("a24cbd3d-10bc-461c-80cc-93d45d2354f9"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("cf57c623-bd1b-4af4-9369-78710d09de74"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PermissionRequest");

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "Duration", "ModifiedBy", "ModifiedDate", "Price", "Status", "SubscriptionType" },
                values: new object[,]
                {
                    { new Guid("04755e43-9a1f-4505-b725-19c5cc2f32f8"), new DateTime(2025, 2, 3, 22, 21, 59, 60, DateTimeKind.Local).AddTicks(6263), "Basedefault", 0, "Basedefault", new DateTime(2025, 2, 3, 22, 21, 59, 60, DateTimeKind.Local).AddTicks(6306), 0m, 1, "Free" },
                    { new Guid("4570aaba-a95f-42dc-a290-8bc1e1c80150"), new DateTime(2025, 2, 3, 22, 21, 59, 60, DateTimeKind.Local).AddTicks(6328), "Basedefault", 12, "Basedefault", new DateTime(2025, 2, 3, 22, 21, 59, 60, DateTimeKind.Local).AddTicks(6335), 1499.90m, 1, "Yearly" },
                    { new Guid("6885d8a3-6f3c-4639-a8a8-3c0e1ed98fca"), new DateTime(2025, 2, 3, 22, 21, 59, 60, DateTimeKind.Local).AddTicks(6323), "Basedefault", 1, "Basedefault", new DateTime(2025, 2, 3, 22, 21, 59, 60, DateTimeKind.Local).AddTicks(6325), 149.90m, 1, "Monthly" },
                    { new Guid("6db7f4cf-66a6-4604-b1da-57fa9d36f030"), new DateTime(2025, 2, 3, 22, 21, 59, 60, DateTimeKind.Local).AddTicks(6338), "Basedefault", 100, "Basedefault", new DateTime(2025, 2, 3, 22, 21, 59, 60, DateTimeKind.Local).AddTicks(6339), 12999.90m, 1, "Premium" }
                });
        }
    }
}
