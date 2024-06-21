using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laxmanPMS.web.Migrations.PMSDb
{
    /// <inheritdoc />
    public partial class quantityadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<float>(
                name: "quantity",
                table: "Product",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "ProductViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductViewModel");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
