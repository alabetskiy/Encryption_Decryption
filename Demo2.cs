using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StreamWithExamples
{
    public class Demo2
    {

        public static Stream EncryptStream(Stream inputStream)
        {
            string key = "ThisIsMySuperSecureKey";
            byte[] keyBytes = Encoding.Unicode.GetBytes(key);

            Rfc2898DeriveBytes derviedKey = new Rfc2898DeriveBytes(key,keyBytes);

            RijndaelManaged rijndaelCSP = new RijndaelManaged();
            rijndaelCSP.Key = derviedKey.GetBytes(rijndaelCSP.KeySize / 8);
            rijndaelCSP.IV = derviedKey.GetBytes(rijndaelCSP.BlockSize / 8);

            var encryptor = rijndaelCSP.CreateEncryptor();

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);


            byte[] toEncrypt = StreamToByteArray(inputStream);

           cs.Write(toEncrypt, 0, 5);
           cs.FlushFinalBlock();

            MemoryStream output = new MemoryStream(ms.ToArray());
            ms.Close();
            return output;
         
        }

        public static byte[] StreamToByteArray(Stream inputStream)
        {

            var ms = new MemoryStream();
            inputStream.Position = 0;
            inputStream.CopyTo(ms);
            return ms.ToArray();
        }
        public static Stream DecryptStream (Stream inputStream)
        {
            string key = "ThisIsMySuperSecureKey";
            byte[] keyBytes = Encoding.Unicode.GetBytes(key);

            Rfc2898DeriveBytes derviedKey = new Rfc2898DeriveBytes(key, keyBytes);

            RijndaelManaged rijndaelCSP = new RijndaelManaged();
            rijndaelCSP.Key = derviedKey.GetBytes(rijndaelCSP.KeySize / 8);
            rijndaelCSP.IV = derviedKey.GetBytes(rijndaelCSP.BlockSize / 8);

            var encryptor = rijndaelCSP.CreateDecryptor();

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encryptor,CryptoStreamMode.Write);

            byte[] arrayOfEncrypedStream = StreamToByteArray(inputStream);

            cs.Write(arrayOfEncrypedStream, 0, arrayOfEncrypedStream.Length);
            MemoryStream output = new MemoryStream(ms.ToArray());

            return output;

        }


    }
}
