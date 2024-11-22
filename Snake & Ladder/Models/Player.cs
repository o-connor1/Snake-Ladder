using System.Xml;

namespace Snake___Ladder.Models
{
    public class Player
    {
        private readonly string Id;

        public string Name { get; set; }

        public int CurrentPosition { get; set; }

        public Player(string name)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.CurrentPosition = 0;
        }

        public void SetPosition(int position)
        {
            this.CurrentPosition = position;
        }
    }
}
