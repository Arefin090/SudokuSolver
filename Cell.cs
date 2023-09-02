using SplashKitSDK;
namespace SudokuSplashkit
{
    // Abstract Cell
    public abstract class Cell
    {
        private double _x;
        private double _y;
        private int _size;
        private int _val;
        private Color _color;
        public Cell(double x, double y, int size)
        {
            _x = x;
            _y = y;
            _size = size;
            _val = 0;
            _color = Color.White;
        }
        public bool IsAt() // Check if Mouse is over the cell
        {
            return (SplashKit.MouseX() > _x && SplashKit.MouseY() > _y && SplashKit.MouseX() < _x + _size && SplashKit.MouseY() < _y + _size);
        }
        public int Val // Value in the cell
        {
            get { return _val; }
            set { _val = value; }
        }
        public abstract bool IsTouched { get; }
        public abstract void Reset(); // Reset the Cell
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public void Display()
        { 
            SplashKit.FillRectangle(Color, _x, _y, _size, _size);
            if (Val != 0)
            {
                Constants constants = new Constants();
                SplashKit.DrawText($"{Val}", Color.Black, Constants.Font, 40, _x + 30, _y + 15);
            }
        }
    }
}

