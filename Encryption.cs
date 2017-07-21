using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StreamWithExamples
{
    public class Encryption
    {
        public static Stream EncryptStream(Stream inputStream)
        {
            string key = "ThisIsMySuperSecureKey";
            byte[] keyBytes = Encoding.UTF32.GetBytes(key);

            Rfc2898DeriveBytes derviedKey = new Rfc2898DeriveBytes(key, keyBytes);

            RijndaelManaged rijndaelCSP = new RijndaelManaged();
            rijndaelCSP.Key = derviedKey.GetBytes(rijndaelCSP.KeySize / 8);
            rijndaelCSP.IV = derviedKey.GetBytes(rijndaelCSP.BlockSize / 8);

            var encryptor = rijndaelCSP.CreateEncryptor();

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);

            //inputStream.Position = 0;
            byte[] toEncrypt = StreamToByteArray(inputStream);

            cs.Write(toEncrypt, 0, toEncrypt.Length);
            cs.FlushFinalBlock();

            MemoryStream output = new MemoryStream(ms.ToArray());
            ms.Close();
            return (Stream)output;

        }

        public static byte[] StreamToByteArray(Stream inputStream)
        {

            var ms = new MemoryStream();
            inputStream.Position = 0;
            inputStream.CopyTo(ms);
            return ms.ToArray();
        }
        public static Stream DecryptStream(Stream inputStream)
        {
            string key = "ThisIsMySuperSecureKey";
            byte[] keyBytes = Encoding.UTF32.GetBytes(key);

            Rfc2898DeriveBytes derviedKey = new Rfc2898DeriveBytes(key, keyBytes);

            RijndaelManaged rijndaelCSP = new RijndaelManaged();
            rijndaelCSP.Key = derviedKey.GetBytes(rijndaelCSP.KeySize / 8);
            rijndaelCSP.IV = derviedKey.GetBytes(rijndaelCSP.BlockSize / 8);

            var decryptor = rijndaelCSP.CreateDecryptor();
            //inputStream.Position = 0;
            byte[] arrayOfEncrypedStream = StreamToByteArray(inputStream);

            MemoryStream ms = new MemoryStream(arrayOfEncrypedStream);
            CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);


            cs.Read(arrayOfEncrypedStream, 0, arrayOfEncrypedStream.Length);
            MemoryStream output = new MemoryStream(ms.ToArray());

            ms.Close();
            return output;

        }

        //Encrypt a string into a string using a password
        public static string Encrypt(string clearText)
        {
            string password = "ThisIsMySuperSecureKey";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }

        public static byte[] Encrypt(byte[] clearBytes, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key=Key;
            alg.IV=IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearBytes, 0, clearBytes.Length);
            cs.Close();
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }


        public static string Decrypt(string cipherText)
        {
            string passwod = "ThisIsMySuperSecureKey";
            return "";
        }
    }
}
