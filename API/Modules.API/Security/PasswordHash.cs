using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace ZFramework.Modules.API.Security
{
    public static class PasswordHash
    {
        public static string Create(long userID, string password)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: BitConverter.GetBytes(userID),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 512 / 8));
            return hashed;
        }
    }
}