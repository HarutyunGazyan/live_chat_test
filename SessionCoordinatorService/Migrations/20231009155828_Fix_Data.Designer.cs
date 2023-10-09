﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.Library.Entities;

#nullable disable

namespace SessionCoordinatorService.Migrations
{
    [DbContext(typeof(SupportDbContext))]
    [Migration("20231009155828_Fix_Data")]
    partial class Fix_Data
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shared.Library.Entities.ActiveAgentSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("SessionId")
                        .IsUnique();

                    b.ToTable("ActiveAgentSessions");
                });

            modelBuilder.Entity("Shared.Library.Entities.Agent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SeniorityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SeniorityId");

                    b.HasIndex("TeamId");

                    b.ToTable("Agents");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7371da25-aed5-4729-83f3-8f019162e247"),
                            Name = "Team_A_Team_Lead",
                            SeniorityId = new Guid("8a23ef84-55e1-4c52-9fa2-20479c9bec0e"),
                            TeamId = new Guid("d3287426-98f0-4d8a-9588-0f44c19f0b2c")
                        },
                        new
                        {
                            Id = new Guid("af177e89-a80a-42a2-99f4-bc0526948ae9"),
                            Name = "Team_A_Mid_1",
                            SeniorityId = new Guid("6d4d0945-4b98-40b3-a24e-daad2096b837"),
                            TeamId = new Guid("d3287426-98f0-4d8a-9588-0f44c19f0b2c")
                        },
                        new
                        {
                            Id = new Guid("bec11bf9-03f0-4ee4-aa0e-9bc7f389ba94"),
                            Name = "Team_A_Mid_2",
                            SeniorityId = new Guid("6d4d0945-4b98-40b3-a24e-daad2096b837"),
                            TeamId = new Guid("d3287426-98f0-4d8a-9588-0f44c19f0b2c")
                        },
                        new
                        {
                            Id = new Guid("6ac6422a-8175-45f1-9e2d-b26795ef159a"),
                            Name = "Team_A_Junior",
                            SeniorityId = new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"),
                            TeamId = new Guid("d3287426-98f0-4d8a-9588-0f44c19f0b2c")
                        },
                        new
                        {
                            Id = new Guid("fae50fbb-5940-4981-beb3-863086e1c127"),
                            Name = "Team_B_Senior",
                            SeniorityId = new Guid("705e8762-21c4-445c-b400-8197b864c10b"),
                            TeamId = new Guid("53dbdf96-52fc-4ead-86d5-8216705572ba")
                        },
                        new
                        {
                            Id = new Guid("d772fa06-b498-4f6d-a76a-d309d4b12e77"),
                            Name = "Team_B_Mid",
                            SeniorityId = new Guid("6d4d0945-4b98-40b3-a24e-daad2096b837"),
                            TeamId = new Guid("53dbdf96-52fc-4ead-86d5-8216705572ba")
                        },
                        new
                        {
                            Id = new Guid("95bf41de-d41e-45b7-8ad7-96cc659f69bf"),
                            Name = "Team_B_Junior_1",
                            SeniorityId = new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"),
                            TeamId = new Guid("53dbdf96-52fc-4ead-86d5-8216705572ba")
                        },
                        new
                        {
                            Id = new Guid("9c8b506b-03c6-4b38-a943-3299ea11e27d"),
                            Name = "Team_B_Junior_2",
                            SeniorityId = new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"),
                            TeamId = new Guid("53dbdf96-52fc-4ead-86d5-8216705572ba")
                        },
                        new
                        {
                            Id = new Guid("68546cd7-c67b-43f6-9414-8ed0d3c18f70"),
                            Name = "Team_C_Mid_1",
                            SeniorityId = new Guid("6d4d0945-4b98-40b3-a24e-daad2096b837"),
                            TeamId = new Guid("da3659ba-a6ff-471a-8ec1-f7b819e22447")
                        },
                        new
                        {
                            Id = new Guid("92766907-c000-46e1-8a8f-afe49a5ae43b"),
                            Name = "Team_C_Mid_2",
                            SeniorityId = new Guid("6d4d0945-4b98-40b3-a24e-daad2096b837"),
                            TeamId = new Guid("da3659ba-a6ff-471a-8ec1-f7b819e22447")
                        },
                        new
                        {
                            Id = new Guid("7db9b214-98fd-4704-befe-ccb2c30d3a58"),
                            Name = "Team_Overflow_Junior_1",
                            SeniorityId = new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"),
                            TeamId = new Guid("d75db702-3633-4429-b34e-37562ec568cb")
                        },
                        new
                        {
                            Id = new Guid("25a4831c-57fe-4ffe-b2c1-e8665790e4f8"),
                            Name = "Team_Overflow_Junior_2",
                            SeniorityId = new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"),
                            TeamId = new Guid("d75db702-3633-4429-b34e-37562ec568cb")
                        },
                        new
                        {
                            Id = new Guid("2ef99b7d-2381-4ff0-98a7-5fee8b1bb8c6"),
                            Name = "Team_Overflow_Junior_3",
                            SeniorityId = new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"),
                            TeamId = new Guid("d75db702-3633-4429-b34e-37562ec568cb")
                        },
                        new
                        {
                            Id = new Guid("677bfb2e-1115-4e9d-ad0e-1933aa4cf772"),
                            Name = "Team_Overflow_Junior_4",
                            SeniorityId = new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"),
                            TeamId = new Guid("d75db702-3633-4429-b34e-37562ec568cb")
                        },
                        new
                        {
                            Id = new Guid("d51a1572-87e6-452e-8ea7-2bc6951c6ab6"),
                            Name = "Team_Overflow_Junior_5",
                            SeniorityId = new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"),
                            TeamId = new Guid("d75db702-3633-4429-b34e-37562ec568cb")
                        },
                        new
                        {
                            Id = new Guid("9d1c5486-c3bd-4474-8e14-aa88f3bfb035"),
                            Name = "Team_Overflow_Junior_6",
                            SeniorityId = new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"),
                            TeamId = new Guid("d75db702-3633-4429-b34e-37562ec568cb")
                        });
                });

            modelBuilder.Entity("Shared.Library.Entities.AgentSeniority", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("SeniorityMultiplier")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Seniority");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"),
                            Name = "Junior",
                            Priority = 1,
                            SeniorityMultiplier = 4
                        },
                        new
                        {
                            Id = new Guid("6d4d0945-4b98-40b3-a24e-daad2096b837"),
                            Name = "Mid-Level",
                            Priority = 2,
                            SeniorityMultiplier = 6
                        },
                        new
                        {
                            Id = new Guid("705e8762-21c4-445c-b400-8197b864c10b"),
                            Name = "Senior",
                            Priority = 3,
                            SeniorityMultiplier = 8
                        },
                        new
                        {
                            Id = new Guid("8a23ef84-55e1-4c52-9fa2-20479c9bec0e"),
                            Name = "Team Lead",
                            Priority = 4,
                            SeniorityMultiplier = 5
                        });
                });

            modelBuilder.Entity("Shared.Library.Entities.SessionMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MessageBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("SentBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.ToTable("SessionChats");
                });

            modelBuilder.Entity("Shared.Library.Entities.SessionQueueItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SessionQueue");
                });

            modelBuilder.Entity("Shared.Library.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("WorkFinishHourAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("WorkStartHourAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d3287426-98f0-4d8a-9588-0f44c19f0b2c"),
                            Active = true,
                            Name = "A",
                            WorkFinishHourAt = new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified),
                            WorkStartHourAt = new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("53dbdf96-52fc-4ead-86d5-8216705572ba"),
                            Active = true,
                            Name = "B",
                            WorkFinishHourAt = new DateTime(1, 1, 2, 2, 1, 1, 0, DateTimeKind.Unspecified),
                            WorkStartHourAt = new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("da3659ba-a6ff-471a-8ec1-f7b819e22447"),
                            Active = true,
                            Name = "C",
                            WorkFinishHourAt = new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified),
                            WorkStartHourAt = new DateTime(1, 1, 1, 2, 1, 1, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("d75db702-3633-4429-b34e-37562ec568cb"),
                            Active = false,
                            Name = "Overflow",
                            WorkFinishHourAt = new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified),
                            WorkStartHourAt = new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Shared.Library.Entities.ActiveAgentSession", b =>
                {
                    b.HasOne("Shared.Library.Entities.Agent", "Agent")
                        .WithMany("ActiveAgentSessions")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("Shared.Library.Entities.Agent", b =>
                {
                    b.HasOne("Shared.Library.Entities.AgentSeniority", "Seniority")
                        .WithMany("Agents")
                        .HasForeignKey("SeniorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Library.Entities.Team", "Team")
                        .WithMany("Agents")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seniority");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Shared.Library.Entities.SessionMessage", b =>
                {
                    b.HasOne("Shared.Library.Entities.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("Shared.Library.Entities.Agent", b =>
                {
                    b.Navigation("ActiveAgentSessions");
                });

            modelBuilder.Entity("Shared.Library.Entities.AgentSeniority", b =>
                {
                    b.Navigation("Agents");
                });

            modelBuilder.Entity("Shared.Library.Entities.Team", b =>
                {
                    b.Navigation("Agents");
                });
#pragma warning restore 612, 618
        }
    }
}