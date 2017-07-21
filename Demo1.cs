using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamWithExamples
{
    class Demo1
    {
        public static void AddTwoByteArraysToMemoryStreamObject()
        {
            //two byte arrays added to MemoryStream, than read to string
            byte[] totalBytes = new byte[10];
            byte[] toBytes1 = Encoding.ASCII.GetBytes("Hello");

            byte[] toBytes2 = Encoding.ASCII.GetBytes("World");
            MemoryStream ms1 = new MemoryStream();
            ms1.Write(toBytes1, 0, 5);
            ms1.Write(toBytes2, 0, 5);
            var a=ms1.ToArray();

            MemoryStream ms = new MemoryStream(totalBytes);
           
                long asd = ms.Length;

            ms.Write(toBytes1, 0, 5);
            ms.Write(toBytes2, 0, 5);
            ms.Position = 0;
         
            var str = System.Text.Encoding.Default.GetString(ms.ToArray());
            //I don't even need a StreamReader to get my string value from stream.

        }
        public static void AddTwoByteArraysToMemoryStreamObject1()
        {
            //two byte arrays added to MemoryStream, than read to string
            byte[] totalBytes = new byte[10];
            byte[] toBytes1 = Encoding.ASCII.GetBytes("Hello");

            byte[] toBytes2 = Encoding.ASCII.GetBytes("World");
            MemoryStream ms = new MemoryStream(totalBytes);
            long asd = ms.Length;

            ms.Write(toBytes1, 0, 5);
            ms.Write(toBytes2, 0, 5);
            ms.Position = 0;

            StreamReader sr = new StreamReader(ms, Encoding.ASCII);
        
            string cont = sr.ReadToEnd();

            Console.WriteLine(cont);
            Console.ReadLine();

          
        }

    }
}
