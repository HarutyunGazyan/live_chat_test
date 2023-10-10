using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SessionCoordinatorService.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seniority",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeniorityMultiplier = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seniority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionQueue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionQueue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkStartHourAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkFinishHourAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeniorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_Seniority_SeniorityId",
                        column: x => x.SeniorityId,
                        principalTable: "Seniority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agents_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActiveAgentSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveAgentSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveAgentSessions_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionChats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SentBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionChats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionChats_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Seniority",
                columns: new[] { "Id", "Name", "Priority", "SeniorityMultiplier" },
                values: new object[,]
                {
                    { new Guid("442a62f5-531a-474e-8ab1-fd2bf4c132a5"), "Mid-Level", 2, 6 },
                    { new Guid("53fcd7af-389e-4834-8de6-1bdffa1b551b"), "Senior", 3, 8 },
                    { new Guid("96db8f03-b7cf-4af9-b6e0-0202333780cb"), "Team Lead", 4, 5 },
                    { new Guid("ec61b203-e958-42fd-97de-8f1e06b12cf5"), "Junior", 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Active", "Name", "WorkFinishHourAt", "WorkStartHourAt" },
                values: new object[,]
                {
                    { new Guid("17d9f599-7138-4ad2-b457-ad68906f906b"), true, "A", new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified) },
                    { new Guid("6c720849-0b8d-41c5-b052-9f032a06b31f"), true, "B", new DateTime(1, 1, 2, 2, 1, 1, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified) },
                    { new Guid("a73c6968-5ae6-452b-8ab6-540e3b60bfae"), false, "Overflow", new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified) },
                    { new Guid("a9f24a6a-1ed6-47a0-9dd8-2466bb9615c4"), true, "C", new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 2, 1, 1, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Name", "SeniorityId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("0fe17fb6-7399-4298-a104-d33e340f1a48"), "Team_A_Team_Lead", new Guid("96db8f03-b7cf-4af9-b6e0-0202333780cb"), new Guid("17d9f599-7138-4ad2-b457-ad68906f906b") },
                    { new Guid("2bb1219b-50eb-4eef-a2e1-8b1e093e12f8"), "Team_B_Mid", new Guid("442a62f5-531a-474e-8ab1-fd2bf4c132a5"), new Guid("6c720849-0b8d-41c5-b052-9f032a06b31f") },
                    { new Guid("4348f952-0699-452b-9df2-83e535df4e35"), "Team_Overflow_Junior_5", new Guid("ec61b203-e958-42fd-97de-8f1e06b12cf5"), new Guid("a73c6968-5ae6-452b-8ab6-540e3b60bfae") },
                    { new Guid("5478f83f-fc48-42f4-b926-cbcbd396aa53"), "Team_A_Mid_2", new Guid("442a62f5-531a-474e-8ab1-fd2bf4c132a5"), new Guid("17d9f599-7138-4ad2-b457-ad68906f906b") },
                    { new Guid("65f76ec6-760f-4900-bd2c-6f0a3c33212e"), "Team_Overflow_Junior_2", new Guid("ec61b203-e958-42fd-97de-8f1e06b12cf5"), new Guid("a73c6968-5ae6-452b-8ab6-540e3b60bfae") },
                    { new Guid("69685bc5-5023-4cea-bf0f-d577f761a73e"), "Team_C_Mid_1", new Guid("442a62f5-531a-474e-8ab1-fd2bf4c132a5"), new Guid("a9f24a6a-1ed6-47a0-9dd8-2466bb9615c4") },
                    { new Guid("7009e30a-4e33-40e7-89f7-9593ecae5039"), "Team_Overflow_Junior_3", new Guid("ec61b203-e958-42fd-97de-8f1e06b12cf5"), new Guid("a73c6968-5ae6-452b-8ab6-540e3b60bfae") },
                    { new Guid("7ca4bf18-d580-4e54-bf90-1bbb16c2adf2"), "Team_A_Mid_1", new Guid("442a62f5-531a-474e-8ab1-fd2bf4c132a5"), new Guid("17d9f599-7138-4ad2-b457-ad68906f906b") },
                    { new Guid("8377038d-dac7-4af3-aa7c-61d1e192e62f"), "Team_B_Senior", new Guid("53fcd7af-389e-4834-8de6-1bdffa1b551b"), new Guid("6c720849-0b8d-41c5-b052-9f032a06b31f") },
                    { new Guid("8b9a71ba-b471-488d-bda1-f2a1e4381ad5"), "Team_B_Junior_2", new Guid("ec61b203-e958-42fd-97de-8f1e06b12cf5"), new Guid("6c720849-0b8d-41c5-b052-9f032a06b31f") },
                    { new Guid("8e75fdea-afec-48a1-8dc4-b98c73a8b620"), "Team_Overflow_Junior_4", new Guid("ec61b203-e958-42fd-97de-8f1e06b12cf5"), new Guid("a73c6968-5ae6-452b-8ab6-540e3b60bfae") },
                    { new Guid("98bb9471-63cb-43c6-8020-cd76bd32a113"), "Team_Overflow_Junior_6", new Guid("ec61b203-e958-42fd-97de-8f1e06b12cf5"), new Guid("a73c6968-5ae6-452b-8ab6-540e3b60bfae") },
                    { new Guid("b2ce6332-bf5f-4438-9a82-6d579b18ee7f"), "Team_A_Junior", new Guid("ec61b203-e958-42fd-97de-8f1e06b12cf5"), new Guid("17d9f599-7138-4ad2-b457-ad68906f906b") },
                    { new Guid("bb558094-72ec-4baf-95ea-003044dbb918"), "Team_B_Junior_1", new Guid("ec61b203-e958-42fd-97de-8f1e06b12cf5"), new Guid("6c720849-0b8d-41c5-b052-9f032a06b31f") },
                    { new Guid("df88abf6-5f4c-4cd4-8231-3a3de13f8db0"), "Team_Overflow_Junior_1", new Guid("ec61b203-e958-42fd-97de-8f1e06b12cf5"), new Guid("a73c6968-5ae6-452b-8ab6-540e3b60bfae") },
                    { new Guid("fa7f8913-eea5-4771-8807-53040cbdba4a"), "Team_C_Mid_2", new Guid("442a62f5-531a-474e-8ab1-fd2bf4c132a5"), new Guid("a9f24a6a-1ed6-47a0-9dd8-2466bb9615c4") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveAgentSessions_AgentId",
                table: "ActiveAgentSessions",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveAgentSessions_SessionId",
                table: "ActiveAgentSessions",
                column: "SessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_SeniorityId",
                table: "Agents",
                column: "SeniorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_TeamId",
                table: "Agents",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionChats_AgentId",
                table: "SessionChats",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name",
                table: "Teams",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveAgentSessions");

            migrationBuilder.DropTable(
                name: "SessionChats");

            migrationBuilder.DropTable(
                name: "SessionQueue");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Seniority");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
