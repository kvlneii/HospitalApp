using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace HospitalApp.SecurityPassword
{
    public class PasswordSecurity
    {
        public const int SALT_SIZE = 16; 
        public const int ITERATIONS = 100000;

        public static string GetHashedSaltedPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            var hashedSaltedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: ITERATIONS,
                numBytesRequested: 32));

            return hashedSaltedPassword;
        }

        public static Tuple<string, string> GetHashedPasswordAndSalt(string password)
        {
            byte[] saltBytes = new byte[SALT_SIZE];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(saltBytes);

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: ITERATIONS,
                numBytesRequested: 32));

            string salt = Convert.ToBase64String(saltBytes);

            return new(hashedPassword, salt);
        }
    }
}
