﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinoBank.Infrastructure.Data;

#nullable disable

namespace MinoBank.Infrastructure.Migrations
{
    [DbContext(typeof(MinoBankDbContext))]
    partial class MinoBankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<decimal>("MonthlyLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.ToTable("BankCards");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankCardDetails", b =>
                {
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

                    b.HasKey("BankCardId");

                    b.ToTable("BankCardDetails");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

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

                    b.Property<Guid>("RecipientBankCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RecipientBankCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SenderBankCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SenderBankCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipientBankCardId");

                    b.HasIndex("SenderBankCardId");

                    b.ToTable("BankTransactions");
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

                    b.Navigation("BankAccount");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankCardDetails", b =>
                {
                    b.HasOne("MinoBank.Core.Entities.BankCard", "BankCard")
                        .WithOne("Details")
                        .HasForeignKey("MinoBank.Core.Entities.BankCardDetails", "BankCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankCard");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankTransaction", b =>
                {
                    b.HasOne("MinoBank.Core.Entities.BankCard", "RecipientBankCard")
                        .WithMany("RecivedTransactions")
                        .HasForeignKey("RecipientBankCardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MinoBank.Core.Entities.BankCard", "SenderBankCard")
                        .WithMany("SentTransactions")
                        .HasForeignKey("SenderBankCardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RecipientBankCard");

                    b.Navigation("SenderBankCard");
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankAccount", b =>
                {
                    b.Navigation("BankCards");

                    b.Navigation("Details")
                        .IsRequired();
                });

            modelBuilder.Entity("MinoBank.Core.Entities.BankCard", b =>
                {
                    b.Navigation("Details")
                        .IsRequired();

                    b.Navigation("RecivedTransactions");

                    b.Navigation("SentTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
