using System;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace Task13._6._2
{
    class Program
    {
        static void Main()
        {
            string path = @"Text1.txt";
            

            //проверяем наличие файла
            if(!File.Exists(path))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }
            
            string noPunctuationText;
            using (StreamReader sr = new StreamReader(path))
            {        
                //считываем из файла текст, отбрасываем знаки пунктуации
                noPunctuationText = new string(sr.ReadToEnd().Where(c => !char.IsPunctuation(c)).ToArray());
                
            }
            //разбиваем строку с текстом на массив слов
            char[] sep = {' ', '\r','\n' };
            var words = noPunctuationText.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            //формируем массив не повторяющихся слов 
            var keys = new HashSet<string>(words);

            //формируем словарь с ключами и нулевыми значениями
            Dictionary<string,int> commonWords = new Dictionary<string,int>();
            foreach (string word in keys) 
            {
                commonWords.Add(word,0);
            }

            foreach (string word in words)
            {
                //проходим по массиву слов и при совпадении с ключем словаря, увеличиваем  значение из словаря на единицу
               if (commonWords.ContainsKey(word)) commonWords[word]++;               
            }
            //сортируем словарь по значению
            var result = commonWords.OrderBy(x => x.Value).ToList();
            result.Reverse();
            //выводим в консоль 10 слов 
            Console.WriteLine("Эти 10 слов чаще всего встречаются в тексте: ");
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine( result[i].Key + "    " + result[i].Value );
            }
            
         Console.ReadKey();
        }
    }
}
