﻿// <auto-generated />
using CityServicesPortal.Petitions.Domain.Models;
using CityServicesPortal.Petitions.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CityServicesPortal.Petitions.Infra.Data.Migrations
{
    [DbContext(typeof(PetitionContext))]
    partial class PetitionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CityServicesPortal.Petitions.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CityServicesPortal.Petitions.Domain.Models.Petition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Petitions");
                });

            modelBuilder.Entity("CityServicesPortal.Petitions.Domain.Models.PetitionVoter", b =>
                {
                    b.Property<Guid>("PetitionId");

                    b.Property<Guid>("UserId");

                    b.HasKey("PetitionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PetitionVoter");
                });

            modelBuilder.Entity("CityServicesPortal.Petitions.Domain.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<Guid>("PetitionId");

                    b.Property<string>("Text");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PetitionId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("CityServicesPortal.Petitions.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<int>("IdentityId");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CityServicesPortal.Petitions.Domain.Models.Petition", b =>
                {
                    b.HasOne("CityServicesPortal.Petitions.Domain.Models.Category", "Category")
                        .WithMany("Petitions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CityServicesPortal.Petitions.Domain.Models.User", "User")
                        .WithMany("Petitions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CityServicesPortal.Petitions.Domain.Models.PetitionVoter", b =>
                {
                    b.HasOne("CityServicesPortal.Petitions.Domain.Models.Petition", "Petition")
                        .WithMany("PetitionVoters")
                        .HasForeignKey("PetitionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CityServicesPortal.Petitions.Domain.Models.User", "User")
                        .WithMany("PetitionVoters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CityServicesPortal.Petitions.Domain.Models.Review", b =>
                {
                    b.HasOne("CityServicesPortal.Petitions.Domain.Models.Petition", "Petition")
                        .WithOne("Review")
                        .HasForeignKey("CityServicesPortal.Petitions.Domain.Models.Review", "PetitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CityServicesPortal.Petitions.Domain.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
