using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame_wolfVsSheep_
{
    class Matrix
    {
        private static string[,] _Matrix;
        private static int count;
        public void DrawMatrix(int[,] Matrix, Dictionary<int, Wolfs> W, Dictionary<int, Sheeps> S,int LengthXandY)
        {
            if (count == 0)
            {
                GenerateMatrix(LengthXandY);
                count++;
            }
            Console.Clear();
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (Matrix[i, j] != 0)
                    {
                        if (W.ContainsKey(Matrix[i, j]))
                        {
                            _Matrix[i, j] = W[Matrix[i, j]].Name;
                        }
                        else
                        {
                            _Matrix[i, j] = S[Matrix[i, j]].Name;
                        }
                    }
                    else
                    {
                        _Matrix[i, j] = "0";
                    }
                    Console.Write(_Matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private void GenerateMatrix(int Length)
        {
            _Matrix = new string[Length, Length];
            for (int i = 0; i < _Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _Matrix.GetLength(1); j++)
                {
                    _Matrix[i, j] = "0";
                }
            }
        }
    }
}
