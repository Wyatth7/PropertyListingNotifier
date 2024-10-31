using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixTypeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Property_PropertyTypeId",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Listings_RealEstateListingSiteId",
                table: "Listings");

            migrationBuilder.CreateIndex(
                name: "IX_Property_PropertyTypeId",
                table: "Property",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_RealEstateListingSiteId",
                table: "Listings",
                column: "RealEstateListingSiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Property_PropertyTypeId",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Listings_RealEstateListingSiteId",
                table: "Listings");

            migrationBuilder.CreateIndex(
                name: "IX_Property_PropertyTypeId",
                table: "Property",
                column: "PropertyTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_RealEstateListingSiteId",
                table: "Listings",
                column: "RealEstateListingSiteId",
                unique: true);
        }
    }
}
