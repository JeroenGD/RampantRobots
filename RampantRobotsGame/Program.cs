using System;

namespace RampantRobotsGame
{
    class Program
    {
        static void Main(string[] args)
        {

            // Game parameters, these parameters will be used for the first game
            // and all the games after that
            int FactoryWidth = 13;
            int FactoryHeight = 8;
            int NumberOfRobots = 4;
            int NumberOfTurns = 5000;
            bool MovingRobots = true;

            // Write explanation, make first factory and run the game
            Console.WriteLine("YOU'VE LOST!");
            Factory factory = new Factory(FactoryWidth, FactoryHeight, NumberOfRobots, NumberOfTurns, MovingRobots);
            factory.Run(FactoryWidth, FactoryHeight, NumberOfRobots, NumberOfTurns, MovingRobots);
        }
    }
}
