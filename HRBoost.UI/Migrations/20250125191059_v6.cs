using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBoost.UI.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Businesses_SubscriptionId",
                table: "Businesses");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_SubscriptionId",
                table: "Businesses",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Businesses_SubscriptionId",
                table: "Businesses");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_SubscriptionId",
                table: "Businesses",
                column: "SubscriptionId",
                unique: true);
        }
    }
}
