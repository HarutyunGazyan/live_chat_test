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
                    { new Guid("6e1865e1-3524-4b08-a0ce-f2851427e547"), "Senior", 3, 8 },
                    { new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"), "Junior", 1, 4 },
                    { new Guid("de62c6ac-1d06-4643-8377-4303f5a7ce7d"), "Mid-Level", 2, 6 },
                    { new Guid("eb0c6f3a-5b34-44ce-b12a-595db4139bef"), "Team Lead", 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Active", "Name", "WorkFinishHourAt", "WorkStartHourAt" },
                values: new object[,]
                {
                    { new Guid("487de4b0-bef5-40b6-97bd-4d95d9848acb"), true, "A", new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified) },
                    { new Guid("4fea00c1-d25f-47a6-8fa0-bca34d15e90d"), true, "B", new DateTime(1, 1, 2, 2, 1, 1, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified) },
                    { new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be"), false, "Overflow", new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified) },
                    { new Guid("b932985c-df11-4658-b4cf-71778aad5282"), true, "C", new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 2, 2, 1, 1, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Name", "SeniorityId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("0d65da4c-b328-40c3-b71c-d4b627503fe3"), "Team_Overflow_Junior_5", new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"), new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be") },
                    { new Guid("2d732fcc-6dc0-40ea-a6cb-4b06af5279d5"), "Team_A_Team_Lead", new Guid("eb0c6f3a-5b34-44ce-b12a-595db4139bef"), new Guid("487de4b0-bef5-40b6-97bd-4d95d9848acb") },
                    { new Guid("3ca51880-68d4-4942-9ef8-4896ebba8d7c"), "Team_B_Mid", new Guid("de62c6ac-1d06-4643-8377-4303f5a7ce7d"), new Guid("4fea00c1-d25f-47a6-8fa0-bca34d15e90d") },
                    { new Guid("55850d77-f5b4-4338-9136-b6f7def8346e"), "Team_B_Junior_2", new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"), new Guid("4fea00c1-d25f-47a6-8fa0-bca34d15e90d") },
                    { new Guid("59398f8e-b752-426b-bacc-6d35cbccfcbd"), "Team_Overflow_Junior_4", new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"), new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be") },
                    { new Guid("5defb01e-36de-4ff0-94b4-5a38f0b12e2c"), "Team_C_Mid_1", new Guid("de62c6ac-1d06-4643-8377-4303f5a7ce7d"), new Guid("b932985c-df11-4658-b4cf-71778aad5282") },
                    { new Guid("624789b6-b5f3-440c-be6c-d5e4f6fe276e"), "Team_A_Junior", new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"), new Guid("487de4b0-bef5-40b6-97bd-4d95d9848acb") },
                    { new Guid("6c07866e-3044-41d0-a493-d39cebabd874"), "Team_B_Junior_1", new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"), new Guid("4fea00c1-d25f-47a6-8fa0-bca34d15e90d") },
                    { new Guid("797d6a9d-dba8-46e9-bd72-729fa24ecb2a"), "Team_Overflow_Junior_6", new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"), new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be") },
                    { new Guid("8e587fa2-e482-4227-b2e1-ac54ec6cc17c"), "Team_A_Mid_1", new Guid("de62c6ac-1d06-4643-8377-4303f5a7ce7d"), new Guid("487de4b0-bef5-40b6-97bd-4d95d9848acb") },
                    { new Guid("a67b0b95-8d84-4222-a7aa-9d22b5e2764c"), "Team_Overflow_Junior_3", new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"), new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be") },
                    { new Guid("aa0ec6aa-a2a9-4960-b6be-95be0eadd5e8"), "Team_Overflow_Junior_1", new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"), new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be") },
                    { new Guid("b48e7123-a765-44d6-9d50-00c659d5bd2f"), "Team_C_Mid_2", new Guid("de62c6ac-1d06-4643-8377-4303f5a7ce7d"), new Guid("b932985c-df11-4658-b4cf-71778aad5282") },
                    { new Guid("d0eadccd-ea31-4b74-b582-b6844539e1c3"), "Team_Overflow_Junior_2", new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"), new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be") },
                    { new Guid("d9f6e9a0-46a4-4c16-8a23-7c2e0184b485"), "Team_A_Mid_2", new Guid("de62c6ac-1d06-4643-8377-4303f5a7ce7d"), new Guid("487de4b0-bef5-40b6-97bd-4d95d9848acb") },
                    { new Guid("e84db322-ae6e-4b85-a36c-3720d68391c0"), "Team_B_Senior", new Guid("6e1865e1-3524-4b08-a0ce-f2851427e547"), new Guid("4fea00c1-d25f-47a6-8fa0-bca34d15e90d") }
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
