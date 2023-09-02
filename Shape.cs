using System;
using SplashKitSDK;
namespace SudokuSplashkit
{
    public abstract class Shape // Abstract Shape to draw artwork
    {
        private double _x;
        private double _y;
        private int _width;
        private int _height;
        private Color _color;
        public Shape(Color color)
        {
            _x = 0;
            _y = 0;
            _width = 0;
            _height = 0;
            _color = color;
        }
        public abstract void Draw();
        public abstract bool IsAt();
        public double X
        {
            get => _x;
            set => _x = value;
        }
        public double Y
        {
            get => _y;
            set => _y = value;
        }
        public int Width
        {
            get => _width;
            set => _width = value;
        }
        public int Height
        {
            get => _height;
            set => _height = value;
        }
        public Color Color
        {
            get => _color;
            set => _color = value;
        }
    }
}

