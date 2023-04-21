using System;

namespace HA_Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(Console.ReadLine() != "exit")
            {
                Console.WriteLine("Вы хотите продолжить если да введите любой текст кроме 'exit'");
            }
            Environment.Exit(0);
        }
    }
}
