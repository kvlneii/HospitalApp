using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "jicet34417@gmail.com", "Connor", "Richardson" },
                    { 2, "lPearson23@gmail.com", "Lisa", "Pearson" },
                    { 3, "sssflores@gmail.com", "Saarah", "Flores" },
                    { 4, "d.mathis@gmail.com", "Alexander", "Mathis" },
                    { 5, "lozano6879@gmail.com", "Amelie", "Lozano" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Desciption", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Pain reliever", "Paracetamol", "Over-the-counter" },
                    { 2, "Antibiotic", "Amoxicillin", "Prescription" },
                    { 3, "Blood pressure medication", "Lisinopril", "Prescription" },
                    { 4, "Pain reliever", "Aspirin", "Over-the-counter" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1973, 9, 8, 17, 22, 53, 366, DateTimeKind.Local).AddTicks(2424), "Philip", "Stafford" },
                    { 2, new DateTime(1993, 9, 8, 17, 22, 53, 366, DateTimeKind.Local).AddTicks(2480), "Hollie", "Eaton" },
                    { 3, new DateTime(2004, 9, 8, 17, 22, 53, 366, DateTimeKind.Local).AddTicks(2483), "Kimberley", "Fernandez" },
                    { 4, new DateTime(1956, 9, 8, 17, 22, 53, 366, DateTimeKind.Local).AddTicks(2487), "Rueben", "Lowery" }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2023, 9, 3, 17, 22, 53, 367, DateTimeKind.Local).AddTicks(9173), new DateTime(2023, 10, 8, 17, 22, 53, 367, DateTimeKind.Local).AddTicks(9229), 2, 1 });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 11, 7, 17, 22, 53, 367, DateTimeKind.Local).AddTicks(9233), 5, 4 },
                    { 3, new DateTime(2023, 10, 28, 17, 22, 53, 367, DateTimeKind.Local).AddTicks(9236), 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 4, new DateTime(2023, 8, 27, 17, 22, 53, 367, DateTimeKind.Local).AddTicks(9239), new DateTime(2023, 10, 8, 17, 22, 53, 367, DateTimeKind.Local).AddTicks(9241), 3, 2 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "Take as needed", 1 },
                    { 1, 4, "Take once daily", 2 },
                    { 2, 2, "Take twice daily", 14 },
                    { 2, 3, "Take with food", 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicament",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 4);
        }
    }
}
