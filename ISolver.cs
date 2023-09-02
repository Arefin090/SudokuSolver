using System;
namespace SudokuSplashkit
{
    public interface ISolver // Solver
    {
        public bool Solve(int row, int col);
    }
}

