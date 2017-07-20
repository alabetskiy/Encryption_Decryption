using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamWithExamples
{
    class Demo3
    {
        internal static string IsCryptedStream(Stream cryptedStream)
        {
            string result = null;
            byte[] convStremToBytes = Demo2.StreamToByteArray(cryptedStream);
            return result = Encoding.ASCII.GetString(convStremToBytes);
        }
    }
}
