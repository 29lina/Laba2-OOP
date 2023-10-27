﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    public class GameWithoutRating : Game
    {
        public GameWithoutRating(GameAccount player1, GameAccount player2) : base(player1, player2)
        {
        }
        override public void StartGame()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n****************************************************************************\n");
            Console.WriteLine("Ласкаво просимо до гри!\n");

            // Введення імен гравців та початкового рейтингу.
            Console.Write("Введіть ім'я першого гравця: ");
            player1.UserName = Console.ReadLine().Trim();

            Console.Write("Введіть ім'я другого гравця: ");
            player2.UserName = Console.ReadLine().Trim();

            
            // Початок гри.
            Play();
        }
        override public void Play()
        {


            // Симуляція кидання кубиків і визначення переможця.
            Random random = new Random();
            int player1Roll = random.Next(1, 7);
            int player2Roll = random.Next(1, 7);
            Console.WriteLine($"{player1.UserName} кинув кубик і випало {player1Roll}");
            Console.WriteLine($"{player2.UserName} кинув кубик і випало {player2Roll}");
            if (player1Roll > player2Roll)
            {
                player1.WinGame(player2.UserName);
                player2.LoseGame(player1.UserName);
                Console.WriteLine($"Переміг {player1.UserName}!");
                player1.GetStatsWithoutRating();
                player2.GetStatsWithoutRating();
            }
            if (player1Roll < player2Roll)
            {
                player2.WinGame(player1.UserName);
                player1.LoseGame(player2.UserName);
                Console.WriteLine($"Переміг {player2.UserName}!");
                player1.GetStatsWithoutRating();
                player2.GetStatsWithoutRating();
            }
            if (player1Roll == player2Roll)
            {
                Console.WriteLine("Нічия");
            }

            // Питання про гру ще раз.
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.Write("Хочете зіграти ще одну гру? (Так/Ні): ");
            string playAgainResponse = Console.ReadLine().Trim();

            bool playAgain = true;
            if (!playAgainResponse.Equals("Так", StringComparison.OrdinalIgnoreCase))
            {
                playAgain = false;
            }
            if (playAgain) Play();
        }
    }
}
