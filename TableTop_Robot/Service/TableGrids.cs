using TableTop_Robot.DTO;

namespace TableTop_Robot.Service
{
    public class TableGrids
    {
        private readonly int GridWidth;
        private readonly int GridHeight;

        private readonly GridNode[,] _gridNodes;

        public int GetGridHeight()
        {
            return GridHeight;
        }

        public int GetGridWidth()
        {
            return GridHeight;
        }
        public GridNode? GetNode(int x, int y)
        {
            if (x < 0 || x >= GridWidth || y < 0 || y >= GridHeight)
            {
                return null;
            }
            return _gridNodes[x, y];
        }

        /// <summary>
        /// Create the table grid
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public TableGrids(int maxHeight, int maxWidth)
        {
            GridHeight = maxHeight;
            GridWidth = maxWidth;

            _gridNodes = new GridNode[GridWidth, GridHeight];
            CreateGridNodes();
            LinkGridNodes();
        }

        /// <summary>
        /// Create all the nodes required for the grid
        /// </summary>
        private void CreateGridNodes()
        {
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    _gridNodes[x, y] = new GridNode(x, y);
                }
            }
        }

        /// <summary>
        /// link grid nodes according to its position 
        /// </summary>
        private void LinkGridNodes()
        {
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    if (y > 0) _gridNodes[x, y].South = _gridNodes[x, y - 1];
                    if (y < GridHeight - 1) _gridNodes[x, y].North = _gridNodes[x, y + 1];
                    if (x > 0) _gridNodes[x, y].West = _gridNodes[x - 1, y];
                    if (x < GridWidth - 1) _gridNodes[x, y].East = _gridNodes[x + 1, y];
                }
            }
        }



    }

}
