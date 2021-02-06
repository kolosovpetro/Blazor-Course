using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemBasedCase1.Data
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
            //InitializeMatrix();
        }

        public void Live(int row, int column)
        {
            try
            {
                _matrix[row, column].Live();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void Die(int row, int column)
        {
            try
            {
                _matrix[row, column].Die();
            }
            catch (Exception)
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
            catch (Exception)
            {
                return false;
            }
        }

        public void InitializeMatrix()
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

        private int AliveNeighborsCount(int row, int col)
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
                catch (Exception)
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

        public IEnumerable<BioUnit> NeighborsList(int row, int col)
        {
            foreach (var point in NeighborPoints(row, col))
            {
                var unit = GetBioUnit(point.X, point.Y);

                if (unit != null)
                {
                    yield return unit;
                }
            }
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

        // From problem based case 1

        public void Insert(BioUnit unit)
        {
            try
            {
                _matrix[unit.Position.X, unit.Position.Y] = unit;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public BioUnit GetBioUnit(int row, int col)
        {
            try
            {
                return _matrix[row, col];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<BioUnit> SurroundingNeighbors(int row, int col, Type type)
        {
            return NeighborsList(row, col).Where(x => x.GetType() == type);
        }

        private Rabbit FirstRabbit(int row, int col)
        {
            return SurroundingNeighbors(row, col, typeof(Rabbit)).FirstOrDefault() as Rabbit;
        }

        public void NextRabbitCarrotStep()
        {
            var aux = new BioUnit[RowsNumber, ColumnsNumber];

            for (var row = 0; row < RowsNumber; row++)
            {
                for (var col = 0; col < ColumnsNumber; col++)
                {
                    aux[row, col] = null;

                    var current = _matrix[row, col];

                    if (current != null && current.GetType() == typeof(Carrot))
                    {
                        if (!SurroundingNeighbors(row, col, typeof(Rabbit)).Any())
                        {
                            if (current.WillILive())
                            {
                                aux[row, col] = current;
                            }
                        }
                        else
                        {
                            FirstRabbit(row, col).Eat();
                        }
                    }

                    else if (current != null && current.GetType() == typeof(Rabbit))
                    {
                        if (current.WillILive())
                        {
                            aux[row, col] = current;
                        }
                    }

                    if (SurroundingNeighbors(row, col, typeof(Rabbit)).Count() >= 2)
                    {
                        aux[row, col] = new Rabbit(row, col, this);
                    }
                    else if (SurroundingNeighbors(row, col, typeof(Carrot)).Count() >= 3)
                    {
                        aux[row, col] = new Carrot(row, col, this);
                    }
                }
            }

            for (var row = 0; row < RowsNumber; row++)
            {
                for (var col = 0; col < ColumnsNumber; col++)
                {
                    _matrix[row, col] = aux[row, col];
                }
            }
        }
    }
}