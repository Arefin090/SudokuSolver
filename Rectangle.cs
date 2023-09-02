using System;
using SplashKitSDK;
namespace SudokuSplashkit
{
    public class Rectangle : Shape // Rectangle shape
    {
        public Rectangle() : this(0, 0, 0, 0, Color.White) { }
        public Rectangle(double x, double y, int width, int height, Color color) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }
        public override bool IsAt()
        {
            return SplashKit.MouseX() > X && SplashKit.MouseY() > Y && SplashKit.MouseX() < X + Width && SplashKit.MouseY() < Y + Height;
        }
    }
}

