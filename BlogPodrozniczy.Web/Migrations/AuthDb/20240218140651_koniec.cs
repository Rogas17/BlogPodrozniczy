using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPodrozniczy.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class koniec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "142fc063-5e35-4bd0-829c-dbbfcc225474",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7b9eb61-3020-4ed0-a8c1-7dcd88394f6e", "AQAAAAIAAYagAAAAECRzIC/PL3botxjWanUbYxCx6ZTiHE8yKSB06h29Ja2VcsqHXHlfnTIrpoIzLSvaxQ==", "52d4914b-703d-4fb2-85b0-767761585028" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "142fc063-5e35-4bd0-829c-dbbfcc225474",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cf176dd-92c0-4ba8-ba11-31cccc20cfe9", "AQAAAAIAAYagAAAAEJvqOkHsKsy7TYWDwudph7mYPcprGhmOWodi2xCFdUTBFqAfWUlOypZjJfU+/7p4rw==", "99f3b170-69fb-42fb-b24c-5036f645896e" });
        }
    }
}
