using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Laba04._04
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> abc = new Dictionary<string, string>();
            abc.Add("ghbdtn", "привет");
            abc.Add("rfr ltkf&", "как дела?");
            abc.Add("првиет", "привет");

            string str = string.Empty;
            using (StreamReader reader = File.OpenText(@"D:\test.txt"))
            {
                str = reader.ReadToEnd();
            }
            foreach (KeyValuePair<string, string> keyValue in abc)
            {
                str = str.Replace(keyValue.Key, keyValue.Value);
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }

            using (StreamWriter file = new StreamWriter(@"D:\test.txt"))
            {
                file.Write(str);
            }
        }
    }
}
