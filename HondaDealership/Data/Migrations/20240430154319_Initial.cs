using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HondaDealership.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hondas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehYear = table.Column<int>(type: "int", nullable: false),
                    VehModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehBodyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hondas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hondas",
                columns: new[] { "Id", "VehBodyType", "VehModel", "VehPrice", "VehYear" },
                values: new object[,]
                {
                    { 1, "HATCHBACK", "CIVIC", 5000, 1998 },
                    { 2, "HATCHBACK", "CIVIC", 5000, 1997 },
                    { 3, "SUV", "CRV", 5000, 1998 },
                    { 4, "SUV", "CRV", 3000, 1999 },
                    { 5, "HATCHBACK", "CRX", 6000, 1992 },
                    { 6, "VAN", "ODYSSEY", 7000, 2005 },
                    { 7, "SUV", "PASSPORT", 1000, 1994 },
                    { 8, "PICKUP", "RIDGELINE", 30000, 2024 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hondas");
        }
    }
}
