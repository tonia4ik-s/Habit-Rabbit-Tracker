using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Bogus;

namespace Infrastructure.Data;

public static class Seed
{
    private static readonly PasswordHasher<User> PasswordHasher = new();

    public static void SeedData(this ModelBuilder builder)
    {
        SeedUser(builder);
        SeedUnit(builder);
        SeedFrequency(builder);
        SeedVisibility(builder);
    }

    #region User
    
    private static readonly string User0Id = Guid.NewGuid().ToString();
    private static readonly string User1Id = Guid.NewGuid().ToString();
    private static readonly string User2Id = Guid.NewGuid().ToString();
    private static readonly string User3Id = Guid.NewGuid().ToString();
    private static readonly string ToniaId = Guid.NewGuid().ToString();
    private static readonly string AnnaId = Guid.NewGuid().ToString();
    private static void SeedUser(ModelBuilder builder)
    {
        var persons = new List<Person>();
        for (var i = 0; i < 4; i++)
        {
            persons.Add(new Person());
        }
        
        var user0 = new User
            {
                Id = User0Id,
                UserName = persons[0].UserName,
                NormalizedEmail = persons[0].Email.ToUpper(),
                NormalizedUserName = persons[0].UserName.ToUpper(),
                Email = persons[0].Email,
                Points = 0
            };
            var user1 = new User
            {
                Id = User1Id,
                UserName = persons[1].UserName,
                NormalizedEmail = persons[1].Email.ToUpper(),
                NormalizedUserName = persons[1].UserName.ToUpper(),
                Email = persons[1].Email,
                Points = 0
            };
            var user2 = new User
            {
                Id = User2Id,
                UserName = persons[2].UserName,
                NormalizedEmail = persons[2].Email.ToUpper(),
                NormalizedUserName = persons[2].UserName.ToUpper(),
                Email = persons[2].Email,
                Points = 0
            };
            var user3 = new User
            {
                Id = User3Id,
                UserName = persons[3].UserName,
                NormalizedEmail = persons[3].Email.ToUpper(),
                NormalizedUserName = persons[3].UserName.ToUpper(),
                Email = persons[3].Email,
                Points = 0
            };
            var userTonia = new User
            {
                Id = ToniaId,
                UserName = "ton4ik",
                NormalizedEmail = "antonina.loboda@oa.edu.ua".ToUpper(),
                NormalizedUserName = "antonina.loboda@oa.edu.ua".ToUpper(),
                Email = "antonina.loboda@oa.edu.ua",
                Points = 0
            };
            var userAnna = new User
            {
                Id = AnnaId,
                UserName = "a_korolchuk",
                NormalizedEmail = "anna.korolchuk@oa.edu.ua".ToUpper(),
                NormalizedUserName = "anna.korolchuk@oa.edu.ua".ToUpper(),
                Email = "anna.korolchuk@oa.edu.ua",
                Points = 0
            };
            user0.PasswordHash = PasswordHasher.HashPassword(user0, "Password_1");
            user1.PasswordHash = PasswordHasher.HashPassword(user1, "Password_1");
            user2.PasswordHash = PasswordHasher.HashPassword(user2, "Password_1");
            user3.PasswordHash = PasswordHasher.HashPassword(user3, "Password_1");
            userTonia.PasswordHash = PasswordHasher.HashPassword(userTonia, "Password_1");
            userAnna.PasswordHash = PasswordHasher.HashPassword(userAnna, "Password_1");
            builder.Entity<User>().HasData(userAnna, userTonia, user0, user1, user2, user3);
    }
    #endregion

    #region Unit

    private static void SeedUnit(ModelBuilder builder)
    {
        builder.Entity<Unit>()
            .HasData(
                new Unit { Id = 1, Type = "times", ShortType = "times"},
                new Unit { Id = 2, Type = "minutes", ShortType = "min"},
                new Unit { Id = 3, Type = "meters", ShortType = "m"},
                new Unit { Id = 4, Type = "kilometers", ShortType = "km"},
                new Unit { Id = 5, Type = "milliliters", ShortType = "ml"},
                new Unit { Id = 6, Type = "pages", ShortType = "pages"}
            );
    }

    #endregion

    #region Frequency

    private static void SeedFrequency(ModelBuilder builder)
    {
        builder.Entity<Frequency>()
            .HasData(
                new Frequency{ Id = 1, Type = "Per Day"},
                new Frequency{ Id = 2, Type = "Per Week"},
                new Frequency{ Id = 3, Type = "Per Month"}
            );
    }

    #endregion

    #region Visibility

    private static void SeedVisibility(ModelBuilder builder)
    {
        builder.Entity<Visibility>()
            .HasData(
                new Visibility{Id = 1, Type = "Only me"},
                new Visibility{ Id = 2, Type = "Friends"},
                new Visibility{ Id = 3, Type = "All users"}
            );
    }

    #endregion
}