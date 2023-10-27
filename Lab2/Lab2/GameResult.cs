using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    // Клас, що представляє результат однієї гри.
    public class GameResult
    {
        public string OpponentName { get; }
        public bool Won { get; }
        public int RatingChange { get; }

        public GameResult(string opponentName, bool won, int ratingChange)
        {
            OpponentName = opponentName;
            Won = won;
            RatingChange = ratingChange;
        }
        public GameResult(string opponentName, bool won)
        {
            OpponentName = opponentName;
            Won = won;
            
        }
    }

}
