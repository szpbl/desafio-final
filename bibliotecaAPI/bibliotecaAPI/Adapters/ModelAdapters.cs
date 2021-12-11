using bibliotecaAPI.Models;
using bibliotecaAPI.Services.Auth.Jwt;
using System;

namespace bibliotecaAPI.Adapters
{
    public static class ModelAdapters
    {
        public static JwtCredentials ToJwtCredentials(this User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            return new JwtCredentials
            {
                Email = user.Email,
                Password = user.Password,
                Role = user.Role.Name
            };
        }


    }
}
