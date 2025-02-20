using Microsoft.EntityFrameworkCore;
using TobaccoDMInputAcceptance.InitialInspections;
using TobaccoDMInputAcceptance.SubsidyRules;
using Volo.Abp;

namespace TobaccoDMInputAcceptance.EntityFrameworkCore;

public static class TobaccoDMInputAcceptanceDbContextModelCreatingExtensions
{
    public static void ConfigureProjectName(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<InitialInspection>(b =>
        {
            b.ToTable("InitialInspections", TobaccoDMInputAcceptanceDomainOptions.DbSchemaName);
            b.HasKey(x => x.Id);

            // 值对象
            // 从属实体类型
            b.OwnsOne(p => p.InitialInspector, c =>
            {
                c.Property(x => x.UserId).HasColumnName("InspectorUserId");
                c.Property(x => x.UserName).HasColumnName("InspectorUserName");
                c.Property(x => x.DeptId).HasColumnName("InspectorDeptId");
            });
            
            // 一对多
            b.HasMany(e => e.TobaccoGrowers)
                .WithOne()
                .HasForeignKey(e => e.InitialInspectionId)
                .IsRequired();
        });
        
        builder.Entity<TobaccoGrower>(b =>
        {
            b.ToTable("TobaccoGrowers", TobaccoDMInputAcceptanceDomainOptions.DbSchemaName);
            b.HasKey(x => x.Id);
        });

        builder.Entity<InvestmentRules>(b =>
        {
            b.ToTable("InvestmentRules", TobaccoDMInputAcceptanceDomainOptions.DbSchemaName);
            
            b.HasKey(x => x.Id);

            //投入规则小类
            b.OwnsOne(p => p.InSmallCategories, c =>
            {
                c.ToJson();
                c.Property(e => e.Id).HasMaxLength(36);
                c.Property(e => e.Name).HasMaxLength(50);
                c.Property(e => e.PartId).HasMaxLength(36);
                c.Property(e => e.PartName).HasMaxLength(50);
            });

            //投入类型
            b.OwnsOne(p => p.TypeInvestment, c =>
            {
                c.ToJson();
                c.Property(e => e.Id).HasMaxLength(36);
                c.Property(e => e.Name).HasMaxLength(50);
            });

            b.HasMany(e => e.ProjectCalculationFormula).WithOne().HasForeignKey(e => e.PartId).IsRequired();

            b.HasMany(e => e.PublishingUnits).WithOne().HasForeignKey(e => e.PartId).IsRequired();
        });

        builder.Entity<ProjectCalculationFormula>(b =>
        {
            b.ToTable("ProjectCalculationFormula", TobaccoDMInputAcceptanceDomainOptions.DbSchemaName);
            b.HasKey(x => x.Id);

            //投入品类
            b.OwnsOne(p => p.CategoryInvestment, c =>
            {
                c.ToJson();
                c.Property(e => e.Id).HasMaxLength(36);
                c.Property(e => e.Name).HasMaxLength(50);

            });

            //职业烟农选择
            b.OwnsOne(p => p.TobaccoFarmerChoice, c =>
            {
                c.ToJson();
                c.Property(e => e.Id).HasMaxLength(36);
                c.Property(e => e.Name).HasMaxLength(50);
            });

            //建档立卡户类型
            b.OwnsOne(p =>p.TypeOfRegisteredAccount, c =>
            {
                c.ToJson();
                c.Property(e => e.Id).HasMaxLength(36);
                c.Property(e => e.Name).HasMaxLength(50);
            });

            //烟叶品种  
            b.OwnsOne(p => p.TobaccoVarieties, c =>
            {
                c.ToJson();
                c.Property(e => e.Id).HasMaxLength(36);
                c.Property(e => e.Name).HasMaxLength(50);
            });

        });

        builder.Entity<PublishingUnit>(b =>
        {
            b.ToTable("PublishingUnit", TobaccoDMInputAcceptanceDomainOptions.DbSchemaName);
            b.HasKey(x => x.Id);
        });
    }
}