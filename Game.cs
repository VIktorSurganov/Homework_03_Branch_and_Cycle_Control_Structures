using System;
using System.Collections.Generic;

namespace Homework_Theme_03
{
    /// <summary>
    /// Основной класс проекта, в котором обрабатываются 
    /// введенные игроками данные. Содержит два метода для
    /// игры с другими игроками либо игры с компьютером.
    /// </summary>
    public static class Game 
    {        
        static Players p1 = new Players();      //Экземпляр класса Players для получения доступа к методам Players.Setname() и .ShowPlayers()
        static Random randomize;                //Переменная для задания игрового числа gameNumber
        static Random randomize2;               //Переменная для ввода компьютера при игре с компьютером

        /// <summary>
        /// Метод проверки окончания игры против компьютера
        /// и вывод поздравления победителя
        /// </summary>
        /// <param name="gn">Игровое число</param>
        /// <param name="catchplayer">Игрок, на котором игра завершилась</param>
        /// <param name="plname">Имя игрока</param>
        /// <param name="pcname">Имя компьютера</param>
        /// <returns></returns>
        /// 
        private static bool chek (int gn, int catchplayer, string plname, string pcname)
        {
            bool catchwinner;                   //если при запуске метода игровое чило равно нулю,
                                                //значение устанавливается в true и метод
                                                //возвращает поздравление для catchplayer(игрок или компьютер)
            if (gn == 0)
            {                
                if (catchplayer == 1)                    
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Поздравляем! Победил {plname}");
                    Console.ResetColor();
                }
                if (catchplayer == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Поздравляем! Победил {pcname}");
                    Console.ResetColor();
                }
                catchwinner = true;
                return catchwinner;
            }
            else { catchwinner = false; }
            return catchwinner;
        }
        /// <summary>
        /// Метод запускает основной цикл игры с принятыми игровыми параметрами
        /// </summary>
        /// <param name="gameNumber1">Минимальное значение для случайного игрового числа</param>
        /// <param name="gameNumber2">Максимальное значение для случайного игрового числа</param>
        /// <param name="tryes">Колличество ходов, после окончания которых игра закончится</param>
        /// <param name="rang">Диапазон доступных игрокам чисел для ввода</param>
        public static void GameStart(int gameNumber1, int gameNumber2, int tryes, params int[]rang)
        {
                                                //инициализация параметров
            #region
            int gameCount = tryes;
            randomize = new Random();
            int GN= randomize.Next(gameNumber1, gameNumber2);

            Players.Setnames();
            Console.WriteLine();
            Console.WriteLine("Добро пожаловать в игру : ");
            Players.ShowPlayers();

            int[] gameRang = rang;
            bool catсhWinner = false;
            #endregion
            do
            {  
                                                //Цикл для обхода всех игроков из списка и
                                                //предоставления каждому возможности хода
                foreach (string s in Players.players)
                {
                                                //Игроки ходят по очереди
                    #region
                                                //на каждом ходе счетчик уменьшается на 1. 
                                                //При достижении нулевого значения игра завершается
                    if (gameCount == 0)
                    {
                        Console.WriteLine("Колличество попыток исчерпано!");                                              
                        return;
                    }
                                                //Вывод текущего состояния игры с предложением ввести число
                    Console.WriteLine("-------------------");
                    Console.WriteLine($"Попыток осталось: {gameCount}");                    
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"/|\\Ход Игрока : {s}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"|||Игровое число : {GN}");
                    Console.ResetColor();
                    int playerIN;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (GN > gameRang[gameRang.Length - 1])
                        {
                            Console.WriteLine($"|||Введите число из диапазона от {gameRang[0]} до {gameRang[gameRang.Length - 1]}");
                        }
                                                //В момент когда игровое число становится меньше максимального из диапазаона числа
                                                //предлагается ввести число изнового диапазона, ограниченного игровым числом
                        else
                        {
                            Console.WriteLine($"|||Введите число из диапазона от {1} до {GN}");
                        }
                        Console.ResetColor();
                        Console.Write("|||Ваше число -> ");
                        playerIN = Convert.ToInt32(Console.ReadLine());
                    }
                                                //Проверка на введенное пользователем число
                    while (gameRang[gameRang.Length-1] < playerIN || playerIN <= 0 ||GN<playerIN);
                    GN -= playerIN;
                    gameCount--;
                    #endregion
                                                //Если после очередного ввода игровое число равно 0, игра завершается
                    if (GN == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Поздравляем! Победил игрок : {s}");
                        Console.ResetColor();
                        catсhWinner = true;
                        break;
                    }
                }
            }
                                                //игра продолжается пока cathWinner равно false
            while (catсhWinner == false);
        }
        /// <summary>
        /// Метод запускает основной цикл игры с принятыми игровыми параметрами
        /// </summary>
        /// <param name="gameNumber1">Минимальное значение для случайного игрового числа</param>
        /// <param name="gameNumber2">Максимальное значение для случайного игрового числа</param>
        /// <param name="tryes">Колличество ходов, после окончания которых игра закончится</param>
        /// <param name="rang">Диапазон доступных игрокам чисел для ввода</param>
        public static void GameWithPCStart(int gameNumber1, int gameNumber2, int tryes, params int[] rang)
        {
                                                //инициализация параметров
            #region
            int gameCount = tryes;
            randomize = new Random();    
            randomize2 = new Random();   
            int GN = randomize.Next(gameNumber1, gameNumber2);
            string plName;
            int playerIN;
            string pcName = Environment.MachineName;
            int pcIN;            
            int[] gameRang = rang;
            bool cathWinner = false;
            Console.Write("Введите имя игрока -> ");
            plName = Console.ReadLine();            
            Console.WriteLine();
            Console.WriteLine($"Добро пожаловать в игру, {plName}!");
            #endregion
            do
            {
                                                //на каждом ходе счетчик уменьшается на 1. 
                                                //При достижении нулевого значения игра завершается
                if (gameCount == 0)
                {
                    Console.WriteLine("Колличество попыток исчерпано!");
                    return;
                }
                                                //Ход игрока
                #region
                int catchPlayer;                //переменная для выявления победителя
                                                //присвоение "1" когда ходит игрок, "2" когда ходит компьютер
                Console.WriteLine("-------------------");
                Console.ForegroundColor = ConsoleColor.Blue;                
                Console.WriteLine($"/|\\Игровое число : {GN}");
                Console.ResetColor();
                do
                {
                    Console.WriteLine($"Попыток осталось: {gameCount}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (GN > gameRang[gameRang.Length - 1])
                    {
                        Console.WriteLine($"|||Введите число из диапазона от {gameRang[0]} до {gameRang[gameRang.Length - 1]}");
                    }
                                                //В момент когда игровое число становится меньше максимального из диапазаона числа
                                                //предлагается ввести число изнового диапазона, ограниченного игровым числом
                    else
                    {
                        Console.WriteLine($"|||Введите число из диапазона от {1} до {GN}");
                    }
                    Console.ResetColor();                    
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"\\|//Ходите, {plName} -> ");
                    Console.ResetColor();
                                                //считывание ввода игрока
                    playerIN = Convert.ToInt32(Console.ReadLine());                    
                    catchPlayer = 1;
                }
                while (gameRang[gameRang.Length-1] < playerIN || playerIN <= 0 || GN < playerIN);
                                                //вычитание введенного числа из игрового числа
                GN -= playerIN;                 
                gameCount--;
                                                //проверка на окончание игры
                cathWinner = chek(GN, catchPlayer, plName, pcName); 
                if (cathWinner == true)
                {
                    break;
                }
                #endregion
                                                //Ход компьютера
                #region
                Console.WriteLine("-------------------");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Игровое число={GN}");
                Console.ResetColor();
                Console.WriteLine($"Попыток осталось: {gameCount}");
                catchPlayer = 2;
                //генерация случайного числа для ввода компьютером
                if (GN > gameRang[gameRang.Length - 1])
                {
                    pcIN = randomize2.Next(gameRang[0], gameRang[gameRang.Length - 1]);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Ходит {pcName} -> {pcIN}");
                    Console.ResetColor();
                    //вычитание введенного числа из игрового числа
                    GN -= pcIN;
                    gameCount--;
                }
                else
                {
                    pcIN = randomize2.Next(1, GN);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Ходит {pcName} -> {pcIN}");
                    Console.ResetColor();
                    //вычитание введенного числа из игрового числа
                    GN -= pcIN;
                    gameCount--;
                }

                //проверка на окончание игры
                cathWinner = chek(GN, catchPlayer, plName, pcName); 
                if (cathWinner == true)
                {
                    break;
                }
                #endregion
            }
                                                //игра продолжается пока cathWinner равно false
            while (cathWinner == false);
        }
    }
}
