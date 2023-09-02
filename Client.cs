using System;
using System.Collections.Generic;
using SplashKitSDK;
using System.IO;
namespace SudokuSplashkit
{
    // Client Control every event in the gam,e
    public class Client
    {
        private ITableSet _set;
        private List<Button> _buttons;
        private Timer _timer;
        private int _count;
        public Client(ITableSet set)
        {
            _set = set;
            _buttons = new List<Button>();
            _buttons.Add(new Button(new Rectangle(), new ClickNext(_set), "Next"));
            _buttons.Add(new Button(new Rectangle(), new ClickPrev(_set), "Prev"));
            _buttons.Add(new Button(new Rectangle(), new ClickReset(_set), "Reset"));
            _buttons.Add(new Button(new Rectangle(), new ClickSolve(_set), "Solve"));
            
            SetUpButtons();
            _timer = new Timer("my timer");
        }
        private void SetUpButtons() // Set up the buttons
        {
            double offsetX = 800;
            double offsetY = 300;
            int width = 150;
            int height = 60;
            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].Shape.X = offsetX;
                _buttons[i].Shape.Y = offsetY + 80 * i;
                _buttons[i].Shape.Width = width;
                _buttons[i].Shape.Height = height;
            }
        }
        public void DisplaySolutionCheck() // Display checkmark if the solution is correct  
        {
            Bitmap checkmark;
            double x = 825;
            double y = 100;
            if (_set.Current.SolutionCheck())
            {
                checkmark = new Bitmap("tick", "check.png");
                _timer.Pause(); // If solution is correct then pause the timer
            }
            else
            {
                checkmark = new Bitmap("fail", "multiply.png");
            }
            checkmark.Draw(x,y);
        }
        public void Display()
        {
            _set.Display();
            
            foreach (Button button in _buttons)
            {
                button.Display();
                button.Hover();
                button.Click();            
            }
            if (SplashKit.KeyDown(KeyCode.PKey))
            {
                _timer.Start(); // Start the timer
            }
            if (SplashKit.KeyDown(KeyCode.RKey))
            {
                _timer.Reset(); // Reset the timer
            }
            SplashKit.DrawText($"{_timer.Ticks / 1000}", Color.White, Constants.Font, 30,912,12); // Draw the Ticks of timer
            DisplaySolutionCheck();
        }
    }
}

