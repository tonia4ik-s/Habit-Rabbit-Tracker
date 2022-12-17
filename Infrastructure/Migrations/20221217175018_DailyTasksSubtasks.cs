using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class DailyTasksSubtasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyTasks_Subtasks_ChallengeId",
                table: "DailyTasks");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b53bc-7044-4d8e-bb0f-53cbc8417a37");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e2b55b5-ad77-4af2-ae72-1ba673448035");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af85de92-2fc6-484a-ba13-ddf8890280d4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b93b4743-b5f8-4872-85cc-f81795e805cd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd6c3f55-6b31-4135-a1b2-2aebebed7bcf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8f48975-6015-4f15-a997-adf1f5680042");

            migrationBuilder.DropColumn(
                name: "SubtaskId",
                table: "DailyTasks");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "DailyTasks",
                newName: "AssignedDate");

            migrationBuilder.CreateTable(
                name: "DailySubtasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    SubtaskId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountOfUnitsDone = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySubtasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailySubtasks_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailySubtasks_Subtasks_SubtaskId",
                        column: x => x.SubtaskId,
                        principalTable: "Subtasks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0096cde4-0bab-4acc-80ab-306a06a0d47c", 0, "24975be2-7e74-4735-88eb-578b82a9d055", "User", "antonina.loboda@oa.edu.ua", false, false, null, "ANTONINA.LOBODA@OA.EDU.UA", "ANTONINA.LOBODA@OA.EDU.UA", "AQAAAAEAACcQAAAAECrjS90yHTupb4luRFBDeJkQ75ezPvp9tKPDcZDbUcjI7EvQ8zeprak27z5cfN1dhQ==", null, false, "772cd334-d6a8-458f-8926-5234f8b3bb95", false, "ton4ik" },
                    { "1e0c428b-5139-450d-87ba-d02227898702", 0, "37ee1af5-72fe-4ef4-9694-eff43e1f3020", "User", "Noah.Schamberger74@gmail.com", false, false, null, "NOAH.SCHAMBERGER74@GMAIL.COM", "NOAH12", "AQAAAAEAACcQAAAAEA5/e/7UMVnqjwxORjPSunRsPFZC2wvuy849/GLp68Ma2B+e4ajyxKjJCZNrt5tKTg==", null, false, "739dc98d-6de9-4f73-916d-9cd8c0bcb028", false, "Noah12" },
                    { "3e04c7ae-7500-4f17-973f-8a881859baca", 0, "b8647355-ff2a-4a9f-9a03-843f82b53f0f", "User", "Kim21@hotmail.com", false, false, null, "KIM21@HOTMAIL.COM", "KIM.BARROWS97", "AQAAAAEAACcQAAAAEBa/BtettVEo4/rUfhlnsJhtfm/MkOMuOYQv8/MBYkuFfVgrEMYt4hQR2i1jCccnxw==", null, false, "bb709187-9e04-4fc2-a6ae-9d4923197225", false, "Kim.Barrows97" },
                    { "88a2812f-1bd9-4911-b120-326a31c800e5", 0, "20156475-4661-45de-beba-7ae718b4916e", "User", "anna.korolchuk@oa.edu.ua", false, false, null, "ANNA.KOROLCHUK@OA.EDU.UA", "ANNA.KOROLCHUK@OA.EDU.UA", "AQAAAAEAACcQAAAAEJGcL+fJXNdRn2bmlVylSXRKqD+mBAvNts0mF975tBTeKNIECcBU22Tx97cLmugXmQ==", null, false, "60ec7f78-7b6a-4e2a-a22d-586c5e5685a5", false, "a_korolchuk" },
                    { "897eab75-419d-42b1-9c82-bfcdaff36f09", 0, "3b0b3537-9083-48fb-acf8-5343d9008c20", "User", "Richard87@hotmail.com", false, false, null, "RICHARD87@HOTMAIL.COM", "RICHARD.SPORER29", "AQAAAAEAACcQAAAAEO+kQG+mnYll3ygrhVP2U3BjwYg3PN4Xl88du90yzpN52J4yCDIspTXwpcQdPUghAA==", null, false, "371849d6-3c91-4704-91c2-1b8c1d642a87", false, "Richard.Sporer29" },
                    { "f491411e-7a6d-412c-b388-e05ef5c23cd1", 0, "e80eb9df-9f08-420f-99b9-a731f3c33959", "User", "Marcus_Mante25@gmail.com", false, false, null, "MARCUS_MANTE25@GMAIL.COM", "MARCUS12", "AQAAAAEAACcQAAAAEC25iat6voBAiSZVEiIUJRBbaNQ0lO3W9ndQ0Lspx1XScdTAWjCvf1o7c8MpY4B4bg==", null, false, "ae3e6d4b-a46b-4dec-81c0-4c51082cefef", false, "Marcus12" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailySubtasks_ChallengeId",
                table: "DailySubtasks",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_DailySubtasks_SubtaskId",
                table: "DailySubtasks",
                column: "SubtaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailySubtasks");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0096cde4-0bab-4acc-80ab-306a06a0d47c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e0c428b-5139-450d-87ba-d02227898702");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e04c7ae-7500-4f17-973f-8a881859baca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88a2812f-1bd9-4911-b120-326a31c800e5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "897eab75-419d-42b1-9c82-bfcdaff36f09");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f491411e-7a6d-412c-b388-e05ef5c23cd1");

            migrationBuilder.RenameColumn(
                name: "AssignedDate",
                table: "DailyTasks",
                newName: "StartDate");

            migrationBuilder.AddColumn<int>(
                name: "SubtaskId",
                table: "DailyTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2b2b53bc-7044-4d8e-bb0f-53cbc8417a37", 0, "564f0eff-8df2-4588-8c0a-ffd360237e6b", "User", "antonina.loboda@oa.edu.ua", false, false, null, "ANTONINA.LOBODA@OA.EDU.UA", "ANTONINA.LOBODA@OA.EDU.UA", "AQAAAAEAACcQAAAAEGwofS+I5dZvuMek4laVycDE2AUxiSNBHfVE/HIDXQDzN8NuuYma2Yw0GXjrzv2ZcA==", null, false, 0, "f3c215a3-5530-47b9-9dec-5391ffb85563", false, "ton4ik" },
                    { "8e2b55b5-ad77-4af2-ae72-1ba673448035", 0, "db524a67-771f-4ec8-9cbe-14d8edc73979", "User", "Hugo_Tromp93@yahoo.com", false, false, null, "HUGO_TROMP93@YAHOO.COM", "HUGO39", "AQAAAAEAACcQAAAAEE74v12W1EkMfd0+yEQ5iVdlEro3cv+MywRPFwzbDaELjygSl8xnGJBXx7shMm9ojA==", null, false, 0, "5f83f10b-0690-4373-8552-1024818e3ecd", false, "Hugo39" },
                    { "af85de92-2fc6-484a-ba13-ddf8890280d4", 0, "a41a34fd-ff2e-4bf0-805e-fd149081a08d", "User", "anna.korolchuk@oa.edu.ua", false, false, null, "ANNA.KOROLCHUK@OA.EDU.UA", "ANNA.KOROLCHUK@OA.EDU.UA", "AQAAAAEAACcQAAAAEDTnlzh6V6nkztZd54vzbjmy43vATmI8R2amlcSduTD0pl70rqNGRtrm+fVcYZrVbw==", null, false, 0, "136cac85-3d3c-4cb5-8722-39a482ad5a81", false, "a_korolchuk" },
                    { "b93b4743-b5f8-4872-85cc-f81795e805cd", 0, "cceddd88-ab9f-411c-8b8e-94e6732135dc", "User", "Krystal72@yahoo.com", false, false, null, "KRYSTAL72@YAHOO.COM", "KRYSTAL_NICOLAS79", "AQAAAAEAACcQAAAAEJ/sBEHMzfe1KXG4s8513AkAVquSnuIe2Ro7eYH+BFnn4MI1JxYIcDtLGylMXeHTQg==", null, false, 0, "b6122fe3-80ef-4fa3-a3c2-61420b6b2e9a", false, "Krystal_Nicolas79" },
                    { "bd6c3f55-6b31-4135-a1b2-2aebebed7bcf", 0, "fe355808-4c59-4214-9ed7-c3235e4c272a", "User", "Rosemary.Schoen@hotmail.com", false, false, null, "ROSEMARY.SCHOEN@HOTMAIL.COM", "ROSEMARY.SCHOEN", "AQAAAAEAACcQAAAAEPF/yYu+96LDghk7IbpD5tjTBF1rp9yxnTj6qtvqwguf7MOv2ucccmTrMDp54hU7Hw==", null, false, 0, "8462b03b-2d11-494b-b907-b29b35f33727", false, "Rosemary.Schoen" },
                    { "d8f48975-6015-4f15-a997-adf1f5680042", 0, "de00bf22-0ed7-4179-8e4b-725851fd06ae", "User", "Charlotte.Pouros@hotmail.com", false, false, null, "CHARLOTTE.POUROS@HOTMAIL.COM", "CHARLOTTE_POUROS", "AQAAAAEAACcQAAAAEGlTwVVUNT5VoQMGvrHfoJnzWloLEpeCexbQ2TGhcgILvf7Ard1H+EDSkODtBQJiaA==", null, false, 0, "ef106d06-3eac-4419-b441-a03629de0433", false, "Charlotte_Pouros" }
                });

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
