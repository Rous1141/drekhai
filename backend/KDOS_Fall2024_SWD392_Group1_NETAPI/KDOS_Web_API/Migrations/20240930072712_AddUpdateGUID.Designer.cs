﻿// <auto-generated />
using KDOS_Web_API.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KDOS_Web_API.Migrations
{
    [DbContext(typeof(KDOSDbContext))]
    [Migration("20240930072712_AddUpdateGUID")]
    partial class AddUpdateGUID
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("KDOS_Web_API.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("AccountId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("KDOS_Web_API.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Addressess")
                        .HasColumnType("longtext");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("KDOS_Web_API.Models.KoiFish", b =>
                {
                    b.Property<int>("KoiFishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("KoiFishId"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("FishType")
                        .HasColumnType("longtext");

                    b.Property<string>("HealthStatus")
                        .HasColumnType("longtext");

                    b.HasKey("KoiFishId");

                    b.ToTable("KoiFish");
                });

            modelBuilder.Entity("KDOS_Web_API.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("OrderDetailsId"));

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("float");

                    b.HasKey("OrderDetailsId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("KDOS_Web_API.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("StaffName")
                        .HasColumnType("longtext");

                    b.HasKey("StaffId");

                    b.ToTable("Staff");
                });
#pragma warning restore 612, 618
        }
    }
}
