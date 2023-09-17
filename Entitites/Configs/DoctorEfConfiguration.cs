using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalApp.Entitites.Configs
{
    public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
    {
        void IEntityTypeConfiguration<Doctor>.Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.IdDoctor).HasName("Doctor_pk");
            builder.Property(e => e.IdDoctor).UseIdentityColumn();

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);

            builder.ToTable("Doctor");

            Doctor[] doctors =
            {
                new Doctor{IdDoctor = 1, FirstName = "Connor", LastName= "Richardson", Email = "jicet34417@gmail.com"},
                new Doctor{IdDoctor = 2, FirstName = "Lisa", LastName= "Pearson", Email = "lPearson23@gmail.com"},
                new Doctor{IdDoctor = 3, FirstName = "Saarah", LastName= "Flores", Email = "sssflores@gmail.com"},
                new Doctor{IdDoctor = 4, FirstName = "Alexander", LastName= "Mathis", Email = "d.mathis@gmail.com"},
                new Doctor{IdDoctor = 5, FirstName = "Amelie", LastName= "Lozano", Email = "lozano6879@gmail.com"},
            };

            builder.HasData(doctors);
        }
    }
}
