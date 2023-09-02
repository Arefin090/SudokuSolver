using System;
namespace SudokuSplashkit
{
    // Reset The current table
    public class ClickReset : IClick
    {
        private ITableSet _set;
        public ClickReset(ITableSet set)
        {
            _set = set;
        }
        public void RunClick()
        {
            _set.Current.Reset();
        }
    }
}

