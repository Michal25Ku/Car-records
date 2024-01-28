using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", nullable: true),
                    Producer = table.Column<string>(type: "TEXT", nullable: true),
                    EngineCapacity = table.Column<string>(type: "TEXT", nullable: true),
                    EnginePower = table.Column<int>(type: "INTEGER", nullable: false),
                    EngineType = table.Column<string>(type: "TEXT", nullable: true),
                    LicensePlateNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Created", "EngineCapacity", "EnginePower", "EngineType", "LicensePlateNumber", "Model", "Priority", "Producer" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100, null, "KR 90L", "Felicia", 1, "Skoda" },
                    { 2, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1.6", 120, null, "KR 17K", "Golf 2", 2, "Wolkswagen" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
