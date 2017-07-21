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

        //WORKING WITH STREAMS
        //two byte arrays added to MemoryStream, than read to string
        WorkingWithStreams.AddTwoByteArraysToMemoryStreamObject();
        WorkingWithStreams.AddTwoByteArraysToMemoryStreamObject1();



        //WORKING WITH STREAM ENCRYPTION AND DECRYPTION 
        //Some string for demo2 v
        string toEncrypt = "Hello everybody";
        byte[] streamBytes = Encoding.UTF32.GetBytes(toEncrypt);
        MemoryStream ms = new MemoryStream(streamBytes);
        //Some string for demo2 ^

        var cryptedStream =  Encryption.EncryptStream(ms);
        //Is my stream encrypted?
        string isCryptedStreamAfterEncryption = Demo3.IsCryptedStream(cryptedStream);
        Console.WriteLine($"After Encryption:{isCryptedStreamAfterEncryption}");

        //Trying to decrypt the stream
        var decryptStream = Encryption.DecryptStream(cryptedStream);
        string isCryptedStreamAfterDecryption = Demo3.IsCryptedStream(decryptStream);
        Console.WriteLine($"After Decryption: {isCryptedStreamAfterDecryption}");
        Console.ReadLine();

       


        }
    }
}
