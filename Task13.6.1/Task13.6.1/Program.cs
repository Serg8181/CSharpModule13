using System;
using System.Diagnostics;

namespace Task13._6._1
{

    class Program
    {

        static void Main()
        {
            string path = @"Text1.txt";
            
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }
               
            double count1 = 0.00000;    
            string str;
            List<string> list = new List<string>(); 
            using (StreamReader reader = new StreamReader(path))
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while ((str = reader.ReadLine()) != null)
                {
                   
                    list.Add(str);
                   
                   
                }
                sw.Stop();
                count1 = sw.Elapsed.TotalMilliseconds;
                
            }

            Console.WriteLine($"Производительность вставки в List<T>: {count1} мс ");
            Console.WriteLine();

            double count2 = 0.00000;
            string str2;
            LinkedList<string> list2 = new LinkedList<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                while ((str2 = reader.ReadLine()) != null)
                {
                   
                    list2.AddLast(str2);
                   
                }
                sw2.Stop();
                count2 = sw2.Elapsed.TotalMilliseconds;
               
            }
           
            Console.WriteLine($"Производительность вставки в LinkedList<T>: {count2} мс ");
            Console.ReadKey();

        }
       
    }

}
