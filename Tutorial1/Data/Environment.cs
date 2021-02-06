using System;
using System.Collections.Generic;

namespace Tutorial1.Data
{
    public class Environment
    {
        public int RowsNumber { get; }
        public int ColumnsNumber { get; }

        private readonly BioUnit[,] _matrix;

        public Environment(int rowsNumber, int columnsNumber)
        {
            RowsNumber = rowsNumber;
            ColumnsNumber = columnsNumber;
            _matrix = new BioUnit[rowsNumber, columnsNumber];
            InitializeMatrix();
        }

        public void Live(int row, int column)
        {
            try
            {
                _matrix[row, column].Live();
            }
            catch (IndexOutOfRangeException)
            {
                // ignored
            }
        }

        public void Die(int row, int column)
        {
            try
            {
                _matrix[row, column].Die();
            }
            catch (IndexOutOfRangeException)
            {
                // ignored
            }
        }

        public bool IsAlive(int row, int column)
        {
            try
            {
                return _matrix[row, column].IsAlive();
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        private void InitializeMatrix()
        {
            for (var row = 0; row < RowsNumber; row++)
            {
                for (var column = 0; column < ColumnsNumber; column++)
                {
                    _matrix[row, column] = new BioUnit();
                }
            }
        }

        public void NextConwayStep()
        {
            var aux = new bool[RowsNumber, ColumnsNumber];

            for (var row = 0; row < RowsNumber; row++)
            {
                for (var col = 0; col < ColumnsNumber; col++)
                {
                    var aliveCount = AliveNeighborsCount(row, col);

                    if (aliveCount == 3 || aliveCount == 2 && IsAlive(row, col))
                    {
                        aux[row, col] = true;
                    }
                    else
                    {
                        aux[row, col] = false;
                    }
                }
            }

            for (var row = 0; row < RowsNumber; row++)
            {
                for (var col = 0; col < ColumnsNumber; col++)
                {
                    if (aux[row, col])
                    {
                        Live(row, col);
                    }
                    else
                    {
                        Die(row, col);
                    }
                }
            }
        }

        public int AliveNeighborsCount(int row, int col)
        {
            var count = 0;
            foreach (var point in NeighborPoints(row, col))
            {
                var currentRow = point.X;
                var currentCol = point.Y;
                bool alive;

                try
                {
                    alive = _matrix[currentRow, currentCol].IsAlive();
                }
                catch (IndexOutOfRangeException)
                {
                    alive = false;
                }

                if (alive)
                {
                    count++;
                }
            }

            return count;
        }

        private static IEnumerable<Point> NeighborPoints(int row, int col)
        {
            yield return new Point(row - 1, col - 1);
            yield return new Point(row - 1, col);
            yield return new Point(row - 1, col + 1);
            yield return new Point(row, col - 1);
            yield return new Point(row, col + 1);
            yield return new Point(row + 1, col - 1);
            yield return new Point(row + 1, col);
            yield return new Point(row + 1, col + 1);
        }
    }
}