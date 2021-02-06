namespace Tutorial2.Data
{
    public class Carrot : BioUnit
    {
        private Carrot(int row, int col) : base(row, col)
        {
            Color = "#fa5511";
            Living = 0;
            LivingMax = 4;
        }

        public Carrot(int row, int col, Environment environment) : this(row, col)
        {
            Environment = environment;
        }

        public override bool WillILive()
        {
            if (Living + 1 >= LivingMax)
            {
                Living++;
                return false;
            }

            return true;
        }
    }
}