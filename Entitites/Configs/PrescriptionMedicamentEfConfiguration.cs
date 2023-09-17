using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalApp.Entitites.Configs
{
    public class PrescriptionMedicamentEfConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        void IEntityTypeConfiguration<PrescriptionMedicament>.Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.HasKey(e => new { e.IdMedicament, e.IdPrescription }).HasName("PrescriptionMedicament_pk");

            builder.Property(e => e.Dose);
            builder.Property(e => e.Details).IsRequired().HasMaxLength(100);

            builder.HasOne(e => e.Medicament)
                  .WithMany(e => e.PrescriptionsMedicament)
                  .HasForeignKey(e => e.IdMedicament)
                  .HasConstraintName("PrescriptionMedicament_Medicament")
                  .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Prescription)
                  .WithMany(e => e.PrescriptionMedicaments)
                  .HasForeignKey(e => e.IdPrescription)
                  .HasConstraintName("PrescriptionMedicament_Prescription")
                  .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Prescription_Medicament");

            PrescriptionMedicament[] prescriptionMedicaments =
            {
                new PrescriptionMedicament {IdMedicament = 1, IdPrescription = 4, Dose = 2, Details = "Take once daily"},
                new PrescriptionMedicament {IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "Take as needed"},
                new PrescriptionMedicament {IdMedicament = 2, IdPrescription = 3, Dose = 6, Details = "Take with food"},
                new PrescriptionMedicament {IdMedicament = 2, IdPrescription = 2, Dose = 14, Details = "Take twice daily"},
            };

            builder.HasData(prescriptionMedicaments);
        }
    }
}
