using TableTop_Robot.Common;
using TableTop_Robot.DTO;

namespace TableTop_Robot.Service
{

    public class Robot
    {
        private readonly int GridWidth;
        private readonly int GridHeight;

        private GridNode? _currentNode;
        private readonly TableGrids _grid;

        public GridNode? Get_currentNode()
        {
            return _currentNode;
        }

        public Robot(TableGrids grid)
        {
            _grid = grid;
            this.GridWidth = grid.GetGridWidth();
            this.GridHeight = grid.GetGridHeight();
            _currentNode = grid.GetNode(0, 0);
        }

        /// <summary>
        /// palce robot on grid
        /// </summary>
        /// <returns></returns>
        public bool Place(int x, int y, string facing)
        {
            //first check if the x and y are in side the grid limits
            if (x < 0 || x >= GridWidth || y < 0 || y >= GridHeight)
            {
                Console.WriteLine("Error: position is outside the grid [range 0-4]");
                return false;
            }

            var node = _grid.GetNode(x, y);
            if (node == null)
            {
                Console.WriteLine("Error: grid node not found [range 0-4]");
                return false;
            }

            if (!Enum.TryParse<Facing>(facing.ToUpper(), out var direction))
            {
                Console.WriteLine("Error: Invalid facing direction.");
                return false;
            }

            _currentNode = node;
            _currentNode.Facing = direction;

            Console.WriteLine("Success: Robot has been placed on the grid at("+ _currentNode.X.ToString() +", "+ _currentNode.Y.ToString() + ") facing " + _currentNode.Facing);
            

            return true;
        }

        /// <summary>
        /// moce the robot one step forward 
        /// </summary>
        public void Move()
        {
            if (_currentNode == null)
            {
                Console.WriteLine("Error: Place the robot the grid first");
                return;
            }

            GridNode? nextNode = null;
            switch (_currentNode.Facing)
            {
                case Facing.NORTH:
                    nextNode = _currentNode.North;
                    break;
                case Facing.SOUTH:
                    nextNode = _currentNode.South;
                    break;
                case Facing.EAST:
                    nextNode = _currentNode.East;
                    break;
                case Facing.WEST:
                    nextNode = _currentNode.West;
                    break;
            }

            if (nextNode == null)
            {
                Console.WriteLine("Move canceled: Robot is at the edge");
                return;
            }

            nextNode.Facing = _currentNode.Facing;
            _currentNode = nextNode;

            Console.WriteLine("Success: Robot moved forward facing " + _currentNode.Facing.ToString());
        }

        /// <summary>
        /// Turn the robot left
        /// </summary>
        public void TurnLeft()
        {
            if (_currentNode == null)
            {
                Console.WriteLine("Error: Place the robot the grid first");
                return;
            }

            switch (_currentNode.Facing)
            {
                case Facing.NORTH:
                    _currentNode.Facing = Facing.WEST;
                    break;
                case Facing.SOUTH:
                    _currentNode.Facing = Facing.EAST;
                    break;
                case Facing.EAST:
                    _currentNode.Facing = Facing.NORTH;
                    break;
                case Facing.WEST:
                    _currentNode.Facing = Facing.SOUTH;
                    break;
            }

            Console.WriteLine("Success: Turned left. Robot is now facing " + _currentNode.Facing.ToString());
        }

        /// <summary>
        /// Turn the robot right
        /// </summary>
        public void TurnRight()
        {
            if (_currentNode == null)
            {
                Console.WriteLine("Error: Place the robot the grid first");
                return;
            }

            switch (_currentNode.Facing)
            {
                case Facing.NORTH:
                    _currentNode.Facing = Facing.EAST;
                    break;
                case Facing.SOUTH:
                    _currentNode.Facing = Facing.WEST;
                    break;
                case Facing.EAST:
                    _currentNode.Facing = Facing.SOUTH;
                    break;
                case Facing.WEST:
                    _currentNode.Facing = Facing.NORTH;
                    break;
            }

            Console.WriteLine("Success: Tured right. Robot is now facing " + _currentNode.Facing.ToString());
        }


        /// <summary>
        /// Report current location 
        /// </summary>
        public void Report()
        {
            if (_currentNode == null)
            {
                Console.WriteLine("Error: Place the robot the grid first");
                return;
            }

            Console.WriteLine($"Output:  {_currentNode.X}, {_currentNode.Y},  {_currentNode.Facing}");
            //draw the grid on screen
            TableDrawer.Draw(GridHeight,GridWidth, _currentNode.X, _currentNode.Y, _currentNode.Facing);
        }

    }



}
