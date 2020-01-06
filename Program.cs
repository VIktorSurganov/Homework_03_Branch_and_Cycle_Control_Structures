using System;

namespace Homework_Theme_03
{
    class Program
    {
        static void Main(string[] args)
        {
                                    // переменная для выбора режима игры
            Console.WriteLine
                   ("Программа загадывает случайное число сообщая это число игрокам.\n" +
                    "Игроки ходят по очереди(игра сообщает о ходе текущего игрока).\n" +
                    "Игрок, ход которого указан вводит число из диапазона допустимых\n" +
                    "чисел. Введенное число вычитается из игрвого числа. Выигрывает \n" +
                    "тот игрок, после чьего хода игровое число обратилась в ноль.\n");
            
                Console.WriteLine("\t\tВыберите режим игры\n" +
                                  "\t\t(1)Стандартная игра\n" +
                                  "\t\t(2)Настраиваемые парамеры\n" +
                                  "\t\t(3)Игра с компьютером");
            int change;
            do
            {
                Console.Write("\t\t\t-> ");
                change = Convert.ToInt32(Console.ReadLine());
            }
            while (change >= 4);

            switch(change)                      //на выбор запускается один из трех вариантов
                                                //Game.Start() со стандартными параметрами,
                                                //Game.Start() с возможностью внести свои параметры или игра против компьтера
            {
                case 1:                       //Запуск стандартной игры с возможностью реванша
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("СТАНДАРТНАЯ ИГРА");
                    Console.ResetColor();
                    string ch;
                    do
                    {
                        Game.GameStart(15, 120, 5,10,29);
                        Console.Write("Хотите сыграть реванш? (y/n) -> ");
                        ch = Console.ReadLine();
                    }
                    while (ch != "n" && ch!="т" && ch != "N" && ch != "Т");                    
                    break;

                case 2:                        //Запуск настраиваемой игры с возможностью реванша
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("НАСТРАИВАЕМАЯ ИГРА");
                    Console.ResetColor();
                    string ch1;
                    do
                    {
                                                //Ввод данных
                        #region 
                        Console.Write("|||Введите минимальное игровое число -> ");
                        int gameNumberMin = Convert.ToInt32(Console.ReadLine());
                        Console.Write("/|\\Введите максимальное игровое число -> ");
                        int gameNumberMax = Convert.ToInt32(Console.ReadLine());

                        Console.Write("|||Введите минимальное доступное игрокам число -> ");
                        int rangMin = Convert.ToInt32(Console.ReadLine());
                        Console.Write("|||Введите максимальное доступное игрокам число -> ");
                        int rangMax = Convert.ToInt32(Console.ReadLine());                    

                        int[] rang = new int[rangMax - rangMin];
                        int count = 0;
                        for (int i = rangMin; i < rangMax - 1; ++i)
                        {
                            rang[count] = i; 
                            count++;
                            if (count == rangMax - rangMin - 1)
                            {
                                rang[count] = rangMax;
                                break;
                            }
                        }                        
                        Console.Write("Введите колличество попыток -> ");
                        int tryes = Convert.ToInt32(Console.ReadLine());
                        #endregion
                        Game.GameStart(gameNumberMin, gameNumberMax, tryes,rang);
                        Console.Write("Хотите сыграть реванш? (y/n) -> ");
                        ch1 = Console.ReadLine();
                    }
                    while (ch1 != "n" && ch1 != "т" && ch1 != "N" && ch1 != "Т");
                    break;

                case 3:                       //Запуск игры с компьютером
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("ИГРА С КОМПЬЮТЕРОМ");
                    Console.ResetColor();
                    string ch2;
                    do
                    {
                                                //Ввод данных
                        #region
                        Console.Write("|||Введите минимальное игровое число -> ");
                        int gamevsPCNumberMin = Convert.ToInt32(Console.ReadLine());
                        Console.Write("/|\\Введите максимальное игровое число -> ");
                        int gamevsPCNumberMax = Convert.ToInt32(Console.ReadLine());

                        Console.Write("|||Введите минимальное доступное игрокам число -> ");
                        int rangvsPCMin = Convert.ToInt32(Console.ReadLine());
                        Console.Write("|||Введите максимальное доступное игрокам число -> ");
                        int rangvsPCMax = Convert.ToInt32(Console.ReadLine());

                        int[] rangvsPC = new int[rangvsPCMax - rangvsPCMin];
                        int count1 = 0;
                        for (int i = rangvsPCMin; i < rangvsPCMax - 1; ++i)
                        {
                            rangvsPC[count1] = i;
                            count1++;
                            if (count1 == rangvsPCMax - rangvsPCMin - 1)
                            {
                                rangvsPC[count1] = rangvsPCMax;
                                break;
                            }
                        }
                        Console.Write("Введите колличество попыток -> ");                        
                        int vsPCtryes = Convert.ToInt32(Console.ReadLine());
                        #endregion
                                                //Старт
                        Game.GameWithPCStart(gamevsPCNumberMin, gamevsPCNumberMax, vsPCtryes, rangvsPC);
                        Console.Write("Хотите сыграть реванш? (y/n) -> ");
                        ch2 = Console.ReadLine();
                    }
                    while (ch2 != "n" && ch2 != "т" && ch2!="N" && ch2!="Т");
                    break;
            }
            Console.ReadLine();
        }
    }
}
