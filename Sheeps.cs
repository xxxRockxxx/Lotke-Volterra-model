using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame_wolfVsSheep_
{
    class Sheeps : Animal
    {
        private static int count;
        public string Name = "S";
        private static Dictionary<int, Sheeps> Newsheeps = new Dictionary<int, Sheeps>();


        public void GenerationSheepinMatrix(int numberSheeps)
        {
            GenerationAnimal(Name, numberSheeps);
        }

        public void MoveSheeps()
        {
            SeachForMove(Name);
            count++;
            if (count == 4)
            {
                Multiply();
                count = 0;
            }
        }

        private void Multiply()
        {
            CopyMatrix();
            foreach (var el in sheeps)
            {
                for (int i = 1; i < _Matrix.GetLength(0); i++)
                {
                    for (int j = 1; j < _Matrix.GetLength(1); j++)
                    {

                        if (_DoubleMatrix[i,j] == el.Key)
                        {
                            if ((_DoubleMatrix[i - 1,j - 1]==0 || sheeps.ContainsKey(_DoubleMatrix[i - 1, j - 1])) & (_DoubleMatrix[i - 1, j ] == 0 || sheeps.ContainsKey(_DoubleMatrix[i - 1, j ])) 
                                & (_DoubleMatrix[i - 1, j + 1] == 0 || sheeps.ContainsKey(_DoubleMatrix[i - 1, j + 1])) & (_DoubleMatrix[i , j - 1]==0 || sheeps.ContainsKey(_DoubleMatrix[i , j - 1])) 
                                &(_DoubleMatrix[i , j + 1] == 0 || sheeps.ContainsKey(_DoubleMatrix[i, j + 1])) & (_DoubleMatrix[i+1, j - 1]==0 || sheeps.ContainsKey(_DoubleMatrix[i+1, j - 1])) 
                                & (_DoubleMatrix[i+1, j ] == 0 || sheeps.ContainsKey(_DoubleMatrix[i + 1, j])) & (_DoubleMatrix[i + 1, j+1] == 0|| sheeps.ContainsKey(_DoubleMatrix[i + 1, j + 1])))
                            {
                                bool stop = true;
                                while (stop)
                                {
                                    _y = i;
                                    _x = j;
                                    GenerateNumber();
                                    ChooseMotion();
                                    if (((_x >= 0 & _x <= (_LengthX - 1)) & (_y >= 0 & _y <= (_LengthY - 1)) && _Matrix[_y, _x] == 0))
                                    {
                                        Id++;
                                        _Matrix[_y, _x] = Id;
                                        Sheeps S = new Sheeps();
                                        Newsheeps.Add(Id, S);
                                        stop = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            sheeps = sheeps.Union(Newsheeps).ToDictionary(x => x.Key, x => x.Value);
            Newsheeps.Clear();
            ClearDoubleMatrix();
        }
    } 
}
