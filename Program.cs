using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamWithExamples
{
    class Program
    {
        static void Main(string[] args)
        {


            //two byte arrays added to MemoryStream, than read to string
            Demo1.AddTwoByteArraysToMemoryStreamObject();


            //Some string for demo2 v
            byte[] streamBytes = Encoding.UTF32.GetBytes("Hello everybody!");
            MemoryStream ms = new MemoryStream(streamBytes);
            //ms.Write(streamBytes, 0, streamBytes.Length);
           
            //Some string for demo2 ^

           var cryptedStream =  Demo2.EncryptStream(ms);

            //Is my stream  really encrypted?
           string isCryptedStreamAfterEncryption = Demo3.IsCryptedStream(cryptedStream);
            Console.WriteLine($"After Encryption:{isCryptedStreamAfterEncryption}");


            var decryptStream = Demo2.DecryptStream(cryptedStream);
            string isCryptedStreamAfterDecryption = Demo3.IsCryptedStream(decryptStream);
            Console.WriteLine($"After Decryption: {isCryptedStreamAfterDecryption}");
            Console.ReadLine();
        }
    }
}
