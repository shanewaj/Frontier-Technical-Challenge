using TableTop_Robot.Common;
using TableTop_Robot.Service;

namespace TableTop_Robot.DTO
{
    public class GridNode
    {
        public int X { get; }
        public int Y { get; }
        public GridNode? North { get; set; }
        public GridNode? South { get; set; }
        public GridNode? East { get; set; }
        public GridNode? West { get; set; }
        public Facing Facing { get; internal set; }

        public GridNode(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
