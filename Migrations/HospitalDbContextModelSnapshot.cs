﻿// <auto-generated />
using System;
using HospitalApp.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalApp.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospitalApp.Entitites.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDoctor"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDoctor")
                        .HasName("Doctor_pk");

                    b.ToTable("Doctor", (string)null);

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "jicet34417@gmail.com",
                            FirstName = "Connor",
                            LastName = "Richardson"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "lPearson23@gmail.com",
                            FirstName = "Lisa",
                            LastName = "Pearson"
                        },
                        new
                        {
                            IdDoctor = 3,
                            Email = "sssflores@gmail.com",
                            FirstName = "Saarah",
                            LastName = "Flores"
                        },
                        new
                        {
                            IdDoctor = 4,
                            Email = "d.mathis@gmail.com",
                            FirstName = "Alexander",
                            LastName = "Mathis"
                        },
                        new
                        {
                            IdDoctor = 5,
                            Email = "lozano6879@gmail.com",
                            FirstName = "Amelie",
                            LastName = "Lozano"
                        });
                });

            modelBuilder.Entity("HospitalApp.Entitites.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicament"));

                    b.Property<string>("Desciption")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament")
                        .HasName("Medicament_pk");

                    b.ToTable("Medicament", (string)null);

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Desciption = "Pain reliever",
                            Name = "Paracetamol",
                            Type = "Over-the-counter"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Desciption = "Antibiotic",
                            Name = "Amoxicillin",
                            Type = "Prescription"
                        },
                        new
                        {
                            IdMedicament = 3,
                            Desciption = "Blood pressure medication",
                            Name = "Lisinopril",
                            Type = "Prescription"
                        },
                        new
                        {
                            IdMedicament = 4,
                            Desciption = "Pain reliever",
                            Name = "Aspirin",
                            Type = "Over-the-counter"
                        });
                });

            modelBuilder.Entity("HospitalApp.Entitites.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatient"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPatient")
                        .HasName("Patient_pk");

                    b.ToTable("Patient", (string)null);

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            Birthdate = new DateTime(1973, 9, 8, 17, 28, 15, 237, DateTimeKind.Local).AddTicks(6687),
                            FirstName = "Philip",
                            LastName = "Stafford"
                        },
                        new
                        {
                            IdPatient = 2,
                            Birthdate = new DateTime(1993, 9, 8, 17, 28, 15, 237, DateTimeKind.Local).AddTicks(6750),
                            FirstName = "Hollie",
                            LastName = "Eaton"
                        },
                        new
                        {
                            IdPatient = 3,
                            Birthdate = new DateTime(2004, 9, 8, 17, 28, 15, 237, DateTimeKind.Local).AddTicks(6755),
                            FirstName = "Kimberley",
                            LastName = "Fernandez"
                        },
                        new
                        {
                            IdPatient = 4,
                            Birthdate = new DateTime(1956, 9, 8, 17, 28, 15, 237, DateTimeKind.Local).AddTicks(6760),
                            FirstName = "Rueben",
                            LastName = "Lowery"
                        });
                });

            modelBuilder.Entity("HospitalApp.Entitites.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrescription"));

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription")
                        .HasName("Prescription_pk");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescription", (string)null);

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2023, 9, 3, 17, 28, 15, 239, DateTimeKind.Local).AddTicks(7842),
                            DueDate = new DateTime(2023, 10, 8, 17, 28, 15, 239, DateTimeKind.Local).AddTicks(7895),
                            IdDoctor = 2,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2023, 11, 7, 17, 28, 15, 239, DateTimeKind.Local).AddTicks(7898),
                            IdDoctor = 5,
                            IdPatient = 4
                        },
                        new
                        {
                            IdPrescription = 3,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2023, 10, 28, 17, 28, 15, 239, DateTimeKind.Local).AddTicks(7902),
                            IdDoctor = 5,
                            IdPatient = 3
                        },
                        new
                        {
                            IdPrescription = 4,
                            Date = new DateTime(2023, 8, 27, 17, 28, 15, 239, DateTimeKind.Local).AddTicks(7905),
                            DueDate = new DateTime(2023, 10, 8, 17, 28, 15, 239, DateTimeKind.Local).AddTicks(7907),
                            IdDoctor = 3,
                            IdPatient = 2
                        });
                });

            modelBuilder.Entity("HospitalApp.Entitites.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament", "IdPrescription")
                        .HasName("PrescriptionMedicament_pk");

                    b.HasIndex("IdPrescription");

                    b.ToTable("Prescription_Medicament", (string)null);

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 4,
                            Details = "Take once daily",
                            Dose = 2
                        },
                        new
                        {
                            IdMedicament = 1,
                            IdPrescription = 1,
                            Details = "Take as needed",
                            Dose = 1
                        },
                        new
                        {
                            IdMedicament = 2,
                            IdPrescription = 3,
                            Details = "Take with food",
                            Dose = 6
                        },
                        new
                        {
                            IdMedicament = 2,
                            IdPrescription = 2,
                            Details = "Take twice daily",
                            Dose = 14
                        });
                });

            modelBuilder.Entity("HospitalApp.Entitites.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RerfreshTokenExpiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser")
                        .HasName("User_pk");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("HospitalApp.Entitites.Prescription", b =>
                {
                    b.HasOne("HospitalApp.Entitites.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Prescription_Doctor");

                    b.HasOne("HospitalApp.Entitites.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("Prescription_Patient");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalApp.Entitites.PrescriptionMedicament", b =>
                {
                    b.HasOne("HospitalApp.Entitites.Medicament", "Medicament")
                        .WithMany("PrescriptionsMedicament")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("PrescriptionMedicament_Medicament");

                    b.HasOne("HospitalApp.Entitites.Prescription", "Prescription")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("PrescriptionMedicament_Prescription");

                    b.Navigation("Medicament");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("HospitalApp.Entitites.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("HospitalApp.Entitites.Medicament", b =>
                {
                    b.Navigation("PrescriptionsMedicament");
                });

            modelBuilder.Entity("HospitalApp.Entitites.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("HospitalApp.Entitites.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
