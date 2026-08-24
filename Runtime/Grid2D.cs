using System;
using System.Collections.Generic;

namespace Splindeman.UnityCommon
{
    /// <summary>
    /// Fixed-size rectangular grid of cells, indexed by (col, row) from
    /// (0, 0) up to (Width - 1, Height - 1). Game-agnostic -- doesn't know
    /// or care what T represents.
    /// </summary>
    public class Grid2D<T>
    {
        public int Width { get; }
        public int Height { get; }

        private readonly T[] _cells;

        public Grid2D(int width, int height)
        {
            if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width));
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));
            Width = width;
            Height = height;
            _cells = new T[width * height];
        }

        public bool IsInBounds(int col, int row) =>
            col >= 0 && col < Width && row >= 0 && row < Height;

        public T this[int col, int row]
        {
            get
            {
                CheckBounds(col, row);
                return _cells[row * Width + col];
            }
            set
            {
                CheckBounds(col, row);
                _cells[row * Width + col] = value;
            }
        }

        private void CheckBounds(int col, int row)
        {
            if (!IsInBounds(col, row))
                throw new ArgumentOutOfRangeException(
                    nameof(col), $"({col}, {row}) is outside the {Width}x{Height} grid.");
        }

        /// <summary>Up/down/left/right neighbors that exist on the grid.</summary>
        public IEnumerable<(int col, int row)> GetOrthogonalNeighbors(int col, int row)
        {
            if (IsInBounds(col - 1, row)) yield return (col - 1, row);
            if (IsInBounds(col + 1, row)) yield return (col + 1, row);
            if (IsInBounds(col, row - 1)) yield return (col, row - 1);
            if (IsInBounds(col, row + 1)) yield return (col, row + 1);
        }
    }
}
