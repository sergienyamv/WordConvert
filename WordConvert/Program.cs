/*
 * В каждом слове текста k-ю букву заменить заданным символом.
 * Если k больше длины слова, корректировку не выполнять.
 * */

using System;

namespace WordConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text:");
            var str = Console.ReadLine();

            Console.WriteLine("Enter position:");
            var buf = Console.ReadLine();
            int k;
            while (!int.TryParse(buf, out k) || k < 1)
            {
                Console.WriteLine("Please, enter correct position:");
                buf = Console.ReadLine();
            }

            Console.WriteLine("Enter symbol:");
            var ch = Console.ReadLine().ToCharArray();
            while (ch.Length != 1)
            {
                Console.WriteLine("Please, enter correct symbol:");
                ch = Console.ReadLine().ToCharArray();
            }

            var sentences = new Text(str).Parse();          //делим текст на предложения
            for (int i = 0; i < sentences.Count; i++)
            {
                var words = sentences[i].Parse();           //делим предложение на слова
                for (int j = 0; j < words.Count; j++)
                {
                    words[j].Convert(k, ch[0]);             //заменяем букву
                    Console.WriteLine(words[j]);
                }
            }



            
            /*Console.WriteLine("Result text:");
            Console.WriteLine(Text.ConvertSymbols(str, k, ch[0]));*/
            Console.ReadKey();
        }
    }
}
