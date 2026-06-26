using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class1Class2_Class1s_Classe1sId",
                table: "Class1Class2");

            migrationBuilder.DropForeignKey(
                name: "FK_Class1Class2_Class2s_Classe2sId",
                table: "Class1Class2");

            migrationBuilder.DropForeignKey(
                name: "FK_Class3s_Class2s_Class2Id",
                table: "Class3s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class3s",
                table: "Class3s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class2s",
                table: "Class2s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class1s",
                table: "Class1s");

            migrationBuilder.RenameTable(
                name: "Class3s",
                newName: "UserInfo1");

            migrationBuilder.RenameTable(
                name: "Class2s",
                newName: "User1");

            migrationBuilder.RenameTable(
                name: "Class1s",
                newName: "Product1");

            migrationBuilder.RenameIndex(
                name: "IX_Class3s_Class2Id",
                table: "UserInfo1",
                newName: "IX_UserInfo1_Class2Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "d2",
                table: "UserInfo1",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "d1",
                table: "UserInfo1",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "UserInfo1",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User1",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "User1",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product1",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product1",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfo1",
                table: "UserInfo1",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User1",
                table: "User1",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product1",
                table: "Product1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Class1Class2_Product1_Classe1sId",
                table: "Class1Class2",
                column: "Classe1sId",
                principalTable: "Product1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Class1Class2_User1_Classe2sId",
                table: "Class1Class2",
                column: "Classe2sId",
                principalTable: "User1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo1_User1_Class2Id",
                table: "UserInfo1",
                column: "Class2Id",
                principalTable: "User1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class1Class2_Product1_Classe1sId",
                table: "Class1Class2");

            migrationBuilder.DropForeignKey(
                name: "FK_Class1Class2_User1_Classe2sId",
                table: "Class1Class2");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo1_User1_Class2Id",
                table: "UserInfo1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfo1",
                table: "UserInfo1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User1",
                table: "User1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product1",
                table: "Product1");

            migrationBuilder.RenameTable(
                name: "UserInfo1",
                newName: "Class3s");

            migrationBuilder.RenameTable(
                name: "User1",
                newName: "Class2s");

            migrationBuilder.RenameTable(
                name: "Product1",
                newName: "Class1s");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfo1_Class2Id",
                table: "Class3s",
                newName: "IX_Class3s_Class2Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "d2",
                table: "Class3s",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "d1",
                table: "Class3s",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Class3s",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Class2s",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Class2s",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Class1s",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Class1s",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class3s",
                table: "Class3s",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class2s",
                table: "Class2s",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class1s",
                table: "Class1s",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Class1Class2_Class1s_Classe1sId",
                table: "Class1Class2",
                column: "Classe1sId",
                principalTable: "Class1s",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Class1Class2_Class2s_Classe2sId",
                table: "Class1Class2",
                column: "Classe2sId",
                principalTable: "Class2s",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Class3s_Class2s_Class2Id",
                table: "Class3s",
                column: "Class2Id",
                principalTable: "Class2s",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
