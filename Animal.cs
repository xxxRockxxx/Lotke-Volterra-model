using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame_wolfVsSheep_
{
    class Animal
    {
        protected static int[,] _Matrix;
        protected static int[,] _DoubleMatrix;
        protected static int _LengthX;
        protected static int _LengthY;
        protected static Dictionary<int, Sheeps> sheeps = new Dictionary<int, Sheeps>();
        protected static Dictionary<int, Wolfs> wolfs = new Dictionary<int, Wolfs>();
        protected static int Id;
        private Random rnd = new();
        private int _direction_of_travel;
        protected int _x;
        protected int _y;

        public void GenerationFiled(int NumberAnimals)
        {
            _LengthX = _LengthY = NumberAnimals * 2;
            _Matrix = new int[_LengthX, _LengthY];
            _DoubleMatrix = new int[_LengthX + 2, _LengthY + 2];
            for (int i = 0; i < _Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _Matrix.GetLength(1); j++)
                {
                    _Matrix[i, j] = 0;
                }
            }
            for (int i = 0; i < _DoubleMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _DoubleMatrix.GetLength(1); j++)
                {
                    _DoubleMatrix[i, j] = 0;
                }
            }
        }

        protected void GenerationAnimal(string nameAnimal, int numberAnimal)
        {
            Random rnd = new Random();
            int count = 0;
            int x;
            int y;
            Id++;
            while (count < numberAnimal)
            {
                x = rnd.Next(0, _LengthX);
                y = rnd.Next(0, _LengthY);
                if (_Matrix[y, x] == 0)
                {
                    _Matrix[y, x] =Id;
                    count++;
                    if (nameAnimal == "S")
                    {
                        Sheeps S = new Sheeps();
                        sheeps.Add(Id, S);
                    }
                    else
                    {
                        Wolfs W = new Wolfs();
                        wolfs.Add(Id, W);
                    }
                    Id++;
                }
            }
        }

        protected void SeachForMove(string NameAnimal)
        {
            if (NameAnimal == "S")
            {
                foreach(var el in sheeps)
                {
                    int ID = el.Key;
                    Move(ID);
                }
            }
            else
            {
                foreach(var el in wolfs)
                {
                    int ID = el.Key;
                    Move(ID);
                    wolfs[ID].Health--;
                }
            }
        }

        private void Move(int ID)
        {
            for (int i = 0; i < _Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _Matrix.GetLength(1); j++)
                {
                    if (_Matrix[i, j] == ID)
                    {
                        while (_Matrix[i, j] == ID)
                        {
                            _y = i;
                            _x = j;
                            GenerateNumber();
                            ChooseMotion();
                            if (((_x >= 0 & _x <= (_LengthX - 1)) & (_y >= 0 & _y <= (_LengthY - 1)) && _Matrix[_y, _x] == 0))
                            {
                                _Matrix[_y, _x] = ID;
                                _Matrix[i, j] = 0;
                            }
                        }
                    }
                }
            }
        }

        protected void CopyMatrix()
        {
            for (int i = 0; i < _Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _Matrix.GetLength(1); j++)
                {
                    _DoubleMatrix[i + 1, j + 1] = _Matrix[i, j];
                }
            }
        }

        protected void ClearDoubleMatrix()
        {
            for (int i = 0; i < _Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _Matrix.GetLength(1); j++)
                {
                    _DoubleMatrix[i , j ] = 0;
                }
            }
        }

        public void Draw()
        {
            Matrix d = new Matrix();
            d.DrawMatrix(_Matrix,wolfs,sheeps,_LengthX);
        }

        protected void GenerateNumber()
        {
            _direction_of_travel = rnd.Next(0, 8);
        }

        protected void ChooseMotion()
        {
            switch (_direction_of_travel)
            {
                case 0:
                    _y--;
                    break;
                case 1:
                    _y++;
                    break;
                case 2:
                    _x--;
                    break;
                case 3:
                    _x++;
                    break;
                case 4:
                    _x++;
                    _y++;
                    break;
                case 5:
                    _y++;
                    _x--;
                    break;
                case 6:
                    _x--;
                    _y--;
                    break;
                case 7:
                    _x++;
                    _y--;
                    break;
            }
        }
    }
}
