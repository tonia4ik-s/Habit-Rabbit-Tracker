// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221207210729_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChallengeUser", b =>
                {
                    b.Property<int>("ChallengesId")
                        .HasColumnType("int");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ChallengesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ChallengeUser");
                });

            modelBuilder.Entity("Core.Entities.Challenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChallengeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountOfUnits")
                        .HasColumnType("int");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("FrequencyId")
                        .HasColumnType("int");

                    b.Property<int>("IconId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("VisibilityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeTypeId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("FrequencyId");

                    b.HasIndex("UnitId");

                    b.HasIndex("VisibilityId");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("Core.Entities.ChallengeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChallengeTypes");
                });

            modelBuilder.Entity("Core.Entities.DailyTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChallengeId")
                        .HasColumnType("int");

                    b.Property<int>("CountOfUnitsDone")
                        .HasColumnType("int");

                    b.Property<bool>("IsDone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubtaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.ToTable("DailyTasks");
                });

            modelBuilder.Entity("Core.Entities.Frequency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Frequencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Per Day"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Per Week"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Per Month"
                        });
                });

            modelBuilder.Entity("Core.Entities.Icon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MdiName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Icons");
                });

            modelBuilder.Entity("Core.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Core.Entities.Subtask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChallengeId")
                        .HasColumnType("int");

                    b.Property<int>("CountOfUnits")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("UnitId");

                    b.ToTable("Subtasks");
                });

            modelBuilder.Entity("Core.Entities.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ShortType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ShortType = "times",
                            Type = "times"
                        },
                        new
                        {
                            Id = 2,
                            ShortType = "min",
                            Type = "minutes"
                        },
                        new
                        {
                            Id = 3,
                            ShortType = "m",
                            Type = "meters"
                        },
                        new
                        {
                            Id = 4,
                            ShortType = "km",
                            Type = "kilometers"
                        },
                        new
                        {
                            Id = 5,
                            ShortType = "ml",
                            Type = "milliliters"
                        },
                        new
                        {
                            Id = 6,
                            ShortType = "pages",
                            Type = "pages"
                        });
                });

            modelBuilder.Entity("Core.Entities.Visibility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Visibilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Only me"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Friends"
                        },
                        new
                        {
                            Id = 3,
                            Type = "All users"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int>("Points")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = "af85de92-2fc6-484a-ba13-ddf8890280d4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a41a34fd-ff2e-4bf0-805e-fd149081a08d",
                            Email = "anna.korolchuk@oa.edu.ua",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ANNA.KOROLCHUK@OA.EDU.UA",
                            NormalizedUserName = "ANNA.KOROLCHUK@OA.EDU.UA",
                            PasswordHash = "AQAAAAEAACcQAAAAEDTnlzh6V6nkztZd54vzbjmy43vATmI8R2amlcSduTD0pl70rqNGRtrm+fVcYZrVbw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "136cac85-3d3c-4cb5-8722-39a482ad5a81",
                            TwoFactorEnabled = false,
                            UserName = "a_korolchuk",
                            Points = 0
                        },
                        new
                        {
                            Id = "2b2b53bc-7044-4d8e-bb0f-53cbc8417a37",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "564f0eff-8df2-4588-8c0a-ffd360237e6b",
                            Email = "antonina.loboda@oa.edu.ua",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ANTONINA.LOBODA@OA.EDU.UA",
                            NormalizedUserName = "ANTONINA.LOBODA@OA.EDU.UA",
                            PasswordHash = "AQAAAAEAACcQAAAAEGwofS+I5dZvuMek4laVycDE2AUxiSNBHfVE/HIDXQDzN8NuuYma2Yw0GXjrzv2ZcA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f3c215a3-5530-47b9-9dec-5391ffb85563",
                            TwoFactorEnabled = false,
                            UserName = "ton4ik",
                            Points = 0
                        },
                        new
                        {
                            Id = "8e2b55b5-ad77-4af2-ae72-1ba673448035",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "db524a67-771f-4ec8-9cbe-14d8edc73979",
                            Email = "Hugo_Tromp93@yahoo.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "HUGO_TROMP93@YAHOO.COM",
                            NormalizedUserName = "HUGO39",
                            PasswordHash = "AQAAAAEAACcQAAAAEE74v12W1EkMfd0+yEQ5iVdlEro3cv+MywRPFwzbDaELjygSl8xnGJBXx7shMm9ojA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5f83f10b-0690-4373-8552-1024818e3ecd",
                            TwoFactorEnabled = false,
                            UserName = "Hugo39",
                            Points = 0
                        },
                        new
                        {
                            Id = "bd6c3f55-6b31-4135-a1b2-2aebebed7bcf",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fe355808-4c59-4214-9ed7-c3235e4c272a",
                            Email = "Rosemary.Schoen@hotmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ROSEMARY.SCHOEN@HOTMAIL.COM",
                            NormalizedUserName = "ROSEMARY.SCHOEN",
                            PasswordHash = "AQAAAAEAACcQAAAAEPF/yYu+96LDghk7IbpD5tjTBF1rp9yxnTj6qtvqwguf7MOv2ucccmTrMDp54hU7Hw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8462b03b-2d11-494b-b907-b29b35f33727",
                            TwoFactorEnabled = false,
                            UserName = "Rosemary.Schoen",
                            Points = 0
                        },
                        new
                        {
                            Id = "d8f48975-6015-4f15-a997-adf1f5680042",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "de00bf22-0ed7-4179-8e4b-725851fd06ae",
                            Email = "Charlotte.Pouros@hotmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "CHARLOTTE.POUROS@HOTMAIL.COM",
                            NormalizedUserName = "CHARLOTTE_POUROS",
                            PasswordHash = "AQAAAAEAACcQAAAAEGlTwVVUNT5VoQMGvrHfoJnzWloLEpeCexbQ2TGhcgILvf7Ard1H+EDSkODtBQJiaA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ef106d06-3eac-4419-b441-a03629de0433",
                            TwoFactorEnabled = false,
                            UserName = "Charlotte_Pouros",
                            Points = 0
                        },
                        new
                        {
                            Id = "b93b4743-b5f8-4872-85cc-f81795e805cd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cceddd88-ab9f-411c-8b8e-94e6732135dc",
                            Email = "Krystal72@yahoo.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "KRYSTAL72@YAHOO.COM",
                            NormalizedUserName = "KRYSTAL_NICOLAS79",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ/sBEHMzfe1KXG4s8513AkAVquSnuIe2Ro7eYH+BFnn4MI1JxYIcDtLGylMXeHTQg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b6122fe3-80ef-4fa3-a3c2-61420b6b2e9a",
                            TwoFactorEnabled = false,
                            UserName = "Krystal_Nicolas79",
                            Points = 0
                        });
                });

            modelBuilder.Entity("ChallengeUser", b =>
                {
                    b.HasOne("Core.Entities.Challenge", null)
                        .WithMany()
                        .HasForeignKey("ChallengesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Challenge", b =>
                {
                    b.HasOne("Core.Entities.ChallengeType", "ChallengeType")
                        .WithMany("Challenges")
                        .HasForeignKey("ChallengeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "CreatedBy")
                        .WithMany("AuthoredChallenges")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Frequency", "Frequency")
                        .WithMany("Challenges")
                        .HasForeignKey("FrequencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Unit", "Unit")
                        .WithMany("Challenges")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Icon", "Icon")
                        .WithMany("Challenges")
                        .HasForeignKey("VisibilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Visibility", "Visibility")
                        .WithMany("Challenges")
                        .HasForeignKey("VisibilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChallengeType");

                    b.Navigation("CreatedBy");

                    b.Navigation("Frequency");

                    b.Navigation("Icon");

                    b.Navigation("Unit");

                    b.Navigation("Visibility");
                });

            modelBuilder.Entity("Core.Entities.DailyTask", b =>
                {
                    b.HasOne("Core.Entities.Challenge", "Challenge")
                        .WithMany("DailyTasks")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Subtask", "Subtask")
                        .WithMany("DailyTasks")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("Subtask");
                });

            modelBuilder.Entity("Core.Entities.RefreshToken", b =>
                {
                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.Subtask", b =>
                {
                    b.HasOne("Core.Entities.Challenge", "Challenge")
                        .WithMany("Subtasks")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Unit", "Unit")
                        .WithMany("Subtasks")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Challenge", b =>
                {
                    b.Navigation("DailyTasks");

                    b.Navigation("Subtasks");
                });

            modelBuilder.Entity("Core.Entities.ChallengeType", b =>
                {
                    b.Navigation("Challenges");
                });

            modelBuilder.Entity("Core.Entities.Frequency", b =>
                {
                    b.Navigation("Challenges");
                });

            modelBuilder.Entity("Core.Entities.Icon", b =>
                {
                    b.Navigation("Challenges");
                });

            modelBuilder.Entity("Core.Entities.Subtask", b =>
                {
                    b.Navigation("DailyTasks");
                });

            modelBuilder.Entity("Core.Entities.Unit", b =>
                {
                    b.Navigation("Challenges");

                    b.Navigation("Subtasks");
                });

            modelBuilder.Entity("Core.Entities.Visibility", b =>
                {
                    b.Navigation("Challenges");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Navigation("AuthoredChallenges");

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
