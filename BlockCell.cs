using System;
using SplashKitSDK;
namespace SudokuSplashkit
{
    // Default Cell
    public class BlockCell : Cell
    {
        public BlockCell(double x, double y, int size, int val) : base(x, y, size)
        {
            Val = val;
            Color = Color.AliceBlue;
        }
        // Default Cell will be untouchable
        public override bool IsTouched => false;
        public override void Reset() { }
    }

}

