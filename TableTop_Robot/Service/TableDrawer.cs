using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTop_Robot.Common;

namespace TableTop_Robot.Service
{
    public static class TableDrawer
    {
        /// <summary>
        /// Draw Table Grid on Screen
        /// </summary>
        /// <param name="TableHeight">Grid Max Height</param>
        /// <param name="TableWidth">Grid Max Width</param>
        /// <param name="robotX">Robot X Cordinate</param>
        /// <param name="robotY">Robot Y Cordinate</param>
        /// <param name="robotFacing">Robot Facing Direction</param>
        public static void Draw(int TableHeight, int TableWidth, int robotX, int robotY, Common.Facing robotFacing)
        {
            // Define the size of each cell in the grid
            int CellWidth = TableWidth - 1;

            //to start calculating from left down 
            robotY = (TableHeight - 1 - robotY);

            // Draw the top border of the grid
            Console.Write("+");
            for (int x = 0; x < TableWidth; x++)
            {
                Console.Write(new string('-', CellWidth) + "+");
            }
            Console.WriteLine();

            // Draw each row of the grid
            for (int y = 0; y < TableHeight; y++)
            {
                // Draw the left border of the row
                Console.Write("|");
                for (int x = 0; x < TableWidth; x++)
                {
                    // Draw the contents of the cell
                    if (x == robotX && y == robotY)
                    {
                        // Draw the arrow in the current cell
                        Console.Write(new string(' ', (CellWidth - 1) / 2) + GetSymbol(robotFacing) + " " + new string(' ', CellWidth / 2 - 1) + "|");
                    }
                    else
                    {
                        Console.Write(new string(' ', CellWidth) + "|");
                    }
                }
                Console.WriteLine();

                // Draw the top border of the next row
                Console.Write("+");
                for (int x = 0; x < TableWidth; x++)
                {
                    Console.Write(new string('-', CellWidth) + "+");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Get correct symbol to show on screen
        /// </summary>
        /// <param name="robotFacing">Direction</param>
        /// <returns></returns>
        private static char GetSymbol(Facing robotFacing)
        {
            return robotFacing switch
            {
                Facing.NORTH => (char)30,
                Facing.SOUTH => (char)31,
                Facing.EAST => (char)16,
                Facing.WEST => (char)17,
                _ => (char)002,
            };
        }
    }
}
