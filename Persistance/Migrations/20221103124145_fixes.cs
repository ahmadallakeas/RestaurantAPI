using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78a9096b-da8b-45b9-8e6f-7fe9feb85938");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8ffa19a-4602-4d37-bbb8-276e59f33f4a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8dcff54d-82d7-426e-88dd-32d826d04ddc", "3f38686f-50bc-438f-a259-1f4130d301c9", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac948fb0-6a0c-4470-862f-4ae5e9cad503", "aab2eef3-d2ea-48f7-9b07-e825516644f2", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dcff54d-82d7-426e-88dd-32d826d04ddc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac948fb0-6a0c-4470-862f-4ae5e9cad503");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78a9096b-da8b-45b9-8e6f-7fe9feb85938", "bbcc2c4a-100e-43ae-9e8f-cfe50e6f4d54", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8ffa19a-4602-4d37-bbb8-276e59f33f4a", "6f7666b7-9027-4fc1-afd4-4affe8ece2b6", "Administrator", "ADMINISTRATOR" });
        }
    }
}
