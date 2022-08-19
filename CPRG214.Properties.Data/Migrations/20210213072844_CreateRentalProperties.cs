using Microsoft.EntityFrameworkCore.Migrations;

namespace CPRG214.Properties.Data.Migrations
{
    public partial class CreateRentalProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Renter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalProperty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalProperty_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalProperty_PropertyType_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalProperty_Renter_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Ben King", "403-555-8500" },
                    { 2, "Paul Wilson", "403-555-6935" },
                    { 3, "Kimberly Dunne", "403-555-4770" }
                });

            migrationBuilder.InsertData(
                table: "PropertyType",
                columns: new[] { "Id", "Style" },
                values: new object[,]
                {
                    { 1, "Apartment" },
                    { 2, "Townhouse" },
                    { 3, "Bungalow" },
                    { 4, "Suite" }
                });

            migrationBuilder.InsertData(
                table: "Renter",
                columns: new[] { "Id", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Sam", "Munro", "403-555-3456" },
                    { 2, "Sarah", "Carr", "403-555-7666" },
                    { 3, "John", "Hudon", "403-555-3000" }
                });

            migrationBuilder.InsertData(
                table: "RentalProperty",
                columns: new[] { "Id", "Address", "City", "OwnerId", "PostalCode", "PropertyTypeId", "Province", "Rent", "RenterId" },
                values: new object[] { 3, "240 - 2111 4th St NW", "Calgary", 3, "T5T 5T5", 4, "AB", 1000m, null });

            migrationBuilder.InsertData(
                table: "RentalProperty",
                columns: new[] { "Id", "Address", "City", "OwnerId", "PostalCode", "PropertyTypeId", "Province", "Rent", "RenterId" },
                values: new object[] { 2, "4567 66th Ave NW", "Calgary", 1, "T2T 2D2", 3, "AB", 2400m, 2 });

            migrationBuilder.InsertData(
                table: "RentalProperty",
                columns: new[] { "Id", "Address", "City", "OwnerId", "PostalCode", "PropertyTypeId", "Province", "Rent", "RenterId" },
                values: new object[] { 1, "1345 - 670 14th Ave SW", "Calgary", 2, "T3T 3T3", 1, "AB", 1200m, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperty_OwnerId",
                table: "RentalProperty",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperty_PropertyTypeId",
                table: "RentalProperty",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalProperty_RenterId",
                table: "RentalProperty",
                column: "RenterId",
                unique: true,
                filter: "[RenterId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalProperty");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "PropertyType");

            migrationBuilder.DropTable(
                name: "Renter");
        }
    }
}
