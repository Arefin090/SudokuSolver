using System;
namespace SudokuSplashkit
{
    // Go to Prev Problem 
    public class ClickPrev : IClick
    {
        private ITableSet _set;
        public ClickPrev(ITableSet collection)
        {
            _set = collection;
        }
        public void RunClick()
        {
            _set.ToPrev();
        }
    }
}

