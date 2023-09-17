using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalApp.Entitites.Configs
{
    public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
    {
        void IEntityTypeConfiguration<Prescription>.Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPrescription).HasName("Prescription_pk");
            builder.Property(e => e.IdPrescription).UseIdentityColumn();

            builder.Property(e => e.Date).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.DueDate).IsRequired();

            builder.HasOne(e => e.Doctor)
                  .WithMany(e => e.Prescriptions)
                  .HasForeignKey(e => e.IdDoctor)
                  .HasConstraintName("Prescription_Doctor")
                  .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Patient)
                  .WithMany(e => e.Prescriptions)
                  .HasForeignKey(e => e.IdPatient)
                  .HasConstraintName("Prescription_Patient")
                  .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Prescription");


            Prescription[] prescriptions =
            {
                new Prescription{IdPrescription = 1, Date = DateTime.Now.AddDays(-5), DueDate = DateTime.Now.AddDays(30), IdPatient = 1, IdDoctor = 2},
                new Prescription{IdPrescription = 2, DueDate = DateTime.Now.AddDays(60), IdPatient = 4, IdDoctor = 5},
                new Prescription{IdPrescription = 3, DueDate = DateTime.Now.AddDays(50), IdPatient = 3, IdDoctor = 5},
                new Prescription{IdPrescription = 4, Date = DateTime.Now.AddDays(-12), DueDate = DateTime.Now.AddDays(30), IdPatient = 2, IdDoctor = 3},
            };

            builder.HasData(prescriptions);
        }
    }
}
