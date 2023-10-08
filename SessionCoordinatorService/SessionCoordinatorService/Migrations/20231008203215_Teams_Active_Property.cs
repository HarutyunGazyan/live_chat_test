using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SessionCoordinatorService.Migrations
{
    /// <inheritdoc />
    public partial class Teams_Active_Property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("08b15074-de2d-49e7-82f4-9878d8719b2e"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("17d74fb9-074e-4a41-ba6c-6fe93ff78fcf"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("36458934-96ae-4bb0-a414-f97f67690c2c"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("388eb163-50d0-4846-bb86-fc927f337139"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("393cb5d4-af46-418c-919c-2feb9baf1e16"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("552a02e6-67ab-4f17-90ed-8d74d9ba4701"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("620a0583-49e6-4f18-9c0f-c18278d84720"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("64dbb614-a7ec-4341-9fec-235d63dc7a12"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("6789e80f-7d3c-481e-b508-403610a45fbe"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("72d1ce82-5251-4947-bfa9-87997fd23493"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("b4c8fa7d-b5c2-4e9d-84e2-b0cb80e41df1"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("c116f8b7-3e16-44ce-8e4f-990a58a98572"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("d6a59728-55b3-47cc-8533-bc4d9984c133"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("d6f2d80a-2772-4c02-9fda-11466565415e"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("e44e0dc2-94f0-4da5-b3ac-7b976a27f431"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("eb0de4e4-19b8-42b5-8c32-3b4f60ef4d62"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("4ec4ade9-7f8f-4f36-9ae6-0d908f4f080a"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("a0379406-bdc9-42ed-bd66-828c568ff1c7"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("a9781f00-9624-46f6-860a-b7be49528419"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("f08d3880-d4ad-42bd-abf6-fb89a7306851"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("5af1b482-14b2-465b-8606-10c40142194b"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("5c39b2dc-c64b-4d5e-8ede-95ba12c5a01b"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("735a7af3-54b4-4d76-b13d-da90271c687a"));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Teams",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Teams");

            migrationBuilder.InsertData(
                table: "Seniority",
                columns: new[] { "Id", "Name", "Priority", "SeniorityMultiplier" },
                values: new object[,]
                {
                    { new Guid("4ec4ade9-7f8f-4f36-9ae6-0d908f4f080a"), "Senior", 3, 8 },
                    { new Guid("a0379406-bdc9-42ed-bd66-828c568ff1c7"), "Team Lead", 4, 5 },
                    { new Guid("a9781f00-9624-46f6-860a-b7be49528419"), "Junior", 1, 4 },
                    { new Guid("f08d3880-d4ad-42bd-abf6-fb89a7306851"), "Mid-Level", 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name", "WorkFinishHourAt", "WorkStartHourAt" },
                values: new object[,]
                {
                    { new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b"), "Overflow", 18, 10 },
                    { new Guid("5af1b482-14b2-465b-8606-10c40142194b"), "B", 2, 18 },
                    { new Guid("5c39b2dc-c64b-4d5e-8ede-95ba12c5a01b"), "A", 18, 10 },
                    { new Guid("735a7af3-54b4-4d76-b13d-da90271c687a"), "C", 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Name", "SeniorityId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("08b15074-de2d-49e7-82f4-9878d8719b2e"), "Team_A_Team_Lead", new Guid("a0379406-bdc9-42ed-bd66-828c568ff1c7"), new Guid("5c39b2dc-c64b-4d5e-8ede-95ba12c5a01b") },
                    { new Guid("17d74fb9-074e-4a41-ba6c-6fe93ff78fcf"), "Team_Overflow_Junior_3", new Guid("a9781f00-9624-46f6-860a-b7be49528419"), new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b") },
                    { new Guid("36458934-96ae-4bb0-a414-f97f67690c2c"), "Team_Overflow_Junior_6", new Guid("a9781f00-9624-46f6-860a-b7be49528419"), new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b") },
                    { new Guid("388eb163-50d0-4846-bb86-fc927f337139"), "Team_Overflow_Junior_5", new Guid("a9781f00-9624-46f6-860a-b7be49528419"), new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b") },
                    { new Guid("393cb5d4-af46-418c-919c-2feb9baf1e16"), "Team_B_Senior", new Guid("4ec4ade9-7f8f-4f36-9ae6-0d908f4f080a"), new Guid("5af1b482-14b2-465b-8606-10c40142194b") },
                    { new Guid("552a02e6-67ab-4f17-90ed-8d74d9ba4701"), "Team_Overflow_Junior_1", new Guid("a9781f00-9624-46f6-860a-b7be49528419"), new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b") },
                    { new Guid("620a0583-49e6-4f18-9c0f-c18278d84720"), "Team_B_Junior_2", new Guid("a9781f00-9624-46f6-860a-b7be49528419"), new Guid("5af1b482-14b2-465b-8606-10c40142194b") },
                    { new Guid("64dbb614-a7ec-4341-9fec-235d63dc7a12"), "Team_B_Mid", new Guid("f08d3880-d4ad-42bd-abf6-fb89a7306851"), new Guid("5af1b482-14b2-465b-8606-10c40142194b") },
                    { new Guid("6789e80f-7d3c-481e-b508-403610a45fbe"), "Team_B_Junior_1", new Guid("a9781f00-9624-46f6-860a-b7be49528419"), new Guid("5af1b482-14b2-465b-8606-10c40142194b") },
                    { new Guid("72d1ce82-5251-4947-bfa9-87997fd23493"), "Team_C_Mid_1", new Guid("f08d3880-d4ad-42bd-abf6-fb89a7306851"), new Guid("735a7af3-54b4-4d76-b13d-da90271c687a") },
                    { new Guid("b4c8fa7d-b5c2-4e9d-84e2-b0cb80e41df1"), "Team_Overflow_Junior_4", new Guid("a9781f00-9624-46f6-860a-b7be49528419"), new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b") },
                    { new Guid("c116f8b7-3e16-44ce-8e4f-990a58a98572"), "Team_A_Junior", new Guid("a9781f00-9624-46f6-860a-b7be49528419"), new Guid("5c39b2dc-c64b-4d5e-8ede-95ba12c5a01b") },
                    { new Guid("d6a59728-55b3-47cc-8533-bc4d9984c133"), "Team_C_Mid_2", new Guid("f08d3880-d4ad-42bd-abf6-fb89a7306851"), new Guid("735a7af3-54b4-4d76-b13d-da90271c687a") },
                    { new Guid("d6f2d80a-2772-4c02-9fda-11466565415e"), "Team_Overflow_Junior_2", new Guid("a9781f00-9624-46f6-860a-b7be49528419"), new Guid("1cad37d9-a78d-443e-85b6-9381f8cfaa0b") },
                    { new Guid("e44e0dc2-94f0-4da5-b3ac-7b976a27f431"), "Team_A_Mid_2", new Guid("f08d3880-d4ad-42bd-abf6-fb89a7306851"), new Guid("5c39b2dc-c64b-4d5e-8ede-95ba12c5a01b") },
                    { new Guid("eb0de4e4-19b8-42b5-8c32-3b4f60ef4d62"), "Team_A_Mid_1", new Guid("f08d3880-d4ad-42bd-abf6-fb89a7306851"), new Guid("5c39b2dc-c64b-4d5e-8ede-95ba12c5a01b") }
                });
        }
    }
}
