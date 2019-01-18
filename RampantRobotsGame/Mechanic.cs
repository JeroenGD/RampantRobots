using System;

namespace RampantRobotsGame
{
    public class Mechanic
    {
        // public parameters
        public int x;
        public int y;

        public Mechanic(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public void MechanicMove(char move, int xbound, int ybound)
        {
            // Make mechanic dance if factory boundaries allow it
            switch (move)
            {
                case 'w':
                    if (y > 1)
                    y--;
                    break;

                case 's':
                    if (y < ybound)
                    y++;
                    break;

                case 'a':
                    if (x > 1)
                    x--;
                    break;

                case 'd':
                    if (x < xbound)
                    x++;
                    break;

                default:
                    Console.WriteLine("Please, only use w, a, s and d to move");
                    break;
            }


            }
        }
    }
