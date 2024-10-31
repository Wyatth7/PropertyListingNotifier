using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "PropertyTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Single Family" },
                    { 2, "Land" }
                });

            migrationBuilder.InsertData(
                table: "RealEstateListingSites",
                columns: new[] { "RealEstateListingSiteId", "Name" },
                values: new object[,]
                {
                    { 1, "Remax" },
                    { 2, "Zillow" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RealEstateListingSites",
                keyColumn: "RealEstateListingSiteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RealEstateListingSites",
                keyColumn: "RealEstateListingSiteId",
                keyValue: 2);
        }
    }
}
