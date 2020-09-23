using System;
using System.Collections.Generic;

namespace CatchPokemons
{
    public class Player
    {
        public Player(string name)
        {
            //Initial State of Ash
            this.Name = name;
            GenerateInitialPosition();
            currentPosition = startPoint;
            uniquePositons.Add(startPoint);
            historyOfPositions.Add(startPoint);
        }

        public void PlayerWalk(string moves, Dictionary<string, int[]> moveToCoordinates)
        {
            int[] translation = new int[2];
            PrintMoves(historyOfPositions, "historyOfPositions");
            PrintMoves(uniquePositons, "uniquePositons");
            Console.WriteLine(moves);

            //Para cada movimento
            foreach (char move in moves)
            {
                Console.Write($"[{string.Join(",", currentPosition)}], "); Console.Write($" Move: {move}\n");

                //1. Qual é a translação?
                translation = Returntranslation(move, moveToCoordinates);
                Console.Write($"[{string.Join(",", translation)}], "); Console.Write($" {move} translation\n");

                // //2. Actualizar a possição atual
                currentPosition = UpdateCurrentPosition(translation);
                Console.Write($"[{string.Join(",", currentPosition)}], "); Console.Write(" Updated Position \n");

                //3. Actualizar história
                historyOfPositions.Add(currentPosition);
                PrintMoves(historyOfPositions, "historyOfPositions");

                //3. Actualizar passos únicos 
                if (!uniquePositons.Contains(currentPosition))
                {
                    uniquePositons.Add(currentPosition);
                }
                PrintMoves(uniquePositons, "uniquePositons");
            }

        }

        private int[] UpdateCurrentPosition(int[] translation)
        {
            for (int i = 0; i < currentPosition.Length; i++)
            {
                currentPosition[i] += translation[i];
            }

            return new int[] { currentPosition[0], currentPosition[1] };
        }

        private int[] Returntranslation(char move, Dictionary<string, int[]> moveToCoordinates)
        {
            foreach (var moveToCoordinate in moveToCoordinates)
            {
                if (Char.ToString(move) == moveToCoordinate.Key)
                {
                    return moveToCoordinate.Value;
                }
            }
            return new int[2];
        }

        public int GetNumberOfPokemonsCatched()
        {
            return numberOfPokemons = uniquePositons.Count;
        }
        public void GenerateInitialPosition()
        {
            int Min = 0;
            int Max = 5;
            startPoint = new int[2];
            Random randNum = new Random();
            for (int i = 0; i < startPoint.Length; i++)
            {
                startPoint[i] = randNum.Next(Min, Max);
            }
        }
        public void PrintMoves(List<int[]> moves, string name)
        {
            foreach (var move in moves)
            {
                Console.Write($"[{string.Join(",", move)}], ");
            }
            Console.Write($"{name}\n");
        }
        private int[] startPoint = new int[2];
        private List<int[]> uniquePositons = new List<int[]>();
        private List<int[]> historyOfPositions = new List<int[]>();
        private int[] currentPosition = new int[2];
        private int numberOfPokemons = 0;
        public string Name = "";

    }
}