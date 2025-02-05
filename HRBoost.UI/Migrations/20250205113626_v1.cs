using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRBoost.UI.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("04755e43-9a1f-4505-b725-19c5cc2f32f8"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("4570aaba-a95f-42dc-a290-8bc1e1c80150"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("6885d8a3-6f3c-4639-a8a8-3c0e1ed98fca"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("6db7f4cf-66a6-4604-b1da-57fa9d36f030"));

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Document");

            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "Document",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "Duration", "ModifiedBy", "ModifiedDate", "Price", "Status", "SubscriptionType" },
                values: new object[,]
                {
                    { new Guid("21210198-60b5-4b4d-9cf1-549abd400ddc"), new DateTime(2025, 2, 5, 14, 36, 25, 492, DateTimeKind.Local).AddTicks(2483), "Basedefault", 1, "Basedefault", new DateTime(2025, 2, 5, 14, 36, 25, 492, DateTimeKind.Local).AddTicks(2486), 149.90m, 1, "Monthly" },
                    { new Guid("3c595579-0e68-4655-ad73-81323621adc0"), new DateTime(2025, 2, 5, 14, 36, 25, 492, DateTimeKind.Local).AddTicks(2496), "Basedefault", 100, "Basedefault", new DateTime(2025, 2, 5, 14, 36, 25, 492, DateTimeKind.Local).AddTicks(2497), 12999.90m, 1, "Premium" },
                    { new Guid("9f30f3ed-a6ac-4581-88bc-319f3bb5b55b"), new DateTime(2025, 2, 5, 14, 36, 25, 492, DateTimeKind.Local).AddTicks(2491), "Basedefault", 12, "Basedefault", new DateTime(2025, 2, 5, 14, 36, 25, 492, DateTimeKind.Local).AddTicks(2492), 1499.90m, 1, "Yearly" },
                    { new Guid("fda6c334-c01a-4c0a-90f1-af0f0f0875c3"), new DateTime(2025, 2, 5, 14, 36, 25, 492, DateTimeKind.Local).AddTicks(2420), "Basedefault", 0, "Basedefault", new DateTime(2025, 2, 5, 14, 36, 25, 492, DateTimeKind.Local).AddTicks(2461), 0m, 1, "Free" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_UserId",
                table: "Document",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_AspNetUsers_UserId",
                table: "Document",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_AspNetUsers_UserId",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_UserId",
                table: "Document");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("21210198-60b5-4b4d-9cf1-549abd400ddc"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("3c595579-0e68-4655-ad73-81323621adc0"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("9f30f3ed-a6ac-4581-88bc-319f3bb5b55b"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("fda6c334-c01a-4c0a-90f1-af0f0f0875c3"));

            migrationBuilder.DropColumn(
                name: "File",
                table: "Document");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Document",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
