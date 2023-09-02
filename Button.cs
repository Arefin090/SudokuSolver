using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace SudokuSplashkit
{
    // Button in the game
    public class Button
    {
        private Shape _shape;
        private IClick _click;
        private string _msg;
        private Font _font;
        public Button(Shape shape, IClick click, string msg)
        {
            _shape = shape;
            _click = click;
            _msg = msg;
            _font = Constants.Font;
        }
        public void Display()
        {
            _shape.Draw();
            SplashKit.DrawText(_msg, Color.Black, _font, 30, _shape.X, _shape.Y);
        }
        public Shape Shape
        {
            get => _shape;
        }
        public void Click() // Click
        {
            if(Shape.IsAt() && SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                _click.RunClick();
            }
        }
        public void Hover() // Hover effect
        {
            if (_shape.IsAt())
            {
                int margin = 5;
                double boxX = _shape.X - margin;
                double boxY = _shape.Y - margin;
                SplashKit.DrawRectangle(Color.AliceBlue, boxX, boxY, _shape.Width + margin * 2, _shape.Height + margin * 2);
            }
        }
    }
}

