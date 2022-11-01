using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6a7361-1d9c-49e7-aef9-875f5dfc059e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cedf450c-5206-458b-8f8d-b23a01541a88");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "78a9096b-da8b-45b9-8e6f-7fe9feb85938", "bbcc2c4a-100e-43ae-9e8f-cfe50e6f4d54", "User", "USER" },
                    { "f8ffa19a-4602-4d37-bbb8-276e59f33f4a", "6f7666b7-9027-4fc1-afd4-4affe8ece2b6", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryImage", "CategoryName" },
                values: new object[,]
                {
                    { 1, "https://i.imgur.com/YMNU1TY.jpg", "Burgers and Sandwiches" },
                    { 2, "https://i.imgur.com/lYO0Ol8.jpeg", "Pizza" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78a9096b-da8b-45b9-8e6f-7fe9feb85938");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8ffa19a-4602-4d37-bbb8-276e59f33f4a");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f6a7361-1d9c-49e7-aef9-875f5dfc059e", "13e2cf56-9363-4033-a332-9358cefc1c39", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cedf450c-5206-458b-8f8d-b23a01541a88", "6df9e368-9e2e-4bd3-9b5a-cd7b132f088e", "Administrator", "ADMINISTRATOR" });
        }
    }
}
