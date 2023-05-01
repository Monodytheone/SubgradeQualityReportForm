using FormService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormService.Infrastructure.EntityConfigs;

public class DeflectionConfig : IEntityTypeConfiguration<Deflection>
{
    public void Configure(EntityTypeBuilder<Deflection> builder)
    {
        builder.ToTable("T_Deflections");
        builder.HasKey(x => x.Id).IsClustered(false);
        builder.HasOne(deflection => deflection.Form).WithMany(form => form.Deflections);
        builder.OwnsOne(deflection => deflection.InspectionDetail, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.Property(detail => detail.SpecifiedValueAndAllowableDeviation)
                .HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.InspectionResult).HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.Code).HasMaxLength(500);
        });
    }
}
