using System.Collections.Generic;

namespace GameDev.UnityCommon
{
    public static class GridFloodFill
    {
        /// <summary>
        /// Breadth-first search over orthogonal neighbors starting at
        /// (startCol, startRow), expanding into any neighbor cell for which
        /// includeCell returns true. The start cell is always included,
        /// without being tested against includeCell.
        /// </summary>
        public static HashSet<(int col, int row)> FindConnectedRegion<T>(
            Grid2D<T> grid, int startCol, int startRow,
            System.Func<int, int, bool> includeCell)
        {
            var region = new HashSet<(int, int)> { (startCol, startRow) };
            var frontier = new Queue<(int, int)>();
            frontier.Enqueue((startCol, startRow));

            while (frontier.Count > 0)
            {
                var (col, row) = frontier.Dequeue();
                foreach (var (nCol, nRow) in grid.GetOrthogonalNeighbors(col, row))
                {
                    if (region.Contains((nCol, nRow))) continue;
                    if (!includeCell(nCol, nRow)) continue;
                    region.Add((nCol, nRow));
                    frontier.Enqueue((nCol, nRow));
                }
            }
            return region;
        }
    }
}
