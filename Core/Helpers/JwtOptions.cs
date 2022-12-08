namespace Core.Helpers;

public class JwtOptions
{
    public string Issuer { get; set; }
    public string Key { get; set; }
    public float LifeTime { get; set; }
    public int RefreshTokenLifeTimeInDays { get; set; }
}