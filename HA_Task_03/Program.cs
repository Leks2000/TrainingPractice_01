using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA_Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "123";
            Console.WriteLine("Введите пароль: ");
            for (int count = 0; count < 3; ++count)
            {
                string userPassword = Console.ReadLine();
                if (userPassword == password)
                {
                    Console.WriteLine("Ладно текст.");
                    Environment.Exit(0);
                }
                else if (count < 2)
                {
                    Console.WriteLine("Пароль не верный\nВведите пароль еще раз: ");
                }
            }
            Environment.Exit(0);
            Console.ReadKey();
        }
    }
}
