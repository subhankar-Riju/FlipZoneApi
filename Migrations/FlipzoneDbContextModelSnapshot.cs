﻿// <auto-generated />
using FlipZoneApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlipZoneApi.Migrations
{
    [DbContext(typeof(FlipzoneDbContext))]
    partial class FlipzoneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlipZoneApi.Data.Customer", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("email");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FlipZoneApi.Data.Laptop", b =>
                {
                    b.Property<string>("p_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<double>("rating")
                        .HasColumnType("float");

                    b.HasKey("p_id");

                    b.ToTable("Laptops");
                });

            modelBuilder.Entity("FlipZoneApi.Data.Mobile", b =>
                {
                    b.Property<string>("p_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<double>("rating")
                        .HasColumnType("float");

                    b.HasKey("p_id");

                    b.ToTable("Mobiles");
                });

            modelBuilder.Entity("FlipZoneApi.Data.Tablet", b =>
                {
                    b.Property<string>("p_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<double>("rating")
                        .HasColumnType("float");

                    b.HasKey("p_id");

                    b.ToTable("Tablets");
                });
#pragma warning restore 612, 618
        }
    }
}