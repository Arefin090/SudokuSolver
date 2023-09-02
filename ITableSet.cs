using System;
namespace SudokuSplashkit
{
    public interface ITableSet // Set of table
    {
        public void Display();
        public void ToNext();
        public void ToPrev();
        public void TriggerSolver();
        public TableBuilder Current { get; }
        public int CurrentIndex { get; }
    }
}

