using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba2
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Встановлюємо кодування консолі на UTF-8 для підтримки спеціальних символів.
            Console.OutputEncoding = Encoding.UTF8;

            // Створюємо об'єкти для двох гравців та гру.
            
            
            GameAccount player1 = ChoseAccount();
            GameAccount player2 = ChoseAccount();
            Game game = TypeOfGame(player1, player2);
            // Розпочинаємо гру.
            game.StartGame();

            // Виводимо статистику гравців після завершення гри.
            player1.GetStats();
            player2.GetStats();
        }

        private static GameAccount ChoseAccount() {
            Console.WriteLine("\nВиберіть акаунт гравця: ");
            Console.WriteLine("1) базовий акаунт;");
            Console.WriteLine("2) акаунт, у якого змінюється у два рази менше балів;");
            Console.WriteLine("3) акаунт, в якому нараховується додаткові бали за серію перемог;\n");
            int temp = Convert.ToInt32(Console.ReadLine());
           if(temp ==1)
                    return new GameAccount();
           if (temp == 2)
                return new HalfRatingAccount();
           if (temp == 3)
                return new StreekAccount();
           else
                Console.WriteLine("\nВведене некоректне значення!");
                return ChoseAccount();
            }
        private static Game TypeOfGame(GameAccount player1, GameAccount player2)
        {
            Console.WriteLine("\nВиберіть вид гри: ");
            Console.WriteLine("1) звичайна гра;");
            Console.WriteLine("2) гра без рейтингу;");
            Console.WriteLine("3) гра, у якій один гравець грає на рейтинг;\n");
            int temp = Convert.ToInt32(Console.ReadLine());
            GameFactory gameFactory = new GameFactory();
            if (temp == 1)
                return gameFactory.CreateGame(player1, player2);
            if (temp == 2)
                return gameFactory.CreateGameWithoutRating(player1, player2);
            if (temp == 3)
                return gameFactory.CreateGameOnePlayerRating(player1, player2);
            else
                Console.WriteLine("\nВведене некоректне значення!");
            return TypeOfGame(player1, player2);
        }

    }
}

    
   

