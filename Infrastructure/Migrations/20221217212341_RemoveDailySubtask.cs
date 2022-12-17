using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveDailySubtask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "SubtaskId",
                table: "DailyTasks",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d6a8f1b-fe28-4e9a-87a8-68f61442c471", 0, "01f728b4-dbdc-45f5-bcf5-25aa6ad62833", "User", "Kara_Murphy@yahoo.com", false, false, null, "KARA_MURPHY@YAHOO.COM", "KARA.MURPHY", "AQAAAAEAACcQAAAAENZnGVWSGK9cy3+iZ/XUiMlIhlr2iCEvR8jMc8EN8WphVNZJezj/4ho30NTihBOdcg==", null, false, "d1d6cd87-cb0e-4607-98cb-4a08e42c39e7", false, "Kara.Murphy" },
                    { "199f6e5f-29a4-4631-815e-c75647d63fea", 0, "12940cca-c5bf-484d-a421-4e57773df522", "User", "Lorena_Mayer@hotmail.com", false, false, null, "LORENA_MAYER@HOTMAIL.COM", "LORENA_MAYER", "AQAAAAEAACcQAAAAEPqIhkEZo/cBfHEXhJFJMMlqTLzjN3osI8hD6/w0XJc4IfYKKFV7lVH6yaLo8OOX4Q==", null, false, "b0c56c85-9800-4acf-8eba-8a5861847655", false, "Lorena_Mayer" },
                    { "6c751415-657e-4fbd-b0df-75b11c5f42ce", 0, "4098c069-c2c8-40f7-bb6c-0d21ed0416ee", "User", "anna.korolchuk@oa.edu.ua", false, false, null, "ANNA.KOROLCHUK@OA.EDU.UA", "ANNA.KOROLCHUK@OA.EDU.UA", "AQAAAAEAACcQAAAAEJuFp7Ls5AWX05PDCJBjYgzYw2JhD3VWrKrXcVcOqfqUC+mbIEbfHPqN4k+iDYtnTg==", null, false, "73ea4ba2-2aa6-4065-848d-a625d2a4ade9", false, "a_korolchuk" },
                    { "9e7d3c60-ca5a-4c30-8e7d-6586f556bd48", 0, "813aaf37-110c-402b-b239-40274c1bb436", "User", "Holly_Stehr@hotmail.com", false, false, null, "HOLLY_STEHR@HOTMAIL.COM", "HOLLY_STEHR", "AQAAAAEAACcQAAAAEOtH49l6S/xWxl73GOcgTJNw0VqlHZFX6FerjRz0BdtGvNyyh69ONgySmOt9oAMhvA==", null, false, "c6f1207f-1121-4ff7-8e4c-4bb03b3c752c", false, "Holly_Stehr" },
                    { "ddbcfedc-fa87-427b-97fe-0b77c6cffc42", 0, "744ec68a-40e4-42dc-87e0-15f0d4feb4e2", "User", "Myrtle.Macejkovic@yahoo.com", false, false, null, "MYRTLE.MACEJKOVIC@YAHOO.COM", "MYRTLE38", "AQAAAAEAACcQAAAAED0rfLeqLg3h/cpEoPbQcnP5+t9nzdl4lxwbk4oveMgaN3AMMg1qxocm55JYeRg7QQ==", null, false, "e0726b67-3dba-4f9e-99f3-be08d6033998", false, "Myrtle38" },
                    { "ead926e1-2a5b-48d9-ae38-6c1f58b63939", 0, "dbed2b2a-d107-4598-b4fc-745c00ff7d68", "User", "antonina.loboda@oa.edu.ua", false, false, null, "ANTONINA.LOBODA@OA.EDU.UA", "ANTONINA.LOBODA@OA.EDU.UA", "AQAAAAEAACcQAAAAECetGczFvJxtKTAHC01G5CMwurnAfZ4bMyvcWkbJJ7Y9MLd4qhkPyNUVXTAQanmDPw==", null, false, "a4d886c6-ec73-47e0-bcba-0bac478a8c77", false, "ton4ik" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyTasks_SubtaskId",
                table: "DailyTasks",
                column: "SubtaskId");

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

            migrationBuilder.DropIndex(
                name: "IX_DailyTasks_SubtaskId",
                table: "DailyTasks");

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
                name: "SubtaskId",
                table: "DailyTasks");

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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0096cde4-0bab-4acc-80ab-306a06a0d47c", 0, "24975be2-7e74-4735-88eb-578b82a9d055", "User", "antonina.loboda@oa.edu.ua", false, false, null, "ANTONINA.LOBODA@OA.EDU.UA", "ANTONINA.LOBODA@OA.EDU.UA", "AQAAAAEAACcQAAAAECrjS90yHTupb4luRFBDeJkQ75ezPvp9tKPDcZDbUcjI7EvQ8zeprak27z5cfN1dhQ==", null, false, 0, "772cd334-d6a8-458f-8926-5234f8b3bb95", false, "ton4ik" },
                    { "1e0c428b-5139-450d-87ba-d02227898702", 0, "37ee1af5-72fe-4ef4-9694-eff43e1f3020", "User", "Noah.Schamberger74@gmail.com", false, false, null, "NOAH.SCHAMBERGER74@GMAIL.COM", "NOAH12", "AQAAAAEAACcQAAAAEA5/e/7UMVnqjwxORjPSunRsPFZC2wvuy849/GLp68Ma2B+e4ajyxKjJCZNrt5tKTg==", null, false, 0, "739dc98d-6de9-4f73-916d-9cd8c0bcb028", false, "Noah12" },
                    { "3e04c7ae-7500-4f17-973f-8a881859baca", 0, "b8647355-ff2a-4a9f-9a03-843f82b53f0f", "User", "Kim21@hotmail.com", false, false, null, "KIM21@HOTMAIL.COM", "KIM.BARROWS97", "AQAAAAEAACcQAAAAEBa/BtettVEo4/rUfhlnsJhtfm/MkOMuOYQv8/MBYkuFfVgrEMYt4hQR2i1jCccnxw==", null, false, 0, "bb709187-9e04-4fc2-a6ae-9d4923197225", false, "Kim.Barrows97" },
                    { "88a2812f-1bd9-4911-b120-326a31c800e5", 0, "20156475-4661-45de-beba-7ae718b4916e", "User", "anna.korolchuk@oa.edu.ua", false, false, null, "ANNA.KOROLCHUK@OA.EDU.UA", "ANNA.KOROLCHUK@OA.EDU.UA", "AQAAAAEAACcQAAAAEJGcL+fJXNdRn2bmlVylSXRKqD+mBAvNts0mF975tBTeKNIECcBU22Tx97cLmugXmQ==", null, false, 0, "60ec7f78-7b6a-4e2a-a22d-586c5e5685a5", false, "a_korolchuk" },
                    { "897eab75-419d-42b1-9c82-bfcdaff36f09", 0, "3b0b3537-9083-48fb-acf8-5343d9008c20", "User", "Richard87@hotmail.com", false, false, null, "RICHARD87@HOTMAIL.COM", "RICHARD.SPORER29", "AQAAAAEAACcQAAAAEO+kQG+mnYll3ygrhVP2U3BjwYg3PN4Xl88du90yzpN52J4yCDIspTXwpcQdPUghAA==", null, false, 0, "371849d6-3c91-4704-91c2-1b8c1d642a87", false, "Richard.Sporer29" },
                    { "f491411e-7a6d-412c-b388-e05ef5c23cd1", 0, "e80eb9df-9f08-420f-99b9-a731f3c33959", "User", "Marcus_Mante25@gmail.com", false, false, null, "MARCUS_MANTE25@GMAIL.COM", "MARCUS12", "AQAAAAEAACcQAAAAEC25iat6voBAiSZVEiIUJRBbaNQ0lO3W9ndQ0Lspx1XScdTAWjCvf1o7c8MpY4B4bg==", null, false, 0, "ae3e6d4b-a46b-4dec-81c0-4c51082cefef", false, "Marcus12" }
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
    }
}
