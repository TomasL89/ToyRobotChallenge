using RobotMovement;
using System;

namespace ToyRobotChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How to use:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("PLACE X, Y, FACING");
            Console.WriteLine("Where");
            Console.WriteLine("X = 1, 2, 3");
            Console.WriteLine("Y = 1, 2, 3");
            Console.WriteLine("FACING = NORTH, SOUTH, EAST, WEST");
            Console.WriteLine();
            Console.WriteLine("Type reset to reset the challenge");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            var robot = new Robot();

            while (true)
            {
                var input = Console.ReadLine();

                var command = input.Split(',');

                if (input.Contains("place ") && command.Length == 3)
                {
                    var xCoordSplit = command[0].Split(' ');
                    robot.RobotPosition.UpdatePosition(xCoordSplit[1], command[1], command[2]);
                }
                else if (robot.RobotPosition.IsOffTable)
                {
                    Console.WriteLine("Move ignored");
                    continue;
                }
                else if (string.Equals("move", command[0], StringComparison.InvariantCultureIgnoreCase) || string.Equals("left", command[0], StringComparison.InvariantCultureIgnoreCase) || string.Equals("right", command[0], StringComparison.InvariantCultureIgnoreCase))
                {
                    robot.CaculateMovement(command[0]);
                }
                else if (string.Equals("report", command[0], StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine();
                    Report(robot.GetReport());
                }
            }
        }

        private static void Report(string report)
        {
 
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(report);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }

}
