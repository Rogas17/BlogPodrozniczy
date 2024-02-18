using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPodrozniczy.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Dokończenie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "142fc063-5e35-4bd0-829c-dbbfcc225474",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cf176dd-92c0-4ba8-ba11-31cccc20cfe9", "AQAAAAIAAYagAAAAEJvqOkHsKsy7TYWDwudph7mYPcprGhmOWodi2xCFdUTBFqAfWUlOypZjJfU+/7p4rw==", "99f3b170-69fb-42fb-b24c-5036f645896e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "142fc063-5e35-4bd0-829c-dbbfcc225474",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13af5a71-522f-4c05-a6f1-c9bc8d51bd0b", "AQAAAAIAAYagAAAAEL9g4z15VO9wfjDmPEBul7LIX8XDPSD2Ng994Tjye9EW8ePhKAZK89r9GGB6jOPcuA==", "65a1bf4d-5ffd-4a74-be07-bc09c8e8ec6b" });
        }
    }
}
