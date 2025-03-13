using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_04_Join_Demo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Empolyes");

            migrationBuilder.AddColumn<int>(
                name: "DetailedAddress_BlocNum",
                table: "Empolyes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailedAddress_City",
                table: "Empolyes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailedAddress_Country",
                table: "Empolyes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailedAddress_Street",
                table: "Empolyes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailedAddress_BlocNum",
                table: "Empolyes");

            migrationBuilder.DropColumn(
                name: "DetailedAddress_City",
                table: "Empolyes");

            migrationBuilder.DropColumn(
                name: "DetailedAddress_Country",
                table: "Empolyes");

            migrationBuilder.DropColumn(
                name: "DetailedAddress_Street",
                table: "Empolyes");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Empolyes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
