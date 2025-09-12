using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserApi.Entities;

namespace UserApi.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Nome).HasColumnName("Nome").HasColumnType("NVARCHAR").HasMaxLength(80).IsRequired();
            builder.Property(x => x.Sobrenome).HasColumnName("Sobrenome").HasColumnType("NVARCHAR").HasMaxLength(120).IsRequired();
            builder.Property(x => x.Cpf).HasColumnName("CPF").HasColumnType("VARCHAR").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("NVARCHAR").HasMaxLength(80).IsRequired();
            builder.Property(x => x.Password).HasColumnName("PasswordHash").HasColumnType("NVARCHAR").HasMaxLength(255).IsRequired();

            builder.HasIndex(x => x.Cpf, "IX_User_Cpf").IsUnique();

        }
    }
}
