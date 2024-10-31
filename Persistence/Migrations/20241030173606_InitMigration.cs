using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    PropertyTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.PropertyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateListingSites",
                columns: table => new
                {
                    RealEstateListingSiteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateListingSites", x => x.RealEstateListingSiteId);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceId);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ListingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RealEstateListingSiteId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResourceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.ListingId);
                    table.ForeignKey(
                        name: "FK_Listings_RealEstateListingSites_RealEstateListingSiteId",
                        column: x => x.RealEstateListingSiteId,
                        principalTable: "RealEstateListingSites",
                        principalColumn: "RealEstateListingSiteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listings_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    ListingAddressFull = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false, defaultValue: ""),
                    ListingAddress1 = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false, defaultValue: ""),
                    ListingAddress2 = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false, defaultValue: ""),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false, defaultValue: ""),
                    State = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false, defaultValue: ""),
                    Country = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false, defaultValue: ""),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false, defaultValue: ""),
                    Timezone = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "ListingEntities",
                columns: table => new
                {
                    ListingEntityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingEntities", x => x.ListingEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ListingId = table.Column<int>(type: "INTEGER", nullable: false),
                    ListingAgentId = table.Column<int>(type: "INTEGER", nullable: true),
                    ListingOfficeId = table.Column<int>(type: "INTEGER", nullable: true),
                    PropertyTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResourceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Property_ListingEntities_ListingAgentId",
                        column: x => x.ListingAgentId,
                        principalTable: "ListingEntities",
                        principalColumn: "ListingEntityId");
                    table.ForeignKey(
                        name: "FK_Property_ListingEntities_ListingOfficeId",
                        column: x => x.ListingOfficeId,
                        principalTable: "ListingEntities",
                        principalColumn: "ListingEntityId");
                    table.ForeignKey(
                        name: "FK_Property_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "ListingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "PropertyTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyDetails",
                columns: table => new
                {
                    PropertyDetailsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropertyId = table.Column<int>(type: "INTEGER", nullable: false),
                    Bedrooms = table.Column<float>(type: "REAL", nullable: false),
                    Bathrooms = table.Column<float>(type: "REAL", nullable: false),
                    LotSizeSqFeet = table.Column<float>(type: "REAL", nullable: false),
                    LotSizeAcres = table.Column<float>(type: "REAL", nullable: false),
                    LivingArea = table.Column<float>(type: "REAL", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    PriceChange = table.Column<decimal>(type: "TEXT", nullable: false),
                    YearBuilt = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyDetails", x => x.PropertyDetailsId);
                    table.ForeignKey(
                        name: "FK_PropertyDetails_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PropertyId",
                table: "Addresses",
                column: "PropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListingEntities_PropertyId",
                table: "ListingEntities",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_RealEstateListingSiteId",
                table: "Listings",
                column: "RealEstateListingSiteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_ResourceId",
                table: "Listings",
                column: "ResourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Property_ListingAgentId",
                table: "Property",
                column: "ListingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_ListingId",
                table: "Property",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_ListingOfficeId",
                table: "Property",
                column: "ListingOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_PropertyTypeId",
                table: "Property",
                column: "PropertyTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Property_ResourceId",
                table: "Property",
                column: "ResourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDetails_PropertyId",
                table: "PropertyDetails",
                column: "PropertyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Property_PropertyId",
                table: "Addresses",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingEntities_Property_PropertyId",
                table: "ListingEntities");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PropertyDetails");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "ListingEntities");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropTable(
                name: "RealEstateListingSites");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
