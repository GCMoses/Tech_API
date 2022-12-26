using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerTechDataAPI.Migrations
{
    public partial class AddedDefaultRolesToTech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b9de74c-1cb7-41af-bbde-1a5acbbf6c41", "af00ea8d-3a89-4c27-a8a9-55fa6e867a0a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0e52416-9ec8-4c2e-8a6b-3a9908a4ff9b", "f6a98ae5-0d79-4c0d-992e-bdc081ceda38", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b9de74c-1cb7-41af-bbde-1a5acbbf6c41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0e52416-9ec8-4c2e-8a6b-3a9908a4ff9b");
        }
    }
}
