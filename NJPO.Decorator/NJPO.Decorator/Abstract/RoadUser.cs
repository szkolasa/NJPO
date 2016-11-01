using System;

namespace NJPO.Decorator.Abstract
{
    public abstract class RoadUser
    {
        private static Random rand = new Random();
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public abstract int Speed();

        public abstract char Symbol();

        public void Move()
        {
            var direction = rand.Next(4);

            switch (direction)
            {
                case 0:
                    if (XPosition - Speed() >= 0)
                    {
                        XPosition -= Speed();
                    }
                    else
                    {
                        XPosition = 1;
                    }
                    break;
                case 1:
                    if (XPosition + Speed() <= Console.WindowWidth - 1)
                    {
                        XPosition += Speed();
                    }
                    else
                    {
                        XPosition = Console.WindowWidth - 1;
                    }
                    break;
                case 2:
                    if (YPosition - Speed() >= 0)
                    {
                        YPosition -= Speed();
                    }
                    else
                    {
                        YPosition = 1;
                    }
                    break;
                case 3:
                    if (YPosition + Speed() <= Console.WindowHeight - 1)
                    {
                        YPosition += Speed();
                    }
                    else
                    {
                        YPosition = Console.WindowHeight - 1;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
