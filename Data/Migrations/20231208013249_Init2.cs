using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Cars",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ContactDetails_CarId",
                table: "Cars",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContactDetails_Email",
                table: "Cars",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactDetails_FirstName",
                table: "Cars",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactDetails_LastName",
                table: "Cars",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactDetails_PhoneNumber",
                table: "Cars",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactDetails_CarId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ContactDetails_Email",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ContactDetails_FirstName",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ContactDetails_LastName",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ContactDetails_PhoneNumber",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Cars",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Created", "EngineCapacity", "EnginePower", "EngineType", "LicensePlateNumber", "Model", "Priority", "Producer" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 100, null, "KR 90L", "Felicia", 1, "Skoda" },
                    { 2, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1.6", 120, null, "KR 17K", "Golf 2", 2, "Wolkswagen" }
                });
        }
    }
}
