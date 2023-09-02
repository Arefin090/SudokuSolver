using System;
using System.IO;
using System.Collections.Generic;
namespace SudokuSplashkit
{
    public class TableBuilder // Builder pattern to build the table
    {
        private double _offsetX;
        private double _offsetY;
        private Cell[,] _grid;
        private int _size;
        public TableBuilder(double offsetX, double offsetY)
        {
            _offsetX = offsetX;
            _offsetY = offsetY;
            _size = 9;
            _grid = new Cell[9, 9];
        }
        public Cell[,] Grid => _grid;
        public void SetColumn(StreamReader reader, int row)
        {
            string[] line = reader.ReadLine().Split(',');
            for (int i = 0; i < _size; i++)
            {
                int num = Convert.ToInt32(line[i]);
                if (num == 0)
                {
                    _grid[row, i] = new InputCell(_offsetX * i, _offsetY * row, 80);
                }
                else
                {
                    _grid[row, i] = new BlockCell(_offsetX * i, _offsetY * row, 80, num);
                }
            }
        }
        public void SetRow(StreamReader reader)
        {
            for (int row = 0; row < _size; row++)
            {
                SetColumn(reader, row);
            }
        }
        public void Reset()
        {
            foreach(Cell c in _grid)
            {
                c.Reset();
            }
        }
        public void AddNumber(int num)
        {
            foreach (Cell c in _grid)
            {
                if (c.IsAt() && c.IsTouched)
                {
                    c.Val = num;
                }
            }
        }
        public bool IsFull()
        {
            foreach(Cell c in Grid)
            {
                if (c.Val == 0) return false;
            }
            return true;
        }
        public bool SolutionCheck()
        {
            HashSet<string> _check = new HashSet<string>();
            for(int i = 0; i < _size; i++)
            {
                for(int j = 0; j < _size; j++)
                {
                    string subgrid = $"found {Grid[i,j].Val} in subgrid row{i-i%3}-col{j-j%3}";
                    string row = $"found {Grid[i,j].Val} in row{i}";
                    string col = $"found {Grid[i,j].Val} in col{j}";
                    if(_check.Contains(subgrid) || _check.Contains(row) || _check.Contains(col) || _grid[i,j].Val == 0)
                    {
                        return false;
                    }
                    _check.Add(subgrid);
                    _check.Add(row);
                    _check.Add(col);
                }
            }
            return true;
        }
        public int Size => _size;
        public void Display()
        {
            foreach (Cell c in _grid)
            {
                c.Display();
            }
        }
    }
}

