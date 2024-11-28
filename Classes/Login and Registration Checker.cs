using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace NexcoApp.Classes
{
    public class Login_and_Registration_Checker
    {
        public int sessionID;



        public void sessionCreation()
        {

        }

        public void sessionEnd()
        {

        }


        public bool isUserTaken(string u1)
        {
            return false;
        }


        public static string hashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(16); // 16 bytes salt (128-bit)

            // Hash the password with the salt using PBKDF2
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32); // 32 bytes hash (256-bit)
                return Convert.ToBase64String(hash); // Convert hash to a Base64 string
            }

        }
        public static bool validateUserCredentials(string enteredPassword, string storedHash, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 100000, HashAlgorithmName.SHA256))
            {
                byte[] enteredHash = pbkdf2.GetBytes(32);
                string enteredHashString = Convert.ToBase64String(enteredHash);

                // Compare the stored hash and the hash of the entered password
                return storedHash == enteredHashString;
            }
        }


        public void verificationEmail()
        {

        }

    }
}
