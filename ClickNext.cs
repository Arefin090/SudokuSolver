using System;
namespace SudokuSplashkit
{
    // Go to next problem
    public class ClickNext : IClick
    {
        private ITableSet _set;
        public ClickNext(ITableSet set)
        {
            _set = set;
        }
        public void RunClick()
        {
            _set.ToNext();
        }
    }
}

