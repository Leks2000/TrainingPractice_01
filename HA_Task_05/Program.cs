using System;
using System.IO;


namespace HA_TASK_05
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool start = true, antwort = false;
        found:
            int y = 0, x = 0, i = 0, j = 0, n = 0, count = 0, playerY = -1, playerX = -1, health = 10, maxHealth = 10, countHP = 0;
            char wall = '█', pus = ' ', player = '☺', end = '*';
            string[] str = File.ReadAllLines("F:/repos/Коноплёв/Всё/Labirint/Res/mazeantw.txt");
            int[,] maze = new int[str.Length, str[0].Split(' ').Length];
            for (i = 0; i < str.Length; i++)
            {
                string[] str2 = str[i].Split(' ');
                for (j = 0; j < str2.Length; j++)
                    maze[i, j] = Int32.Parse(str2[j]);
                n = str2.Length;
            }
            Console.SetCursorPosition(0, 0);
            for (i = 0; i < maze.GetLength(0); i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(x++, y);
                    count++;
                    Console.ForegroundColor = ConsoleColor.White;
                    if (maze[i, j] == 0)
                    {
                        Console.Write(pus);
                    }
                    else if (maze[i, j] == 1)
                    {
                        Console.Write(wall);
                    }
                    else if (maze[i, j] == 2)
                    {
                        Console.Write(player);
                        playerX = j;
                        playerY = i;
                    }
                    else if (maze[i, j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(end);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (antwort == true)
                    {
                        if (maze[i, j] == 4)
                        {
                            Console.Write("*");
                        }
                    }
                    if (count == 20)
                    {
                        Console.SetCursorPosition(x = 0, y++);
                        count = 0;
                    }
                }
            }
            Console.WriteLine("\nНажмите на R для подсказки");
            DrawBar(health, maxHealth);
            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            Console.SetCursorPosition(x = playerX, y = playerY);
            Console.Write("☺");

            while (start)
            {
                key = Console.ReadKey(true);

                if (key.KeyChar == 119 || key.KeyChar == 87)
                {
                    if (maze[playerY - 1, playerX] != 1)
                    {
                        Console.SetCursorPosition(x, y--); Console.Write(" ");
                        Console.SetCursorPosition(x, y); Console.Write("☺");
                        playerY--;
                    }
                    countHP++;
                }
                else if (key.KeyChar == 115 || key.KeyChar == 83)
                {
                    if (maze[playerY + 1, playerX] != 1)
                    {
                        Console.SetCursorPosition(x, y++); Console.Write(" ");
                        Console.SetCursorPosition(x, y); Console.Write("☺");
                        playerY++;
                    }
                    countHP++;
                }
                else if (key.KeyChar == 97 || key.KeyChar == 65)
                {
                    if (maze[playerY, playerX - 1] != 1)
                    {
                        Console.SetCursorPosition(x--, y); Console.Write(" ");
                        Console.SetCursorPosition(x, y); Console.Write("☺");
                        playerX--;
                    }
                    countHP++;
                }
                else if (key.KeyChar == 100 || key.KeyChar == 68)
                {
                    if (maze[playerY, playerX + 1] != 1)
                    {
                        Console.SetCursorPosition(x, y); Console.Write(" ");
                        Console.SetCursorPosition(++x, y); Console.Write("☺");
                        playerX++;
                    }
                    countHP++;
                }
                else if (key.KeyChar == 114 || key.KeyChar == 82)
                {
                    Console.Clear();
                    antwort = true;
                    goto found;
                }
                if (countHP == 10)
                {
                    health--;
                    countHP = 0;
                    Console.SetCursorPosition(0, 21);
                    DrawBar(health, maxHealth);
                    if(health == 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Вы не успели пройти лабиринт и умерли от голода");
                        Console.ForegroundColor = ConsoleColor.White;
                        Environment.Exit(0);
                    }
                }
                if (playerY == 18 & playerX == 18)
                {
                    start = false;

                }

            }
            Console.Clear();
            Console.SetCursorPosition(x = 50, y = 15);
            if (antwort == true)
            {
                Console.WriteLine("Вы прошли лабиринт с подсказкой");
            }
            else
            {
                Console.WriteLine("Вы прошли лабиринт без подсказки");
            }
            Console.SetCursorPosition(x -= 50, y = 30);
        }
        static void DrawBar(int value, int maxValue)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += " ";
            }
            Console.Write('[');
            Console.BackgroundColor = ConsoleColor.Green;
            if (value <= 6 && value >3) Console.BackgroundColor = ConsoleColor.Yellow;
                else if(value <=3)Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += " ";
            }
            Console.Write(bar + ']');
        }
    }
}
