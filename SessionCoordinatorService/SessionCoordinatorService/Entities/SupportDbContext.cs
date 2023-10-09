﻿using Microsoft.EntityFrameworkCore;
using SessionCoordinatorService.Services;

namespace SessionCoordinatorService.Entities
{
    public class SupportDbContext : DbContext
    {
        public SupportDbContext(DbContextOptions<SupportDbContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentSeniority> Seniority { get; set; }
        public DbSet<ActiveAgentSession> ActiveAgentSessions { get; set; }
        public DbSet<SessionMessage> SessionChats { get; set; }
        public DbSet<SessionQueueItem> SessionQueue { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasMany(x => x.Agents)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId);

            modelBuilder.Entity<Agent>()
                .HasOne(x => x.Seniority)
                .WithMany(x => x.Agents)
                .HasForeignKey(x => x.SeniorityId);

            modelBuilder.Entity<Agent>()
                .HasMany(x => x.ActiveAgentSessions)
                .WithOne(x => x.Agent)
                .HasForeignKey(x => x.AgentId);

            modelBuilder.Entity<ActiveAgentSession>(x => x.HasIndex(y => y.SessionId).IsUnique());

            modelBuilder.Entity<AgentSeniority>().HasData(_agentSenioritiesSeed);
            modelBuilder.Entity<Team>().HasData(_teamsSeed);
            modelBuilder.Entity<Agent>().HasData(_agentsSeed);


        }

        static Guid juniorSeniorityId = Guid.NewGuid();
        static Guid midSeniorityId = Guid.NewGuid();
        static Guid seniorSeniorityId = Guid.NewGuid();
        static Guid leadSeniorityId = Guid.NewGuid();

        static Guid teamA = Guid.NewGuid();
        static Guid teamB = Guid.NewGuid();
        static Guid teamC = Guid.NewGuid();
        static Guid teamOverflow = Guid.NewGuid();

        private List<AgentSeniority> _agentSenioritiesSeed = new List<AgentSeniority>
        {
            new AgentSeniority
            {
                Id = juniorSeniorityId,
                Name = "Junior",
                SeniorityMultiplier = 4,
                Priority = 1
            },
            new AgentSeniority
            {
                Id = midSeniorityId,
                Name = "Mid-Level",
                SeniorityMultiplier = 6,
                Priority = 2
            },
            new AgentSeniority
            {
                Id = seniorSeniorityId,
                Name = "Senior",
                SeniorityMultiplier = 8,
                Priority = 3
            },
            new AgentSeniority
            {
                Id =leadSeniorityId,
                Name = "Team Lead",
                SeniorityMultiplier = 5,
                Priority = 4
            }
        };
        private List<Team> _teamsSeed = new List<Team>
        {
            new Team
            {
                Id = teamA,
                Name = "A",
                WorkStartHourAt = 10,
                WorkFinishHourAt = 18,
                Active = true
            },
            new Team
            {
                Id = teamB,
                Name = "B",
                WorkStartHourAt = 18,
                WorkFinishHourAt = 2,
                Active = true
            },
            new Team
            {
                Id = teamC,
                Name = "C",
                WorkStartHourAt = 2,
                WorkFinishHourAt = 10,
                Active = true
            },
            new Team
            {
                Id = teamOverflow,
                Name = Constants.OverflowTeamName,
                WorkStartHourAt = 10,
                WorkFinishHourAt = 18,
                Active = false
            },
        };
        public List<Agent> _agentsSeed = new List<Agent>
        {
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamA,
                Name = "Team_A_Team_Lead",
                SeniorityId = leadSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamA,
                Name = "Team_A_Mid_1",
                SeniorityId = midSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamA,
                Name = "Team_A_Mid_2",
                SeniorityId = midSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamA,
                Name = "Team_A_Junior",
                SeniorityId = juniorSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamB,
                Name = "Team_B_Senior",
                SeniorityId = seniorSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamB,
                Name = "Team_B_Mid",
                SeniorityId = midSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamB,
                Name = "Team_B_Junior_1",
                SeniorityId = juniorSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamB,
                Name = "Team_B_Junior_2",
                SeniorityId = juniorSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamC,
                Name = "Team_C_Mid_1",
                SeniorityId = midSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamC,
                Name = "Team_C_Mid_2",
                SeniorityId = midSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamOverflow,
                Name = "Team_Overflow_Junior_1",
                SeniorityId = juniorSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamOverflow,
                Name = "Team_Overflow_Junior_2",
                SeniorityId = juniorSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamOverflow,
                Name = "Team_Overflow_Junior_3",
                SeniorityId = juniorSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamOverflow,
                Name = "Team_Overflow_Junior_4",
                SeniorityId = juniorSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamOverflow,
                Name = "Team_Overflow_Junior_5",
                SeniorityId = juniorSeniorityId,
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                TeamId = teamOverflow,
                Name = "Team_Overflow_Junior_6",
                SeniorityId = juniorSeniorityId,
            }
        };
    }
}
