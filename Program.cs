using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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


            string path = Console.ReadLine();
            string str = string.Empty;
            /*using (StreamReader reader = File.OpenText(@"D:\test.txt"))
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
            }*/
            
            var keywords = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (var files in keywords)
            {
                Console.WriteLine(files);
                using (StreamReader reader = File.OpenText(files))
                {
                    str = reader.ReadToEnd();
                }
                foreach (KeyValuePair<string, string> keyValue in abc)
                {
                    str = str.Replace(keyValue.Key, keyValue.Value);
                    Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                }

                using (StreamWriter file = new StreamWriter(files))
                {
                    file.Write(str);
                }

            }
        }
    }
    /*public class search
    {
        public string directory;
        public string word;
        public search(string keyword, string path)
        {
            this.directory = path;
            this.word = keyword;

        }

        public void result()
        {
            var keywords = from search in Directory.GetFiles(directory, "*", SearchOption.AllDirectories) where File.ReadAllLines(search).Contains(word) select search;

            foreach (var files in keywords)
            {
                Console.WriteLine(files);

            }
        }
    }*/
}
