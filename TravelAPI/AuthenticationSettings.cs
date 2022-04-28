namespace TravelAPI
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public int JwtExpiteDays { get; set; }
        public string JwtIssuer { get; set; }
    }
}
