﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinoBank.Infrastructure.Data;

#nullable disable

namespace MinoBank.Infrastructure.Migrations
{
    [DbContext(typeof(MinoBankDbContext))]
    [Migration("20241228152829_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MinoBank.Core.Entities.BankAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankAccountDetails", b =>
                {
                    b.Property<Guid>("BankAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BankAccountId");

                    b.ToTable("BankAccountDetails");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AnnualLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("BankAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DailyLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("DetailsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("MonthlyLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PinCode")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.HasIndex("DetailsId")
                        .IsUnique();

                    b.ToTable("BankCards");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankCardDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BankCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyCode")
                        .HasColumnType("int");

                    b.Property<string>("CvvCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpiryDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BankCardDetails");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("BankCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<decimal>("Commission")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrencyCode")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankCardId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankAccountDetails", b =>
                {
                    b.HasOne("MinoBank.Core.Entities.BankAccount", "BankAccount")
                        .WithOne("Details")
                        .HasForeignKey("MinoBank.Core.Entities.BankAccountDetails", "BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAccount");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankCard", b =>
                {
                    b.HasOne("MinoBank.Core.Entities.BankAccount", "BankAccount")
                        .WithMany("BankCards")
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinoBank.Core.Entities.BankCardDetails", "Details")
                        .WithOne("BankCard")
                        .HasForeignKey("MinoBank.Core.Entities.BankCard", "DetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAccount");

                    b.Navigation("Details");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.Transaction", b =>
                {
                    b.HasOne("MinoBank.Core.Entities.BankCard", null)
                        .WithMany("Transactions")
                        .HasForeignKey("BankCardId");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankAccount", b =>
                {
                    b.Navigation("BankCards");

                    b.Navigation("Details");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankCard", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankCardDetails", b =>
                {
                    b.Navigation("BankCard")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
