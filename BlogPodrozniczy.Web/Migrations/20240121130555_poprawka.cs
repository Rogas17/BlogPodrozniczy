using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPodrozniczy.Web.Migrations
{
    /// <inheritdoc />
    public partial class poprawka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PokazanaNazwa",
                table: "Tagi",
                newName: "WyświetlanaNazwa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WyświetlanaNazwa",
                table: "Tagi",
                newName: "PokazanaNazwa");
        }
    }
}
