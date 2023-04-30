using System;
using TableTop_Robot.Common;
using TableTop_Robot.Service;

namespace TableTop_Robot {
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Creating a 5x5 Table");
            TableGrids grid = new TableGrids(5, 5);

            //building robot
            Robot robot = new Robot(grid);

            Console.WriteLine("Starting Demo");

            RobotDemo(robot);
            
            // Place the robot at (0, 0) facing North
            robot.Place(0, 0, Facing.NORTH.ToString());

            ShowMenu();
            StartManualInput(robot);
        }

        /// <summary>
        /// Control the robot with manual comands
        /// </summary>
        private static void StartManualInput(Robot robot)
        {
            while (true)
            {
                Console.Write("Enter a command: ");
                string input = Console.ReadLine()?.Trim() ?? "";

                if (input.Equals("x", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                switch (input.ToLower())
                {
                    case string s when s.StartsWith("place"):
                        PlaceRobot(robot, s.Substring(6).Trim('(', ')'));
                        break;
                    case "move":
                        robot.Move();
                        break;
                    case "left":
                        robot.TurnLeft();
                        break;
                    case "right":
                        robot.TurnRight();
                        break;
                    case "report":
                        robot.Report();
                        break;
                    case "menu":
                        ShowMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            }
        }

        private static void PlaceRobot(Robot robot, string arguments)
        {
            // Parse arguments
            string[] args = arguments.Split(',');
            int x, y;
            if (int.TryParse(args[0], out x) && int.TryParse(args[1], out y))
            {
                robot.Place(x, y, args[2].ToLower());
            }
            else
            {
                Console.WriteLine("Invalid arguments for place command.");
            }
        }


        /// <summary>
        /// Print menu on the screen
        /// </summary>
        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Command Options");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine(" Menu                [Clear Screen and Return to menu]       Example: menu");
            Console.WriteLine(" Exit                [Exit the program]                      Example: x/Exit");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine(" Place(x,y,facing)   [Place robot on grid]                   Example: place(0,0,North/South/West/East)");
            Console.WriteLine(" Move                [Moves the robot 1 grid]                Example: move");
            Console.WriteLine(" Left                [Rotate the robot 90° anticlockwise]    Example: left");
            Console.WriteLine(" Right               [Rotate the robot 90° clockwise]        Example: right");
            Console.WriteLine(" Report              [Outputs the robot's current location]  Example: report");
            Console.WriteLine("-----------------------------------------------------------------------------");
            
        }

        /// <summary>
        /// Demo moves
        /// </summary>
        private static void RobotDemo(Robot robot)
        {
            // Place the robot at (0, 0) facing North
            robot.Place(0, 0, Facing.NORTH.ToString());
            // Move the robot forward one unit
            robot.Move();
            robot.Report();

            // Turn the robot to the right
            robot.Place(0, 0, Facing.NORTH.ToString());
            // Turn the robot to the left
            robot.TurnLeft();
            robot.Report();

            // Place the robot at (1, 2) facing East
            robot.Place(1, 2, Facing.EAST.ToString());
            robot.Move();
            robot.Move();
            robot.TurnLeft();
            robot.Move();
            robot.Report();

            Console.WriteLine("Demo Completed");
            Console.WriteLine("Press any key to start manual Inputs.");
            Console.ReadKey();
        }
    }
}
