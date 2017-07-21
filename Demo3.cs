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
            string result = "";
            byte[] convStremToBytes = Encryption.StreamToByteArray(cryptedStream);
            return result = Encoding.UTF32.GetString(convStremToBytes);
        }
    }
}
