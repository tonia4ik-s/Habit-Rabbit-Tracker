using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Status = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChallengeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountOfUnits = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChallengeTypeId = table.Column<int>(type: "int", nullable: false),
                    VisibilityId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Challenges_ChallengeTypes_ChallengeTypeId",
                        column: x => x.ChallengeTypeId,
                        principalTable: "ChallengeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Challenges_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Challenges_Visibilities_VisibilityId",
                        column: x => x.VisibilityId,
                        principalTable: "Visibilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subtasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    CountOfUnits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subtasks_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subtasks_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DailyTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    SubtaskId = table.Column<int>(type: "int", nullable: true),
                    AssignedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CountOfUnitsDone = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyTasks_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyTasks_Subtasks_SubtaskId",
                        column: x => x.SubtaskId,
                        principalTable: "Subtasks",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0b843f0e-f1f1-4943-90d5-a4c093f24a24", 0, "9611f81f-394c-4b16-a4d8-0ab498b93e19", "User", "Erik4@yahoo.com", false, false, null, "ERIK4@YAHOO.COM", "ERIK_HETTINGER62", "AQAAAAEAACcQAAAAEK8Tbpp8fuoDuG9D+8DYlQTFzg0tKhFkGO2M9xVkANS2ZZneJO33WSQo+LK2rmxNGw==", null, false, "3054516d-2e88-422c-bc08-99480990cf92", false, "Erik_Hettinger62" },
                    { "2d4cf49d-0337-4d22-b6f3-99c4f4c84154", 0, "608e40a1-67b1-45ac-8955-d9244c57b64d", "User", "anna.korolchuk@oa.edu.ua", false, false, null, "ANNA.KOROLCHUK@OA.EDU.UA", "ANNA.KOROLCHUK@OA.EDU.UA", "AQAAAAEAACcQAAAAEI7RYDhfyOD8R4Qr/gCYiVdBJkkM/nDOIKgE4hqd0osAhcVH6ZerryptJqi9kGzspQ==", null, false, "51d8bd7f-7fce-4f89-9c74-e2f9af5b56c2", false, "a_korolchuk" },
                    { "925c1878-68c0-4fca-98f0-f33f728db1fa", 0, "0eb667c0-85d0-4b5e-bcc8-90448743b18f", "User", "Randall.Spencer@gmail.com", false, false, null, "RANDALL.SPENCER@GMAIL.COM", "RANDALL_SPENCER53", "AQAAAAEAACcQAAAAEAbbX9AAOn1nNraZWtcR2MTRyJoUITyNqC70EyHUuNWgAa67/kFlHQB0ySp2yqsbfQ==", null, false, "61c485a8-b132-473d-b66b-b951662c275f", false, "Randall_Spencer53" },
                    { "9b772948-ec50-4259-a288-89846eed26d2", 0, "f4a9343b-1634-451a-bf2e-198da22118cf", "User", "antonina.loboda@oa.edu.ua", false, false, null, "ANTONINA.LOBODA@OA.EDU.UA", "ANTONINA.LOBODA@OA.EDU.UA", "AQAAAAEAACcQAAAAEM+0uV20KfnV8WyPj4UELBnXe2M0Fs+B1mG5zSrrLLRWNcerEhywwV44LctyfdxmWQ==", null, false, "f71130d9-f0c4-4875-ab39-7d62b2bd7e02", false, "ton4ik" },
                    { "c2956c48-973d-4915-a739-0df7533e7261", 0, "fd2e2b3e-05c4-452e-9d5c-1f5e69ba8415", "User", "Ollie_Beier@gmail.com", false, false, null, "OLLIE_BEIER@GMAIL.COM", "OLLIE_BEIER", "AQAAAAEAACcQAAAAEBUyLuPQmEYCvLIAD6pqFva/91VdY0TxJxU3/e30SoH/8bIrenP8qNOkxg4ei/WqWw==", null, false, "4efa82ff-9881-40ee-bd4d-a9bb209d095f", false, "Ollie_Beier" },
                    { "d4e75c26-b3fc-4e10-a4b2-af69533a9152", 0, "25f5aafd-b205-4c70-9681-144c451090cd", "User", "Kendra.Herzog@gmail.com", false, false, null, "KENDRA.HERZOG@GMAIL.COM", "KENDRA41", "AQAAAAEAACcQAAAAEFEN4KPWx6qlfBWhq8J9duLwsZ8cvNhPRwASKWQ0W2zHKrF4c9DG7f1X39UnPYF4tQ==", null, false, "f56905c4-08e2-46e7-9aa0-7b8d1f425048", false, "Kendra41" }
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
                    { 1, 1, "#8CEF73", 500, "9b772948-ec50-4259-a288-89846eed26d2", "Water is vital for healthy life. So, I need to drink it enough!", new DateTimeOffset(new DateTime(2023, 7, 9, 17, 27, 1, 525, DateTimeKind.Unspecified).AddTicks(7621), new TimeSpan(0, 3, 0, 0, 0)), "1111100", "mdiWaterCheck", new DateTimeOffset(new DateTime(2023, 6, 18, 17, 27, 1, 525, DateTimeKind.Unspecified).AddTicks(6161), new TimeSpan(0, 3, 0, 0, 0)), "Drink Water", 5, 1 },
                    { 2, 1, "#8CEF73", 500, "2d4cf49d-0337-4d22-b6f3-99c4f4c84154", "Water is vital for healthy life. So, I need to drink it enough!", new DateTimeOffset(new DateTime(2023, 7, 9, 17, 27, 1, 525, DateTimeKind.Unspecified).AddTicks(8575), new TimeSpan(0, 3, 0, 0, 0)), "1111100", "mdiWaterCheck", new DateTimeOffset(new DateTime(2023, 6, 18, 17, 27, 1, 525, DateTimeKind.Unspecified).AddTicks(8556), new TimeSpan(0, 3, 0, 0, 0)), "Drink Water", 5, 1 },
                    { 3, 1, "#FEFA95", 15, "9b772948-ec50-4259-a288-89846eed26d2", "", new DateTimeOffset(new DateTime(2023, 7, 9, 17, 27, 1, 525, DateTimeKind.Unspecified).AddTicks(8595), new TimeSpan(0, 3, 0, 0, 0)), "1101100", "mdiRunFast", new DateTimeOffset(new DateTime(2023, 6, 18, 17, 27, 1, 525, DateTimeKind.Unspecified).AddTicks(8592), new TimeSpan(0, 3, 0, 0, 0)), "Run", 2, 1 },
                    { 4, 1, "#FEFA95", 15, "2d4cf49d-0337-4d22-b6f3-99c4f4c84154", "", new DateTimeOffset(new DateTime(2023, 7, 9, 17, 27, 1, 525, DateTimeKind.Unspecified).AddTicks(8603), new TimeSpan(0, 3, 0, 0, 0)), "1101100", "mdiRunFast", new DateTimeOffset(new DateTime(2023, 6, 18, 17, 27, 1, 525, DateTimeKind.Unspecified).AddTicks(8600), new TimeSpan(0, 3, 0, 0, 0)), "Run", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "DailyTasks",
                columns: new[] { "Id", "AssignedDate", "ChallengeId", "CountOfUnitsDone", "SubtaskId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 2, new DateTimeOffset(new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 3, new DateTimeOffset(new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 4, new DateTimeOffset(new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 5, new DateTimeOffset(new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 6, new DateTimeOffset(new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 7, new DateTimeOffset(new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 8, new DateTimeOffset(new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 9, new DateTimeOffset(new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 10, new DateTimeOffset(new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 11, new DateTimeOffset(new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 12, new DateTimeOffset(new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 13, new DateTimeOffset(new DateTime(2023, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 14, new DateTimeOffset(new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 15, new DateTimeOffset(new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 16, new DateTimeOffset(new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 0, null },
                    { 17, new DateTimeOffset(new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 18, new DateTimeOffset(new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 19, new DateTimeOffset(new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 20, new DateTimeOffset(new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 21, new DateTimeOffset(new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 22, new DateTimeOffset(new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 23, new DateTimeOffset(new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 24, new DateTimeOffset(new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 25, new DateTimeOffset(new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 26, new DateTimeOffset(new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 27, new DateTimeOffset(new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 28, new DateTimeOffset(new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 29, new DateTimeOffset(new DateTime(2023, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 30, new DateTimeOffset(new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 31, new DateTimeOffset(new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 32, new DateTimeOffset(new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 0, null },
                    { 33, new DateTimeOffset(new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 34, new DateTimeOffset(new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 35, new DateTimeOffset(new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 36, new DateTimeOffset(new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 37, new DateTimeOffset(new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 38, new DateTimeOffset(new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 39, new DateTimeOffset(new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 40, new DateTimeOffset(new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 41, new DateTimeOffset(new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 42, new DateTimeOffset(new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null }
                });

            migrationBuilder.InsertData(
                table: "DailyTasks",
                columns: new[] { "Id", "AssignedDate", "ChallengeId", "CountOfUnitsDone", "SubtaskId" },
                values: new object[,]
                {
                    { 43, new DateTimeOffset(new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 44, new DateTimeOffset(new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 45, new DateTimeOffset(new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 0, null },
                    { 46, new DateTimeOffset(new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 47, new DateTimeOffset(new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 48, new DateTimeOffset(new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 49, new DateTimeOffset(new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 50, new DateTimeOffset(new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 51, new DateTimeOffset(new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 52, new DateTimeOffset(new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 53, new DateTimeOffset(new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 54, new DateTimeOffset(new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 55, new DateTimeOffset(new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 56, new DateTimeOffset(new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 57, new DateTimeOffset(new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null },
                    { 58, new DateTimeOffset(new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 4, 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_ChallengeTypeId",
                table: "Challenges",
                column: "ChallengeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_CreatedById",
                table: "Challenges",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_UnitId",
                table: "Challenges",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_VisibilityId",
                table: "Challenges",
                column: "VisibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTasks_ChallengeId",
                table: "DailyTasks",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyTasks_SubtaskId",
                table: "DailyTasks",
                column: "SubtaskId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subtasks_ChallengeId",
                table: "Subtasks",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subtasks_UnitId",
                table: "Subtasks",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DailyTasks");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Subtasks");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ChallengeTypes");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Visibilities");
        }
    }
}
