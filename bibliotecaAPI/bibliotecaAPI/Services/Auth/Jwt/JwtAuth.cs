namespace bibliotecaAPI.Services.Auth.Jwt
{
    public class JwtAuth
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }

    }
}
 