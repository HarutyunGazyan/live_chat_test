﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Shared.Library.Entities;

#nullable disable

namespace SessionCoordinatorService.Migrations
{
    [DbContext(typeof(SupportDbContext))]
    [Migration("20231009155537_Initial_Migration")]
    partial class Initial_Migration
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
                            Id = new Guid("2d732fcc-6dc0-40ea-a6cb-4b06af5279d5"),
                            Name = "Team_A_Team_Lead",
                            SeniorityId = new Guid("eb0c6f3a-5b34-44ce-b12a-595db4139bef"),
                            TeamId = new Guid("487de4b0-bef5-40b6-97bd-4d95d9848acb")
                        },
                        new
                        {
                            Id = new Guid("8e587fa2-e482-4227-b2e1-ac54ec6cc17c"),
                            Name = "Team_A_Mid_1",
                            SeniorityId = new Guid("de62c6ac-1d06-4643-8377-4303f5a7ce7d"),
                            TeamId = new Guid("487de4b0-bef5-40b6-97bd-4d95d9848acb")
                        },
                        new
                        {
                            Id = new Guid("d9f6e9a0-46a4-4c16-8a23-7c2e0184b485"),
                            Name = "Team_A_Mid_2",
                            SeniorityId = new Guid("de62c6ac-1d06-4643-8377-4303f5a7ce7d"),
                            TeamId = new Guid("487de4b0-bef5-40b6-97bd-4d95d9848acb")
                        },
                        new
                        {
                            Id = new Guid("624789b6-b5f3-440c-be6c-d5e4f6fe276e"),
                            Name = "Team_A_Junior",
                            SeniorityId = new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"),
                            TeamId = new Guid("487de4b0-bef5-40b6-97bd-4d95d9848acb")
                        },
                        new
                        {
                            Id = new Guid("e84db322-ae6e-4b85-a36c-3720d68391c0"),
                            Name = "Team_B_Senior",
                            SeniorityId = new Guid("6e1865e1-3524-4b08-a0ce-f2851427e547"),
                            TeamId = new Guid("4fea00c1-d25f-47a6-8fa0-bca34d15e90d")
                        },
                        new
                        {
                            Id = new Guid("3ca51880-68d4-4942-9ef8-4896ebba8d7c"),
                            Name = "Team_B_Mid",
                            SeniorityId = new Guid("de62c6ac-1d06-4643-8377-4303f5a7ce7d"),
                            TeamId = new Guid("4fea00c1-d25f-47a6-8fa0-bca34d15e90d")
                        },
                        new
                        {
                            Id = new Guid("6c07866e-3044-41d0-a493-d39cebabd874"),
                            Name = "Team_B_Junior_1",
                            SeniorityId = new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"),
                            TeamId = new Guid("4fea00c1-d25f-47a6-8fa0-bca34d15e90d")
                        },
                        new
                        {
                            Id = new Guid("55850d77-f5b4-4338-9136-b6f7def8346e"),
                            Name = "Team_B_Junior_2",
                            SeniorityId = new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"),
                            TeamId = new Guid("4fea00c1-d25f-47a6-8fa0-bca34d15e90d")
                        },
                        new
                        {
                            Id = new Guid("5defb01e-36de-4ff0-94b4-5a38f0b12e2c"),
                            Name = "Team_C_Mid_1",
                            SeniorityId = new Guid("de62c6ac-1d06-4643-8377-4303f5a7ce7d"),
                            TeamId = new Guid("b932985c-df11-4658-b4cf-71778aad5282")
                        },
                        new
                        {
                            Id = new Guid("b48e7123-a765-44d6-9d50-00c659d5bd2f"),
                            Name = "Team_C_Mid_2",
                            SeniorityId = new Guid("de62c6ac-1d06-4643-8377-4303f5a7ce7d"),
                            TeamId = new Guid("b932985c-df11-4658-b4cf-71778aad5282")
                        },
                        new
                        {
                            Id = new Guid("aa0ec6aa-a2a9-4960-b6be-95be0eadd5e8"),
                            Name = "Team_Overflow_Junior_1",
                            SeniorityId = new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"),
                            TeamId = new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be")
                        },
                        new
                        {
                            Id = new Guid("d0eadccd-ea31-4b74-b582-b6844539e1c3"),
                            Name = "Team_Overflow_Junior_2",
                            SeniorityId = new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"),
                            TeamId = new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be")
                        },
                        new
                        {
                            Id = new Guid("a67b0b95-8d84-4222-a7aa-9d22b5e2764c"),
                            Name = "Team_Overflow_Junior_3",
                            SeniorityId = new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"),
                            TeamId = new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be")
                        },
                        new
                        {
                            Id = new Guid("59398f8e-b752-426b-bacc-6d35cbccfcbd"),
                            Name = "Team_Overflow_Junior_4",
                            SeniorityId = new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"),
                            TeamId = new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be")
                        },
                        new
                        {
                            Id = new Guid("0d65da4c-b328-40c3-b71c-d4b627503fe3"),
                            Name = "Team_Overflow_Junior_5",
                            SeniorityId = new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"),
                            TeamId = new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be")
                        },
                        new
                        {
                            Id = new Guid("797d6a9d-dba8-46e9-bd72-729fa24ecb2a"),
                            Name = "Team_Overflow_Junior_6",
                            SeniorityId = new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"),
                            TeamId = new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be")
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
                            Id = new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"),
                            Name = "Junior",
                            Priority = 1,
                            SeniorityMultiplier = 4
                        },
                        new
                        {
                            Id = new Guid("de62c6ac-1d06-4643-8377-4303f5a7ce7d"),
                            Name = "Mid-Level",
                            Priority = 2,
                            SeniorityMultiplier = 6
                        },
                        new
                        {
                            Id = new Guid("6e1865e1-3524-4b08-a0ce-f2851427e547"),
                            Name = "Senior",
                            Priority = 3,
                            SeniorityMultiplier = 8
                        },
                        new
                        {
                            Id = new Guid("eb0c6f3a-5b34-44ce-b12a-595db4139bef"),
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
                            Id = new Guid("487de4b0-bef5-40b6-97bd-4d95d9848acb"),
                            Active = true,
                            Name = "A",
                            WorkFinishHourAt = new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified),
                            WorkStartHourAt = new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("4fea00c1-d25f-47a6-8fa0-bca34d15e90d"),
                            Active = true,
                            Name = "B",
                            WorkFinishHourAt = new DateTime(1, 1, 2, 2, 1, 1, 0, DateTimeKind.Unspecified),
                            WorkStartHourAt = new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("b932985c-df11-4658-b4cf-71778aad5282"),
                            Active = true,
                            Name = "C",
                            WorkFinishHourAt = new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified),
                            WorkStartHourAt = new DateTime(1, 1, 2, 2, 1, 1, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be"),
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