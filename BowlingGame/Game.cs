namespace BowlingGame
{
    /// <summary>
    /// Game object to handle all rolls and scoring
    /// </summary>
    public class Game
    {
        private int[] _rolls { get; }
        private int _currentRoll { get; set; }

        public Game()
        {
            _rolls = new int[21];
            _currentRoll = 0;
        }

        /// <summary>
        /// Add a roll to the game
        /// </summary>
        /// <param name="pins">Number of pins hit</param>
        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        /// <summary>
        /// Score the game results.  Not to be called until the end of the game.
        /// </summary>
        /// <returns>Integer final bowling score</returns>
        public int Score()
        {
            var score = 0;
            var rollIndex = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    score += 10 + StrikeBonus(rollIndex);
                    rollIndex++;
                }
                else if (IsSpare(rollIndex))
                {
                    score += 10 + SpareBonus(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(rollIndex);
                    rollIndex += 2;
                }
            }

            return score;
        }

        private bool IsStrike(int rollIndex) => _rolls[rollIndex] == 10;

        private bool IsSpare(int rollIndex) => _rolls[rollIndex] + _rolls[rollIndex + 1] == 10;

        private int SumOfBallsInFrame(int rollIndex) => _rolls[rollIndex] + _rolls[rollIndex + 1];

        private int SpareBonus(int rollIndex) => _rolls[rollIndex + 2];

        private int StrikeBonus(int rollIndex) => _rolls[rollIndex + 1] + _rolls[rollIndex + 2];
    }
}
