using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HospitalApp.SecurityPassword;

namespace HospitalApp.Entitites.Configs
{
    public class UserEfConfiguration : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.IdUser).HasName("User_pk");
            builder.Property(e => e.IdUser).UseIdentityColumn();

            builder.Property(e => e.Login).IsRequired();
            builder.Property(e => e.Password).IsRequired();
            builder.Property(e => e.Salt).IsRequired();
            builder.Property(e => e.RefreshToken).IsRequired();
            builder.Property(e => e.RerfreshTokenExpiration);

            builder.ToTable("User");
        }
    }
}
