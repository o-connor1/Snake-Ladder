namespace Snake___Ladder.Models
{
    public class Die
    {

        private static Die instance;

        private static readonly object lockObj = new object();

        private int Sides { get; set; }

        private Die(int sides)
        {
            this.Sides = sides;
        }

        public static Die getInstance(int sides = 6)
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new Die(sides);
                    }
                }
            }
            return instance;
        }

        public int Roll()
        {
            //return random number from 1 to sides
            Random random = new Random();
            return random.Next(1, Sides+1);
        }
    }
}
