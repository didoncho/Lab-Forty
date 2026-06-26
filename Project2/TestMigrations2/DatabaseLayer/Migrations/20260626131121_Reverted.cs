using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class Reverted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class1s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class1s", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Class2s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Balance = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class2s", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Class1Class2",
                columns: table => new
                {
                    Classe1sId = table.Column<int>(type: "int", nullable: false),
                    Classe2sId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class1Class2", x => new { x.Classe1sId, x.Classe2sId });
                    table.ForeignKey(
                        name: "FK_Class1Class2_Class1s_Classe1sId",
                        column: x => x.Classe1sId,
                        principalTable: "Class1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class1Class2_Class2s_Classe2sId",
                        column: x => x.Classe2sId,
                        principalTable: "Class2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Class3s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    d1 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    d2 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Class2Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class3s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class3s_Class2s_Class2Id",
                        column: x => x.Class2Id,
                        principalTable: "Class2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Class1Class2_Classe2sId",
                table: "Class1Class2",
                column: "Classe2sId");

            migrationBuilder.CreateIndex(
                name: "IX_Class3s_Class2Id",
                table: "Class3s",
                column: "Class2Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class1Class2");

            migrationBuilder.DropTable(
                name: "Class3s");

            migrationBuilder.DropTable(
                name: "Class1s");

            migrationBuilder.DropTable(
                name: "Class2s");
        }
    }
}
