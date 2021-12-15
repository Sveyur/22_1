using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22
{
    class Program
    {
        static public int x;
        static int[] array;
        static int Sum = 0;
        static int max = 0;
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива:  ");
            int x = Convert.ToInt32(Console.ReadLine());
            array = new int[x];
            Random random = new Random();
            for (int a = 0; a < x; a++)
            {
                array[a] = random.Next(0, 50);
                Console.Write(array[a] + " ");
            }
            Console.WriteLine("\n");
            Action action1 = new Action(Summa);
            Task task1 = new Task(action1);
            Action<Task> action2 = new Action<Task>(Max);
            Task task2 = task1.ContinueWith(action2);
            task1.Start();
            task2.Wait();
            Console.WriteLine("Сумма чисел массива равна = " + Sum + "\n");
            Console.WriteLine("Максимальное число = " + max);

            Console.ReadKey();
        }
        static void Summa()
        {
            Sum = array.Sum();
        }
        static void Max(Task task)
        {
            max = array.Max();
        }


    }


}


