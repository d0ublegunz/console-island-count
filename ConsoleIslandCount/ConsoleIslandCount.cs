using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIslandCount
{
/* sample input
10
XX--------
-X-----XX-
--XX---XXX
----------
---X------
---------X
--XX----X-
-XXX-----X
-XXXX-----
X---------

*/

    class ConsoleIslandCount
    {
        static void Main(string[] args)
        {
            //Read input: first line declares size of square grid
            //Remaining lines describe island layout. 'X' represent land
            int gridSize;
            if (!int.TryParse(Console.ReadLine(), out gridSize))
            {
                Console.WriteLine("Invalid grid size specified.");
                return;               
            }

            var landGrid = new bool[gridSize,gridSize];
            for (int i = 0; i < gridSize; i++)
            {
                var landRow = Console.ReadLine();
                for (int j = 0; j < gridSize; j++)
                {
                    landGrid[i, j] = 'X' == landRow[j]; 
                }
            }

            Console.WriteLine($"{IslandCount(landGrid)} islands detected.");
            Console.Write("Press enter to complete process.");
            Console.ReadLine();
        }

        public static int IslandCount(bool [,] grid)
        {
            var gridSize = (int)Math.Sqrt(grid.Length);
            var islandCount = 0;
            var visitedMap = new bool[gridSize, gridSize];

            for (var row = 0; row < gridSize; row++)
            {
                for (var col = 0; col < gridSize; col++)
                {
                    if (visitedMap[row,col])
                    {
                        continue;
                    }

                    if (IslandMapper(new Coordinate(row,col), grid, visitedMap, gridSize))
                    {
                        ++islandCount;
                    }
                }
            }
            return islandCount;
        }

        private static bool IslandMapper(Coordinate position, bool[,] grid, bool[,] map, int size)
        {
            var landHo = grid[position.Row, position.Column];
            map[position.Row, position.Column] = true;
            if (!landHo)
            {
                return landHo;
            }

            var parimeter = DefineParimeter(position, size);
            foreach (var coordinate in parimeter.Where(p => !map[p.Row, p.Column]))
            {
                IslandMapper(coordinate, grid, map, size);
            }

            return landHo;
        }

        public static List<Coordinate> DefineParimeter(Coordinate center, int size)
        {
            var coordinates = new List<Coordinate>();

            for (var xPos = center.Row - 1; xPos < (center.Row + 2); xPos++)
            {
                //bounds check
                if (xPos < 0 || xPos >= size)
                {
                    continue;
                }

                for (var yPos = center.Column -1; yPos < (center.Column + 2); yPos++)
                {
                    //bounds and center check 
                    if (yPos < 0 || yPos >= size || (xPos == center.Row && yPos == center.Column ))
                    {
                        continue;
                    }

                    coordinates.Add(new Coordinate(xPos, yPos));
                }
            }

            return coordinates;
        }
    }
    

    public class Coordinate
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Coordinate(int row, int col)
        {
            Row = row;
            Column = col;
        }   
    }
}
