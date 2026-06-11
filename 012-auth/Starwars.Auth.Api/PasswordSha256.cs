using System.Security.Cryptography;
using System.Text;

namespace Starwars.Auth.Api
{
    public static class PasswordSha256
    {
        private const int Sha256HashLength = 32;

        /// <summary>
        /// Genera el hash SHA-256 de la contraseña concatenada con el salt.
        /// El resultado se devuelve en Base64.
        /// </summary>
        public static string HashPassword(
            string password,
            byte[] salt)
        {
            ArgumentNullException.ThrowIfNull(password);
            ArgumentNullException.ThrowIfNull(salt);

            byte[] hashBytes = ComputeHash(password, salt);

            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Valida la contraseña usando un salt representado como byte[].
        /// El hash esperado debe estar almacenado en Base64.
        /// </summary>
        public static bool ValidatePassword(
            string password,
            byte[] salt,
            byte[] expectedHash)
        {
            ArgumentNullException.ThrowIfNull(password);
            ArgumentNullException.ThrowIfNull(salt);

            

            if (expectedHash.Length != Sha256HashLength)
            {
                return false;
            }

            byte[] calculatedHash = ComputeHash(password, salt);

            // Evita comparar los hashes directamente con SequenceEqual.
            return CryptographicOperations.FixedTimeEquals(
                calculatedHash,
                expectedHash);
        }


        /// <summary>
        /// Valida la contraseña usando un salt representado como byte[].
        /// El hash esperado debe estar almacenado en Base64.
        /// </summary>
        public static bool ValidatePassword(
            string password,
            byte[] salt,
            string expectedHashBase64)
        {
            ArgumentNullException.ThrowIfNull(password);
            ArgumentNullException.ThrowIfNull(salt);

            if (string.IsNullOrWhiteSpace(expectedHashBase64))
            {
                return false;
            }

            byte[] expectedHash;

            try
            {
                expectedHash = Convert.FromBase64String(expectedHashBase64);
            }
            catch (FormatException)
            {
                return false;
            }

            if (expectedHash.Length != Sha256HashLength)
            {
                return false;
            }

            byte[] calculatedHash = ComputeHash(password, salt);

            // Evita comparar los hashes directamente con SequenceEqual.
            return CryptographicOperations.FixedTimeEquals(
                calculatedHash,
                expectedHash);
        }

        /// <summary>
        /// Valida la contraseña cuando el salt y el hash están almacenados
        /// como cadenas Base64.
        /// </summary>
        public static bool ValidatePassword(
            string password,
            string saltBase64,
            string expectedHashBase64)
        {
            if (string.IsNullOrWhiteSpace(saltBase64))
            {
                return false;
            }

            byte[] salt;

            try
            {
                salt = Convert.FromBase64String(saltBase64);
            }
            catch (FormatException)
            {
                return false;
            }

            return ValidatePassword(
                password,
                salt,
                expectedHashBase64);
        }

        private static byte[] ComputeHash(
            string password,
            ReadOnlySpan<byte> salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] passwordWithSalt =
                new byte[passwordBytes.Length + salt.Length];

            try
            {
                // Primero la contraseña.
                passwordBytes.CopyTo(passwordWithSalt, 0);

                // Luego el salt.
                salt.CopyTo(
                    passwordWithSalt.AsSpan(passwordBytes.Length));

                return SHA256.HashData(passwordWithSalt);
            }
            finally
            {
                // Limpia los buffers que contenían la contraseña.
                CryptographicOperations.ZeroMemory(passwordBytes);
                CryptographicOperations.ZeroMemory(passwordWithSalt);
            }
        }
    }
}
