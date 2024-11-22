using Snake___Ladder.Services;

namespace Snake___Ladder.Models
{
    public class Game
    {
        private List<Player> Players { get; set; }
        private Board board { get; set; }

        private Die die { get; set; }

        private Dictionary<int, int> SnakeAndLadderPosition { get; set; }

        public Game(int cells = 100, int sides = 6)
        {
            this.Players = new List<Player>();
            this.board = new Board(cells);
            this.die = Die.getInstance(sides);
            this.SnakeAndLadderPosition = new Dictionary<int, int>();
        }

        public void AddSnakeAndLadder(int startPos, int endPos)
        {
            this.SnakeAndLadderPosition.Add(startPos, endPos);
        }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }

        private void RemovePlayer(Player player)
        {
            this.Players.Remove(player);
        }

        public void StartGame()
        {
            BoardService boardService = new BoardService();
            int rolledCount = 0;
            while (this.Players.Count > 1)
            {
                rolledCount = rolledCount % this.Players.Count;
                Player currentPlayer = this.Players[rolledCount];
                if (currentPlayer == null)
                {
                    this.RemovePlayer(currentPlayer);
                    continue;
                }
                int moveSteps = this.die.Roll();
                int currentPosition = boardService.GetCurrentPosition(currentPlayer);
                int nextPosition = boardService.GetNextPosition(currentPlayer, moveSteps, this.SnakeAndLadderPosition);

                if (nextPosition > this.board.Cells)
                {
                    nextPosition = currentPosition;
                }
                currentPlayer.SetPosition(nextPosition);

                Console.WriteLine($"{currentPlayer.Name} rolled a {moveSteps} and moved from {currentPosition} to {nextPosition}");

                if (nextPosition == this.board.Cells)
                {
                    Console.WriteLine($"{currentPlayer.Name} wins the game");
                    this.RemovePlayer(currentPlayer);
                    break;
                }
                rolledCount++;
                //yet to handle logic for other players to play
            }
            //when the last player remains then print he lost the game
        }
    }
}
