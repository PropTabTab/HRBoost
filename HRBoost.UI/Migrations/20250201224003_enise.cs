using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRBoost.UI.Migrations
{
    /// <inheritdoc />
    public partial class enise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_UserId",
                table: "Expenses");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("326ae2aa-9292-46cd-94af-d6073bba377e"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("5ff4fcbc-6fa1-45da-be84-fdd8e7891028"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("91dbc3ef-46dd-4167-9d37-2c09ec27f3ab"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("adb7d1af-455c-45b3-be44-a35c97f8f153"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Expenses",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses",
                newName: "IX_Expenses_UserID");

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "Duration", "ModifiedBy", "ModifiedDate", "Price", "Status", "SubscriptionType" },
                values: new object[,]
                {
                    { new Guid("14f807fc-4062-4d9c-8860-be9cd10b3e71"), new DateTime(2025, 2, 2, 1, 40, 3, 157, DateTimeKind.Local).AddTicks(4588), "Basedefault", 0, "Basedefault", new DateTime(2025, 2, 2, 1, 40, 3, 157, DateTimeKind.Local).AddTicks(4632), 0m, 1, "Free" },
                    { new Guid("2178cbb9-53dd-4ad1-b7bf-9b8357d8d9a5"), new DateTime(2025, 2, 2, 1, 40, 3, 157, DateTimeKind.Local).AddTicks(4651), "Basedefault", 1, "Basedefault", new DateTime(2025, 2, 2, 1, 40, 3, 157, DateTimeKind.Local).AddTicks(4654), 149.90m, 1, "Monthly" },
                    { new Guid("2f9692fc-f60e-4150-99bf-3012d3ab5d57"), new DateTime(2025, 2, 2, 1, 40, 3, 157, DateTimeKind.Local).AddTicks(4661), "Basedefault", 100, "Basedefault", new DateTime(2025, 2, 2, 1, 40, 3, 157, DateTimeKind.Local).AddTicks(4663), 12999.90m, 1, "Premium" },
                    { new Guid("c343e511-dbef-474a-b116-671d1af1156c"), new DateTime(2025, 2, 2, 1, 40, 3, 157, DateTimeKind.Local).AddTicks(4657), "Basedefault", 12, "Basedefault", new DateTime(2025, 2, 2, 1, 40, 3, 157, DateTimeKind.Local).AddTicks(4659), 1499.90m, 1, "Yearly" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_UserID",
                table: "Expenses",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_UserID",
                table: "Expenses");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("14f807fc-4062-4d9c-8860-be9cd10b3e71"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("2178cbb9-53dd-4ad1-b7bf-9b8357d8d9a5"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("2f9692fc-f60e-4150-99bf-3012d3ab5d57"));

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: new Guid("c343e511-dbef-474a-b116-671d1af1156c"));

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Expenses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_UserID",
                table: "Expenses",
                newName: "IX_Expenses_UserId");

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "Duration", "ModifiedBy", "ModifiedDate", "Price", "Status", "SubscriptionType" },
                values: new object[,]
                {
                    { new Guid("326ae2aa-9292-46cd-94af-d6073bba377e"), new DateTime(2025, 2, 1, 18, 28, 18, 437, DateTimeKind.Local).AddTicks(6205), "Basedefault", 12, "Basedefault", new DateTime(2025, 2, 1, 18, 28, 18, 437, DateTimeKind.Local).AddTicks(6207), 1499.90m, 1, "Yearly" },
                    { new Guid("5ff4fcbc-6fa1-45da-be84-fdd8e7891028"), new DateTime(2025, 2, 1, 18, 28, 18, 437, DateTimeKind.Local).AddTicks(6209), "Basedefault", 100, "Basedefault", new DateTime(2025, 2, 1, 18, 28, 18, 437, DateTimeKind.Local).AddTicks(6211), 12999.90m, 1, "Premium" },
                    { new Guid("91dbc3ef-46dd-4167-9d37-2c09ec27f3ab"), new DateTime(2025, 2, 1, 18, 28, 18, 437, DateTimeKind.Local).AddTicks(6140), "Basedefault", 0, "Basedefault", new DateTime(2025, 2, 1, 18, 28, 18, 437, DateTimeKind.Local).AddTicks(6172), 0m, 1, "Free" },
                    { new Guid("adb7d1af-455c-45b3-be44-a35c97f8f153"), new DateTime(2025, 2, 1, 18, 28, 18, 437, DateTimeKind.Local).AddTicks(6199), "Basedefault", 1, "Basedefault", new DateTime(2025, 2, 1, 18, 28, 18, 437, DateTimeKind.Local).AddTicks(6202), 149.90m, 1, "Monthly" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_UserId",
                table: "Expenses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
