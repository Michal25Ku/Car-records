using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class NewOwnerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Cars",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Cars",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "ContactDetails_CarId",
                table: "Cars",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Cars",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Cars",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Pesel = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Region = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address_City", "Address_PostalCode", "Address_Region", "Address_Street", "Email", "FirstName", "LastName", "Pesel", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Kraków", "12-900", "Małopolska", "Krakowska 1", "jan.nowak@gmail.com", "Jan", "Nowak", "95715209461", "+48923614982" },
                    { 2, "Warszawa", "21-009", "Mazowsze", "Warszawska 2", "piotr.kowalski@wp.pl", "Piotr", "Kowalski", "12497432487", "+48740981265" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CreateDate", "EngineCapacity", "EnginePower", "EngineType", "LicensePlateNumber", "Model", "OwnerId", "Producer", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 1, 1, 27, 4, 443, DateTimeKind.Local).AddTicks(687), "1.3", 60, "Benzynowy", "KR AB12", "Felicia", 1, "Skoda", 1 },
                    { 2, new DateTime(2024, 2, 1, 1, 27, 4, 443, DateTimeKind.Local).AddTicks(734), "1.6", 50, "Benzynowy", "WI CB21", "Golf 2", 2, "BMW", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Owners_OwnerId",
                table: "Cars",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Owners_OwnerId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Cars",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Cars",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Cars",
                newName: "ContactDetails_CarId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cars",
                newName: "CarId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Cars",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

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
    }
}
