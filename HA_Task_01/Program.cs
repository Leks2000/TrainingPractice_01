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
            bool resultGold;
            int rate = 3;
            Console.WriteLine("Введите количество вашего золота ");
            int inventory = int.Parse(Console.ReadLine());
            Console.WriteLine("Курс валюты: 3 золота за 1 кристал\n\n" + "Сколько вы хотите купить кристаллов? ");
            int buyCount = int.Parse(Console.ReadLine());
            resultGold = inventory >= buyCount * rate;
            buyCount *= Convert.ToInt32(resultGold);
            inventory -= buyCount * rate;
            Console.WriteLine($"Количество кристалов: {buyCount} остаток золота: {inventory}");
            Console.ReadKey();
        }
    }
}
