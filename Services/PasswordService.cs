using System.Security.Cryptography;

namespace MyTasksBackend.Services
{
    
    public class PasswordService
    {
        private const int SaltSize = 16; // Taille du salt en bytes
        private const int HashSize = 32; // Taille du hash en bytes
        private const int Iterations = 100000; // Nombre d'itérations (ajustable selon vos besoins)

        public static string HashPassword(string password)
        {
            // Générer un nouveau salt
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

            // Créer le hash
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password: password,
                salt: salt,
                iterations: Iterations,
                hashAlgorithm: HashAlgorithmName.SHA256,
                outputLength: HashSize);

            // Combiner salt et hash
            byte[] combinedBytes = new byte[SaltSize + HashSize];
            Buffer.BlockCopy(salt, 0, combinedBytes, 0, SaltSize);
            Buffer.BlockCopy(hash, 0, combinedBytes, SaltSize, HashSize);

            // Convertir en string base64 pour stockage
            return Convert.ToBase64String(combinedBytes);
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            try
            {
                // Convertir le hash stocké de base64 en bytes
                byte[] combinedBytes = Convert.FromBase64String(storedHash);

                // Extraire le salt
                byte[] salt = new byte[SaltSize];
                Buffer.BlockCopy(combinedBytes, 0, salt, 0, SaltSize);

                // Extraire le hash original
                byte[] originalHash = new byte[HashSize];
                Buffer.BlockCopy(combinedBytes, SaltSize, originalHash, 0, HashSize);

                // Calculer le hash du mot de passe fourni
                byte[] newHash = Rfc2898DeriveBytes.Pbkdf2(
                    password: password,
                    salt: salt,
                    iterations: Iterations,
                    hashAlgorithm: HashAlgorithmName.SHA256,
                    outputLength: HashSize);

                // Comparer les hash
                return CryptographicOperations.FixedTimeEquals(originalHash, newHash);
            }
            catch
            {
                return false;
            }
        }
    }
}
