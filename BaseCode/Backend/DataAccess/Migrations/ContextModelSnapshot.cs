﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmailHolderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("EmailHolderId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeviceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.DummyLeak", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DummyLeaks");
                });

            modelBuilder.Entity("Domain.EmailHolder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("WasLeaked")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("Domain.LeakedSite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmailHolderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("NotificationSent")
                        .HasColumnType("bit");

                    b.Property<string>("Site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmailHolderId");

                    b.ToTable("LeakedSites");
                });

            modelBuilder.Entity("Domain.Account", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany("Accounts")
                        .HasForeignKey("AppUserId");

                    b.HasOne("Domain.EmailHolder", "EmailHolder")
                        .WithMany()
                        .HasForeignKey("EmailHolderId");

                    b.Navigation("EmailHolder");
                });

            modelBuilder.Entity("Domain.LeakedSite", b =>
                {
                    b.HasOne("Domain.EmailHolder", null)
                        .WithMany("LeakedSites")
                        .HasForeignKey("EmailHolderId");
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Domain.EmailHolder", b =>
                {
                    b.Navigation("LeakedSites");
                });
#pragma warning restore 612, 618
        }
    }
}
