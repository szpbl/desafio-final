namespace bibliotecaAPI.Services.Auth.Jwt.Interfaces
{
    public interface IJwtAuthManager
    {
        JwtAuth GenerateToken(JwtCredentials credentials);

    }
}
    