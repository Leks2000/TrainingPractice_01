using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HA_Task_04
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "WellWell";
            Console.WriteLine("Игра - Победи БОССА\n\nУсловия:\nМаксимальный уровень жизни у врагов - 939\n" +
            "Случайным образом выбирается игрок, делающий первый ход\n" +
            "Величина урона, наносимого БОССОМ, для каждого хода случайна\nИгрок может пользоваться следующими действиями:\n");
            rulesAttack();
            string[] enemy = { "Гоблин","Минотавр","Скелет"};
            Random random = new Random();
            int newEnemy = random.Next(enemy.Length), health = 3, timeToAttack = 0;
            float enemyHP = (newEnemy == 0 ? 563 : newEnemy == 1 ? 939: 257), playerHP = 250, countWalk = 1;
            string resultOfEnemy = enemy[newEnemy], centerText = "";
            Console.WriteLine($"Вы встретили врага под названием {resultOfEnemy}");
            Console.ReadKey();
            Console.Clear();
            while (playerHP > 0 && enemyHP > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Раунд {countWalk}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Здоровье {resultOfEnemy}а {enemyHP}");
                    Console.WriteLine($"Ваше здоровье {playerHP} \n");
                    Console.ForegroundColor = ConsoleColor.White;
                    rulesAttack();
                    bool attack = random.Next(2) == 1;
                    float enemyAttack = (newEnemy == 0 ? 27 : newEnemy == 1 ? 67 : 34) + countWalk;
                    float playerAttack = 45 + countWalk * 2;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Ваш урон: {playerAttack}\nУрон {resultOfEnemy}а: {enemyAttack}\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    PlayerAttack(ref health, ref playerHP, ref playerAttack, ref enemyAttack, ref resultOfEnemy,ref timeToAttack,ref resultOfEnemy,ref attack);
                    enemyHP -= playerAttack;
                    playerHP -= enemyAttack;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Здоровье {resultOfEnemy}а {enemyHP}");
                    Console.WriteLine($"Ваше здоровье {playerHP} \n");
                    _ = timeToAttack != 0 ? timeToAttack-- : timeToAttack;
                    countWalk++;
                    Console.ReadKey();
                    Console.Clear();
                }
            if (playerHP < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                centerText = ($"Вы умерли от рук {resultOfEnemy}а\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                centerText = ($"Вы победили {resultOfEnemy}а и получили {random.Next(1,55)} золота\n");
            }
            int centerX = (Console.WindowWidth / 2) - (centerText.Length / 2);
            int centerY = (Console.WindowHeight / 2) - 1;
            Console.SetCursorPosition(centerX, centerY);
            Console.Write(centerText);
            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PlayerAttack(ref int health, ref float playerHP, ref float playerAttack, ref float enemyAttack, ref string enemy, ref int timeToAttack, ref string resultOfEnemy,ref bool attack)
        {
            Console.WriteLine("Выберите действие от 1 до 5: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Random random = new Random();
            int playerChoise = int.Parse(Console.ReadLine()), chance = random.Next(1, 10);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            EnemyAttack(ref enemyAttack, ref playerAttack, ref resultOfEnemy,ref attack);
            switch (playerChoise)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Вы атакуете {enemy}а и наносите {playerAttack} урона\n");

                    break;
                case 2:
                    if (attack == true)
                    {
                        playerAttack = 0;
                        enemyAttack = 0;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    enemyAttack *= 0.1f; 
                    Console.WriteLine($"Вы решили поставить щит от атаки {enemy}а и прошло только {enemyAttack} урона\n");
                    break;
                case 3:
                    if(timeToAttack == 0)
                    {
                        _ = (chance <= 2 ? playerAttack = 85 : playerAttack = 15);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Вы решили провести ультимативную атаку и нанесли {enemy}у {playerAttack} урона\n");
                        timeToAttack = 3;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Для ультимативной атаки необходимо продержатся еще {timeToAttack} раундов\n");
                    }
                    break;
                case 4:
                    playerAttack = 0;
                    if (health != 0)
                    {
                        health--;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Вы решили восстановить себе здоровье\nВы восстановиле себе {playerHP *0.3f} здоровья\nУ вас осталось {health} зелья здоровья\n");
                        playerHP += playerHP * 0.3f;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"У вас законичилсь зелья XC\n");
                    }
                    break;
                case 5:
                    chance = random.Next(1, 10);
                    _ = (chance <= 7 ? playerAttack *= 1.35f : playerAttack *= 2.5f);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Вы спели болладу и подняли себе боевой дух\n");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Вы решили не ждать решения {enemy}а и атакавали его сразу нанеся {playerAttack} урона\n");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void EnemyAttack(ref float enemyAttack, ref float playerAttack, ref string enemy, ref bool attack)
        {
            switch (attack)
            {
                case false:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Вас атакует {enemy} и наносит {enemyAttack} урона\n");
                    break;
                case true:
                    playerAttack *= 0.1f;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{enemy} в шоке и решает защититься от вашей зловещей атаки\n");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void rulesAttack()
        {
            Console.WriteLine(
                "1 - Обычная атака мечем (наносит 45 урона при условии если враг не поставил щит)\n" +
                "2 - Поставить щит (Блокирует 90% урона)\n" +
                "3 - Провести ультимативную атаку (Усиленная атака наносящая 85 урона с 30% шансом, урон проходит сквозь щит)\n" +
                "4 - Выпить зелье восстановления (восстанавливает 30% от базового здоровья)\n" +
                "5 - Спеть балладу (Вдохновляет игрока и с вероятностью 70% увеличивает урон на 35% и с 30% шансом увеличить урон на 150% одновременно атакуя шанс)\n");
        }
    }
}
