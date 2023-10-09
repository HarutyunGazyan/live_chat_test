using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SessionCoordinatorService.Migrations
{
    /// <inheritdoc />
    public partial class Add_SessionQueue_Table_Unique_SessionId_ActiveAgentSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("228210f2-c097-4f5e-bc9d-0396208153c9"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("511d122e-4ce2-463a-a58c-127e6d98838d"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("63c91c31-50ee-4c9c-8c2f-526889b49dff"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("6f8a832c-bb78-4493-8ea8-d5d5807e2b76"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("7680aeb8-1768-4abb-9bef-754f50f4f809"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("8b18c73a-eb9a-483b-bcf2-fc0ac6b93907"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("93b7c28d-4e86-43a0-9487-1bf57a1b2271"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("9524efba-f611-4382-9398-5708c7e71888"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("9e0174c2-bd45-4659-b56c-1841464ddb1e"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("b2d6976a-d502-4cf2-b31d-2bcc07341634"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("cbafae8d-2226-4151-b68b-045b1badd74d"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("d1f7fc52-f847-4ceb-b044-ae826f3a5cf9"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("e9c3e939-cff5-45e4-9e77-c68bd0dda4c0"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("ea122361-89b8-4d30-8bee-108539c2f5ff"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("fb178c45-cf2d-4d36-a938-417fc20d74b6"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("fd339b30-0a15-41d6-b9e7-b820eb410a9f"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("2e9ce439-53fc-49a0-a1b3-c815ad880da5"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("cf4bb79c-6573-4a7c-a7cd-e118ead8d1fb"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("ecfab3b2-9ccf-46c8-99bf-fde65ce11b3b"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("fba73d8b-2616-4936-82f6-d38d14a22704"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("4dadd8a1-6338-46ce-b12f-e351dc8797b6"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("5a2074de-281f-4baf-879d-e58ec75a6c42"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("9f6d40f5-7031-4c10-ab54-b940d217a99f"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("bdef6327-20f4-4a6e-942b-9ad20eab570c"));

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

            migrationBuilder.InsertData(
                table: "Seniority",
                columns: new[] { "Id", "Name", "Priority", "SeniorityMultiplier" },
                values: new object[,]
                {
                    { new Guid("50112afc-d878-444d-abaf-34632427debd"), "Junior", 1, 4 },
                    { new Guid("825c8c5e-c290-4603-b973-d2f8b2e6d533"), "Mid-Level", 2, 6 },
                    { new Guid("84392792-84f3-4cac-a551-85dbc7fde1bc"), "Team Lead", 4, 5 },
                    { new Guid("ffe91256-3a1a-4a1e-a5b2-cdbbf4848e14"), "Senior", 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Active", "Name", "WorkFinishHourAt", "WorkStartHourAt" },
                values: new object[,]
                {
                    { new Guid("13cbf644-e1ae-4106-b480-c5a9ac5c8320"), true, "C", 10, 2 },
                    { new Guid("28264979-69cc-4414-9d8f-cf1360ebe471"), true, "B", 2, 18 },
                    { new Guid("768e2812-8644-4be4-8ce6-8203d79231f4"), false, "Overflow", 18, 10 },
                    { new Guid("78caa9cf-8cee-483d-a5e1-870cf6d45769"), true, "A", 18, 10 }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Name", "SeniorityId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("02d30124-ede3-48f5-97cb-203c8a370ce8"), "Team_Overflow_Junior_1", new Guid("50112afc-d878-444d-abaf-34632427debd"), new Guid("768e2812-8644-4be4-8ce6-8203d79231f4") },
                    { new Guid("0379fba9-efc3-4035-a1d1-5619a3fe0ac7"), "Team_A_Mid_1", new Guid("825c8c5e-c290-4603-b973-d2f8b2e6d533"), new Guid("78caa9cf-8cee-483d-a5e1-870cf6d45769") },
                    { new Guid("0e308e43-49ba-4bf3-a9a4-22c9a395c4fa"), "Team_Overflow_Junior_4", new Guid("50112afc-d878-444d-abaf-34632427debd"), new Guid("768e2812-8644-4be4-8ce6-8203d79231f4") },
                    { new Guid("278020aa-6b9b-4b35-8ed3-8ffdefde508d"), "Team_C_Mid_2", new Guid("825c8c5e-c290-4603-b973-d2f8b2e6d533"), new Guid("13cbf644-e1ae-4106-b480-c5a9ac5c8320") },
                    { new Guid("3c07e23e-2170-4917-b0d7-289aedbc2655"), "Team_A_Team_Lead", new Guid("84392792-84f3-4cac-a551-85dbc7fde1bc"), new Guid("78caa9cf-8cee-483d-a5e1-870cf6d45769") },
                    { new Guid("49421c5d-df31-40a2-a9c6-896b8aae937f"), "Team_B_Junior_2", new Guid("50112afc-d878-444d-abaf-34632427debd"), new Guid("28264979-69cc-4414-9d8f-cf1360ebe471") },
                    { new Guid("50170ebd-b209-4ae4-bbad-a910d1f4dcde"), "Team_B_Mid", new Guid("825c8c5e-c290-4603-b973-d2f8b2e6d533"), new Guid("28264979-69cc-4414-9d8f-cf1360ebe471") },
                    { new Guid("55799113-9116-4009-8897-c6a41fb743de"), "Team_Overflow_Junior_5", new Guid("50112afc-d878-444d-abaf-34632427debd"), new Guid("768e2812-8644-4be4-8ce6-8203d79231f4") },
                    { new Guid("640e3839-c013-4d3c-b3bc-35df63f80656"), "Team_A_Junior", new Guid("50112afc-d878-444d-abaf-34632427debd"), new Guid("78caa9cf-8cee-483d-a5e1-870cf6d45769") },
                    { new Guid("67c4d886-35c1-4ec6-934b-b65e2191a47a"), "Team_B_Junior_1", new Guid("50112afc-d878-444d-abaf-34632427debd"), new Guid("28264979-69cc-4414-9d8f-cf1360ebe471") },
                    { new Guid("869b4af1-af1e-48d5-8e86-f10a00894337"), "Team_A_Mid_2", new Guid("825c8c5e-c290-4603-b973-d2f8b2e6d533"), new Guid("78caa9cf-8cee-483d-a5e1-870cf6d45769") },
                    { new Guid("8c5d7430-da66-4afe-bab9-ffe3399ab594"), "Team_Overflow_Junior_3", new Guid("50112afc-d878-444d-abaf-34632427debd"), new Guid("768e2812-8644-4be4-8ce6-8203d79231f4") },
                    { new Guid("b19355b4-4581-4a10-93a4-567b0c136071"), "Team_B_Senior", new Guid("ffe91256-3a1a-4a1e-a5b2-cdbbf4848e14"), new Guid("28264979-69cc-4414-9d8f-cf1360ebe471") },
                    { new Guid("b96dd648-2835-43b9-8c19-9d5aecd6acec"), "Team_C_Mid_1", new Guid("825c8c5e-c290-4603-b973-d2f8b2e6d533"), new Guid("13cbf644-e1ae-4106-b480-c5a9ac5c8320") },
                    { new Guid("ea5257d4-62e1-4fd5-b5e8-778d6e0013fc"), "Team_Overflow_Junior_2", new Guid("50112afc-d878-444d-abaf-34632427debd"), new Guid("768e2812-8644-4be4-8ce6-8203d79231f4") },
                    { new Guid("f633e091-efb0-4a99-b529-4eb511d35dfe"), "Team_Overflow_Junior_6", new Guid("50112afc-d878-444d-abaf-34632427debd"), new Guid("768e2812-8644-4be4-8ce6-8203d79231f4") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveAgentSessions_SessionId",
                table: "ActiveAgentSessions",
                column: "SessionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionQueue");

            migrationBuilder.DropIndex(
                name: "IX_ActiveAgentSessions_SessionId",
                table: "ActiveAgentSessions");

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("02d30124-ede3-48f5-97cb-203c8a370ce8"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("0379fba9-efc3-4035-a1d1-5619a3fe0ac7"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("0e308e43-49ba-4bf3-a9a4-22c9a395c4fa"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("278020aa-6b9b-4b35-8ed3-8ffdefde508d"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("3c07e23e-2170-4917-b0d7-289aedbc2655"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("49421c5d-df31-40a2-a9c6-896b8aae937f"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("50170ebd-b209-4ae4-bbad-a910d1f4dcde"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("55799113-9116-4009-8897-c6a41fb743de"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("640e3839-c013-4d3c-b3bc-35df63f80656"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("67c4d886-35c1-4ec6-934b-b65e2191a47a"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("869b4af1-af1e-48d5-8e86-f10a00894337"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("8c5d7430-da66-4afe-bab9-ffe3399ab594"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("b19355b4-4581-4a10-93a4-567b0c136071"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("b96dd648-2835-43b9-8c19-9d5aecd6acec"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("ea5257d4-62e1-4fd5-b5e8-778d6e0013fc"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("f633e091-efb0-4a99-b529-4eb511d35dfe"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("50112afc-d878-444d-abaf-34632427debd"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("825c8c5e-c290-4603-b973-d2f8b2e6d533"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("84392792-84f3-4cac-a551-85dbc7fde1bc"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("ffe91256-3a1a-4a1e-a5b2-cdbbf4848e14"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("13cbf644-e1ae-4106-b480-c5a9ac5c8320"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("28264979-69cc-4414-9d8f-cf1360ebe471"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("768e2812-8644-4be4-8ce6-8203d79231f4"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("78caa9cf-8cee-483d-a5e1-870cf6d45769"));

            migrationBuilder.InsertData(
                table: "Seniority",
                columns: new[] { "Id", "Name", "Priority", "SeniorityMultiplier" },
                values: new object[,]
                {
                    { new Guid("2e9ce439-53fc-49a0-a1b3-c815ad880da5"), "Junior", 1, 4 },
                    { new Guid("cf4bb79c-6573-4a7c-a7cd-e118ead8d1fb"), "Team Lead", 4, 5 },
                    { new Guid("ecfab3b2-9ccf-46c8-99bf-fde65ce11b3b"), "Mid-Level", 2, 6 },
                    { new Guid("fba73d8b-2616-4936-82f6-d38d14a22704"), "Senior", 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Active", "Name", "WorkFinishHourAt", "WorkStartHourAt" },
                values: new object[,]
                {
                    { new Guid("4dadd8a1-6338-46ce-b12f-e351dc8797b6"), true, "A", 18, 10 },
                    { new Guid("5a2074de-281f-4baf-879d-e58ec75a6c42"), true, "C", 10, 2 },
                    { new Guid("9f6d40f5-7031-4c10-ab54-b940d217a99f"), false, "Overflow", 18, 10 },
                    { new Guid("bdef6327-20f4-4a6e-942b-9ad20eab570c"), true, "B", 2, 18 }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Name", "SeniorityId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("228210f2-c097-4f5e-bc9d-0396208153c9"), "Team_B_Senior", new Guid("fba73d8b-2616-4936-82f6-d38d14a22704"), new Guid("bdef6327-20f4-4a6e-942b-9ad20eab570c") },
                    { new Guid("511d122e-4ce2-463a-a58c-127e6d98838d"), "Team_Overflow_Junior_2", new Guid("2e9ce439-53fc-49a0-a1b3-c815ad880da5"), new Guid("9f6d40f5-7031-4c10-ab54-b940d217a99f") },
                    { new Guid("63c91c31-50ee-4c9c-8c2f-526889b49dff"), "Team_Overflow_Junior_4", new Guid("2e9ce439-53fc-49a0-a1b3-c815ad880da5"), new Guid("9f6d40f5-7031-4c10-ab54-b940d217a99f") },
                    { new Guid("6f8a832c-bb78-4493-8ea8-d5d5807e2b76"), "Team_Overflow_Junior_5", new Guid("2e9ce439-53fc-49a0-a1b3-c815ad880da5"), new Guid("9f6d40f5-7031-4c10-ab54-b940d217a99f") },
                    { new Guid("7680aeb8-1768-4abb-9bef-754f50f4f809"), "Team_B_Junior_2", new Guid("2e9ce439-53fc-49a0-a1b3-c815ad880da5"), new Guid("bdef6327-20f4-4a6e-942b-9ad20eab570c") },
                    { new Guid("8b18c73a-eb9a-483b-bcf2-fc0ac6b93907"), "Team_A_Mid_1", new Guid("ecfab3b2-9ccf-46c8-99bf-fde65ce11b3b"), new Guid("4dadd8a1-6338-46ce-b12f-e351dc8797b6") },
                    { new Guid("93b7c28d-4e86-43a0-9487-1bf57a1b2271"), "Team_Overflow_Junior_3", new Guid("2e9ce439-53fc-49a0-a1b3-c815ad880da5"), new Guid("9f6d40f5-7031-4c10-ab54-b940d217a99f") },
                    { new Guid("9524efba-f611-4382-9398-5708c7e71888"), "Team_C_Mid_2", new Guid("ecfab3b2-9ccf-46c8-99bf-fde65ce11b3b"), new Guid("5a2074de-281f-4baf-879d-e58ec75a6c42") },
                    { new Guid("9e0174c2-bd45-4659-b56c-1841464ddb1e"), "Team_C_Mid_1", new Guid("ecfab3b2-9ccf-46c8-99bf-fde65ce11b3b"), new Guid("5a2074de-281f-4baf-879d-e58ec75a6c42") },
                    { new Guid("b2d6976a-d502-4cf2-b31d-2bcc07341634"), "Team_A_Team_Lead", new Guid("cf4bb79c-6573-4a7c-a7cd-e118ead8d1fb"), new Guid("4dadd8a1-6338-46ce-b12f-e351dc8797b6") },
                    { new Guid("cbafae8d-2226-4151-b68b-045b1badd74d"), "Team_Overflow_Junior_6", new Guid("2e9ce439-53fc-49a0-a1b3-c815ad880da5"), new Guid("9f6d40f5-7031-4c10-ab54-b940d217a99f") },
                    { new Guid("d1f7fc52-f847-4ceb-b044-ae826f3a5cf9"), "Team_B_Mid", new Guid("ecfab3b2-9ccf-46c8-99bf-fde65ce11b3b"), new Guid("bdef6327-20f4-4a6e-942b-9ad20eab570c") },
                    { new Guid("e9c3e939-cff5-45e4-9e77-c68bd0dda4c0"), "Team_B_Junior_1", new Guid("2e9ce439-53fc-49a0-a1b3-c815ad880da5"), new Guid("bdef6327-20f4-4a6e-942b-9ad20eab570c") },
                    { new Guid("ea122361-89b8-4d30-8bee-108539c2f5ff"), "Team_Overflow_Junior_1", new Guid("2e9ce439-53fc-49a0-a1b3-c815ad880da5"), new Guid("9f6d40f5-7031-4c10-ab54-b940d217a99f") },
                    { new Guid("fb178c45-cf2d-4d36-a938-417fc20d74b6"), "Team_A_Mid_2", new Guid("ecfab3b2-9ccf-46c8-99bf-fde65ce11b3b"), new Guid("4dadd8a1-6338-46ce-b12f-e351dc8797b6") },
                    { new Guid("fd339b30-0a15-41d6-b9e7-b820eb410a9f"), "Team_A_Junior", new Guid("2e9ce439-53fc-49a0-a1b3-c815ad880da5"), new Guid("4dadd8a1-6338-46ce-b12f-e351dc8797b6") }
                });
        }
    }
}
