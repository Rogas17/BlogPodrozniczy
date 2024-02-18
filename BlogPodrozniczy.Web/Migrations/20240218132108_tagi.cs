using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPodrozniczy.Web.Migrations
{
    /// <inheritdoc />
    public partial class tagi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nagłówek = table.Column<string>(type: "TEXT", nullable: false),
                    TytułStrony = table.Column<string>(type: "TEXT", nullable: false),
                    Treść = table.Column<string>(type: "TEXT", nullable: false),
                    KrótkiOpis = table.Column<string>(type: "TEXT", nullable: false),
                    UrlZdjęcia = table.Column<string>(type: "TEXT", nullable: false),
                    UrlHandle = table.Column<string>(type: "TEXT", nullable: false),
                    DataPublikacji = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Autor = table.Column<string>(type: "TEXT", nullable: false),
                    Widoczność = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tagi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false),
                    WyświetlanaNazwa = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tagi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPostTag",
                columns: table => new
                {
                    PostyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagiId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostTag", x => new { x.PostyId, x.TagiId });
                    table.ForeignKey(
                        name: "FK_BlogPostTag_Posty_PostyId",
                        column: x => x.PostyId,
                        principalTable: "Posty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPostTag_Tagi_TagiId",
                        column: x => x.TagiId,
                        principalTable: "Tagi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostTag_TagiId",
                table: "BlogPostTag",
                column: "TagiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostTag");

            migrationBuilder.DropTable(
                name: "Posty");

            migrationBuilder.DropTable(
                name: "Tagi");
        }
    }
}
