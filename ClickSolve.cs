using System;
namespace SudokuSplashkit
{
    // Solve the puzzle
    public class ClickSolve:IClick
    {
        private ITableSet _collection;
        public ClickSolve(ITableSet collection)
        {
            _collection = collection;
        }
        public void RunClick()
        {
            _collection.TriggerSolver();
        }
    }
}

