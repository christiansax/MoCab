using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace MoCap.MoCap.Security
{
    public class Cypher
    {
        public string Password { get; } = "admin";
        public string Secret { get; } = "MY SECRET KEY";
        public string DynamicSecret { get { return dynamicSecret; } }

        private static SymmetricAlgorithm cypher;
        private string dynamicSecret = string.Empty;

        public Cypher(string pPassword, string pSecret)
        {
            Password = pPassword;
            Secret = pSecret;
        }

        public void Encrypt(string pContent, out string pEncryptedString, string pDynamicSecret)
        {
            pEncryptedString = string.Empty;
            dynamicSecret = pDynamicSecret;
        }

        /// <summary>
        /// Returns an encrypted stream from a decrypted object
        /// </summary>
        /// <param name="pObject">The decrypted object to encrypt</param>
        /// <param name="pEncryptedObjectStream">(Out) The encrypted stream from the object</param>
        /// <param name="pDynamicSecret">The dynamic secret string</param>
        public void Encrypt(object pObject, out Stream pEncryptedObjectStream, string pDynamicSecret)
        {
            pEncryptedObjectStream = null;
            dynamicSecret = pDynamicSecret;

            Init();
            var encryptor = cypher.CreateEncryptor();

            MemoryStream objectStream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(objectStream, pObject);

            objectStream.Position = 0;
            var encryptStream = new CryptoStream(pEncryptedObjectStream, encryptor, CryptoStreamMode.Write);
            objectStream.CopyTo(encryptStream);
            encryptStream.FlushFinalBlock();
        }

        public void Decrypt(string pContent, out string pDecryptedString, string pDynamicSecret)
        {
            pDecryptedString = string.Empty;
            dynamicSecret = pDynamicSecret;
        }

        /// <summary>
        /// Returns an object from en encrypted stream
        /// </summary>
        /// <param name="pObjectStream">The encrypted object stream</param>
        /// <param name="pDecryptedObject">(Out) The decrypted object</param>
        /// <param name="pDynamicSecret">The dynamic secret string</param>
        public void Decrypt(Stream pObjectStream, out object pDecryptedObject, string pDynamicSecret)
        {
            pDecryptedObject = null;
            dynamicSecret = pDynamicSecret;

            // Decrypt stream
            Init();
            var encryptor = cypher.CreateEncryptor();
            pObjectStream.Position = 0;
            var encryptStream = new CryptoStream(pObjectStream, encryptor, CryptoStreamMode.Read);
            encryptStream.CopyTo(pObjectStream);
            pObjectStream.Position = 0;

            // Convert stream to object
            IFormatter formatter = new BinaryFormatter();
            pObjectStream.Seek(0, SeekOrigin.Begin);
            pDecryptedObject = formatter.Deserialize(pObjectStream);
        }

        private void Init()
        {
            cypher = new RijndaelManaged();
            var key = new Rfc2898DeriveBytes(Password, Encoding.ASCII.GetBytes(Secret + dynamicSecret));

            cypher.Key = key.GetBytes(cypher.KeySize / 8);
            cypher.IV = key.GetBytes(cypher.BlockSize / 8);
            cypher.Padding = PaddingMode.PKCS7;
        }
    }
}
