using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    // Клас, що представляє гравця гри.
    public class GameAccount
    {
        public string UserName { get; set; } // Ім'я гравця
        public int CurrentRating { get; set; } // Поточний рейтинг гравця
        private List<GameResult> gameHistory; // Історія ігор гравця
        public int GamesCount { get; set; } // Кількість ігор гравця
        public int WinStreek { get; set; } = 0;

        // Конструктор класу GameAccount, де можливо вказати початкову кількість ігор (за замовчуванням - 0).
        public GameAccount(int gamesCount = 0)
        {
            GamesCount = gamesCount;
            gameHistory = new List<GameResult>();
        }

        // Методи для фіксації результатів гри та оновлення статистики гравця.

        public void WinGame(string opponentName, Game game)
        {
            int rating = PointsCalculate(game.getPlayRating(this));
            GamesCount++;
            CurrentRating += rating;
            gameHistory.Add(new GameResult(opponentName, true, rating));
            WinStreek++;
        }
        public void WinGame(string opponentName)
        {

            GamesCount++;
            gameHistory.Add(new GameResult(opponentName, true));
            WinStreek++;
        }

        public void LoseGame(string opponentName, Game game)
        {
            int rating = PointsCalculate(game.getPlayRating(this));
            GamesCount++;
            CurrentRating -= rating;
            gameHistory.Add(new GameResult(opponentName, false, rating));
            WinStreek = 0;
        }
        public void LoseGame(string opponentName)
        {
           
            GamesCount++;
            gameHistory.Add(new GameResult(opponentName, false));
            WinStreek = 0;
        }

        // Виведення статистики гравця на консоль.
        public void GetStats()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n.................................\n");
            Console.WriteLine($"ІСТОРІЯ ІГОР для {UserName}:");
            for (int i = 0; i < gameHistory.Count; i++)
            {
                var result = gameHistory[i];
                String matchResult;
                if (result.Won) { matchResult = "Перемога"; } else { matchResult = "Поразка"; }
                Console.WriteLine($"Гра {i + 1}: \n" +
                                  $"Опонент: {result.OpponentName}\n" +
                                  $"Результат: {(matchResult)}\n" +
                                  $"Зміна рейтингу: {result.RatingChange}\n");
            }
            Console.WriteLine($"Поточний рейтинг для {UserName}: {CurrentRating}\n" +
                              $"Кількість ігор: {GamesCount}\n");
        }
        public void GetStatsWithoutRating()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n.................................\n");
            Console.WriteLine($"ІСТОРІЯ ІГОР для {UserName}:");
            for (int i = 0; i < gameHistory.Count; i++)
            {
                var result = gameHistory[i];
                String matchResult;
                if (result.Won) { matchResult = "Перемога"; } else { matchResult = "Поразка"; }
                Console.WriteLine($"Гра {i + 1}: \n" +
                                  $"Опонент: {result.OpponentName}\n" +
                                  $"Результат: {(matchResult)}\n");
                                  
            }
            Console.WriteLine(
                              $"Кількість ігор: {GamesCount}\n");
        }

        public virtual int PointsCalculate(int rating)
        {
            return rating;
        }
    }

    public class HalfRatingAccount : GameAccount 
    {
        public override int PointsCalculate(int rating)
        {
            return rating /= 2;
        }
    }
    public class StreekAccount : GameAccount
    {
        public override int PointsCalculate(int rating)
        {
            return rating = rating * (1+WinStreek);
        }
    }

}
