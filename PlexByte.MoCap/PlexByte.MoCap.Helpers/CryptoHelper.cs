//////////////////////////////////////////////////////////////
//                      Class CryptoHelper                              
//      Author: Christian B. Sax            Date:   2016/02/29
//      Contains methods to en-/decrypt strings using a given password
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PlexByte.MoCap.Helpers
{
    public class CryptoHelper
    {
        private static byte[] _salt = new byte[] { 0x77, 0x22, 0x55, 0xBC, 0xF0, 0xA3, 0x14, 0x62, 0x76, 0x65, 0xAA, 0xA1, 0xEF };
        public static string Encrypt(string pStringToEncrypt, string pPassword)
        {
            byte[] plainBytes = Encoding.Unicode.GetBytes(pStringToEncrypt);
            string encryptedString = null;
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(pPassword, _salt);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptStream = new CryptoStream(memoryStream,
                        encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptStream.Write(plainBytes, 0, plainBytes.Length);
                        cryptStream.Close();
                    }
                    encryptedString = Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return encryptedString;
        }

        public static string Decrypt(string pStringToDecrypt, string pPassword)
        {
            pStringToDecrypt = pStringToDecrypt.Replace(" ", "+");
            byte[] cryptBytes = Convert.FromBase64String(pStringToDecrypt);
            string decryptedString = null;
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(pPassword, _salt);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptStream = new CryptoStream(memoryStream, encryptor.CreateDecryptor(),
                        CryptoStreamMode.Write))
                    {
                        cryptStream.Write(cryptBytes, 0, cryptBytes.Length);
                        cryptStream.Close();
                    }
                    decryptedString = Encoding.Unicode.GetString(memoryStream.ToArray());
                }
            }
            return decryptedString;
        }
    }
}
