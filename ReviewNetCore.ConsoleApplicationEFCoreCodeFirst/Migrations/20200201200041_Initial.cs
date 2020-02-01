using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewNetCore.ConsoleApplicationEFCoreCodeFirst.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false),
                    Description = table.Column<string>(type: "varchar(45)", nullable: true),
                    AuthorId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "Book_FK_Author",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Rodrigo" });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Max" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "AuthorId", "Description", "Name" },
                values: new object[] { 1, 1, "Review", "Asp.Net Core Review" });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "AuthorId", "Description", "Name" },
                values: new object[] { 2, 2, "SPA", "Angular 8" });

            migrationBuilder.CreateIndex(
                name: "Book_FK_Author_idx",
                table: "books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "authors");
        }
    }
}
