﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SessionCoordinatorService.Entities;

#nullable disable

namespace SessionCoordinatorService.Migrations
{
    [DbContext(typeof(SupportDbContext))]
    [Migration("20231008200129_AgentSeniority_Priority")]
    partial class AgentSeniority_Priority
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SessionCoordinatorService.Entities.ActiveAgentSession", b =>
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

                    b.ToTable("ActiveAgentSessions");
                });

            modelBuilder.Entity("SessionCoordinatorService.Entities.Agent", b =>
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
                            Id = new Guid("08b15074-de2d-49e7-82f4-9878d8719b2e"),
                            Name = "Team_A_Team_Lead",
                            SeniorityId = new Guid("a0379406-bdc9-42ed-bd66-828c568ff1c7"),
                            TeamId = new Guid("5c39b2dc-c64b-4d5e-8ede-95ba12c5a01b")
                        },
                        new
                        {
                            Id = new Guid("eb0de4e4-19b8-42b5-8c32-3b4f60ef4d62"),
                            Name = "Team_A_Mid_1",
                            SeniorityId = new Guid("f08d3880-d4ad-42bd-abf6-fb89a7306851"),
                            TeamId = new Guid("5c39b2dc-c64b-4d5e-8ede-95ba12c5a01b")
                        },
                        new
                        {
                            Id = new Guid("e44e0dc2-94f0-4da5-b3ac-7b976a27f431"),
                            Name = "Team_A_Mid_2",
                            SeniorityId = new Guid("f08d3880-d4ad-42bd-abf6-fb89a7306851"),
                            TeamId = new Guid("5c39b2dc-c64b-4d5e-8ede-95ba12c5a01b")
                        },
                        new
                        {
                            Id = new Guid("c116f8b7-3e16-44ce-8e4f-990a58a98572"),
                            Name = "Team_A_Junior",
                            SeniorityId = new Guid("a9781f00-9624-46f6-860a-b7be49528419"),
                            TeamId = new Guid("5c39b2dc-c64b-4d5e-8ede-95ba12c5a01b")
                        },
                        new
                        {
                            Id = new Guid("393cb5d4-af46-418c-919c-2feb9baf1e16"),
                            Name = "Team_B_Senior",
                            SeniorityId = new Guid("4ec4ade9-7f8f-4f36-9ae6-0d908f4f080a"),
                            TeamId = new Guid("5af1b482-14b2-465b-8606-10c40142194b")
                        },
                        new
                        {
                            Id = new Guid("64dbb614-a7ec-4341-9fec-235d63dc7a12"),
                            Name = "Team_B_Mid",
                            SeniorityId = new Guid("f08d3880-d4ad-42bd-abf6-fb89a7306851"),
                            TeamId = new Guid("5af1b482-14b2-465b-8606-10c40142194b")
                        },
                        new
                        {
                            Id = new Guid("6789e80f-7d3c-481e-b508-403610a45fbe"),
                            Name = "Team_B_Junior_1",
                            SeniorityId = new Guid("a9781f00-9624-46f6-860a-b7be49528419"),
                            TeamId = new Guid("5af1b482-14b2-465b-8606-10c40142194b")
                        },
                        new
                        {
                            Id = new Guid("620a0583-49e6-4f18-9c0f-c18278d84720"),
                            Name = "Team_B_Junior_2",
                            SeniorityId = new Guid("a9781f00-9624-46f6-860a-b7be49528419"),
                            TeamId = new Guid("5af1b482-14b2-465b-8606-10c40142194b")
                        },
                        new
                        {
                            Id = new Guid("72d1ce82-5251-4947-bfa9-87997fd23493"),
                            Name = "Team_C_Mid_1",
                            SeniorityId = new Guid("f08d3880-d4ad-42bd-abf6-fb89a7306851"),
                            TeamId = new Guid("735a7af3-54b4-4d76-b13d-da90271c687a")
                        },
                        new
                        {
                            Id = new Guid("d6a59728-55b3-47cc-8533-bc4d9984c133"),
                            Name = "Team_C_Mid_2",
                            SeniorityId = new Guid("f08d3880-d4ad-42bd-abf6-fb89a7306851"),
                            TeamId = new Guid("735a7af3-54b4-4d76-b13d-da90271c687a")
                        },
                        new
                        {
                            Id = new Guid("552a02e6-67ab-4f17-90ed-8d74d9ba4701"),
                            Name = "Team_Overflow_Junior_1",
                            SeniorityId = new Guid("a9781f00-9624-46f6-860a-b7be49528419"),
                            TeamId = new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b")
                        },
                        new
                        {
                            Id = new Guid("d6f2d80a-2772-4c02-9fda-11466565415e"),
                            Name = "Team_Overflow_Junior_2",
                            SeniorityId = new Guid("a9781f00-9624-46f6-860a-b7be49528419"),
                            TeamId = new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b")
                        },
                        new
                        {
                            Id = new Guid("17d74fb9-074e-4a41-ba6c-6fe93ff78fcf"),
                            Name = "Team_Overflow_Junior_3",
                            SeniorityId = new Guid("a9781f00-9624-46f6-860a-b7be49528419"),
                            TeamId = new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b")
                        },
                        new
                        {
                            Id = new Guid("b4c8fa7d-b5c2-4e9d-84e2-b0cb80e41df1"),
                            Name = "Team_Overflow_Junior_4",
                            SeniorityId = new Guid("a9781f00-9624-46f6-860a-b7be49528419"),
                            TeamId = new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b")
                        },
                        new
                        {
                            Id = new Guid("388eb163-50d0-4846-bb86-fc927f337139"),
                            Name = "Team_Overflow_Junior_5",
                            SeniorityId = new Guid("a9781f00-9624-46f6-860a-b7be49528419"),
                            TeamId = new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b")
                        },
                        new
                        {
                            Id = new Guid("36458934-96ae-4bb0-a414-f97f67690c2c"),
                            Name = "Team_Overflow_Junior_6",
                            SeniorityId = new Guid("a9781f00-9624-46f6-860a-b7be49528419"),
                            TeamId = new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b")
                        });
                });

            modelBuilder.Entity("SessionCoordinatorService.Entities.AgentSeniority", b =>
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
                            Id = new Guid("a9781f00-9624-46f6-860a-b7be49528419"),
                            Name = "Junior",
                            Priority = 1,
                            SeniorityMultiplier = 4
                        },
                        new
                        {
                            Id = new Guid("f08d3880-d4ad-42bd-abf6-fb89a7306851"),
                            Name = "Mid-Level",
                            Priority = 2,
                            SeniorityMultiplier = 6
                        },
                        new
                        {
                            Id = new Guid("4ec4ade9-7f8f-4f36-9ae6-0d908f4f080a"),
                            Name = "Senior",
                            Priority = 3,
                            SeniorityMultiplier = 8
                        },
                        new
                        {
                            Id = new Guid("a0379406-bdc9-42ed-bd66-828c568ff1c7"),
                            Name = "Team Lead",
                            Priority = 4,
                            SeniorityMultiplier = 5
                        });
                });

            modelBuilder.Entity("SessionCoordinatorService.Entities.SessionMessage", b =>
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

            modelBuilder.Entity("SessionCoordinatorService.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkFinishHourAt")
                        .HasColumnType("int");

                    b.Property<int>("WorkStartHourAt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5c39b2dc-c64b-4d5e-8ede-95ba12c5a01b"),
                            Name = "A",
                            WorkFinishHourAt = 18,
                            WorkStartHourAt = 10
                        },
                        new
                        {
                            Id = new Guid("5af1b482-14b2-465b-8606-10c40142194b"),
                            Name = "B",
                            WorkFinishHourAt = 2,
                            WorkStartHourAt = 18
                        },
                        new
                        {
                            Id = new Guid("735a7af3-54b4-4d76-b13d-da90271c687a"),
                            Name = "C",
                            WorkFinishHourAt = 10,
                            WorkStartHourAt = 2
                        },
                        new
                        {
                            Id = new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b"),
                            Name = "Overflow",
                            WorkFinishHourAt = 18,
                            WorkStartHourAt = 10
                        });
                });

            modelBuilder.Entity("SessionCoordinatorService.Entities.ActiveAgentSession", b =>
                {
                    b.HasOne("SessionCoordinatorService.Entities.Agent", "Agent")
                        .WithMany("ActiveAgentSessions")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("SessionCoordinatorService.Entities.Agent", b =>
                {
                    b.HasOne("SessionCoordinatorService.Entities.AgentSeniority", "Seniority")
                        .WithMany("Agents")
                        .HasForeignKey("SeniorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SessionCoordinatorService.Entities.Team", "Team")
                        .WithMany("Agents")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seniority");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("SessionCoordinatorService.Entities.SessionMessage", b =>
                {
                    b.HasOne("SessionCoordinatorService.Entities.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("SessionCoordinatorService.Entities.Agent", b =>
                {
                    b.Navigation("ActiveAgentSessions");
                });

            modelBuilder.Entity("SessionCoordinatorService.Entities.AgentSeniority", b =>
                {
                    b.Navigation("Agents");
                });

            modelBuilder.Entity("SessionCoordinatorService.Entities.Team", b =>
                {
                    b.Navigation("Agents");
                });
#pragma warning restore 612, 618
        }
    }
}
