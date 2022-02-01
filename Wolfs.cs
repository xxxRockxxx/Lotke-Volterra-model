using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame_wolfVsSheep_
{
    class Wolfs : Animal
    {
        public string Name = "W";
        public int Health = 4;
        private static Dictionary<int, Wolfs> NewWolfs = new Dictionary<int, Wolfs>();

        public void GenerationWolfsinMatrix(int numberWolfs)
        {
            GenerationAnimal(Name, numberWolfs);
        }

        public void MoveWolfs()
        {
            SeachForMove(Name);
            CheckHealth();
            Multiply();
        }

        private void CheckHealth()
        {
            foreach (var el in wolfs)
            {
                int k = el.Key;
                if (wolfs[k].Health == 0)
                {
                    for (int i = 0; i < _Matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < _Matrix.GetLength(1); j++)
                        {
                            if (_Matrix[i, j] == k) _Matrix[i, j] = 0;
                        }
                    }
                    wolfs.Remove(k);
                }
            }
        }

        private void Multiply()
        {
            CopyMatrix();
            foreach (var el in wolfs)
            {
                for (int i = 1; i < _Matrix.GetLength(0); i++)
                {
                    for (int j = 1; j < _Matrix.GetLength(1); j++)
                    {

                        if (_DoubleMatrix[i, j] == el.Key)
                        {
                            if (sheeps.ContainsKey(_DoubleMatrix[i - 1, j - 1]) ||  sheeps.ContainsKey(_DoubleMatrix[i - 1, j])
                               || sheeps.ContainsKey(_DoubleMatrix[i - 1, j + 1])|| sheeps.ContainsKey(_DoubleMatrix[i, j - 1])
                               || sheeps.ContainsKey(_DoubleMatrix[i, j + 1]) || sheeps.ContainsKey(_DoubleMatrix[i + 1, j - 1])
                               || sheeps.ContainsKey(_DoubleMatrix[i + 1, j]) || sheeps.ContainsKey(_DoubleMatrix[i + 1, j + 1]))
                            {
                                bool stop = true;
                                while (stop)
                                {
                                    _y = i;
                                    _x = j;
                                    GenerateNumber();
                                    ChooseMotion();
                                    if (((_x >= 0 & _x <= (_LengthX - 1)) & (_y >= 0 & _y <= (_LengthY - 1))) && sheeps.ContainsKey(_Matrix[_y, _x]))
                                    {
                                        Id++;
                                        _Matrix[_y, _x] = Id;
                                        Wolfs W = new Wolfs();
                                        NewWolfs.Add(Id, W);
                                        stop = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            wolfs = wolfs.Union(NewWolfs).ToDictionary(x => x.Key, x => x.Value);
            NewWolfs.Clear();
            ClearDoubleMatrix();
        }
    }
 }


