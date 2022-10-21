using System;

namespace Fighting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Объявление переменных
            int maxHealth = 100;
            int maxEnergy = 100;

            int playerHealth = maxHealth;
            int playerEnergy = maxEnergy;

            int enemyHealth = maxHealth;
            int enemyEnergy = maxEnergy;

            int action = -1;

            Random random = new Random();

            while (true) 
            {
                if (playerHealth < 0) playerHealth = 0;
                if (enemyHealth < 0) enemyHealth = 0;
                Console.Clear();
                // Отображение статов и скиллов
                Console.WriteLine(@"    Жизни: {0}                  Жизни вируса: {1}", playerHealth, enemyHealth);
                Console.WriteLine(@"    Энергия: {0}                Энергия вируса: {1}", playerEnergy, enemyEnergy);
                Console.WriteLine();

                Console.WriteLine("1. Почистить папку Temp (20 урона, -10 энергии)");
                Console.WriteLine("2. Использовать Касперского (30 урона, -40 энергии)");
                Console.WriteLine("3. Выпить кофе (+20 энергии)");
                Console.WriteLine("4. Заказать доставку пиццы (+ 30 жизни, -20 энергии)");
                Console.WriteLine();

                //Определение победы или поражения
                if (playerHealth <= 0)
                {
                    Console.WriteLine("Вирус победил!");
                    break;
                }

                while (true)
                {
                    //Получение действия от игрока
                    Console.Write("Команда: ");
                    action = int.Parse(Console.ReadLine());

                    //Описание работы скиллов игрока
                    if (action == 1)
                    {
                        if (playerEnergy >= 10)
                        {
                            enemyHealth -= 20;
                            playerEnergy -= 10;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Не достаточно энергии. Выберите другую команду");
                            Console.ReadKey();
                        }
                    }
                    else if (action == 2)
                    {
                        if (playerEnergy >= 40)
                        {
                            enemyHealth -= 30;
                            playerEnergy -= 40;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Не достаточно энергии. Выберите другую команду");
                            Console.ReadKey();
                        }
                    }
                    else if (action == 3)
                    {
                        playerEnergy += 20;
                        if (playerEnergy > maxEnergy) playerEnergy = maxEnergy;
                        break;
                    }
                    else if (action == 4)
                    {
                        if (playerEnergy >= 20)
                        {
                            playerHealth += 30;
                            playerEnergy -= 20;
                            if (playerHealth > maxHealth) playerHealth = maxHealth;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Не достаточно энергии. Выберите другую команду");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такой команды нет. Выберите другую команду");
                        Console.ReadKey();
                    }
                }

                //Определение победы или поражения после хода игрока
                if (enemyHealth <= 0)
                {
                    Console.WriteLine("Ты победил!");
                    break;
                }

                //Получение действия от противника        
                if (enemyHealth <= 20)
                {
                    action = 3;
                } else action = random.Next(1, 3);


                //Описание работы скиллов противника
                if (action == 1)
                {
                    if (enemyEnergy >= 12)
                    {
                        playerHealth -= 15;
                        enemyEnergy -= 12;
                        Console.WriteLine("Вирус нанёс 15 урона");
                        Console.ReadKey();
                    }
                    else
                    {
                        enemyEnergy += 20;
                        if (enemyEnergy > maxEnergy) enemyEnergy = maxEnergy;
                        Console.WriteLine("Вирус восстановил 20 энергии");
                        Console.ReadKey();
                    }
                }
                else if (action == 2)
                {
                    if (enemyEnergy >= 20)
                    {
                        playerHealth -= 25;
                        enemyEnergy -= 20;
                        Console.WriteLine("Вирус нанёс 25 урона");
                        Console.ReadKey();
                    }
                    else
                    {
                        enemyEnergy += 20;
                        if (enemyEnergy > maxEnergy) enemyEnergy = maxEnergy;
                        Console.WriteLine("Вирус восстановил 20 энергии");
                        Console.ReadKey();
                    }
                }
                else if (action == 3)
                {
                    enemyHealth += 30;
                    if (enemyHealth > maxHealth) enemyHealth = maxHealth;
                    Console.WriteLine("Вирус восстановил 30 хп");
                    Console.ReadKey();
                } 
            }
            Console.ReadKey();
        }        
    }
}
