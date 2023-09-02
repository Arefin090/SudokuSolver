using System;
using System.IO;
using System.Collections.Generic;
using SplashKitSDK;
namespace SudokuSplashkit
{
    public class Program
    {
        public static void Main()
        {
            new Window("Sudoku", 1000, 740);
            Client client = new Client(new TableSet());
            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);
                client.Display();
                SplashKit.RefreshScreen(60);
            }
        }
    }

}