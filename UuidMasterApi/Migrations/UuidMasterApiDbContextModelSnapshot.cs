﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UuidMasterApi;

#nullable disable

namespace UuidMasterApi.Migrations
{
    [DbContext(typeof(UuidMasterApiDbContext))]
    partial class UuidMasterApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UuidMasterApi.Entities.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<int>("EntityVersion")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("SourceEntityId")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Uuid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.ToTable("Resources");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EntityType = "SESSION",
                            EntityVersion = 1,
                            Source = "FRONTEND",
                            SourceEntityId = "78",
                            Uuid = "6c3df037-b316-484b-8a0e-7ec7d00a05a3"
                        },
                        new
                        {
                            Id = 2,
                            EntityType = "SESSION",
                            EntityVersion = 1,
                            Source = "CRM",
                            SourceEntityId = "13",
                            Uuid = "6c3df037-b316-484b-8a0e-7ec7d00a05a3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
