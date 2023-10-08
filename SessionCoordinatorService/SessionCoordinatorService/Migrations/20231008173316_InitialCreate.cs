using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SessionCoordinatorService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    SeniorityMultiplier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seniority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkStartHourAt = table.Column<int>(type: "int", nullable: false),
                    WorkFinishHourAt = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "Id", "Name", "SeniorityMultiplier" },
                values: new object[,]
                {
                    { new Guid("4b2b355f-c2f6-487e-b2af-58a37243218b"), "Senior", 8 },
                    { new Guid("693322d7-1989-4e35-8449-50d7262be52c"), "Junior", 4 },
                    { new Guid("70e14af8-2b36-491a-9fe7-f041e6f8548d"), "Team Lead", 5 },
                    { new Guid("95d957dc-7184-4506-b4f8-f0eca3d4d9f5"), "Mid-Level", 6 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name", "WorkFinishHourAt", "WorkStartHourAt" },
                values: new object[,]
                {
                    { new Guid("28fbf6fe-1a4a-4304-b88d-acd03e273014"), "A", 18, 10 },
                    { new Guid("3a5aab28-b35d-40fe-bca1-e9ec849b6459"), "B", 2, 18 },
                    { new Guid("6e9be61e-0bb7-42b7-8462-bb45f8fab017"), "Overflow", 18, 10 },
                    { new Guid("e8120c31-461b-4a93-8f61-9e37dbf5a8cb"), "C", 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Name", "SeniorityId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("011120b1-deb1-4a25-a722-07b0c3cc619f"), "Team_A_Team_Lead", new Guid("70e14af8-2b36-491a-9fe7-f041e6f8548d"), new Guid("28fbf6fe-1a4a-4304-b88d-acd03e273014") },
                    { new Guid("10fbdf23-ddb3-4547-b015-54c5e19fa0b6"), "Team_A_Mid_1", new Guid("95d957dc-7184-4506-b4f8-f0eca3d4d9f5"), new Guid("28fbf6fe-1a4a-4304-b88d-acd03e273014") },
                    { new Guid("27356d94-050d-449d-81ef-2bf501abc3e3"), "Team_Overflow_Junior_5", new Guid("693322d7-1989-4e35-8449-50d7262be52c"), new Guid("6e9be61e-0bb7-42b7-8462-bb45f8fab017") },
                    { new Guid("3b5fdebe-e447-4bca-8e40-bf95b176a8f5"), "Team_B_Mid", new Guid("95d957dc-7184-4506-b4f8-f0eca3d4d9f5"), new Guid("3a5aab28-b35d-40fe-bca1-e9ec849b6459") },
                    { new Guid("42fad6d9-49a6-4d74-a1f1-6741de0273ed"), "Team_Overflow_Junior_1", new Guid("693322d7-1989-4e35-8449-50d7262be52c"), new Guid("6e9be61e-0bb7-42b7-8462-bb45f8fab017") },
                    { new Guid("4392a336-2598-4ee2-a14c-19e0486d3fdd"), "Team_Overflow_Junior_4", new Guid("693322d7-1989-4e35-8449-50d7262be52c"), new Guid("6e9be61e-0bb7-42b7-8462-bb45f8fab017") },
                    { new Guid("68c30ca4-2d2e-4e08-a576-b2c0ba1bd599"), "Team_Overflow_Junior_3", new Guid("693322d7-1989-4e35-8449-50d7262be52c"), new Guid("6e9be61e-0bb7-42b7-8462-bb45f8fab017") },
                    { new Guid("69cd109c-ac88-4c30-984a-10c8530c4be7"), "Team_B_Junior_1", new Guid("693322d7-1989-4e35-8449-50d7262be52c"), new Guid("3a5aab28-b35d-40fe-bca1-e9ec849b6459") },
                    { new Guid("6d16410a-19a9-4298-9f1c-f9455a214d0e"), "Team_C_Mid_1", new Guid("95d957dc-7184-4506-b4f8-f0eca3d4d9f5"), new Guid("e8120c31-461b-4a93-8f61-9e37dbf5a8cb") },
                    { new Guid("6ec60c06-c978-42a4-8c4f-3c10cd5d4f22"), "Team_Overflow_Junior_2", new Guid("693322d7-1989-4e35-8449-50d7262be52c"), new Guid("6e9be61e-0bb7-42b7-8462-bb45f8fab017") },
                    { new Guid("75eac2fa-b183-48f2-9a85-765b266c5540"), "Team_B_Senior", new Guid("4b2b355f-c2f6-487e-b2af-58a37243218b"), new Guid("3a5aab28-b35d-40fe-bca1-e9ec849b6459") },
                    { new Guid("8ae34fde-fab5-4e06-8483-48801321dc14"), "Team_A_Junior", new Guid("693322d7-1989-4e35-8449-50d7262be52c"), new Guid("28fbf6fe-1a4a-4304-b88d-acd03e273014") },
                    { new Guid("933a6450-49b8-47a7-83ee-2a66cd175335"), "Team_C_Mid_2", new Guid("95d957dc-7184-4506-b4f8-f0eca3d4d9f5"), new Guid("e8120c31-461b-4a93-8f61-9e37dbf5a8cb") },
                    { new Guid("9ce592e4-7de9-4121-9164-78a068659a76"), "Team_A_Mid_2", new Guid("95d957dc-7184-4506-b4f8-f0eca3d4d9f5"), new Guid("28fbf6fe-1a4a-4304-b88d-acd03e273014") },
                    { new Guid("c0acd479-7239-45f6-ae01-5d8a467499f0"), "Team_Overflow_Junior_6", new Guid("693322d7-1989-4e35-8449-50d7262be52c"), new Guid("6e9be61e-0bb7-42b7-8462-bb45f8fab017") },
                    { new Guid("edf5938d-8397-404f-abf4-377e51607707"), "Team_B_Junior_2", new Guid("693322d7-1989-4e35-8449-50d7262be52c"), new Guid("3a5aab28-b35d-40fe-bca1-e9ec849b6459") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveAgentSessions_AgentId",
                table: "ActiveAgentSessions",
                column: "AgentId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveAgentSessions");

            migrationBuilder.DropTable(
                name: "SessionChats");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Seniority");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
