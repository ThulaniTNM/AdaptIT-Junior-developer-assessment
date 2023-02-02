using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdaptITAcademy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addressTypesChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "PostalAddresses");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "PhysicalAddresses");

            migrationBuilder.AddColumn<string>(
                name: "PostalCodePostalAddress",
                table: "PostalAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCodePhysicalAddress",
                table: "PhysicalAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCodePostalAddress",
                table: "PostalAddresses");

            migrationBuilder.DropColumn(
                name: "PostalCodePhysicalAddress",
                table: "PhysicalAddresses");

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "PostalAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "PhysicalAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
