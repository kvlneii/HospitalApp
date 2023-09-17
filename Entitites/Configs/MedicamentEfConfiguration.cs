using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalApp.Entitites.Configs
{
    public class MedicamentEfConfiguration : IEntityTypeConfiguration<Medicament>
    {
        void IEntityTypeConfiguration<Medicament>.Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.IdMedicament).HasName("Medicament_pk");
            builder.Property(e => e.IdMedicament).UseIdentityColumn();

            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Desciption).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Type).IsRequired().HasMaxLength(100);

            builder.ToTable("Medicament");

            Medicament[] medicaments =
            {
                new Medicament { IdMedicament = 1, Name = "Paracetamol", Desciption = "Pain reliever", Type = "Over-the-counter" },
                new Medicament { IdMedicament = 2, Name = "Amoxicillin", Desciption = "Antibiotic", Type = "Prescription" },
                new Medicament { IdMedicament = 3, Name = "Lisinopril", Desciption = "Blood pressure medication", Type = "Prescription" },
                new Medicament { IdMedicament = 4, Name = "Aspirin", Desciption = "Pain reliever", Type = "Over-the-counter" },
            };

            builder.HasData(medicaments);
        }
    }

}
