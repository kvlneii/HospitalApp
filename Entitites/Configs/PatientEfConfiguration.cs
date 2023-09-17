using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalApp.Entitites.Configs
{
    public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
    {
        void IEntityTypeConfiguration<Patient>.Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient).HasName("Patient_pk");
            builder.Property(e => e.IdPatient).UseIdentityColumn();

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Birthdate).IsRequired();

            builder.ToTable("Patient");

            Patient[] patients =
            {
                new Patient{IdPatient = 1, FirstName = "Philip", LastName= "Stafford", Birthdate = DateTime.Now.AddYears(-50)},
                new Patient{IdPatient = 2, FirstName = "Hollie", LastName= "Eaton", Birthdate = DateTime.Now.AddYears(-30)},
                new Patient{IdPatient = 3, FirstName = "Kimberley", LastName= "Fernandez", Birthdate = DateTime.Now.AddYears(-19)},
                new Patient{IdPatient = 4, FirstName = "Rueben", LastName= "Lowery", Birthdate = DateTime.Now.AddYears(-67)},
            };

            builder.HasData(patients);
        }
    }
}
