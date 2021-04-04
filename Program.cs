using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Laba04._04
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> abc = new Dictionary<string, string>();//создаем словарь ошибочных и правильных слов
            abc.Add("ghbdtn", "привет");
            abc.Add("rfr ltkf&", "как дела?");
            abc.Add("првиет", "привет");

            string path = Console.ReadLine();//вводим путь в директорию где нужно выполнить работу
            string str = string.Empty;//очищаем строку в которой будут проводиться действия
            string target = "+380 12";//значение на которое будем менять номера

            var dirs = Directory.GetFiles(path, "*", SearchOption.AllDirectories);//создаем переменную в которой хранятся пути к файлам в директории
            foreach (var files in dirs)//для каждого файла в директории выполняем следующее:
            {
                Console.WriteLine(files);//выводим файлы 
                using (StreamReader reader = File.OpenText(files))//открываем текст
                {
                    str = reader.ReadToEnd();//читаем до конца
                }
                foreach (KeyValuePair<string, string> keyValue in abc)//для каждого ключазначения в словаре абс выполняем:
                {
                    str = str.Replace(keyValue.Key, keyValue.Value);//заменяем найденные "неправильные" ключи "правильным" значениями
                    Regex regex = new Regex(@"\w*.012.\w*");//создаем регулярное выражение которое ищет все что содержит 012 вместе с рядом стоящими занчениями(у нас это "()")
                    str = regex.Replace(str, target);//выполняем замену в снашем тексте на +380 12
                }

                using (StreamWriter file = new StreamWriter(files))//записываем в файл
                    file.Write(str);
            }
        }
    }
}
