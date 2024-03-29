﻿using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class User : IdentityUser
{
    public int Points { get; set; }
    public int Status { get; set; }
    public ICollection<Challenge> AuthoredChallenges { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }

}
