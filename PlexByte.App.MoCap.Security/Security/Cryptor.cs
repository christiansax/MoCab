using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace MoCap.Security
{
    public class Cryptor
    {
        public byte[] Salt { get; } = Encoding.ASCII.GetBytes("skjpqoiwue2134ds");
        public string Secret { get; set; } = Assembly.GetExecutingAssembly().FullName.Replace(" ", "");

        private Trace trace = new Trace(MethodBase.GetCurrentMethod().DeclaringType.Name);
        /// <summary>
        /// Encrypt the given string using AES
        /// </summary>
        /// <param name="pText">The text to encrypt</param>
        /// <param name="sharedSecret">A password used to generate a key for encryption.</param>
        public string EncryptStringAES(string pText, string pSecret)
        {
            trace.Log.EnterScope("Entering...");
            if (string.IsNullOrEmpty(pText))
                throw new ArgumentNullException("No string to encrypt");

            Secret = pSecret;
            string encryptedString = null;
            RijndaelManaged aesAlg = null;

            try
            {
                trace.Log.Info(String.Format("Attempting to encrypt string [String={0}] [Secret={1}]", pText, pSecret));
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(Secret, Salt);
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(pText);
                        }
                    }
                    encryptedString = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                if (aesAlg != null)
                    aesAlg.Clear();
            }
            trace.Log.Info(String.Format("String successfully encrypted [String={0}] [Encrypted={1}]", 
                pText, encryptedString));
            trace.Log.ExitScope("Exiting returning the encrypted string...");
            return encryptedString;
        }

        /// <summary>
        /// Decrypt the given string
        /// </summary>
        /// <param name="pText">The text to decrypt.</param>
        /// <param name="pSecret">A password used to generate a key for decryption.</param>
        public string DecryptStringAES(string pText, string pSecret)
        {
            trace.Log.EnterScope("Entering...");

            if (string.IsNullOrEmpty(pText))
                throw new ArgumentNullException("cipherText");
            
            RijndaelManaged aesAlg = null;
            string decryptedString = null;
            Secret = pSecret;

            try
            {
                trace.Log.Info(String.Format("Attempting to decrypt string [String={0}] [Secret={1}]", pText, pSecret));
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(Secret, Salt);
                byte[] bytes = Convert.FromBase64String(pText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    aesAlg.IV = ReadByteArray(msDecrypt);
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            decryptedString = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                if (aesAlg != null)
                    aesAlg.Clear();
            }
            trace.Log.Info(String.Format("String successfully decrypted [String={0}] [Decrypted={1}]",
                pText, decryptedString));
            trace.Log.ExitScope("Exiting returning the decrypted string...");
            return decryptedString;
        }

        private byte[] ReadByteArray(Stream s)
        {
            trace.Log.EnterScope("Entering...");
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
                throw new SystemException("Byte array was not formatted properly");

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
                throw new SystemException("Filed to read all bytes");
            trace.Log.Info(String.Format("Bytes successfully read [Buffer={0}]",
                buffer.ToString()));
            trace.Log.ExitScope("Exiting returning the bytes read from stream...");
            return buffer;
        }
    }
}