
using System;
using System.Collections.Generic;
using System.IO;
using SplashKitSDK;
namespace SudokuSplashkit
{
    public class TableSet : ITableSet // Set of the table and control the solver of current table
    {
        private List<TableBuilder> _tableList;
        private int _cur;
        private ISolver _solver;
        public TableSet()
        {
            _tableList = new List<TableBuilder>();
            _cur = 0;
            LazyInit();
            _solver = new Solver(this);
        }
        public void TriggerSolver()
        {
            int start = 0;
            if (_solver.Solve(start, start))
            {
                return;
            }
        }
        private void LazyInit()
        {
            StreamReader reader = new StreamReader("Problems.txt");
            try
            {
                int num = Convert.ToInt32(reader.ReadLine());
                for (int i = 0; i < num; i++)
                {
                    TableBuilder table = new TableBuilder(82, 82);
                    table.SetRow(reader);
                    _tableList.Add(table);
                }
            }
            finally
            {
                reader.Close();
            }
        }
        public TableBuilder Current => _tableList[_cur];
        public int CurrentIndex => _cur;
        public void Display()
        {
            _tableList[_cur].Display();
            if (SplashKit.KeyDown(KeyCode.Num1Key)){
                _tableList[_cur].AddNumber(1);
            }
            if (SplashKit.KeyDown(KeyCode.Num2Key))
            {
                _tableList[_cur].AddNumber(2);
            }
            if (SplashKit.KeyDown(KeyCode.Num3Key))
            {
                _tableList[_cur].AddNumber(3);
            }
            if (SplashKit.KeyDown(KeyCode.Num4Key))
            {
                _tableList[_cur].AddNumber(4);
            }
            if (SplashKit.KeyDown(KeyCode.Num5Key))
            {
                _tableList[_cur].AddNumber(5);
            }
            if (SplashKit.KeyDown(KeyCode.Num6Key))
            {
                _tableList[_cur].AddNumber(6);
            }
            if (SplashKit.KeyDown(KeyCode.Num7Key))
            {
                _tableList[_cur].AddNumber(7);
            }
            if (SplashKit.KeyDown(KeyCode.Num8Key))
            {
                _tableList[_cur].AddNumber(8);
            }
            if (SplashKit.KeyDown(KeyCode.Num9Key))
            {
                _tableList[_cur].AddNumber(9);
            }
        }
        public void ToNext()
        {
            if (_cur == _tableList.Count - 1)
            {
                _cur = 0;
            }
            else
            {
                _cur += 1;
            }
            Console.WriteLine(_tableList.Count);
        }
        public void ToPrev()
        {
            if (_cur == 0)
            {
                _cur = _tableList.Count - 1;
            }
            else
            {
                _cur -= 1;
            }
        }
    }
}

