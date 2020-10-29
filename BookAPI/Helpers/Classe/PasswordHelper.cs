using BookAPI.Helpers.Interface;
using BookAPI.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Helpers.Classe
{
    public class PasswordHelper : IPasswordHelper
    {
        private static byte[] salt = Encoding.ASCII.GetBytes("8fbde915ebbd2044768a415d26f63cc4");
        public string HashPassword(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        public bool VerifyPasswordHash(int userID, string candidate, string userHashedPass)
        {
            return (HashPassword(candidate) == userHashedPass);
        }

    }
}
