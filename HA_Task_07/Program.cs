using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA_Task_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов массива");
            int[] fillCountMassive = new int[int.Parse(Console.ReadLine())];
            int i = 0;
            while(i < fillCountMassive.Length)
            {
                fillCountMassive[i] = Convert.ToInt32(Console.ReadLine());
                i++;
            }
            Console.Clear();
            Console.WriteLine("Исходный массив чисел:");
            OutputArray(fillCountMassive);

            Console.WriteLine("\nПеремешанный массив чисел:");
            Shuffle(fillCountMassive);
            Console.WriteLine();
            Console.ReadKey();
        }


        static void OutputArray(int[] arrayNumberOutput)
        {
            for (int i = 0; i < arrayNumberOutput.Length; i++)
            {
                Console.Write(arrayNumberOutput[i] + " ");
            }
        }

        static void Shuffle(int[] arrayNumberShuffle)
        {
            Random random = new Random();
            int randomIndex, shuffledElement;

            for (int i = arrayNumberShuffle.Length - 1; i >= 0; i--)
            {
                randomIndex = random.Next(i);
                shuffledElement = arrayNumberShuffle[randomIndex];
                arrayNumberShuffle[randomIndex] = arrayNumberShuffle[i];
                arrayNumberShuffle[i] = shuffledElement;

                Console.Write(shuffledElement + " ");
            }
        }
    }
}
