namespace bibliotecaAPI.Services.Auth.Jwt
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string All = Admin + ", " + User;
    }
}
