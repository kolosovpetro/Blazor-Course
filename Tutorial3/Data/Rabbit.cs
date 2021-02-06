namespace Tutorial3.Data
{
    public class Rabbit : BioUnit
    {
        public int Hungry { get; set; }
        public int HungryTop { get; set; }

        public Rabbit(int row, int col) : base(row, col)
        {
            Color = "#fafafa";
            Living = 0;
            LivingMax = 6;
            Hungry = 0;
            HungryTop = 3;
        }

        public Rabbit(int row, int col, Environment environment) : this(row, col)
        {
            Environment = environment;
        }

        public override bool WillILive()
        {
            Hungry++;
            Living++;

            if (Living - 1 >= LivingMax || Hungry - 1 >= HungryTop)
            {
                return false;
            }

            return true;
        }

        public void Eat()
        {
            Hungry = 0;
        }
    }
}