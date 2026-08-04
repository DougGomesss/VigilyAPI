using System.Security.Cryptography;
using VigilyAPI.Interfaces;

namespace VigilyAPI.Models
{
    public class PasswordHasher : IPasswordHasher
    {

        private const int SaltSize = 128 / 8;

        private const int KeySize = 256 / 8;

        private const int Iterations = 10000;
        private static readonly HashAlgorithmName _hashAlg = HashAlgorithmName.SHA256;
        private const char Delimiter = ';';

        public string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _hashAlg, KeySize);

            return string.Join(Delimiter,Convert.ToBase64String(salt),Convert.ToBase64String(hash));

        }

        public bool Verify(string passwordHash, string inputPassword)
        {
            var partes = passwordHash.Split(Delimiter);
            if (partes.Length != 2)
            {
                return false;
            }

            byte[] salt = Convert.FromBase64String(partes[0]);
            byte[] hash = Convert.FromBase64String(partes[1]);

            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, Iterations, _hashAlg, KeySize);

            return CryptographicOperations.FixedTimeEquals(hash, inputHash);
        }
    }
}
