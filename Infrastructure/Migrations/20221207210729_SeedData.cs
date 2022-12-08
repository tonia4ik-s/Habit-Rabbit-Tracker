using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2b2b53bc-7044-4d8e-bb0f-53cbc8417a37", 0, "564f0eff-8df2-4588-8c0a-ffd360237e6b", "User", "antonina.loboda@oa.edu.ua", false, false, null, "ANTONINA.LOBODA@OA.EDU.UA", "ANTONINA.LOBODA@OA.EDU.UA", "AQAAAAEAACcQAAAAEGwofS+I5dZvuMek4laVycDE2AUxiSNBHfVE/HIDXQDzN8NuuYma2Yw0GXjrzv2ZcA==", null, false, "f3c215a3-5530-47b9-9dec-5391ffb85563", false, "ton4ik" },
                    { "8e2b55b5-ad77-4af2-ae72-1ba673448035", 0, "db524a67-771f-4ec8-9cbe-14d8edc73979", "User", "Hugo_Tromp93@yahoo.com", false, false, null, "HUGO_TROMP93@YAHOO.COM", "HUGO39", "AQAAAAEAACcQAAAAEE74v12W1EkMfd0+yEQ5iVdlEro3cv+MywRPFwzbDaELjygSl8xnGJBXx7shMm9ojA==", null, false, "5f83f10b-0690-4373-8552-1024818e3ecd", false, "Hugo39" },
                    { "af85de92-2fc6-484a-ba13-ddf8890280d4", 0, "a41a34fd-ff2e-4bf0-805e-fd149081a08d", "User", "anna.korolchuk@oa.edu.ua", false, false, null, "ANNA.KOROLCHUK@OA.EDU.UA", "ANNA.KOROLCHUK@OA.EDU.UA", "AQAAAAEAACcQAAAAEDTnlzh6V6nkztZd54vzbjmy43vATmI8R2amlcSduTD0pl70rqNGRtrm+fVcYZrVbw==", null, false, "136cac85-3d3c-4cb5-8722-39a482ad5a81", false, "a_korolchuk" },
                    { "b93b4743-b5f8-4872-85cc-f81795e805cd", 0, "cceddd88-ab9f-411c-8b8e-94e6732135dc", "User", "Krystal72@yahoo.com", false, false, null, "KRYSTAL72@YAHOO.COM", "KRYSTAL_NICOLAS79", "AQAAAAEAACcQAAAAEJ/sBEHMzfe1KXG4s8513AkAVquSnuIe2Ro7eYH+BFnn4MI1JxYIcDtLGylMXeHTQg==", null, false, "b6122fe3-80ef-4fa3-a3c2-61420b6b2e9a", false, "Krystal_Nicolas79" },
                    { "bd6c3f55-6b31-4135-a1b2-2aebebed7bcf", 0, "fe355808-4c59-4214-9ed7-c3235e4c272a", "User", "Rosemary.Schoen@hotmail.com", false, false, null, "ROSEMARY.SCHOEN@HOTMAIL.COM", "ROSEMARY.SCHOEN", "AQAAAAEAACcQAAAAEPF/yYu+96LDghk7IbpD5tjTBF1rp9yxnTj6qtvqwguf7MOv2ucccmTrMDp54hU7Hw==", null, false, "8462b03b-2d11-494b-b907-b29b35f33727", false, "Rosemary.Schoen" },
                    { "d8f48975-6015-4f15-a997-adf1f5680042", 0, "de00bf22-0ed7-4179-8e4b-725851fd06ae", "User", "Charlotte.Pouros@hotmail.com", false, false, null, "CHARLOTTE.POUROS@HOTMAIL.COM", "CHARLOTTE_POUROS", "AQAAAAEAACcQAAAAEGlTwVVUNT5VoQMGvrHfoJnzWloLEpeCexbQ2TGhcgILvf7Ard1H+EDSkODtBQJiaA==", null, false, "ef106d06-3eac-4419-b441-a03629de0433", false, "Charlotte_Pouros" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Frequencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Frequencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Frequencies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

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
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Visibilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Visibilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Visibilities",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
