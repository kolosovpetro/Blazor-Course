namespace Tutorial4.Data
{
    public class MovingBall
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public Colors Color { get; set; } = Colors.Blue;
        private int VelocityX { get; set; } = 1;
        private int VelocityY { get; set; } = 1;
        private int MinX { get; set; }
        private int MaxX { get; set; } = 100;
        private int MinY { get; set; }
        private int MaxY { get; set; }

        public MovingBall(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public void SetLimitX(int min, int max)
        {
            MaxX = max;
            MinX = min;
        }

        public void SetLimitY(int min, int max)
        {
            MaxY = max;
            MinY = min;
        }

        public void SetVelocity(int velX, int velY)
        {
            VelocityX = velX;
            VelocityY = velY;
        }

        public void Move()
        {
            PositionX += VelocityX;
            PositionY += VelocityY;

            if (PositionX < MinX || PositionX > MaxX)
            {
                VelocityX *= -1;
            }

            if (PositionY < MinY || PositionY > MaxY)
            {
                VelocityY *= -1;
            }
        }
    }
}