using Snake___Ladder.Models;

namespace Snake___Ladder.Services
{
    public class BoardService
    {
        public BoardService() { }

        public int GetCurrentPosition(Player player)
        {
            if (player == null)
            {
                return -1;
            }
            return player.CurrentPosition;
        }

        public int GetNextPosition(Player player, int moveSteps, Dictionary<int, int> snakeAndLadder)
        {
            if (snakeAndLadder == null)
            {
                return -1;
            }
            int nextPosition = player.CurrentPosition + moveSteps;
            while(snakeAndLadder.ContainsKey(nextPosition))
            {
                nextPosition = snakeAndLadder[nextPosition];
            }
            return nextPosition;
        }
    }
}
