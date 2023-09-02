using System;
namespace SudokuSplashkit
{
    public class Solver:ISolver // Implementation the sudoku solver
    {
        private ITableSet _set;
        public Solver(ITableSet set)
        {
            _set = set;
        }
        private bool IsDuplicate(int row, int col, int num)
        {
            for(int i = 0; i < _set.Current.Size; i++)
            {
                if (_set.Current.Grid[row, i].Val == num) return false;
            }
            for (int i = 0; i < _set.Current.Size; i++)
            {
                if (_set.Current.Grid[i,col].Val == num) return false;
            }
            int subgrid = 3;
            int startRow = row - row % 3, startCol
                              = col - col % 3;
            for (int i = 0; i < subgrid; i++)
            {
                for(int j = 0; j < subgrid; j++)
                {
                    if (_set.Current.Grid[startRow + i, startCol + j].Val == num) return false;
                }
            }
            return true;
        }
        // Implementing Bitwise technique to solve sudoku problem
        public bool Solve(int row, int col)
        {
            if (row == 0 && col == 0)
            {
                _set.Current.Reset();
            }
            int size = _set.Current.Size;
            if (row == size - 1 && col == size) 
                return true;
            if (col == size)
            {
                row++;
                col = 0;
            }
            if (_set.Current.Grid[row, col].Val != 0)
                return Solve(row, col + 1);

            for (int num = 1; num < 10; num++)
            {

                // Check if it is safe to place
                // the num (1-9)  in the
                // given row ,col ->we move to next column
                if (IsDuplicate(row, col, num))
                {

                    /*  assigning the num in the current
                            (row,col)  position of the _set.Current and
                            assuming our assigned num in the
                       position is correct */
                    _set.Current.Grid[row, col].Val = num;

                    // Checking for next
                    // possibility with next column
                    if (Solve(row, col + 1))
                        return true;
                }
                /* removing the assigned num , since our
                         assumption was wrong , and we go for
                   next assumption with diff num value   */
                _set.Current.Grid[row, col].Val = 0;
            }
            return false;
        }
    }
}

