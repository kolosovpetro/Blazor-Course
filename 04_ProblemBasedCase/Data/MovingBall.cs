using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemBasedCase4.Data
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

        #region ProblemBasedCase4

        public int Radius { get; set; } = 8;
        private int Diameter => 2 * Radius;

        public int CollisionCount(MovingBall ball, IEnumerable<MovingBall> ballList)
        {
            return ballList.Count(x => Distance(ball, x) < ball.Diameter);
        }

        public static IEnumerable<MovingBall> GetCollisionBalls(MovingBall ball, IEnumerable<MovingBall> balls)
        {
            return balls.Where(x => ball.Distance(x, ball) < ball.Diameter && x.Color == Colors.Green);
        }

        public double Distance(MovingBall b1, MovingBall b2)
        {
            return Math.Sqrt(Math.Pow(b2.PositionX - b1.PositionX, 2) + Math.Pow(b2.PositionY - b1.PositionY, 2));
        }

        #endregion
    }
}