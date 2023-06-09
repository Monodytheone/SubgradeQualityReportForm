﻿// <auto-generated />
using System;
using FormService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormService.Infrastructure.Migrations
{
    [DbContext(typeof(FormDbContext))]
    partial class FormDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FormService.Domain.Entities.Deflection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SequenceInForm")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("FormId");

                    b.ToTable("T_Deflections", (string)null);
                });

            modelBuilder.Entity("FormService.Domain.Entities.Form", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContractNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContractorCompany")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ExpresswayName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("InspectionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StakeNumberAndLocation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubgradeType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("SubmitTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SupervisionCompany")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("SubmitTime");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("SubmitTime"));

                    b.ToTable("T_Forms", (string)null);
                });

            modelBuilder.Entity("FormService.Domain.Entities.Deflection", b =>
                {
                    b.HasOne("FormService.Domain.Entities.Form", "Form")
                        .WithMany("Deflections")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FormService.Domain.Entities.ValueObjects.InspectionDetail", "InspectionDetail", b1 =>
                        {
                            b1.Property<Guid>("DeflectionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("InspectionResult")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Note")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SpecifiedValueAndAllowableDeviation")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("DeflectionId");

                            b1.ToTable("T_Deflections");

                            b1.WithOwner()
                                .HasForeignKey("DeflectionId");
                        });

                    b.Navigation("Form");

                    b.Navigation("InspectionDetail")
                        .IsRequired();
                });

            modelBuilder.Entity("FormService.Domain.Entities.Form", b =>
                {
                    b.OwnsOne("FormService.Domain.Entities.ValueObjects.InspectionDetail", "ExtraAndExtremely_0_1dot20m_", b1 =>
                        {
                            b1.Property<Guid>("FormId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("InspectionResult")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Note")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SpecifiedValueAndAllowableDeviation")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("FormId");

                            b1.ToTable("T_Forms");

                            b1.WithOwner()
                                .HasForeignKey("FormId");
                        });

                    b.OwnsOne("FormService.Domain.Entities.ValueObjects.InspectionDetail", "ExtraAndExtremely_1dot20_1dot90m_", b1 =>
                        {
                            b1.Property<Guid>("FormId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("InspectionResult")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Note")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SpecifiedValueAndAllowableDeviation")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("FormId");

                            b1.ToTable("T_Forms");

                            b1.WithOwner()
                                .HasForeignKey("FormId");
                        });

                    b.OwnsOne("FormService.Domain.Entities.ValueObjects.InspectionDetail", "ExtraAndExtremely_GreaterThan_1dot90m_", b1 =>
                        {
                            b1.Property<Guid>("FormId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("InspectionResult")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Note")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SpecifiedValueAndAllowableDeviation")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("FormId");

                            b1.ToTable("T_Forms");

                            b1.WithOwner()
                                .HasForeignKey("FormId");
                        });

                    b.OwnsOne("FormService.Domain.Entities.ValueObjects.InspectionDetail", "LightModerateAndHeavy_0_0dot80m_", b1 =>
                        {
                            b1.Property<Guid>("FormId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("InspectionResult")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Note")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SpecifiedValueAndAllowableDeviation")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("FormId");

                            b1.ToTable("T_Forms");

                            b1.WithOwner()
                                .HasForeignKey("FormId");
                        });

                    b.OwnsOne("FormService.Domain.Entities.ValueObjects.InspectionDetail", "LightModerateAndHeavy_0dot80_1dot50m_", b1 =>
                        {
                            b1.Property<Guid>("FormId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("InspectionResult")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Note")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SpecifiedValueAndAllowableDeviation")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("FormId");

                            b1.ToTable("T_Forms");

                            b1.WithOwner()
                                .HasForeignKey("FormId");
                        });

                    b.OwnsOne("FormService.Domain.Entities.ValueObjects.InspectionDetail", "LightModerateAndHeavy_GreaterThan_1dot50m_", b1 =>
                        {
                            b1.Property<Guid>("FormId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("InspectionResult")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Note")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SpecifiedValueAndAllowableDeviation")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("FormId");

                            b1.ToTable("T_Forms");

                            b1.WithOwner()
                                .HasForeignKey("FormId");
                        });

                    b.OwnsOne("FormService.Domain.Entities.ValueObjects.InspectionDetail", "ZeroFillingAndCutting_0_0dot80m_", b1 =>
                        {
                            b1.Property<Guid>("FormId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("InspectionResult")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Note")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SpecifiedValueAndAllowableDeviation")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("FormId");

                            b1.ToTable("T_Forms");

                            b1.WithOwner()
                                .HasForeignKey("FormId");
                        });

                    b.OwnsOne("FormService.Domain.Entities.ValueObjects.ConstructionDate", "ConstructionDate", b1 =>
                        {
                            b1.Property<Guid>("FormId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("FormId");

                            b1.ToTable("T_Forms");

                            b1.WithOwner()
                                .HasForeignKey("FormId");
                        });

                    b.OwnsOne("FormService.Domain.Entities.ValueObjects.SupervisorOpinion", "SupervisorOpinion", b1 =>
                        {
                            b1.Property<Guid>("FormId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("IsQualified")
                                .IsRequired()
                                .HasMaxLength(11)
                                .IsUnicode(false)
                                .HasColumnType("varchar(11)");

                            b1.Property<DateTime>("SupervisionDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("SupervisorName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("UnqualifiedItems")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.HasKey("FormId");

                            b1.ToTable("T_Forms");

                            b1.WithOwner()
                                .HasForeignKey("FormId");
                        });

                    b.Navigation("ConstructionDate")
                        .IsRequired();

                    b.Navigation("ExtraAndExtremely_0_1dot20m_")
                        .IsRequired();

                    b.Navigation("ExtraAndExtremely_1dot20_1dot90m_")
                        .IsRequired();

                    b.Navigation("ExtraAndExtremely_GreaterThan_1dot90m_")
                        .IsRequired();

                    b.Navigation("LightModerateAndHeavy_0_0dot80m_")
                        .IsRequired();

                    b.Navigation("LightModerateAndHeavy_0dot80_1dot50m_")
                        .IsRequired();

                    b.Navigation("LightModerateAndHeavy_GreaterThan_1dot50m_")
                        .IsRequired();

                    b.Navigation("SupervisorOpinion")
                        .IsRequired();

                    b.Navigation("ZeroFillingAndCutting_0_0dot80m_")
                        .IsRequired();
                });

            modelBuilder.Entity("FormService.Domain.Entities.Form", b =>
                {
                    b.Navigation("Deflections");
                });
#pragma warning restore 612, 618
        }
    }
}
