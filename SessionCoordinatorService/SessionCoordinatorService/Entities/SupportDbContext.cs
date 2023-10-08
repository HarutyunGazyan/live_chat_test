using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Pipelines.Sockets.Unofficial.Arenas;

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


            modelBuilder.Entity<AgentSeniority>().HasData(_agentSeniorities);
            modelBuilder.Entity<Team>().HasData(_teams);


        }

        static Guid juniorSeniorityId = Guid.NewGuid();
        static Guid midSeniorityId = Guid.NewGuid();
        static Guid seniorSeniorityId = Guid.NewGuid();
        static Guid leadSeniorityId = Guid.NewGuid();

        private List<AgentSeniority> _agentSeniorities = new List<AgentSeniority>
        {
            new AgentSeniority
            {
                Id = juniorSeniorityId,
                Name = "Junior",
                SeniorityMultiplier = 4
            },
            new AgentSeniority
            {
                Id = midSeniorityId,
                Name = "Mid-Level",
                SeniorityMultiplier = 6
            },
            new AgentSeniority
            {
                Id = seniorSeniorityId,
                Name = "Senior",
                SeniorityMultiplier = 8
            },
            new AgentSeniority
            {
                Id =leadSeniorityId,
                Name = "Team Lead",
                SeniorityMultiplier = 5
            }
        };
        private List<Team> _teams = new List<Team>
        {
            new Team
            {
                Id = Guid.NewGuid(),
                Name = "A",
                WorkStartAt = new TimeOnly(10,0,0),
                WorkFinishAt = new TimeOnly(18,0,0),
                Agents = new List<Agent>
                {
                    new Agent
                    {
                        Name = "Team_A_Team_Lead",
                        SeniorityId = leadSeniorityId,
                    },
                    new Agent
                    {
                        Name = "Team_A_Mid_1",
                        SeniorityId = midSeniorityId,
                    },
                    new Agent
                    {
                        Name = "Team_A_Mid_2",
                        SeniorityId = midSeniorityId,
                    },
                    new Agent
                    {
                        Name = "Team_A_Junior",
                        SeniorityId = juniorSeniorityId,
                    }
                }
            },
            new Team
            {
                Id = Guid.NewGuid(),
                Name = "B",
                WorkStartAt = new TimeOnly(18,0,0),
                WorkFinishAt = new TimeOnly(2,0,0),
                Agents = new List<Agent>
                {
                    new Agent
                    {
                        Name = "Team_B_Senior",
                        SeniorityId = seniorSeniorityId,
                    },
                    new Agent
                    {
                        Name = "Team_B_Mid",
                        SeniorityId = midSeniorityId,
                    },
                    new Agent
                    {
                        Name = "Team_B_Junior_1",
                        SeniorityId = juniorSeniorityId,
                    },
                    new Agent
                    {
                        Name = "Team_B_Junior_2",
                        SeniorityId = juniorSeniorityId,
                    }
                }
            },
            new Team
            {
                Id = Guid.NewGuid(),
                Name = "C",
                WorkStartAt = new TimeOnly(2,0,0),
                WorkFinishAt = new TimeOnly(10,0,0),
                Agents = new List<Agent>
                {
                    new Agent
                    {
                        Name = "Team_C_Mid_1",
                        SeniorityId = midSeniorityId,
                    },
                    new Agent
                    {
                        Name = "Team_C_Mid_2",
                        SeniorityId = midSeniorityId,
                    }
                }
            },
            new Team
            {
                Id = Guid.NewGuid(),
                Name = "Overflow",
                WorkStartAt = new TimeOnly(10,0,0),
                WorkFinishAt = new TimeOnly(18,0,0),
                Agents = new List<Agent>
                {
                    new Agent
                    {
                        Name = "Team_Overflow_Junior_1",
                        SeniorityId = juniorSeniorityId,
                    },
                    new Agent
                    {
                        Name = "Team_Overflow_Junior_2",
                        SeniorityId = juniorSeniorityId,
                    },
                    new Agent
                    {
                        Name = "Team_Overflow_Junior_3",
                        SeniorityId = juniorSeniorityId,
                    },
                    new Agent
                    {
                        Name = "Team_Overflow_Junior_4",
                        SeniorityId = juniorSeniorityId,
                    },
                    new Agent
                    {
                        Name = "Team_Overflow_Junior_5",
                        SeniorityId = juniorSeniorityId,
                    },
                    new Agent
                    {
                        Name = "Team_Overflow_Junior_6",
                        SeniorityId = juniorSeniorityId,
                    }
                }
            },
        };
    }
}
