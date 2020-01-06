using System;
using System.Collections.Generic;

namespace Homework_Theme_03
{
   public  class Players
    {
        public static List<string> players;          //Список с игроками
        static int pcount = 0;                       //Счетчик игроков
        /// <summary>
        /// Метод присваивания имен игрокам и подсчета их колличества
        /// </summary>
        public static void Setnames()
        {
            pcount = 0;
            players = new List<string>();
            Console.Write("|||Введите колличество игроков: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            for (int i = 1;i<=quantity;i++)         //цикл проходит по всем игрокам предлагая ввести имя
            {                
                Console.Write($"|||Введите имя {i}го игрока: ");
                string name = Console.ReadLine();
                players.Add(name);
                pcount++;
            }
        }
        /// <summary>
        /// Метод вывода на консоль списка с игроками
        /// </summary>
        public static void ShowPlayers()
        {
            if(pcount==0)                           //если список пуст, предлагает заполнить его
            {
                Console.WriteLine("Сначала заполните список!");
                Setnames();
            }
            else
            {                
                for(int i = 1;i<=pcount;i++)
                {
                    string format = $"\t{players[i - 1]} ";
                    Console.WriteLine(format, i);
                }
            }
        }

    }
}
