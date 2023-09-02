using System;
using SplashKitSDK;
namespace SudokuSplashkit
{
    public class InputCell : Cell // Input cell accepts the input from user
    {
        public InputCell(double x, double y, int size) : base(x, y, size)
        {
            Color = Color.White;
        }
        public override bool IsTouched => true;
        public override void Reset()
        {
            Val = 0;
        }
    }
}

