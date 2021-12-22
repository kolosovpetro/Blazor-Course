namespace Tutorial1.Data
{
    public class BioUnit
    {
        private bool Alive { get; set; }

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
    }
}