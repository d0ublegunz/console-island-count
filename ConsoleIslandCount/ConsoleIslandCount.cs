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
            var gridSize = grid.Length;
            var islandCount = 0;
            var visitedMap = new bool[gridSize, gridSize];

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    if (visitedMap[row,col])
                    {
                        continue;
                    }

                    islandCount += IslandMapper(row, col, grid, visitedMap);
                }
            }
            return islandCount;
        }

        private static int IslandMapper(int row, int col, bool[,] grid, bool[,] map)
        {
            int landFound = 0;

            return landFound;
        }
    }
}
