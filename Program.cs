﻿using System;
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
            byte[] streamBytes = Encoding.ASCII.GetBytes("Hello");
            MemoryStream ms = new MemoryStream();
            ms.Write(streamBytes,0,streamBytes.Length);
            //Some string for demo2 ^

           var cryptedStream =  Demo2.EncryptStream(ms);

            

        }
    }
}