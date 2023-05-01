using FormService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormService.Infrastructure.EntityConfigs;

public class FormConfig : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.ToTable("T_Forms");
        builder.HasKey(form => form.Id).IsClustered(false);
        builder.Property(form => form.ExpresswayName).HasMaxLength(50);  // 约定就是nvarchar，不用专门配置
        builder.Property(form => form.ContractorCompany).HasMaxLength(50);
        builder.Property(form => form.SupervisionCompany).HasMaxLength(50);
        builder.Property(form => form.ContractNumber).HasMaxLength(100);
        builder.Property(form => form.SerialNumber).HasMaxLength(100);
        builder.Property(form => form.SubgradeType)
            .HasConversion<string>()
            .HasMaxLength(10)
            .IsUnicode(false);
        builder.Property(form => form.SerialNumber).HasMaxLength(50);
        builder.Property(form => form.StakeNumberAndLocation).HasMaxLength(100);

        // 值对象：
        builder.OwnsOne(form => form.ConstructionDate);
        builder.OwnsOne(form => form.ZeroFillingAndCutting_0_0dot80m_, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.Property(detail => detail.SpecifiedValueAndAllowableDeviation)
                .HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.InspectionResult).HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.Code).HasMaxLength(500);
        });  // 0
        builder.OwnsOne(form => form.LightModerateAndHeavy_0_0dot80m_, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.Property(detail => detail.SpecifiedValueAndAllowableDeviation)
                .HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.InspectionResult).HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.Code).HasMaxLength(500);
        });  // 1
        builder.OwnsOne(form => form.ExtraAndExtremely_0_1dot20m_, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.Property(detail => detail.SpecifiedValueAndAllowableDeviation)
                .HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.InspectionResult).HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.Code).HasMaxLength(500);
        });  // 2
        builder.OwnsOne(form => form.LightModerateAndHeavy_0dot80_1dot50m_, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.Property(detail => detail.SpecifiedValueAndAllowableDeviation)
                .HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.InspectionResult).HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.Code).HasMaxLength(500);
        });  // 3
        builder.OwnsOne(form => form.ExtraAndExtremely_1dot20_1dot90m_, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.Property(detail => detail.SpecifiedValueAndAllowableDeviation)
                .HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.InspectionResult).HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.Code).HasMaxLength(500);
        });  // 4
        builder.OwnsOne(form => form.LightModerateAndHeavy_GreaterThan_1dot50m_, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.Property(detail => detail.SpecifiedValueAndAllowableDeviation)
                .HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.InspectionResult).HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.Code).HasMaxLength(500);
        });  // 5
        builder.OwnsOne(form => form.ExtraAndExtremely_GreaterThan_1dot90m_, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.Property(detail => detail.SpecifiedValueAndAllowableDeviation)
                .HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.InspectionResult).HasMaxLength(100);
            ownedNavigationBuilder.Property(detail => detail.Code).HasMaxLength(500);
        });  // 6

        // 与弯沉一对多关系配置放在弯沉实体类的配置类里
    }
}
