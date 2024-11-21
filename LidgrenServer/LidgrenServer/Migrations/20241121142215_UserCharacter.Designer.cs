﻿// <auto-generated />
using System;
using LidgrenServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LidgrenServer.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20241121142215_UserCharacter")]
    partial class UserCharacter
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LidgrenServer.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("IsSelectedCharacter")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_selected_character");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("exp")
                        .HasColumnType("int")
                        .HasColumnName("exp");

                    b.Property<int>("level")
                        .HasColumnType("int")
                        .HasColumnName("level");

                    b.HasKey("Id");

                    b.ToTable("character");
                });

            modelBuilder.Entity("LidgrenServer.Models.LoginHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("device_id");

                    b.Property<DateTime>("LoginTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("login_time");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("LoginTime");

                    b.HasIndex("UserId");

                    b.ToTable("login_history");
                });

            modelBuilder.Entity("LidgrenServer.Models.UserCharacter", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int")
                        .HasColumnName("character_id");

                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.HasKey("UserId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("user_characters");
                });

            modelBuilder.Entity("LidgrenServer.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("Coin")
                        .HasColumnType("int")
                        .HasColumnName("coin");

                    b.Property<string>("Display_name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("display_name");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_online");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("Username");

                    b.ToTable("users");
                });

            modelBuilder.Entity("LidgrenServer.Models.LoginHistory", b =>
                {
                    b.HasOne("LidgrenServer.Models.UserModel", "UserModel")
                        .WithMany("LoginHistory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserModel");
                });

            modelBuilder.Entity("LidgrenServer.Models.UserCharacter", b =>
                {
                    b.HasOne("LidgrenServer.Models.Character", "Character")
                        .WithMany("UserCharacters")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LidgrenServer.Models.UserModel", "User")
                        .WithMany("UserCharacters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LidgrenServer.Models.Character", b =>
                {
                    b.Navigation("UserCharacters");
                });

            modelBuilder.Entity("LidgrenServer.Models.UserModel", b =>
                {
                    b.Navigation("LoginHistory");

                    b.Navigation("UserCharacters");
                });
#pragma warning restore 612, 618
        }
    }
}