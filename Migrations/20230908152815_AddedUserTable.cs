using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RerfreshTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pk", x => x.IdUser);
                });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(1973, 9, 8, 17, 28, 15, 237, DateTimeKind.Local).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(1993, 9, 8, 17, 28, 15, 237, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3,
                column: "Birthdate",
                value: new DateTime(2004, 9, 8, 17, 28, 15, 237, DateTimeKind.Local).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 4,
                column: "Birthdate",
                value: new DateTime(1956, 9, 8, 17, 28, 15, 237, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 9, 3, 17, 28, 15, 239, DateTimeKind.Local).AddTicks(7842), new DateTime(2023, 10, 8, 17, 28, 15, 239, DateTimeKind.Local).AddTicks(7895) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 11, 7, 17, 28, 15, 239, DateTimeKind.Local).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 10, 28, 17, 28, 15, 239, DateTimeKind.Local).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 4,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 8, 27, 17, 28, 15, 239, DateTimeKind.Local).AddTicks(7905), new DateTime(2023, 10, 8, 17, 28, 15, 239, DateTimeKind.Local).AddTicks(7907) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(1973, 9, 8, 17, 22, 53, 366, DateTimeKind.Local).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(1993, 9, 8, 17, 22, 53, 366, DateTimeKind.Local).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3,
                column: "Birthdate",
                value: new DateTime(2004, 9, 8, 17, 22, 53, 366, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 4,
                column: "Birthdate",
                value: new DateTime(1956, 9, 8, 17, 22, 53, 366, DateTimeKind.Local).AddTicks(2487));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 9, 3, 17, 22, 53, 367, DateTimeKind.Local).AddTicks(9173), new DateTime(2023, 10, 8, 17, 22, 53, 367, DateTimeKind.Local).AddTicks(9229) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2023, 11, 7, 17, 22, 53, 367, DateTimeKind.Local).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2023, 10, 28, 17, 22, 53, 367, DateTimeKind.Local).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 4,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 8, 27, 17, 22, 53, 367, DateTimeKind.Local).AddTicks(9239), new DateTime(2023, 10, 8, 17, 22, 53, 367, DateTimeKind.Local).AddTicks(9241) });
        }
    }
}
