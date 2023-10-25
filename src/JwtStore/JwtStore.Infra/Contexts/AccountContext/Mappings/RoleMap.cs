using JwtStore.Core.Contexts.AccountContext.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Infra.Contexts.AccountContext.Mappings
{
  public class RoleMap : IEntityTypeConfiguration<Role>
  {
    public void Configure(EntityTypeBuilder<Role> builder)
    {
      builder.ToTable("Role");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Name)
          .HasColumnName("Name")
          .HasColumnType("NVARCHAR")
          .HasMaxLength(120)
          .IsRequired(true);
    }
  }
}
