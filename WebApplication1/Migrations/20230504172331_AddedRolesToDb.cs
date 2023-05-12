using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f3cd238-6b6a-4e50-aa44-787a9dbac228", "e2328624-4b2e-435e-a4aa-622ec3215632", "Admin", "ADMIN" },
                    { "b82618c7-b631-444e-960d-61713b1a0db3", "d5626b0f-e04d-44d7-905f-2a47745be7fe", "Librarian", "LIBRARIAN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f3cd238-6b6a-4e50-aa44-787a9dbac228");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b82618c7-b631-444e-960d-61713b1a0db3");
        }
    }
}
