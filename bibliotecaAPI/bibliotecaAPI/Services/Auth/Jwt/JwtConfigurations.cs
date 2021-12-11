namespace bibliotecaAPI.Services.Auth.Jwt
{
    public class JwtConfigurations
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public int ValidMinutes { get; set; }
    }
}
