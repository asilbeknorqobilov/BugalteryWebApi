﻿// <auto-generated />
using System;
using Bugaltery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bugaltery.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20241117082215_Yangilanish")]
    partial class Yangilanish
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bugaltery.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Apartment")
                        .HasColumnType("integer");

                    b.Property<int>("Building")
                        .HasColumnType("integer");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<string>("Quarter")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ResidentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ResidentId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Bugaltery.Model.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("Bugaltery.Model.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<float>("PaymentAmount")
                        .HasColumnType("real");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Bugaltery.Model.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("Bugaltery.Model.Resident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Residents");
                });

            modelBuilder.Entity("Bugaltery.Model.Address", b =>
                {
                    b.HasOne("Bugaltery.Model.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bugaltery.Model.Resident", null)
                        .WithMany("Addresses")
                        .HasForeignKey("ResidentId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Bugaltery.Model.Owner", b =>
                {
                    b.HasOne("Bugaltery.Model.Address", null)
                        .WithMany("Owners")
                        .HasForeignKey("AddressId");

                    b.HasOne("Bugaltery.Model.Payment", null)
                        .WithMany("Owners")
                        .HasForeignKey("PaymentId");
                });

            modelBuilder.Entity("Bugaltery.Model.Payment", b =>
                {
                    b.HasOne("Bugaltery.Model.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bugaltery.Model.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("Bugaltery.Model.PaymentType", b =>
                {
                    b.HasOne("Bugaltery.Model.Payment", null)
                        .WithMany("PaymentTypes")
                        .HasForeignKey("PaymentId");
                });

            modelBuilder.Entity("Bugaltery.Model.Resident", b =>
                {
                    b.HasOne("Bugaltery.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Bugaltery.Model.Address", b =>
                {
                    b.Navigation("Owners");
                });

            modelBuilder.Entity("Bugaltery.Model.Payment", b =>
                {
                    b.Navigation("Owners");

                    b.Navigation("PaymentTypes");
                });

            modelBuilder.Entity("Bugaltery.Model.Resident", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
