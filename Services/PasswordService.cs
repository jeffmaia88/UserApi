using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace UserApi.Services
{
    public class PasswordService
    {
        private static readonly PasswordHasher<string> _hasher = new();

        public static string Hash(string password)
        {
            return _hasher.HashPassword(null, password);
        }

        public static bool Verify(string password, string hashed)
        {
            return _hasher.VerifyHashedPassword(null, hashed, password) == PasswordVerificationResult.Success;
        }
        

    }
}
