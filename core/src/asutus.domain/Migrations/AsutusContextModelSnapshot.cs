﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using asutus.domain.Data;

#nullable disable

namespace asutus.domain.Migrations
{
    [DbContext(typeof(AsutusContext))]
    partial class AsutusContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("asutus.domain.Entities.Asutus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Asutused");
                });

            modelBuilder.Entity("asutus.domain.Entities.Classifier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Classifiers");
                });

            modelBuilder.Entity("asutus.domain.Entities.InformationSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("InformationSystems");
                });

            modelBuilder.Entity("asutus.domain.Entities.SystemInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("InformationSystemId")
                        .HasColumnType("integer");

                    b.Property<int>("InstanceTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InformationSystemId");

                    b.HasIndex("InstanceTypeId");

                    b.ToTable("SystemInstances");
                });

            modelBuilder.Entity("asutus.domain.Entities.Translation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AsutusId")
                        .HasColumnType("integer");

                    b.Property<int>("LanguageId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AsutusId");

                    b.HasIndex("LanguageId");

                    b.ToTable("Translations");
                });

            modelBuilder.Entity("asutus.domain.Entities.SystemInstance", b =>
                {
                    b.HasOne("asutus.domain.Entities.InformationSystem", "InformationSystem")
                        .WithMany("SystemInstances")
                        .HasForeignKey("InformationSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("asutus.domain.Entities.Classifier", "InstanceType")
                        .WithMany()
                        .HasForeignKey("InstanceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InformationSystem");

                    b.Navigation("InstanceType");
                });

            modelBuilder.Entity("asutus.domain.Entities.Translation", b =>
                {
                    b.HasOne("asutus.domain.Entities.Asutus", "Asutus")
                        .WithMany("Translations")
                        .HasForeignKey("AsutusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("asutus.domain.Entities.Classifier", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asutus");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("asutus.domain.Entities.Asutus", b =>
                {
                    b.Navigation("Translations");
                });

            modelBuilder.Entity("asutus.domain.Entities.InformationSystem", b =>
                {
                    b.Navigation("SystemInstances");
                });
#pragma warning restore 612, 618
        }
    }
}
