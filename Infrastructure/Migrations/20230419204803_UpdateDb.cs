using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_Frequencies_FrequencyId",
                table: "Challenges");

            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_Icons_VisibilityId",
                table: "Challenges");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "Icons");

            migrationBuilder.DropIndex(
                name: "IX_Challenges_FrequencyId",
                table: "Challenges");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d6a8f1b-fe28-4e9a-87a8-68f61442c471");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "199f6e5f-29a4-4631-815e-c75647d63fea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c751415-657e-4fbd-b0df-75b11c5f42ce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e7d3c60-ca5a-4c30-8e7d-6586f556bd48");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddbcfedc-fa87-427b-97fe-0b77c6cffc42");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ead926e1-2a5b-48d9-ae38-6c1f58b63939");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "IconId",
                table: "Challenges");

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "Challenges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IconName",
                table: "Challenges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2d63186a-b5fc-4080-a630-f37b5b84ee54", 0, "9464e34d-8b4d-4ed9-8f98-76a626bce933", "User", "Tomas.Parker@gmail.com", false, false, null, "TOMAS.PARKER@GMAIL.COM", "TOMAS.PARKER", "AQAAAAEAACcQAAAAECVfyTky5/PTaSRaStKR4e9qd+jLlVTIOdUr5B5SVBITvVZvknSEnILRZ/hCfiSEuw==", null, false, "b696c1de-c2ad-48f6-be64-46bf3250d4a2", false, "Tomas.Parker" },
                    { "317019c7-affb-4721-b088-03c0edb892fd", 0, "55b792a2-2d80-41bc-b530-9b3e3800e03e", "User", "antonina.loboda@oa.edu.ua", false, false, null, "ANTONINA.LOBODA@OA.EDU.UA", "ANTONINA.LOBODA@OA.EDU.UA", "AQAAAAEAACcQAAAAEFuNG7m0dz7bSCXcQoxiCIBEggbTWrOVWrJ3EQvZ0kMdgQIeg3vZyhpPx/tGqKJttQ==", null, false, "55368574-ab92-4e40-863a-ec7e59aae95f", false, "ton4ik" },
                    { "98f58c84-c7d7-4852-ba2d-925fdb31ffc1", 0, "2140e97b-2422-458a-8fca-133cd14d7ed3", "User", "Kim96@hotmail.com", false, false, null, "KIM96@HOTMAIL.COM", "KIM33", "AQAAAAEAACcQAAAAEEE4OTbjcZ0Xmz3tycjtGWMsjIHRxAFwaWhDR7/1ikq40GJwtcSpVM5mh1TtRMvsOw==", null, false, "32b186dc-7e58-474e-a0cc-bcb324d41c57", false, "Kim33" },
                    { "aca9c1c8-960e-468d-8de8-3dc9f35fb3f8", 0, "1b316969-bc05-4989-9288-300b77ead96b", "User", "Jacob_Mitchell42@gmail.com", false, false, null, "JACOB_MITCHELL42@GMAIL.COM", "JACOB4", "AQAAAAEAACcQAAAAENUHP56sbPmLCGe5qvHwiibtCF0vP7mESLjcm9GR6hYlA2lhla2fs2nQkpSB7kTnrg==", null, false, "565b7c29-4fc6-4f44-b1e3-5d73730970bf", false, "Jacob4" },
                    { "af2eb052-90b7-4e48-b363-3da0bedfb9c8", 0, "fb02b8fe-dd5d-44da-a90e-e6203c562bae", "User", "Clayton_Ward11@gmail.com", false, false, null, "CLAYTON_WARD11@GMAIL.COM", "CLAYTON.WARD94", "AQAAAAEAACcQAAAAECQtboG+SvZIhp4iRQNzAN+RtjoZUDW8pftjhvu00oGJqVSb18KC8ku8iYmX5oqZ+w==", null, false, "d19bbc76-11f9-465b-9b83-fe6dfa51c866", false, "Clayton.Ward94" },
                    { "d040ca2a-d137-4723-804a-d54c8060c121", 0, "7a8dc252-8c31-4034-817e-16db3b94d789", "User", "anna.korolchuk@oa.edu.ua", false, false, null, "ANNA.KOROLCHUK@OA.EDU.UA", "ANNA.KOROLCHUK@OA.EDU.UA", "AQAAAAEAACcQAAAAEKb2Jil+6y1969odLMwfvrUmXRiU5AfACQs3XN+2ezCtsMKDOf3YC3GoCegbLNk+AA==", null, false, "7ee67958-8593-4b17-8f53-788ab83b51bf", false, "a_korolchuk" }
                });

            migrationBuilder.InsertData(
                table: "ChallengeTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Build a habit" },
                    { 2, "Quit a habit" }
                });

            migrationBuilder.InsertData(
                table: "Challenges",
                columns: new[] { "Id", "ChallengeTypeId", "Color", "CountOfUnits", "CreatedById", "Description", "EndDate", "Frequency", "IconName", "StartDate", "Title", "UnitId", "VisibilityId" },
                values: new object[,]
                {
                    { 1, 1, "#8CEF73", 500, "317019c7-affb-4721-b088-03c0edb892fd", "Water is vital for healthy life. So, I need to drink it enough!", new DateTimeOffset(new DateTime(2023, 5, 10, 23, 48, 2, 45, DateTimeKind.Unspecified).AddTicks(3761), new TimeSpan(0, 3, 0, 0, 0)), "1111100", "mdiWaterCheck", new DateTimeOffset(new DateTime(2023, 4, 19, 23, 48, 2, 45, DateTimeKind.Unspecified).AddTicks(2413), new TimeSpan(0, 3, 0, 0, 0)), "Drink Water", 5, 1 },
                    { 2, 1, "#8CEF73", 500, "d040ca2a-d137-4723-804a-d54c8060c121", "Water is vital for healthy life. So, I need to drink it enough!", new DateTimeOffset(new DateTime(2023, 5, 10, 23, 48, 2, 45, DateTimeKind.Unspecified).AddTicks(4721), new TimeSpan(0, 3, 0, 0, 0)), "1111100", "mdiWaterCheck", new DateTimeOffset(new DateTime(2023, 4, 19, 23, 48, 2, 45, DateTimeKind.Unspecified).AddTicks(4703), new TimeSpan(0, 3, 0, 0, 0)), "Drink Water", 5, 1 },
                    { 3, 1, "#FEFA95", 15, "317019c7-affb-4721-b088-03c0edb892fd", "", new DateTimeOffset(new DateTime(2023, 5, 10, 23, 48, 2, 45, DateTimeKind.Unspecified).AddTicks(4741), new TimeSpan(0, 3, 0, 0, 0)), "1101100", "mdiRunFast", new DateTimeOffset(new DateTime(2023, 4, 19, 23, 48, 2, 45, DateTimeKind.Unspecified).AddTicks(4738), new TimeSpan(0, 3, 0, 0, 0)), "Run", 2, 1 },
                    { 4, 1, "#FEFA95", 15, "d040ca2a-d137-4723-804a-d54c8060c121", "", new DateTimeOffset(new DateTime(2023, 5, 10, 23, 48, 2, 45, DateTimeKind.Unspecified).AddTicks(4750), new TimeSpan(0, 3, 0, 0, 0)), "1101100", "mdiRunFast", new DateTimeOffset(new DateTime(2023, 4, 19, 23, 48, 2, 45, DateTimeKind.Unspecified).AddTicks(4747), new TimeSpan(0, 3, 0, 0, 0)), "Run", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "DailyTasks",
                columns: new[] { "Id", "AssignedDate", "ChallengeId", "CountOfUnitsDone", "SubtaskId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 2, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 3, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 4, new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 5, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 6, new DateTime(2023, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 7, new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 8, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 9, new DateTime(2023, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 10, new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 11, new DateTime(2023, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 12, new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 13, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 14, new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 15, new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 16, new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 17, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 18, new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 19, new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 20, new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 21, new DateTime(2023, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 22, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null },
                    { 23, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 24, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 25, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 26, new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 27, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 28, new DateTime(2023, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 29, new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 30, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 31, new DateTime(2023, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 32, new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 33, new DateTime(2023, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 34, new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 35, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 36, new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 37, new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 38, new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 39, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 40, new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 41, new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 42, new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null }
                });

            migrationBuilder.InsertData(
                table: "DailyTasks",
                columns: new[] { "Id", "AssignedDate", "ChallengeId", "CountOfUnitsDone", "SubtaskId" },
                values: new object[,]
                {
                    { 43, new DateTime(2023, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 44, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null },
                    { 45, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 46, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 47, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 48, new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 49, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 50, new DateTime(2023, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 51, new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 52, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 53, new DateTime(2023, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 54, new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 55, new DateTime(2023, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 56, new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 57, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 58, new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 59, new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 60, new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 61, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 62, new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 63, new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 64, new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 65, new DateTime(2023, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 66, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null },
                    { 67, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 68, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 69, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 70, new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 71, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 72, new DateTime(2023, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 73, new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 74, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 75, new DateTime(2023, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 76, new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 77, new DateTime(2023, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 78, new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 79, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 80, new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 81, new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 82, new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 83, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 84, new DateTime(2023, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null }
                });

            migrationBuilder.InsertData(
                table: "DailyTasks",
                columns: new[] { "Id", "AssignedDate", "ChallengeId", "CountOfUnitsDone", "SubtaskId" },
                values: new object[,]
                {
                    { 85, new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 86, new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 87, new DateTime(2023, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null },
                    { 88, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d63186a-b5fc-4080-a630-f37b5b84ee54");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f58c84-c7d7-4852-ba2d-925fdb31ffc1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aca9c1c8-960e-468d-8de8-3dc9f35fb3f8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af2eb052-90b7-4e48-b363-3da0bedfb9c8");

            migrationBuilder.DeleteData(
                table: "ChallengeTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "DailyTasks",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Challenges",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Challenges",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Challenges",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Challenges",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "317019c7-affb-4721-b088-03c0edb892fd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d040ca2a-d137-4723-804a-d54c8060c121");

            migrationBuilder.DeleteData(
                table: "ChallengeTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "IconName",
                table: "Challenges");

            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                table: "Challenges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IconId",
                table: "Challenges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Icons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MdiName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d6a8f1b-fe28-4e9a-87a8-68f61442c471", 0, "01f728b4-dbdc-45f5-bcf5-25aa6ad62833", "User", "Kara_Murphy@yahoo.com", false, false, null, "KARA_MURPHY@YAHOO.COM", "KARA.MURPHY", "AQAAAAEAACcQAAAAENZnGVWSGK9cy3+iZ/XUiMlIhlr2iCEvR8jMc8EN8WphVNZJezj/4ho30NTihBOdcg==", null, false, 0, "d1d6cd87-cb0e-4607-98cb-4a08e42c39e7", false, "Kara.Murphy" },
                    { "199f6e5f-29a4-4631-815e-c75647d63fea", 0, "12940cca-c5bf-484d-a421-4e57773df522", "User", "Lorena_Mayer@hotmail.com", false, false, null, "LORENA_MAYER@HOTMAIL.COM", "LORENA_MAYER", "AQAAAAEAACcQAAAAEPqIhkEZo/cBfHEXhJFJMMlqTLzjN3osI8hD6/w0XJc4IfYKKFV7lVH6yaLo8OOX4Q==", null, false, 0, "b0c56c85-9800-4acf-8eba-8a5861847655", false, "Lorena_Mayer" },
                    { "6c751415-657e-4fbd-b0df-75b11c5f42ce", 0, "4098c069-c2c8-40f7-bb6c-0d21ed0416ee", "User", "anna.korolchuk@oa.edu.ua", false, false, null, "ANNA.KOROLCHUK@OA.EDU.UA", "ANNA.KOROLCHUK@OA.EDU.UA", "AQAAAAEAACcQAAAAEJuFp7Ls5AWX05PDCJBjYgzYw2JhD3VWrKrXcVcOqfqUC+mbIEbfHPqN4k+iDYtnTg==", null, false, 0, "73ea4ba2-2aa6-4065-848d-a625d2a4ade9", false, "a_korolchuk" },
                    { "9e7d3c60-ca5a-4c30-8e7d-6586f556bd48", 0, "813aaf37-110c-402b-b239-40274c1bb436", "User", "Holly_Stehr@hotmail.com", false, false, null, "HOLLY_STEHR@HOTMAIL.COM", "HOLLY_STEHR", "AQAAAAEAACcQAAAAEOtH49l6S/xWxl73GOcgTJNw0VqlHZFX6FerjRz0BdtGvNyyh69ONgySmOt9oAMhvA==", null, false, 0, "c6f1207f-1121-4ff7-8e4c-4bb03b3c752c", false, "Holly_Stehr" },
                    { "ddbcfedc-fa87-427b-97fe-0b77c6cffc42", 0, "744ec68a-40e4-42dc-87e0-15f0d4feb4e2", "User", "Myrtle.Macejkovic@yahoo.com", false, false, null, "MYRTLE.MACEJKOVIC@YAHOO.COM", "MYRTLE38", "AQAAAAEAACcQAAAAED0rfLeqLg3h/cpEoPbQcnP5+t9nzdl4lxwbk4oveMgaN3AMMg1qxocm55JYeRg7QQ==", null, false, 0, "e0726b67-3dba-4f9e-99f3-be08d6033998", false, "Myrtle38" },
                    { "ead926e1-2a5b-48d9-ae38-6c1f58b63939", 0, "dbed2b2a-d107-4598-b4fc-745c00ff7d68", "User", "antonina.loboda@oa.edu.ua", false, false, null, "ANTONINA.LOBODA@OA.EDU.UA", "ANTONINA.LOBODA@OA.EDU.UA", "AQAAAAEAACcQAAAAECetGczFvJxtKTAHC01G5CMwurnAfZ4bMyvcWkbJJ7Y9MLd4qhkPyNUVXTAQanmDPw==", null, false, 0, "a4d886c6-ec73-47e0-bcba-0bac478a8c77", false, "ton4ik" }
                });

            migrationBuilder.InsertData(
                table: "Frequencies",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Per Day" },
                    { 2, "Per Week" },
                    { 3, "Per Month" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_FrequencyId",
                table: "Challenges",
                column: "FrequencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_Frequencies_FrequencyId",
                table: "Challenges",
                column: "FrequencyId",
                principalTable: "Frequencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Challenges_Icons_VisibilityId",
                table: "Challenges",
                column: "VisibilityId",
                principalTable: "Icons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
