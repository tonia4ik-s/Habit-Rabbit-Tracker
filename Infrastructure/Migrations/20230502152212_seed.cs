using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Statuses_StatusId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_Frequencies_FrequencyId",
                table: "Challenges");

            migrationBuilder.DropForeignKey(
                name: "FK_Challenges_Icons_VisibilityId",
                table: "Challenges");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyTasks_Subtasks_ChallengeId",
                table: "DailyTasks");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "Icons");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Challenges_FrequencyId",
                table: "Challenges");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StatusId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "DailyTasks");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "IconId",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "SubtaskId",
                table: "DailyTasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "AssignedDate",
                table: "DailyTasks",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

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

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0f62a9d4-941b-467f-b7e6-f73b09776829", 0, "35a24b9f-7ce9-4b2b-b249-038dcb733f7d", "User", "Hazel.Windler@yahoo.com", false, false, null, "HAZEL.WINDLER@YAHOO.COM", "HAZEL.WINDLER54", "AQAAAAEAACcQAAAAEGhm4/v2BKI/HZYTNtpnNTRkbu2MxWRc62KQhpFqyUclM2U5yspYzsxs87Uza9eSUw==", null, false, "2d1c24a2-1ae0-4347-9d85-0b2bf24d3532", false, "Hazel.Windler54" },
                    { "81a2a998-6922-4cd9-ba36-b449a34a766a", 0, "38bccebb-9a16-4253-8a26-8ab7b6988c0a", "User", "antonina.loboda@oa.edu.ua", false, false, null, "ANTONINA.LOBODA@OA.EDU.UA", "ANTONINA.LOBODA@OA.EDU.UA", "AQAAAAEAACcQAAAAEBGqLKbJw2OMQC09TB10aXTCvTLHCM3xuCPa5DcImqenZ84FtTFWqwF4jKtHMtzApQ==", null, false, "ea001771-eeff-4418-911a-911fcd128f83", false, "ton4ik" },
                    { "8526c845-e7be-4844-adbd-d512656409cc", 0, "d9ec33dd-5e80-4ccf-8e19-f187eb63444b", "User", "anna.korolchuk@oa.edu.ua", false, false, null, "ANNA.KOROLCHUK@OA.EDU.UA", "ANNA.KOROLCHUK@OA.EDU.UA", "AQAAAAEAACcQAAAAEFudCFAoB+hlNmb/NyptFmxfgm3Zl8vm+5LNj5Vx0B3oxfWR6+dFYAezZMN6dt448g==", null, false, "21ce0b7e-a765-4dc3-b1ad-7cc522490426", false, "a_korolchuk" },
                    { "8e0b9c60-db77-4f6f-a533-0c06862c6885", 0, "c3c2f021-4882-4c82-9520-86bd78a6d3b4", "User", "Isaac_Quitzon46@gmail.com", false, false, null, "ISAAC_QUITZON46@GMAIL.COM", "ISAAC.QUITZON38", "AQAAAAEAACcQAAAAEAfBWOkDCPgEmhIE5031CnvilxzwAHu5+cRbrk7JV7H3mhhgoQ5bOOIOi0yN36TEkQ==", null, false, "aec308e3-9118-43d6-9c27-3bd216e6e22f", false, "Isaac.Quitzon38" },
                    { "ae7798fc-28c0-42fe-ac62-522f5ba98346", 0, "f52150be-e837-469c-a6fc-dd67d97ffd7a", "User", "Evelyn74@gmail.com", false, false, null, "EVELYN74@GMAIL.COM", "EVELYN19", "AQAAAAEAACcQAAAAEOddig0JblU++PbYBZcPiuM3vcqKSToQEGfpfF3+r4sqSWUhfdlda04jqYW0px+T4A==", null, false, "54bdb774-6147-49ea-a12c-5dd30e7bdbc1", false, "Evelyn19" },
                    { "ee531384-2905-423d-b65b-8c913f89333a", 0, "8b9efb0d-23d3-4707-809c-011cf56ffd1a", "User", "Trevor.Bashirian25@gmail.com", false, false, null, "TREVOR.BASHIRIAN25@GMAIL.COM", "TREVOR30", "AQAAAAEAACcQAAAAELPE1PkjK68LUhCB+o/srDEcqunFFKAltG90MSqmB9v2Htj+dmk6LRIvpJlf3Wf1sA==", null, false, "f542193e-a320-4c41-b2e6-ba7620e7b73e", false, "Trevor30" }
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
                table: "Units",
                columns: new[] { "Id", "ShortType", "Type" },
                values: new object[,]
                {
                    { 1, "times", "times" },
                    { 2, "min", "minutes" },
                    { 3, "m", "meters" },
                    { 4, "km", "kilometers" },
                    { 5, "ml", "milliliters" },
                    { 6, "pages", "pages" }
                });

            migrationBuilder.InsertData(
                table: "Visibilities",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Only me" },
                    { 2, "Friends" },
                    { 3, "All users" }
                });

            migrationBuilder.InsertData(
                table: "Challenges",
                columns: new[] { "Id", "ChallengeTypeId", "Color", "CountOfUnits", "CreatedById", "Description", "EndDate", "Frequency", "IconName", "StartDate", "Title", "UnitId", "VisibilityId" },
                values: new object[,]
                {
                    { 1, 1, "#8CEF73", 500, "81a2a998-6922-4cd9-ba36-b449a34a766a", "Water is vital for healthy life. So, I need to drink it enough!", new DateTimeOffset(new DateTime(2023, 5, 23, 18, 22, 10, 745, DateTimeKind.Unspecified).AddTicks(2277), new TimeSpan(0, 3, 0, 0, 0)), "1111100", "mdiWaterCheck", new DateTimeOffset(new DateTime(2023, 5, 2, 18, 22, 10, 745, DateTimeKind.Unspecified).AddTicks(239), new TimeSpan(0, 3, 0, 0, 0)), "Drink Water", 5, 1 },
                    { 2, 1, "#8CEF73", 500, "8526c845-e7be-4844-adbd-d512656409cc", "Water is vital for healthy life. So, I need to drink it enough!", new DateTimeOffset(new DateTime(2023, 5, 23, 18, 22, 10, 745, DateTimeKind.Unspecified).AddTicks(3689), new TimeSpan(0, 3, 0, 0, 0)), "1111100", "mdiWaterCheck", new DateTimeOffset(new DateTime(2023, 5, 2, 18, 22, 10, 745, DateTimeKind.Unspecified).AddTicks(3666), new TimeSpan(0, 3, 0, 0, 0)), "Drink Water", 5, 1 },
                    { 3, 1, "#FEFA95", 15, "81a2a998-6922-4cd9-ba36-b449a34a766a", "", new DateTimeOffset(new DateTime(2023, 5, 23, 18, 22, 10, 745, DateTimeKind.Unspecified).AddTicks(3718), new TimeSpan(0, 3, 0, 0, 0)), "1101100", "mdiRunFast", new DateTimeOffset(new DateTime(2023, 5, 2, 18, 22, 10, 745, DateTimeKind.Unspecified).AddTicks(3713), new TimeSpan(0, 3, 0, 0, 0)), "Run", 2, 1 },
                    { 4, 1, "#FEFA95", 15, "8526c845-e7be-4844-adbd-d512656409cc", "", new DateTimeOffset(new DateTime(2023, 5, 23, 18, 22, 10, 745, DateTimeKind.Unspecified).AddTicks(3732), new TimeSpan(0, 3, 0, 0, 0)), "1101100", "mdiRunFast", new DateTimeOffset(new DateTime(2023, 5, 2, 18, 22, 10, 745, DateTimeKind.Unspecified).AddTicks(3726), new TimeSpan(0, 3, 0, 0, 0)), "Run", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "DailyTasks",
                columns: new[] { "Id", "AssignedDate", "ChallengeId", "CountOfUnitsDone", "SubtaskId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 2, new DateTimeOffset(new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 3, new DateTimeOffset(new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 4, new DateTimeOffset(new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 5, new DateTimeOffset(new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 6, new DateTimeOffset(new DateTime(2023, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 7, new DateTimeOffset(new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 8, new DateTimeOffset(new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 9, new DateTimeOffset(new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 10, new DateTimeOffset(new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 11, new DateTimeOffset(new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 12, new DateTimeOffset(new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 13, new DateTimeOffset(new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 14, new DateTimeOffset(new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 15, new DateTimeOffset(new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 16, new DateTimeOffset(new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 17, new DateTimeOffset(new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 18, new DateTimeOffset(new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 19, new DateTimeOffset(new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 20, new DateTimeOffset(new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 21, new DateTimeOffset(new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 22, new DateTimeOffset(new DateTime(2023, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 23, new DateTimeOffset(new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 24, new DateTimeOffset(new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 25, new DateTimeOffset(new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 26, new DateTimeOffset(new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 27, new DateTimeOffset(new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 28, new DateTimeOffset(new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 29, new DateTimeOffset(new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 30, new DateTimeOffset(new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 31, new DateTimeOffset(new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 32, new DateTimeOffset(new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 33, new DateTimeOffset(new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 34, new DateTimeOffset(new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 35, new DateTimeOffset(new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 36, new DateTimeOffset(new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 37, new DateTimeOffset(new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 38, new DateTimeOffset(new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 39, new DateTimeOffset(new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 40, new DateTimeOffset(new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 41, new DateTimeOffset(new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 42, new DateTimeOffset(new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null }
                });

            migrationBuilder.InsertData(
                table: "DailyTasks",
                columns: new[] { "Id", "AssignedDate", "ChallengeId", "CountOfUnitsDone", "SubtaskId" },
                values: new object[,]
                {
                    { 43, new DateTimeOffset(new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 44, new DateTimeOffset(new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 45, new DateTimeOffset(new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 46, new DateTimeOffset(new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 47, new DateTimeOffset(new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 48, new DateTimeOffset(new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 49, new DateTimeOffset(new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 50, new DateTimeOffset(new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 51, new DateTimeOffset(new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 52, new DateTimeOffset(new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 53, new DateTimeOffset(new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 54, new DateTimeOffset(new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 55, new DateTimeOffset(new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 56, new DateTimeOffset(new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyTasks_SubtaskId",
                table: "DailyTasks",
                column: "SubtaskId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyTasks_Subtasks_SubtaskId",
                table: "DailyTasks",
                column: "SubtaskId",
                principalTable: "Subtasks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyTasks_Subtasks_SubtaskId",
                table: "DailyTasks");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_DailyTasks_SubtaskId",
                table: "DailyTasks");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f62a9d4-941b-467f-b7e6-f73b09776829");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e0b9c60-db77-4f6f-a533-0c06862c6885");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae7798fc-28c0-42fe-ac62-522f5ba98346");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee531384-2905-423d-b65b-8c913f89333a");

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
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Visibilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Visibilities",
                keyColumn: "Id",
                keyValue: 3);

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
                keyValue: "81a2a998-6922-4cd9-ba36-b449a34a766a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8526c845-e7be-4844-adbd-d512656409cc");

            migrationBuilder.DeleteData(
                table: "ChallengeTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Visibilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "AssignedDate",
                table: "DailyTasks");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "IconName",
                table: "Challenges");

            migrationBuilder.AlterColumn<int>(
                name: "SubtaskId",
                table: "DailyTasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "DailyTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_FrequencyId",
                table: "Challenges",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StatusId",
                table: "AspNetUsers",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Statuses_StatusId",
                table: "AspNetUsers",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_DailyTasks_Subtasks_ChallengeId",
                table: "DailyTasks",
                column: "ChallengeId",
                principalTable: "Subtasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
