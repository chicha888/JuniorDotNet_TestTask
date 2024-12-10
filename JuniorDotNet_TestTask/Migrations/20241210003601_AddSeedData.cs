using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JuniorDotNet_TestTask.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProcessEquipmentTypes",
                columns: new[] { "Id", "Area", "Code", "Name" },
                values: new object[,]
                {
                    { 1, 50.0, "EQ1", "Type 1 Small Equipment" },
                    { 2, 30.0, "EQ2", "Type 2 Compact Equipment" },
                    { 3, 70.0, "EQ3", "Type 3 Large Equipment" },
                    { 4, 120.0, "EQ4", "Type 4 Extra Large" },
                    { 5, 15.0, "EQ5", "Type 5 High Density" },
                    { 6, 45.0, "EQ6", "Type 6 Medium Equipment" },
                    { 7, 90.0, "EQ7", "Type 7 Advanced" },
                    { 8, 20.0, "EQ8", "Type 8 Lightweight" },
                    { 9, 100.0, "EQ9", "Type 9 Custom" },
                    { 10, 200.0, "EQ10", "Type 10 Extreme" }
                });

            migrationBuilder.InsertData(
                table: "ProductionFacilities",
                columns: new[] { "Id", "Code", "Name", "StandardArea" },
                values: new object[,]
                {
                    { 1, "FAC1", "Factory 1", 5000.0 },
                    { 2, "FAC2", "Factory 2", 3000.0 },
                    { 3, "FAC3", "Factory 3", 4000.0 },
                    { 4, "FAC4", "Factory 4", 7000.0 },
                    { 5, "FAC5", "Factory 5", 2500.0 },
                    { 6, "FAC6", "Factory 6", 8000.0 },
                    { 7, "FAC7", "Factory 7", 3500.0 },
                    { 8, "FAC8", "Factory 8", 6000.0 },
                    { 9, "FAC9", "Factory 9", 4500.0 },
                    { 10, "FAC10", "Factory 10", 10000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductionFacilities",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
