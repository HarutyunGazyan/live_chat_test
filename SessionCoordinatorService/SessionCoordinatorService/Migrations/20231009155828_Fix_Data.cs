using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SessionCoordinatorService.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("0d65da4c-b328-40c3-b71c-d4b627503fe3"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("2d732fcc-6dc0-40ea-a6cb-4b06af5279d5"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("3ca51880-68d4-4942-9ef8-4896ebba8d7c"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("55850d77-f5b4-4338-9136-b6f7def8346e"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("59398f8e-b752-426b-bacc-6d35cbccfcbd"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("5defb01e-36de-4ff0-94b4-5a38f0b12e2c"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("624789b6-b5f3-440c-be6c-d5e4f6fe276e"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("6c07866e-3044-41d0-a493-d39cebabd874"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("797d6a9d-dba8-46e9-bd72-729fa24ecb2a"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("8e587fa2-e482-4227-b2e1-ac54ec6cc17c"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("a67b0b95-8d84-4222-a7aa-9d22b5e2764c"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("aa0ec6aa-a2a9-4960-b6be-95be0eadd5e8"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("b48e7123-a765-44d6-9d50-00c659d5bd2f"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("d0eadccd-ea31-4b74-b582-b6844539e1c3"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("d9f6e9a0-46a4-4c16-8a23-7c2e0184b485"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("e84db322-ae6e-4b85-a36c-3720d68391c0"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("6e1865e1-3524-4b08-a0ce-f2851427e547"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("9f1a2439-4b5c-4200-ab48-590e2dc935e6"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("de62c6ac-1d06-4643-8377-4303f5a7ce7d"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("eb0c6f3a-5b34-44ce-b12a-595db4139bef"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("487de4b0-bef5-40b6-97bd-4d95d9848acb"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("4fea00c1-d25f-47a6-8fa0-bca34d15e90d"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("5ba95a9a-ecbe-4f8a-9527-a7245bf094be"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("b932985c-df11-4658-b4cf-71778aad5282"));

            migrationBuilder.InsertData(
                table: "Seniority",
                columns: new[] { "Id", "Name", "Priority", "SeniorityMultiplier" },
                values: new object[,]
                {
                    { new Guid("6d4d0945-4b98-40b3-a24e-daad2096b837"), "Mid-Level", 2, 6 },
                    { new Guid("705e8762-21c4-445c-b400-8197b864c10b"), "Senior", 3, 8 },
                    { new Guid("8a23ef84-55e1-4c52-9fa2-20479c9bec0e"), "Team Lead", 4, 5 },
                    { new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"), "Junior", 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Active", "Name", "WorkFinishHourAt", "WorkStartHourAt" },
                values: new object[,]
                {
                    { new Guid("53dbdf96-52fc-4ead-86d5-8216705572ba"), true, "B", new DateTime(1, 1, 2, 2, 1, 1, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified) },
                    { new Guid("d3287426-98f0-4d8a-9588-0f44c19f0b2c"), true, "A", new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified) },
                    { new Guid("d75db702-3633-4429-b34e-37562ec568cb"), false, "Overflow", new DateTime(1, 1, 1, 18, 1, 1, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified) },
                    { new Guid("da3659ba-a6ff-471a-8ec1-f7b819e22447"), true, "C", new DateTime(1, 1, 1, 10, 1, 1, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 2, 1, 1, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Name", "SeniorityId", "TeamId" },
                values: new object[,]
                {
                    { new Guid("25a4831c-57fe-4ffe-b2c1-e8665790e4f8"), "Team_Overflow_Junior_2", new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"), new Guid("d75db702-3633-4429-b34e-37562ec568cb") },
                    { new Guid("2ef99b7d-2381-4ff0-98a7-5fee8b1bb8c6"), "Team_Overflow_Junior_3", new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"), new Guid("d75db702-3633-4429-b34e-37562ec568cb") },
                    { new Guid("677bfb2e-1115-4e9d-ad0e-1933aa4cf772"), "Team_Overflow_Junior_4", new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"), new Guid("d75db702-3633-4429-b34e-37562ec568cb") },
                    { new Guid("68546cd7-c67b-43f6-9414-8ed0d3c18f70"), "Team_C_Mid_1", new Guid("6d4d0945-4b98-40b3-a24e-daad2096b837"), new Guid("da3659ba-a6ff-471a-8ec1-f7b819e22447") },
                    { new Guid("6ac6422a-8175-45f1-9e2d-b26795ef159a"), "Team_A_Junior", new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"), new Guid("d3287426-98f0-4d8a-9588-0f44c19f0b2c") },
                    { new Guid("7371da25-aed5-4729-83f3-8f019162e247"), "Team_A_Team_Lead", new Guid("8a23ef84-55e1-4c52-9fa2-20479c9bec0e"), new Guid("d3287426-98f0-4d8a-9588-0f44c19f0b2c") },
                    { new Guid("7db9b214-98fd-4704-befe-ccb2c30d3a58"), "Team_Overflow_Junior_1", new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"), new Guid("d75db702-3633-4429-b34e-37562ec568cb") },
                    { new Guid("92766907-c000-46e1-8a8f-afe49a5ae43b"), "Team_C_Mid_2", new Guid("6d4d0945-4b98-40b3-a24e-daad2096b837"), new Guid("da3659ba-a6ff-471a-8ec1-f7b819e22447") },
                    { new Guid("95bf41de-d41e-45b7-8ad7-96cc659f69bf"), "Team_B_Junior_1", new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"), new Guid("53dbdf96-52fc-4ead-86d5-8216705572ba") },
                    { new Guid("9c8b506b-03c6-4b38-a943-3299ea11e27d"), "Team_B_Junior_2", new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"), new Guid("53dbdf96-52fc-4ead-86d5-8216705572ba") },
                    { new Guid("9d1c5486-c3bd-4474-8e14-aa88f3bfb035"), "Team_Overflow_Junior_6", new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"), new Guid("d75db702-3633-4429-b34e-37562ec568cb") },
                    { new Guid("af177e89-a80a-42a2-99f4-bc0526948ae9"), "Team_A_Mid_1", new Guid("6d4d0945-4b98-40b3-a24e-daad2096b837"), new Guid("d3287426-98f0-4d8a-9588-0f44c19f0b2c") },
                    { new Guid("bec11bf9-03f0-4ee4-aa0e-9bc7f389ba94"), "Team_A_Mid_2", new Guid("6d4d0945-4b98-40b3-a24e-daad2096b837"), new Guid("d3287426-98f0-4d8a-9588-0f44c19f0b2c") },
                    { new Guid("d51a1572-87e6-452e-8ea7-2bc6951c6ab6"), "Team_Overflow_Junior_5", new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"), new Guid("d75db702-3633-4429-b34e-37562ec568cb") },
                    { new Guid("d772fa06-b498-4f6d-a76a-d309d4b12e77"), "Team_B_Mid", new Guid("6d4d0945-4b98-40b3-a24e-daad2096b837"), new Guid("53dbdf96-52fc-4ead-86d5-8216705572ba") },
                    { new Guid("fae50fbb-5940-4981-beb3-863086e1c127"), "Team_B_Senior", new Guid("705e8762-21c4-445c-b400-8197b864c10b"), new Guid("53dbdf96-52fc-4ead-86d5-8216705572ba") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("25a4831c-57fe-4ffe-b2c1-e8665790e4f8"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("2ef99b7d-2381-4ff0-98a7-5fee8b1bb8c6"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("677bfb2e-1115-4e9d-ad0e-1933aa4cf772"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("68546cd7-c67b-43f6-9414-8ed0d3c18f70"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("6ac6422a-8175-45f1-9e2d-b26795ef159a"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("7371da25-aed5-4729-83f3-8f019162e247"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("7db9b214-98fd-4704-befe-ccb2c30d3a58"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("92766907-c000-46e1-8a8f-afe49a5ae43b"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("95bf41de-d41e-45b7-8ad7-96cc659f69bf"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("9c8b506b-03c6-4b38-a943-3299ea11e27d"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("9d1c5486-c3bd-4474-8e14-aa88f3bfb035"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("af177e89-a80a-42a2-99f4-bc0526948ae9"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("bec11bf9-03f0-4ee4-aa0e-9bc7f389ba94"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("d51a1572-87e6-452e-8ea7-2bc6951c6ab6"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("d772fa06-b498-4f6d-a76a-d309d4b12e77"));

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: new Guid("fae50fbb-5940-4981-beb3-863086e1c127"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("6d4d0945-4b98-40b3-a24e-daad2096b837"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("705e8762-21c4-445c-b400-8197b864c10b"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("8a23ef84-55e1-4c52-9fa2-20479c9bec0e"));

            migrationBuilder.DeleteData(
                table: "Seniority",
                keyColumn: "Id",
                keyValue: new Guid("cd80aec0-73e7-4fb9-8c17-81e53724a380"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("53dbdf96-52fc-4ead-86d5-8216705572ba"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("d3287426-98f0-4d8a-9588-0f44c19f0b2c"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("d75db702-3633-4429-b34e-37562ec568cb"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("da3659ba-a6ff-471a-8ec1-f7b819e22447"));

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
        }
    }
}
