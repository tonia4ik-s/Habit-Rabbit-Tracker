﻿// <auto-generated />
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
    [Migration("20221217212341_RemoveDailySubtask")]
    partial class RemoveDailySubtask
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

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ChallengeId")
                        .HasColumnType("int");

                    b.Property<int>("CountOfUnitsDone")
                        .HasColumnType("int");

                    b.Property<bool>("IsDone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("SubtaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("SubtaskId");

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
                            Id = "6c751415-657e-4fbd-b0df-75b11c5f42ce",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4098c069-c2c8-40f7-bb6c-0d21ed0416ee",
                            Email = "anna.korolchuk@oa.edu.ua",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ANNA.KOROLCHUK@OA.EDU.UA",
                            NormalizedUserName = "ANNA.KOROLCHUK@OA.EDU.UA",
                            PasswordHash = "AQAAAAEAACcQAAAAEJuFp7Ls5AWX05PDCJBjYgzYw2JhD3VWrKrXcVcOqfqUC+mbIEbfHPqN4k+iDYtnTg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "73ea4ba2-2aa6-4065-848d-a625d2a4ade9",
                            TwoFactorEnabled = false,
                            UserName = "a_korolchuk",
                            Points = 0
                        },
                        new
                        {
                            Id = "ead926e1-2a5b-48d9-ae38-6c1f58b63939",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "dbed2b2a-d107-4598-b4fc-745c00ff7d68",
                            Email = "antonina.loboda@oa.edu.ua",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ANTONINA.LOBODA@OA.EDU.UA",
                            NormalizedUserName = "ANTONINA.LOBODA@OA.EDU.UA",
                            PasswordHash = "AQAAAAEAACcQAAAAECetGczFvJxtKTAHC01G5CMwurnAfZ4bMyvcWkbJJ7Y9MLd4qhkPyNUVXTAQanmDPw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a4d886c6-ec73-47e0-bcba-0bac478a8c77",
                            TwoFactorEnabled = false,
                            UserName = "ton4ik",
                            Points = 0
                        },
                        new
                        {
                            Id = "ddbcfedc-fa87-427b-97fe-0b77c6cffc42",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "744ec68a-40e4-42dc-87e0-15f0d4feb4e2",
                            Email = "Myrtle.Macejkovic@yahoo.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MYRTLE.MACEJKOVIC@YAHOO.COM",
                            NormalizedUserName = "MYRTLE38",
                            PasswordHash = "AQAAAAEAACcQAAAAED0rfLeqLg3h/cpEoPbQcnP5+t9nzdl4lxwbk4oveMgaN3AMMg1qxocm55JYeRg7QQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e0726b67-3dba-4f9e-99f3-be08d6033998",
                            TwoFactorEnabled = false,
                            UserName = "Myrtle38",
                            Points = 0
                        },
                        new
                        {
                            Id = "199f6e5f-29a4-4631-815e-c75647d63fea",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "12940cca-c5bf-484d-a421-4e57773df522",
                            Email = "Lorena_Mayer@hotmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "LORENA_MAYER@HOTMAIL.COM",
                            NormalizedUserName = "LORENA_MAYER",
                            PasswordHash = "AQAAAAEAACcQAAAAEPqIhkEZo/cBfHEXhJFJMMlqTLzjN3osI8hD6/w0XJc4IfYKKFV7lVH6yaLo8OOX4Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b0c56c85-9800-4acf-8eba-8a5861847655",
                            TwoFactorEnabled = false,
                            UserName = "Lorena_Mayer",
                            Points = 0
                        },
                        new
                        {
                            Id = "9e7d3c60-ca5a-4c30-8e7d-6586f556bd48",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "813aaf37-110c-402b-b239-40274c1bb436",
                            Email = "Holly_Stehr@hotmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "HOLLY_STEHR@HOTMAIL.COM",
                            NormalizedUserName = "HOLLY_STEHR",
                            PasswordHash = "AQAAAAEAACcQAAAAEOtH49l6S/xWxl73GOcgTJNw0VqlHZFX6FerjRz0BdtGvNyyh69ONgySmOt9oAMhvA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c6f1207f-1121-4ff7-8e4c-4bb03b3c752c",
                            TwoFactorEnabled = false,
                            UserName = "Holly_Stehr",
                            Points = 0
                        },
                        new
                        {
                            Id = "0d6a8f1b-fe28-4e9a-87a8-68f61442c471",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "01f728b4-dbdc-45f5-bcf5-25aa6ad62833",
                            Email = "Kara_Murphy@yahoo.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "KARA_MURPHY@YAHOO.COM",
                            NormalizedUserName = "KARA.MURPHY",
                            PasswordHash = "AQAAAAEAACcQAAAAENZnGVWSGK9cy3+iZ/XUiMlIhlr2iCEvR8jMc8EN8WphVNZJezj/4ho30NTihBOdcg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d1d6cd87-cb0e-4607-98cb-4a08e42c39e7",
                            TwoFactorEnabled = false,
                            UserName = "Kara.Murphy",
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
                        .HasForeignKey("SubtaskId");

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