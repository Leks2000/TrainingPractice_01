using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA_Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool resultGold = false;
            int rate = 3;
            while (resultGold == false)
            {
            Console.Clear();
            gold:
            Console.WriteLine("Введите количество вашего золота ");
            int inventory = int.Parse(Console.ReadLine());
            if (inventory < 0)
            {
                Console.WriteLine("Количество кристаллов не может быть равно 0, введите число снова");
                Console.ReadLine();
                Console.Clear();
                goto gold;
            }
            cristalls:
            Console.WriteLine("Курс валюты: 3 золота за 1 кристал\n\n" + "Сколько вы хотите купить кристаллов? ");
            int buyCount = int.Parse(Console.ReadLine());
            if(buyCount < 0)
            {
                Console.WriteLine("Количество кристаллов не может быть равно 0, введите число снова");
                Console.ReadLine();
                Console.Clear();
                goto cristalls;
            }
            resultGold = inventory >= buyCount * rate;
            buyCount *= Convert.ToInt32(resultGold);
            inventory -= buyCount * rate;
            Console.WriteLine($"Количество кристалов: {buyCount} остаток золота: {inventory}");
                if (resultGold == false)
                {
                    Console.WriteLine("Недостаточно средств для конвертации валюты");
                }
            Console.ReadKey();
            }
        }
    }
}
