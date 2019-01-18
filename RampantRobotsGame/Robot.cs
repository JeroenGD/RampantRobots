using System;
namespace RampantRobotsGame
{
    public class Robot
    {
        public int x;
        public int y;
        static Random random = new Random();

        public Robot(int X, int Y)
        {
            x = X;
            y = Y;
        }
        public void RobotMove(int move, int xbound, int ybound)
        {
            // Make robot dance if factory boundaries allow it
            switch (move)
            {
                case -1:
                    if (y > 1)
                        y--;
                    break;

                case 1:
                    if (y < ybound)
                        y++;
                    break;

                case -2:
                    if (x > 1)
                        x--;
                    break;

                case 2:
                    if (x < xbound)
                        x++;
                    break;
            }
        }

        // override equals to compare robot positions

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Robot))
                return false;

            return (this.x == ((Robot)obj).x & this.y == ((Robot)obj).y);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
