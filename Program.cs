using System;

namespace TestGame_wolfVsSheep_
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            //animal.GenerationFiled(2);
            //animal.GenerationAnimal();
            Sheeps sheep = new Sheeps();
            Wolfs wolfs = new Wolfs();
            int numberSheeps = int.Parse(Console.ReadLine());
            int numberWoolfs = int.Parse(Console.ReadLine());
            int Sum = numberSheeps + numberWoolfs;
            animal.GenerationFiled(Sum);
            sheep.GenerationSheepinMatrix(numberSheeps);
            wolfs.GenerationWolfsinMatrix(numberWoolfs);
            while (true)
            {
                sheep.MoveSheeps();
                wolfs.MoveWolfs();
                animal.Draw();
            }
        }
    }
}
