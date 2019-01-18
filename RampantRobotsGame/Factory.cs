using System;
using System.Collections.Generic;
using System.Text;

namespace RampantRobotsGame
{
    public class Factory
    {
        // A bunch of public parameters used in this class
        public int Width;
        public int Height;
        public int Robots;
        public int Turns;
        public bool MovingRobots;
        static Random random = new Random();
        public Mechanic mechanic = new Mechanic(1, 1);
        public List<Robot> BotList;

        public Factory(int width, int height, int robots, int turns, bool movingRobots)
        {
            Width = width;
            Height = height;
            Robots = robots;
            Turns = turns;
            MovingRobots = movingRobots;
            BotList = new List<Robot>();
            // Fillig list with robots 
            for (int i = 0; i<Robots; i++)
            {
                Robot NewBot = new Robot(random.Next(1, width+1), random.Next(1, height+1));
                // If robot has same location as another robot in list, don't add to list and redo iteration
                if (BotList.Contains(NewBot) | (NewBot.x == mechanic.x & NewBot.y == mechanic.y))
                    i--;
                else
                    BotList.Add(NewBot);
            }
        }

        // Drawing method
        public void Draw()
        {
            // Loop over each row of dots...
            for (int yDraw = 1; yDraw <= Height; yDraw++)
            {
                StringBuilder FactoryLine = new StringBuilder();

                // ...and each dot in that row
                for (int xDraw = 1; xDraw <= Width; xDraw++)
                {
                    // using dummy robot to use the compare function to check if a robot is on this position in the factory
                    var BotCheck = new Robot(xDraw, yDraw);
                    // check if mechanic is on this position
                    if (mechanic.x == xDraw & mechanic.y == yDraw)
                    {
                        FactoryLine.Append('M');
                    }
                    else
                    {
                        if (BotList.Contains(BotCheck))
                        {
                            FactoryLine.Append('R');
                        }
                        else
                        {
                            FactoryLine.Append('.');
                        }
                    }
                }
                Console.WriteLine(FactoryLine);
            }
        }

        // Method to play one turn of the game
        public void PlayTurn()
        {
            String moves = Console.ReadLine();
            // for each character in given moves
            foreach (char move in moves)
            {
                // variables to check if robot is oiled
                int OiledRobots = 0;
                bool RemoveRobot = false;

                // Move mechanic
                mechanic.MechanicMove(move, Width, Height);

                // Loop over robots
                for (int bot1 = 0; bot1 < BotList.Count; bot1++)
                {
                    // only do this part is robots are moving
                    if (MovingRobots)
                    {
                        //Generate robot move
                        int RandMove = random.Next(-2, 3);
                        BotList[bot1].RobotMove(RandMove, Width, Height);

                        // Check if robot collides with other robot, reverse move if this is the case
                        for (int bot2 = 0; bot2 < BotList.Count; bot2++)
                        {
                            if (!(bot1 == bot2) && BotList[bot1].x == BotList[bot2].x && BotList[bot1].y == BotList[bot2].y)
                            {
                                if (BotList[bot1].Equals(BotList[bot2]))
                                {
                                    BotList[bot1].RobotMove(-RandMove, Width, Height);
                                }
                            }
                        }
                    }

                    // If mechanic is on top of robot, change variable to remove robot
                    if (mechanic.x==BotList[bot1].x && mechanic.y == BotList[bot1].y)
                    {
                        OiledRobots = bot1;
                        RemoveRobot = true;
                    }
                }
                // Check if robots need to be removed and remove if so
                if (RemoveRobot)
                {
                    BotList.RemoveAt(OiledRobots);
                    RemoveRobot = false;
                }

            }
            // Draw new factory after moves
            Draw();
            // Minus one turn
            Turns--;
            // If turns are over and there are is still a robot left, YOU'VE LOST
            if (Turns == 0 && BotList.Count>0)
            {
                Console.WriteLine("YOU'VE LOST!");
                return;
            }
            // Tell user how many turns and robots are left
            Console.WriteLine(String.Format("You've got {0} turns left. {1} robot still need to be oiled.", Turns, BotList.Count));
        }

        public void Run(int w, int h, int r, int t, bool m)
        {
            //Keep running untill user decides is enough
            do
            {
                // start with fresh console each new game
                Console.Clear();
                //draw and update on how many turns
                Draw();
                Console.WriteLine(String.Format("You've got {0} turns left. {1} robot still need to be oiled.", Turns, BotList.Count));

                // play all round untill a win or untill no more turns are left
                for (int i = Turns; i > 0; i--)
                {
                    PlayTurn();
                    if (BotList.Count == 0)
                    {
                        Console.WriteLine("YOU'VE WON!");
                        break;
                    }
                }
                // ask user if they want to play again
                Console.WriteLine("Do you want to play again? y(es)/n(o)");
                string Playing = Console.ReadLine();
                if (Playing[0] == 'y')
                {
                    Factory newFactory = new Factory(w, h, r, t, m);
                    newFactory.Run(w, h, r, t, m);
                }
                break;
            }
            while (true);


            Console.WriteLine("please play again... I'm just a lonely programboy!");



        }
    }
}
