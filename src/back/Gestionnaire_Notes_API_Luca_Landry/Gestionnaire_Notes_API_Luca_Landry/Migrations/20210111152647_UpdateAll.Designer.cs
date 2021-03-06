﻿// <auto-generated />
using System;
using Gestionnaire_Notes_API_Luca_Landry.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gestionnaire_Notes_API_Luca_Landry.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210111152647_UpdateAll")]
    partial class UpdateAll
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("Gestionnaire_Notes_API_Luca_Landry.Models.BrancheModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("barem")
                        .HasColumnType("INTEGER");

                    b.Property<string>("brancheName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("philialId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("philialId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Gestionnaire_Notes_API_Luca_Landry.Models.NoteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrancheId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("note")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BrancheId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Gestionnaire_Notes_API_Luca_Landry.Models.PhilialModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("philialName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Philials");
                });

            modelBuilder.Entity("Gestionnaire_Notes_API_Luca_Landry.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("BLOB");

                    b.Property<bool>("admin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("userLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("userPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Gestionnaire_Notes_API_Luca_Landry.Models.BrancheModel", b =>
                {
                    b.HasOne("Gestionnaire_Notes_API_Luca_Landry.Models.PhilialModel", "Philial")
                        .WithMany()
                        .HasForeignKey("philialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gestionnaire_Notes_API_Luca_Landry.Models.NoteModel", b =>
                {
                    b.HasOne("Gestionnaire_Notes_API_Luca_Landry.Models.BrancheModel", "Branche")
                        .WithMany()
                        .HasForeignKey("BrancheId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gestionnaire_Notes_API_Luca_Landry.Models.PhilialModel", b =>
                {
                    b.HasOne("Gestionnaire_Notes_API_Luca_Landry.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
