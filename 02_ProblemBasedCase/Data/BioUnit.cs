namespace ProblemBasedCase2.Data
{
    public class BioUnit
    {
        private bool Alive { get; set; }

        public BioUnit()
        {
        }

        public bool IsAlive()
        {
            return Alive;
        }

        public bool IsDead()
        {
            return !IsAlive();
        }

        public void Live()
        {
            Alive = true;
        }

        public void Die()
        {
            Alive = false;
        }

        // from problem based case

        protected string Color { get; set; }
        protected int Living { get; set; }
        protected int LivingMax { get; set; }
        public Point Position { get; }
        protected Environment Environment { get; set; }

        protected BioUnit(int row, int col)
        {
            Position = new Point(row, col);
            Color = "#444444";
        }

        public BioUnit(int row, int col, Environment environment) : this(row, col)
        {
            Environment = environment;
        }

        public string GetColor()
        {
            return Color;
        }

        public virtual bool WillILive()
        {
            return true;
        }
    }
}