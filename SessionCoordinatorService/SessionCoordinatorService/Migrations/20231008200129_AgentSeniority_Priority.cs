using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SessionCoordinatorService.Migrations
{
    /// <inheritdoc />
    public partial class AgentSeniority_Priority : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("011120b1-deb1-4a25-a722-07b0c3cc619f"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("10fbdf23-ddb3-4547-b015-54c5e19fa0b6"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("27356d94-050d-449d-81ef-2bf501abc3e3"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("3b5fdebe-e447-4bca-8e40-bf95b176a8f5"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("42fad6d9-49a6-4d74-a1f1-6741de0273ed"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("4392a336-2598-4ee2-a14c-19e0486d3fdd"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("68c30ca4-2d2e-4e08-a576-b2c0ba1bd599"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("69cd109c-ac88-4c30-984a-10c8530c4be7"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("6d16410a-19a9-4298-9f1c-f9455a214d0e"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("6ec60c06-c978-42a4-8c4f-3c10cd5d4f22"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("75eac2fa-b183-48f2-9a85-765b266c5540"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("8ae34fde-fab5-4e06-8483-48801321dc14"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("933a6450-49b8-47a7-83ee-2a66cd175335"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("9ce592e4-7de9-4121-9164-78a068659a76"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("c0acd479-7239-45f6-ae01-5d8a467499f0"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("edf5938d-8397-404f-abf4-377e51607707"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("4b2b355f-c2f6-487e-b2af-58a37243218b"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("693322d7-1989-4e35-8449-50d7262be52c"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("70e14af8-2b36-491a-9fe7-f041e6f8548d"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("95d957dc-7184-4506-b4f8-f0eca3d4d9f5"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("28fbf6fe-1a4a-4304-b88d-acd03e273014"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("3a5aab28-b35d-40fe-bca1-e9ec849b6459"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("6e9be61e-0bb7-42b7-8462-bb45f8fab017"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("e8120c31-461b-4a93-8f61-9e37dbf5a8cb"));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Seniority",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Seniority");

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
        }
    }
}
