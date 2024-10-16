using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Product",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Category",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Product",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Category",
                newName: "ReleaseDate");
        }
    }
}
